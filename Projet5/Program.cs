using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projet5.Data;
using Projet5.Repositories;
using Projet5.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// Ajouter HttpContextAccessor pour accéder au contexte HTTP
builder.Services.AddHttpContextAccessor();

// Enregistrer les repositories
builder.Services.AddScoped<IVoitureRepository, VoitureRepository>();

// Enregistrer les services
builder.Services.AddScoped<IVoitureService, VoitureService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    pattern: "{controller=Voitures}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
