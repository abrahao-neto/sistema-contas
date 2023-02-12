using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Habilitar o projeto para cookies no navegador do usuário
builder.Services.Configure<CookiePolicyOptions>(Options => { Options.MinimumSameSitePolicy = SameSiteMode.None; });

//Definir o tipo de autenticação implementado pelo projeto (Cookie de identificação de usuário)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//ativando as configurações
app.UseCookiePolicy();
app.UseAuthorization();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
