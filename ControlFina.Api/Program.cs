using ControlFina.Api.Extensions;
using ControlFina.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApiVersionConfiguration();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddOpenApi();

builder.Services.AddCors();

builder.Services
    .AddDatabase(builder.Configuration)
    .AddRepository()
    .AddHandlers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
    app.MapOpenApi();
    app.ApplyMigrations();
}

app.UseCors(option => option
    .SetIsOriginAllowed(_ => true)
    .AllowAnyHeader()
    .WithMethods("POST", "PUT", "DELETE", "GET")
    .AllowCredentials()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
