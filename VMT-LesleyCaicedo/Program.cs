using BusinessLayer.Servicios.Cliente;
using BusinessLayer.Servicios.Contratos;
using BusinessLayer.Servicios.Usuarios;
using BusinessLayer.Servicios.Servicios;
using DataLayer;
using DataLayer.Repositorio.Cliente;
using DataLayer.Repositorio.Contratos;
using DataLayer.Repositorio.Usuarios;
using DataLayer.Repositorio.Servicios;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Servicios.Login;
using DataLayer.Repositorio.Login;
using EntityLayer.Mappers;
using EntityLayer.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VmtlesleyCaicedoContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))
        );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IClienteServicio, ClienteServicio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IContratoServicio, ContratoServicio>();
builder.Services.AddScoped<IContratoRepositorio, ContratoRepositorio>();
builder.Services.AddScoped<IServiciosServicio, ServiciosServicio>();
builder.Services.AddScoped<IServiciosRepositorio, ServiciosRepositorio>();
builder.Services.AddScoped<ILoginServicio, LoginServicio>();
builder.Services.AddScoped<ILoginRepositorio, LoginRepositorio>();

var policyName = "MyPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName, builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
