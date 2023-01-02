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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false)
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
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehicleParkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_VehicleParks_VehicleParkId",
                        column: x => x.VehicleParkId,
                        principalTable: "VehicleParks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleWash",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehicleParkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleWash", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleWash_VehicleParks_VehicleParkId",
                        column: x => x.VehicleParkId,
                        principalTable: "VehicleParks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EngineType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    VehicleParkId = table.Column<int>(type: "int", nullable: false),
                    RenterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForRepearing = table.Column<bool>(type: "bit", nullable: false),
                    ForCleaning = table.Column<bool>(type: "bit", nullable: false),
                    RepairingTerm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FailureDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairsCount = table.Column<int>(type: "int", nullable: false),
                    RentsCount = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    VehicleWashId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleParks_VehicleParkId",
                        column: x => x.VehicleParkId,
                        principalTable: "VehicleParks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleWash_VehicleWashId",
                        column: x => x.VehicleWashId,
                        principalTable: "VehicleWash",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PartsOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    DeliveryTerm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartsOrder_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "96951d5c-3820-44c5-8954-970b5fd305a9", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEMuC032bapLkjeuJQlyn0wa4EG3fxS1H81p0UgbnPKS6aJolEJNc+nsPL2cDgVUd1g==", null, false, "e98eef95-d710-4b05-9741-7149f22e0bfb", false, "guest@mail.com" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bike" },
                    { 2, "Scooter" },
                    { 3, "Car" }
                });

            migrationBuilder.InsertData(
                table: "VehicleParks",
                columns: new[] { "Id", "Adress", "Description", "Email", "ImageUrl", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Bulgaria Sofia City Mladost 4", "Your eastern oportunity to find out the best ranting offer!", "eastern_rent@abv.bg", "https://travelwest.info/app/uploads/2022/04/Portway-Park-Ride-Car-Park-1349x900.jpg.webp", "Eastern Park", "+359878128343" },
                    { 2, "Bulgaria Sofia City Iskar Str. 36", "Your central oportunity to find out the best ranting offer!", "central_rent@abv.bg", "https://s.driving-tests.org/wp-content/uploads/2012/02/back-parking.webp", "Central Park", "+359878128344" },
                    { 3, "Bulgaria Sofia City Lulin 2", "Your western oportunity to find out the best ranting offer!", "estern_rent@abv.bg", "https://d193ppza2qrruo.cloudfront.net/production/images/Multi-storey-car-park-tips.jpg", "Western Park", "+359878128345" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CategoryId", "Description", "EngineType", "FailureDescription", "ForCleaning", "ForRepearing", "ImageUrl", "Model", "PricePerHour", "Rating", "RenterId", "RentsCount", "RepairingTerm", "RepairsCount", "ServiceId", "VehicleParkId", "VehicleWashId" },
                values: new object[,]
                {
                    { 1, 2, "Exellent transport solution for a city center.", "Electric", null, false, false, "https://bg.e-scooter.co/i/17/72/ed/d5015b9723a5397c924e7b797d.jpg", "Piaggo", 11.00m, 5, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, null, 0, null, 2, null },
                    { 2, 2, "A realy good transport solution for a city.", "Petrol", null, false, false, "https://images.piaggio.com/piaggio/vehicles/nclp000u15/nclp8znu15/nclp8znu15-01-s.png", "Piaggo", 10.00m, 5, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, null, 0, null, 1, null },
                    { 3, 2, "A very good transport solution for a city and center.", "Petrol", null, false, false, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT4TbIp4RJgECS2py-M_zNjwLrXYIbcZ07XQA&usqp=CAU", "Vespa", 9.00m, 6, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, null, 0, null, 3, null },
                    { 4, 1, "A very good transport solution for sport people.", null, null, false, false, "https://www.home-max.bg/static/media/ups/cached/781e8afa44a58ec261abdd83455444f5c203f4c5.jpg", "Passati", 4.00m, 4, null, 0, null, 0, null, 1, null },
                    { 5, 1, "A very good luxury transport solution for beasy people.", null, null, false, false, "https://hips.hearstapps.com/hmg-prod/images/pinarello-dogma-f-tested-1624463882.jpg?crop=1.00xw:0.807xh;0,0.0629xh&resize=2048:*", "Pinarello", 7.00m, 6, null, 0, null, 0, null, 2, null },
                    { 6, 1, "A realy good transport solution for sport people.", null, null, false, false, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuinQIdRNjDVnCddYQFkMkFIkt3cyXVfVqPA&usqp=CAU", "Cross", 5.00m, 5, null, 0, null, 0, null, 3, null },
                    { 7, 3, "A very good and transport solution for a city center.", "Electric", null, false, false, "https://imgd.aeplcdn.com/1056x594/cw/ec/9692/Hyundai-Eon-Right-Front-Three-Quarter-94097.jpg?v=201711021421&q=75&wm=1", "Hynday EON", 20.00m, 4, null, 0, null, 0, null, 1, null },
                    { 8, 3, "A realy good and transport solution for a big family.", "Diesel", null, false, false, "https://www.topgear.com/sites/default/files/cars-car/carousel/2016/03/vw_7422.jpg?w=976&h=549", "VW Touran", 23.00m, 5, null, 0, null, 0, null, 2, null },
                    { 9, 3, "A realy good and luxury transport solution.", "Petrol", null, false, false, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFiWMRzQZJ4dYjRVlv-l25KWCVweGaWbIJOA&usqp=CAU", "Mercedes CLS 180", 25.00m, 6, null, 0, null, 0, null, 3, null }
                });

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
                name: "IX_PartsOrder_VehicleId",
                table: "PartsOrder",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_VehicleParkId",
                table: "Service",
                column: "VehicleParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CategoryId",
                table: "Vehicles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ServiceId",
                table: "Vehicles",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleParkId",
                table: "Vehicles",
                column: "VehicleParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleWashId",
                table: "Vehicles",
                column: "VehicleWashId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleWash_VehicleParkId",
                table: "VehicleWash",
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
                name: "PartsOrder");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "VehicleWash");

            migrationBuilder.DropTable(
                name: "VehicleParks");
        }
    }
}
