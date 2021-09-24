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
        TermsOfService = new Uri("https://hunluxlauncher.hu/tos"),
        Contact = new OpenApiContact
        {
            Name = "Czompi",
            Email = "developer@czompi.hu",
            Url = new Uri("https://czompi.hu"),
        },
        License = new OpenApiLicense
        {
            Name = "CC0",
            Url = new Uri("https://creativecommons.org/publicdomain/zero/1.0/"),
        }
    });
});

builder.Services.AddDbContext<AnvilDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AnvilDatabaseContext"))
);
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
