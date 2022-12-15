using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityMobilitySystem.Infrasructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleParks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleParks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    VehicleParkId = table.Column<int>(type: "int", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    RenterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsForRepearing = table.Column<bool>(type: "bit", nullable: false),
                    IsForCleaning = table.Column<bool>(type: "bit", nullable: false),
                    IsNeedHelmet = table.Column<bool>(type: "bit", nullable: false),
                    IsNeedDayExchangeVehicleCard = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bikes_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bikes_VehicleParks_VehicleParkId",
                        column: x => x.VehicleParkId,
                        principalTable: "VehicleParks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    VehicleParkId = table.Column<int>(type: "int", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    RenterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsForRepearing = table.Column<bool>(type: "bit", nullable: false),
                    IsForCleaning = table.Column<bool>(type: "bit", nullable: false),
                    EngineType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsNeedDayBlueCard = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_VehicleParks_VehicleParkId",
                        column: x => x.VehicleParkId,
                        principalTable: "VehicleParks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scooters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    VehicleParkId = table.Column<int>(type: "int", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    RenterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsForRepearing = table.Column<bool>(type: "bit", nullable: false),
                    IsForCleaning = table.Column<bool>(type: "bit", nullable: false),
                    EngineType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsNeedHelmet = table.Column<bool>(type: "bit", nullable: false),
                    IsNeedDayExchangeVehicleCard = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scooters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scooters_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scooters_VehicleParks_VehicleParkId",
                        column: x => x.VehicleParkId,
                        principalTable: "VehicleParks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    VehicleParkId = table.Column<int>(type: "int", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    RenterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsForRepearing = table.Column<bool>(type: "bit", nullable: false),
                    IsForCleaning = table.Column<bool>(type: "bit", nullable: false),
                    EngineType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsNeedDayBlueCard = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trucks_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trucks_VehicleParks_VehicleParkId",
                        column: x => x.VehicleParkId,
                        principalTable: "VehicleParks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "3de65bc5-d44c-418c-ad58-c01d4d9e6b52", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEPK7wMgYdMAQQNce6BuQ8i/8m/IHOUApmhQ1SjWqsaTTydIAKVlt24naANq9IzjfJA==", null, false, "27ed42d5-b1bf-4dbb-b913-68c3137f8403", false, "guest@mail.com" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "Name", "Size" },
                values: new object[,]
                {
                    { 1, "Small", 0 },
                    { 2, "Middle", 0 },
                    { 3, "Large", 0 }
                });

            migrationBuilder.InsertData(
                table: "VehicleParks",
                columns: new[] { "Id", "ParkName" },
                values: new object[] { 1, "Central" });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsForCleaning", "IsForRepearing", "IsNeedDayExchangeVehicleCard", "IsNeedHelmet", "PricePerHour", "Rating", "RenterId", "Type", "VehicleParkId" },
                values: new object[] { 1, 2, "A very good transport solution for sport people.", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fpassati.com%2Fimages%2Fstories%2Fvirtuemart%2Fproduct%2FEGBERT27.5-29%2520DISK%2520BLUE%2520Front.jpg&imgrefurl=https%3A%2F%2Fpassati.com%2Findex.php%3Foption%3Dcom_virtuemart%26view%3Dproductdetails%26virtuemart_product_id%3D203%26virtuemart_category_id%3D2%26lang%3Dbg&tbnid=F1pd6OQdaNHHfM&vet=12ahUKEwia-avZ5vj7AhUunv0HHSr8DY8QMygHegUIARDLAQ..i&docid=zUMwW1b5u_0RHM&w=4750&h=3123&q=passati%20%D0%BA%D0%BE%D0%BB%D0%B5%D0%BB%D0%BE&ved=2ahUKEwia-avZ5vj7AhUunv0HHSr8DY8QMygHegUIARDLAQ", false, false, false, false, 8.00m, 4, null, "Passati", 1 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Description", "EngineType", "ImageUrl", "IsForCleaning", "IsForRepearing", "IsNeedDayBlueCard", "PricePerHour", "Rating", "RenterId", "Type", "VehicleParkId" },
                values: new object[] { 1, 2, "A realy good and luxury transport solution.", "Petrol", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fcommons%2F5%2F52%2FMercedes-Benz_C_200_Avantgarde_%2528W_205%2529_%25E2%2580%2593_Frontansicht%252C_26._April_2014%252C_D%25C3%25BCsseldorf.jpg&imgrefurl=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FMercedes-Benz_C-Class_(W205)&tbnid=wz3T3Jbg3NRb1M&vet=12ahUKEwjw97il6fj7AhUunv0HHSr8DY8QMygCegUIARDGAQ..i&docid=W-hhnTTjUDZfoM&w=3418&h=1711&q=mercedes%20c%20class%20w205&ved=2ahUKEwjw97il6fj7AhUunv0HHSr8DY8QMygCegUIARDGAQ", false, false, false, 20.00m, 6, null, "Mercedes C 180", 1 });

            migrationBuilder.InsertData(
                table: "Scooters",
                columns: new[] { "Id", "CategoryId", "Description", "EngineType", "ImageUrl", "IsForCleaning", "IsForRepearing", "IsNeedDayExchangeVehicleCard", "IsNeedHelmet", "PricePerHour", "Rating", "RenterId", "Type", "VehicleParkId" },
                values: new object[] { 1, 1, "A realy good transport solution for a city center.", "Electric", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fbg.e-scooter.co%2Fwp-content%2Fuploads%2F2021%2F06%2Fcuckgo.com_-e1623030797433.jpeg&imgrefurl=https%3A%2F%2Fbg.e-scooter.co%2Fpiaggio-one%2F&tbnid=xM2wRoaEPhPNHM&vet=12ahUKEwiD_cOT5Pj7AhVxyrsIHaqtCpUQMygBegUIARC6AQ..i&docid=zsJorUwAg6RoyM&w=753&h=771&q=Piaggio&ved=2ahUKEwiD_cOT5Pj7AhVxyrsIHaqtCpUQMygBegUIARC6AQ", false, false, false, false, 10.00m, 6, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "Piaggo", 1 });

            migrationBuilder.InsertData(
                table: "Trucks",
                columns: new[] { "Id", "CategoryId", "Description", "EngineType", "ImageUrl", "IsForCleaning", "IsForRepearing", "IsNeedDayBlueCard", "PricePerHour", "Rating", "RenterId", "Type", "VehicleParkId" },
                values: new object[] { 1, 3, "A realy good transport solution for a big cargo.", "Diesel", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.volvotrucks.us%2F-%2Fmedia%2Fvtna%2Fimages%2Fshared%2Ftab-content%2Fvnl%2Ftabbed-feature%2Fvolvo-vnl-25th-aerodynamics.jpg%3Fh%3D410%26w%3D725%26rev%3D4a1b9e19a65e418ba2bcffc4b952005a%26hash%3D78C61F2B39C62E7464AAA1FC051487C0&imgrefurl=https%3A%2F%2Fwww.volvotrucks.us%2Ftrucks%2Fvnl%2F&tbnid=4lteSbMPeJB2jM&vet=12ahUKEwj3jKWa6vj7AhUykv0HHaDKC88QMygPegUIARDgAQ..i&docid=cXhpx2BnsyvK8M&w=725&h=410&q=volvo%20truck%202021&ved=2ahUKEwj3jKWa6vj7AhUykv0HHaDKC88QMygPegUIARDgAQ", false, false, false, 40.00m, 5, null, "Volvo", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_CategoryId",
                table: "Bikes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_VehicleParkId",
                table: "Bikes",
                column: "VehicleParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_VehicleParkId",
                table: "Cars",
                column: "VehicleParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Scooters_CategoryId",
                table: "Scooters",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Scooters_VehicleParkId",
                table: "Scooters",
                column: "VehicleParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_CategoryId",
                table: "Trucks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_VehicleParkId",
                table: "Trucks",
                column: "VehicleParkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Scooters");

            migrationBuilder.DropTable(
                name: "Trucks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "VehicleParks");
        }
    }
}
