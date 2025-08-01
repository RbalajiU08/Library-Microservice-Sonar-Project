using BookServices.Data;
using BookServices.UnitofWork;
using BookServices.UnitofWork.Repository;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnections"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnections"))));
builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
