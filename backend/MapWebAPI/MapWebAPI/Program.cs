using MapWebAPI.Models;
using MapWebAPI.Seeder;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MapAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Server=localhost,1433;Database=MapAppDB;User Id=SA;Password=CSharpCool_1!;TrustServerCertificate=True;")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var context = new MapAppDbContext())
{
    DbSeeder.Seed(context);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
