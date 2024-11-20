using CountryApp_Cloud;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(); // добавление сервиса, чтобы его можно было принимать в качестве параметра

var app = builder.Build();

app.MapGet("/api", () => new { Massage = "server is running" });
app.MapGet("/api/ping", () => new { Massage = "pong" });


// 1. Get /api/country
app.MapGet("/api/country", async (ApplicationDbContext db) =>
{
    return await db.Country.ToListAsync();
});

// 2. Get /api/country/{id}
app.MapGet("/api/country/{id:int}", async (int id, ApplicationDbContext db) =>
{
    return await db.Country.FirstOrDefaultAsync(d => d.id == id);
});

// 3. POST /api/country
app.MapPost("/api/country", async (CountryEntity CountryEntity, ApplicationDbContext db) =>
{
   await db.Country.AddAsync(CountryEntity);
   await db.SaveChangesAsync();
   return CountryEntity;
});

// 4. DELETE /api/country/{id}
app.MapDelete("/api/country/{id:int}", async (int id, ApplicationDbContext db) =>
{
    CountryEntity? deleted = await db.Country.FirstOrDefaultAsync(d => d.id == id);
   if (deleted != null) db.Country.Remove(deleted);
   await db.SaveChangesAsync(); //сохранение дб
});


app.Run();