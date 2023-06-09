using Application.Interfaces;
using InfraEstrutura.Configuration;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Interfaces.InterfaceProduto;
using InfraEstrutura.Repository.Repositories;
using Domain.Interfaces.InterfaceCategoria;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionStringMysql = builder.Configuration.GetConnectionString("ConnectionMysql");
builder.Services.AddDbContext<ContextBase>(options => options.UseMySql(connectionStringMysql, ServerVersion.Parse("8.0.31-mysql")));
builder.Services.AddScoped<ITelemetrix, TelemetrixApplication>();
builder.Services.AddScoped<IProduto, RepositorioProduto>();
builder.Services.AddScoped<ICategoria, RepositorioCategoria>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
