using Anvil.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApiVersioning();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Anvil",
        Version = "v1",
        Description = "A custom HunLux Launcher modpack host for those to like to self-host stuff. Support for Technic Launcher coming when the main goal of this project reached.",
        TermsOfService = new("https://hunluxlauncher.hu/tos"),
        Contact = new()
        {
            Name = "Czompi",
            Email = "developer@czompi.hu",
            Url = new("https://czompi.hu"),
        },
        License = new()
        {
            Name = "CC0",
            Url = new("https://creativecommons.org/publicdomain/zero/1.0/"),
        }
    });
});

builder.Services.AddDbContext<AnvilDatabaseContext>(options =>
{
    options.UseSqlServer("Data Source=SQL1;Initial Catalog=Anvil.Test;Persist Security Info=True;User ID=sa;Password=#7$Qp3iWRLyB76PP");
}, contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Singleton);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Anvil v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseApiVersioning();
app.MapControllers();

app.Run();
