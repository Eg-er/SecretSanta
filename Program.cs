using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretSanta.Models;
using SecretSanta.Models.Interfaces;
using SecretSanta.Services;
using SecretSanta.Services.Interfaces;
using SecretSanta.Utils;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

services.AddDbContext<SecretSantaDbContext>(opt => opt.UseSqlServer(connection));
services.AddScoped<IUserRepository, UserRepository>();

var mapperConfiguration = new MapperConfiguration(e =>
    e.AddProfile(new AutoMapperProfile()));
var mapper = mapperConfiguration.CreateMapper();

services.AddSingleton(mapper);
services.AddScoped<IUserService, UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");
app.UseRouting();

app.MapControllerRoute(
    "default",
    "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();