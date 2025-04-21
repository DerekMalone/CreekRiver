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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
            new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
            new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
            new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
            new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });

        // seed data with campsites
        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
            new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
            new Campsite {Id = 2, CampsiteTypeId = 3, Nickname = "Sasquach", ImageUrl = "https://www.nps.gov/bibe/planyourvisit/images/backcountry-primitive-camp_1.jpg?maxwidth=1300&maxheight=1300&autorotate=false"},
            new Campsite {Id = 3, CampsiteTypeId = 4, Nickname = "Bandersnatch", ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi2.wp.com%2Fmemolition.com%2Fwp-content%2Fuploads%2F2015%2F09%2Fextreme-camping-hundreds-of-feet-off-the-ground-82525.jpg%3Ffit%3D1500%252C1000&f=1&nofb=1&ipt=e7302516701c084be88c19987b314679be60051b0cffe7280b88c255ffc3f7a8"},
            new Campsite {Id = 4, CampsiteTypeId = 1, Nickname = "Slowbro", ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi0.wp.com%2Fextremesportsx.com%2Fwp-content%2Fuploads%2F2020%2F11%2FCamping-1.jpeg%3Fresize%3D768%252C510%26ssl%3D1&f=1&nofb=1&ipt=ff59746fbd283dee044687ac60a9b7042f38748db5d88a26c15945a4964c2896"},
            new Campsite {Id = 5, CampsiteTypeId = 2, Nickname = "Smooth Sailing", ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fblog-assets.thedyrt.com%2Fuploads%2F2019%2F06%2Frv-beach-camping-1024x682.jpg&f=1&nofb=1&ipt=4a30cb2ac4911634a8d1b25d550834a70ded01758ee70bd2975d04c164a94c37"},
        });

        // seed data with userprofile
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile {Id = 1, Email = "steve.johnstone@gmail.com", FirstName = "Steve", LastName = "Johnstone"}
        });

        // seed data with reservation
        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
            new Reservation {Id = 1, CampsiteId = 2, UserProfileId = 1, CheckinDate = new DateTime(2025, 04, 03, 14, 30, 00), CheckoutDate = new DateTime(2025, 04, 07, 14, 30, 00)}
        });
    }
}

