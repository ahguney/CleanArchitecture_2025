using CleanArchictecture_2025.WebAPI;
using CleanArchitecture_2025.Application;
using CleanArchitecture_2025.Infrastructure;
using CleanArchitecture_2025.WebAPI.Controllers;
using CleanArchitecture_2025.WebAPI.Modules;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.RateLimiting;
using Scalar.AspNetCore;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers().AddOData(opt =>
        opt
        .Select()
        .Filter()
        .Count()
        .Expand()
        .OrderBy()
        .SetMaxTop(null)
        .AddRouteComponents("odata", AppODataController.GetEdmModel())
);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddOpenApi();
builder.Services.AddCors();
builder.Services.AddRateLimiter(x=>
x.AddFixedWindowLimiter("fixed", cfg => {
    cfg.QueueLimit = 100; // bu limit kuyru�a al�nabilecek istek say�s�n� belirler
    cfg.Window = TimeSpan.FromSeconds(1); // bu s�re zarf�nda istek say�s�n� s�n�rlar
    cfg.PermitLimit = 100; // bu limit belirtilen s�re zarf�nda izin verilen istek say�s�n� belirler
    cfg.QueueProcessingOrder = QueueProcessingOrder.OldestFirst; // kuyru�a al�nan isteklerin i�lenme s�ras�n� belirler YAN� F�RST IN FIRST OUT
}));
builder.Services.AddExceptionHandler<ExceptionHandler>().AddProblemDetails();

builder.Services.AddControllers();


var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.UseCors(x => x
.AllowAnyHeader()
.AllowCredentials()
.AllowAnyMethod()
.SetIsOriginAllowed(t=>true));
app.MapControllers().RequireRateLimiting("fixed");
app.RegisterEmployeeRoutes();
app.UseExceptionHandler();


app.MapDefaultEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();
