using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projeto_ecommerce.Data;
using Projeto_ecommerce.Models;
using Projeto_ecommerce.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<BancoContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")));

builder.Services.AddScoped<InterfaceContatoRepositorio, ContatoRepositorio>();
builder.Services.AddScoped<InterfaceServicoRepositorio, ServicoRepositorio>();
builder.Services.AddScoped<InterfaceUserRepositorio, UserRepositorio>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // Caminho para a página de login
        options.LogoutPath = "/Login/Logout"; // Caminho para a ação de logout
    });

var app = builder.Build();
SeedData.Seed(app);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();




app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
