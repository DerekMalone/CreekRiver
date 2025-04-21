using CreekRiver.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using CreekRiver.Models.DTOs;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<CreekRiverDbContext>(builder.Configuration["CreekRiverDbConnectionString"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/campsites", (CreekRiverDbContext db) =>
{
    return db.Campsites
    .Select(c => new CampsiteDTO
    {
        Id = c.Id,
        Nickname = c.Nickname,
        ImageUrl = c.ImageUrl,
        CampsiteTypeId = c.CampsiteTypeId
    }).ToList();
});

app.MapGet("/api/campsites/{id}", (CreekRiverDbContext db, int id) =>
{
    try 
    {
        CampsiteDTO campsite = db.Campsites
            .Include(c => c.CampsiteType)
            .Select(c => new CampsiteDTO
            {
                Id = c.Id,
                Nickname = c.Nickname,
                CampsiteTypeId = c.CampsiteTypeId,
                CampsiteType = new CampsiteTypeDTO
                {
                    Id = c.CampsiteType.Id,
                    CampsiteTypeName = c.CampsiteType.CampsiteTypeName,
                    FeePerNight = c.CampsiteType.FeePerNight,
                    MaxReservationDays = c.CampsiteType.MaxReservationDays
                }
            })
            .Single(c => c.Id == id);

            return Results.Ok(campsite);
    }
    catch (InvalidOperationException)
    {
        return Results.NotFound();
    }
});

app.Run();

//! Pick up on Create a Campsite
// ? https://github.com/nashville-software-school/server-side-dotnet-curriculum/blob/main/book-3-sql-efcore/chapters/creek-river-create-campsite.md