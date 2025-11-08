using Microsoft.EntityFrameworkCore;
using web.econecta.dpa.core.Infrastructure.Data;
using web.econecta.dpa.core.Core.Interfaces;
using web.econecta.dpa.core.Infrastructure.Repositories;
using web.econecta.dpa.core.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Server=localhost;Database=EcoConectaDB;Trusted_Connection=True;TrustServerCertificate=True";
builder.Services.AddDbContext<EcoConectaDBContext>(options => options.UseSqlServer(connectionString));

// Register repositories and services
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ICalificacioneRepository, CalificacioneRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>();
builder.Services.AddScoped<IDistritoRepository, DistritoRepository>();
builder.Services.AddScoped<IImagenesProductoRepository, ImagenesProductoRepository>();
builder.Services.AddScoped<IInteresesProductoRepository, InteresesProductoRepository>();
builder.Services.AddScoped<INotificacioneRepository, NotificacioneRepository>();
builder.Services.AddScoped<IRestablecimientosContrasenaRepository, RestablecimientosContrasenaRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ITransaccioneRepository, TransaccioneRepository>();
builder.Services.AddScoped<IVerificacionesCorreoRepository, VerificacionesCorreoRepository>();

// Register services by interface
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<ICalificacioneService, CalificacioneService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IComentarioService, ComentarioService>();
builder.Services.AddScoped<IDistritoService, DistritoService>();
builder.Services.AddScoped<IImagenesProductoService, ImagenesProductoService>();
builder.Services.AddScoped<IInteresesProductoService, InteresesProductoService>();
builder.Services.AddScoped<INotificacioneService, NotificacioneService>();
builder.Services.AddScoped<IRestablecimientosContrasenaService, RestablecimientosContrasenaService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ITransaccioneService, TransaccioneService>();
builder.Services.AddScoped<IVerificacionesCorreoService, VerificacionesCorreoService>();

builder.Services.AddControllers();
// CORS - allow frontend during development
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
