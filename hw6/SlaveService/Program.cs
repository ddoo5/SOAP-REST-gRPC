using Microsoft.AspNetCore.HttpLogging;
using NLog.Web;
using Polly;
using SlaveService.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All | HttpLoggingFields.RequestQuery;
    logging.ResponseBodyLogLimit = 4096;
    logging.RequestBodyLogLimit = 4096;
    logging.RequestHeaders.Add("Authorization");
    logging.RequestHeaders.Add("X-Real-IP");
    logging.RequestHeaders.Add("X-Forwarder-for");


});

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
}).UseNLog(new NLogAspNetCoreOptions() { RemoveLoggerFactoryFilter = true });


builder.Services.AddHttpClient<IFromSlaveToMasterService, FromSlaveToMasterService>()
    .AddTransientHttpErrorPolicy(
    configurePolicy => configurePolicy.WaitAndRetryAsync(retryCount: 20, sleepDurationProvider:(attemps) => TimeSpan.FromSeconds(1),
    onRetry:(response, sleep, attempt, context) =>
    {
        var logger = builder.Services.BuildServiceProvider().GetService<ILogger>();

        logger?.LogError(response.Exception != null ? response.Exception : new Exception($"\n\n" +
            $"[Version: {response.Result.Version}, Status Code: {response.Result.StatusCode}] Headers: {response.Result.Headers}\n " +
            $"Request message: {response.Result.RequestMessage} \n " +
            $"Content:{response.Result.Content}\n\n"),
            $"[Attempt: {attempt}] MastersClient request exeption");
    }));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseHttpLogging();

app.MapControllers();

app.Run();

