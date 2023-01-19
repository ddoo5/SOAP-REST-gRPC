using Microsoft.EntityFrameworkCore;
using VetClinicService;
using VetClinicService.Library.DBContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddDbContext<VetClinicDbContext>(opt =>
{
    opt.UseSqlite("Data Source=VCS.db;", b => b.MigrationsAssembly("VetClinicService"));
});

var app = builder.Build();

app.MapGrpcService<VetClinicService.Services.VetService>();

app.Run();

