using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }
}

//! Pick up immediately after "paste the following code" block.
// ? https://github.com/nashville-software-school/server-side-dotnet-curriculum/blob/main/book-3-sql-efcore/chapters/creek-river-db-context.md