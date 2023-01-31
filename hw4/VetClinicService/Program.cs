using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using VetClinicService;
using VetClinicService.Library.DBContext;

var builder = WebApplication.CreateBuilder(args);


#region Configure Kestrel

builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Any, 5001, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1;
    });

    options.Listen(IPAddress.Any, 5002, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});

#endregion


#region Configure gRPC

builder.Services.AddGrpc().AddJsonTranscoding();

#endregion


#region Configure EF Core DB context

builder.Services.AddDbContext<VetClinicDbContext>(opt =>
{
    opt.UseSqlite("Data Source=VCS.db;",
        b => b.MigrationsAssembly("VetClinicService"));
});

#endregion

builder.Services.AddAuthorization();


#region Configure Swagger

builder.Services.AddGrpcSwagger();

builder.Services.AddSwaggerGen(s =>
{
s.SwaggerDoc("v0.4",
    new OpenApiInfo
    {
        Title = "Vet Clinic Service",
        License = new OpenApiLicense()
        {
            Name = "MIT"
        },
        Version = "v0.4",
        Contact = new OpenApiContact()
        {
            Name = "DD",
            Url = new Uri("https://github.com/ddoo5")
        },
        Description = "Some test service with gRPC"
        });
    var path = Path.Combine(AppContext.BaseDirectory, "VetClinicService.xml");
    s.IncludeXmlComments(path);
    s.IncludeGrpcXmlComments(path, includeControllerXmlComments: true);
});

#endregion


#region Configure app

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v0.4/swagger.json", "v0.4");
    });
}

app.UseRouting();
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

app.MapGrpcService<VetClinicService.Services.VetService>().EnableGrpcWeb();

app.MapGet("/", () => "...");

app.Run();

#endregion

