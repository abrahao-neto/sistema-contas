using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Habilitar o projeto para cookies no navegador do usu�rio
builder.Services.Configure<CookiePolicyOptions>(Options => { Options.MinimumSameSitePolicy = SameSiteMode.None; });

//Definir o tipo de autentica��o implementado pelo projeto (Cookie de identifica��o de usu�rio)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//ativando as configura��es
app.UseCookiePolicy();
app.UseAuthorization();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
