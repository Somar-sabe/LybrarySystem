using LybrarySystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Http;
using LybrarySystem;
using LybrarySystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer("Data Source=DESKTOP-10KMJEB;Initial Catalog=library;Integrated Security=True;Pooling=False;TrustServerCertificate=true"));

// Add HttpClient service for API integration
builder.Services.AddHttpClient<IExternalApiService, ExternalApiService>(client =>
{
    client.BaseAddress = new Uri("https://api.example.com/"); // Replace with the base URL of your external API
    // You can configure other HttpClient settings here, such as timeout, headers, etc.
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
