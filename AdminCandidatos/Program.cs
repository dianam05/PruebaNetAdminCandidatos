using AdminCandidatos.Infrastructure;
using AdminCandidatos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configurar conexión a la base de datos
builder.Services.AddDbContext<AdminCandidatosDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar soporte para controladores y vistas (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Aplicar migraciones automáticamente (opcional para desarrollo)
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<AdminCandidatosDBContext>();
//    dbContext.Database.Migrate();
//    // Opcional: sembrar datos iniciales
//    // DbInitializer.Seed(dbContext);
//}

// Configuración del middleware HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configurar rutas por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Candidate}/{action=Index}/{id?}");

app.Run();
