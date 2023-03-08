using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TMS1.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TMS1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TMS1Context") ?? throw new InvalidOperationException("Connection string 'TMS1Context' not found.")));
var connectionString = builder.Configuration.GetConnectionString("DataTMS1ContextConnection") ?? throw new InvalidOperationException("Connection string 'DataTMS1ContextConnection' not found.");

builder.Services.AddDbContext<DataTMS1Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<TMS1User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DataTMS1Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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
app.UseAuthentication();

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Allocate}/{action=Index}/{id?}");

app.Run();
