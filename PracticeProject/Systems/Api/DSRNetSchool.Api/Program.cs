using DSRNetSchool.Api;
using DSRNetSchool.Api.Configuration;
using DSRNetSchool.Services.Settings;
using DSRNetSchool.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var mainSettings = Settings.Load<MainSettings>("Main");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");

builder.AddAppLogger();

// Configure services
var services = builder.Services;

services.AddHttpContextAccessor();
services.AddAppCors();

services.AddAppHealthChecks();
services.AddAppVersioning();
services.AddAppSwagger(mainSettings, swaggerSettings);

services.AddAppControllerAndViews();

services.RegisterAppServices();

var app = builder.Build();

app.UseAppHealthChecks();
app.UseAppSwagger();



// Configure the HTTP request pipeline.

app.UseAppControllerAndViews();

app.Run();
