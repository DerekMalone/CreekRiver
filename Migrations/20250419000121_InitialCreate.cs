using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CreekRiver.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampsiteTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampsiteTypeName = table.Column<string>(type: "text", nullable: false),
                    MaxReservationDays = table.Column<int>(type: "integer", nullable: false),
                    FeePerNight = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampsiteTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campsites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nickname = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    CampsiteTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campsites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campsites_CampsiteTypes_CampsiteTypeId",
                        column: x => x.CampsiteTypeId,
                        principalTable: "CampsiteTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampsiteId = table.Column<int>(type: "integer", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    CheckinDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CheckoutDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Campsites_CampsiteId",
                        column: x => x.CampsiteId,
                        principalTable: "Campsites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CampsiteTypes",
                columns: new[] { "Id", "CampsiteTypeName", "FeePerNight", "MaxReservationDays" },
                values: new object[,]
                {
                    { 1, "Tent", 15.99m, 7 },
                    { 2, "RV", 26.50m, 14 },
                    { 3, "Primitive", 10.00m, 3 },
                    { 4, "Hammock", 12m, 7 }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "steve.johnstone@gmail.com", "Steve", "Johnstone" });

            migrationBuilder.InsertData(
                table: "Campsites",
                columns: new[] { "Id", "CampsiteTypeId", "ImageUrl", "Nickname" },
                values: new object[,]
                {
                    { 1, 1, "https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg", "Barred Owl" },
                    { 2, 3, "https://www.nps.gov/bibe/planyourvisit/images/backcountry-primitive-camp_1.jpg?maxwidth=1300&maxheight=1300&autorotate=false", "Sasquach" },
                    { 3, 4, "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi2.wp.com%2Fmemolition.com%2Fwp-content%2Fuploads%2F2015%2F09%2Fextreme-camping-hundreds-of-feet-off-the-ground-82525.jpg%3Ffit%3D1500%252C1000&f=1&nofb=1&ipt=e7302516701c084be88c19987b314679be60051b0cffe7280b88c255ffc3f7a8", "Bandersnatch" },
                    { 4, 1, "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi0.wp.com%2Fextremesportsx.com%2Fwp-content%2Fuploads%2F2020%2F11%2FCamping-1.jpeg%3Fresize%3D768%252C510%26ssl%3D1&f=1&nofb=1&ipt=ff59746fbd283dee044687ac60a9b7042f38748db5d88a26c15945a4964c2896", "Slowbro" },
                    { 5, 2, "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fblog-assets.thedyrt.com%2Fuploads%2F2019%2F06%2Frv-beach-camping-1024x682.jpg&f=1&nofb=1&ipt=4a30cb2ac4911634a8d1b25d550834a70ded01758ee70bd2975d04c164a94c37", "Smooth Sailing" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CampsiteId", "CheckinDate", "CheckoutDate", "UserProfileId" },
                values: new object[] { 1, 2, new DateTime(2025, 4, 3, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 7, 14, 30, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Campsites_CampsiteTypeId",
                table: "Campsites",
                column: "CampsiteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CampsiteId",
                table: "Reservations",
                column: "CampsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserProfileId",
                table: "Reservations",
                column: "UserProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Campsites");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "CampsiteTypes");
        }
    }
}
