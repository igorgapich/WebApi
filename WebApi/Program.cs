using Core.Interfaces;
using Core.Services;
using Infrastructure.Data;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Infrastructure;
using Core;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("CinemaCS") ?? throw new InvalidOperationException("Connection string 'ShopMVCConnection' not found.");

builder.Services.AddDbContext(connection);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x=>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.MapType<TimeSpan>(() => new OpenApiSchema
    {
        Type = "string",
        Example = new OpenApiString("00:00:00")
    });
});
builder.Services.AddIdentity();

builder.Services.AddRepository();
builder.Services.AddValidators();
builder.Services.AddAutoMapper();

builder.Services.AddCustomService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//Global handler Middleware
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
