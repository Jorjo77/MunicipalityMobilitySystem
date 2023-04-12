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
                name: "RepairCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleParkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairCenters_VehicleParks_VehicleParkId",
                        column: x => x.VehicleParkId,
                        principalTable: "VehicleParks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WashingCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleParkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WashingCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WashingCenters_VehicleParks_VehicleParkId",
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
                    RegistrationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EngineType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    VehicleParkId = table.Column<int>(type: "int", nullable: false),
                    RenterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForRepearing = table.Column<bool>(type: "bit", nullable: false),
                    ForCleaning = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RentedPeriod = table.Column<double>(type: "float", nullable: false),
                    MomenOfRent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MomenOfLeave = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FailureDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairsCount = table.Column<int>(type: "int", nullable: false),
                    RentsCount = table.Column<int>(type: "int", nullable: false),
                    RepairCenterId = table.Column<int>(type: "int", nullable: true),
                    WashingCenterId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Vehicles_RepairCenters_RepairCenterId",
                        column: x => x.RepairCenterId,
                        principalTable: "RepairCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleParks_VehicleParkId",
                        column: x => x.VehicleParkId,
                        principalTable: "VehicleParks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_WashingCenters_WashingCenterId",
                        column: x => x.WashingCenterId,
                        principalTable: "WashingCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    RenterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentedPeriod = table.Column<double>(type: "float", nullable: false),
                    MomenOfRent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MomenOfLeave = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Vote = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomersFeedbacks_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartsOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartsOrders_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PartsOrderId = table.Column<int>(type: "int", nullable: false),
                    UnutPrice = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_PartsOrders_PartsOrderId",
                        column: x => x.PartsOrderId,
                        principalTable: "PartsOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "5bfc5907-188b-4675-883e-dfa43d31d926", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEDzikr/zbwhtKJJvFoy4dmcvu4lyJeiPM7XI11WN1ieztiVulBp7y2KsFjXslLaL/g==", null, false, "550315db-3dfd-454d-b94a-4c931abfa4c6", false, "guest@mail.com" });

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
                    { 1, "Bulgaria Sofia City Iskar Str. 36", "Your central oportunity to find out the best ranting offer!", "central_rent@abv.bg", "https://travelwest.info/app/uploads/2022/04/Portway-Park-Ride-Car-Park-1349x900.jpg.webp", "Central Park", "+359878128343" },
                    { 2, "Bulgaria Sofia City Mladost 4", "Your eastern oportunity to find out the best ranting offer!", "eastern_rent@abv.bg", "https://s.driving-tests.org/wp-content/uploads/2012/02/back-parking.webp", "Eastern Park", "+359878128344" },
                    { 3, "Bulgaria Sofia City Lulin 2", "Your western oportunity to find out the best ranting offer!", "western_rent@abv.bg", "https://d193ppza2qrruo.cloudfront.net/production/images/Multi-storey-car-park-tips.jpg", "Western Park", "+359878128345" }
                });

            migrationBuilder.InsertData(
                table: "RepairCenters",
                columns: new[] { "Id", "ImageUrl", "Name", "VehicleParkId" },
                values: new object[,]
                {
                    { 1, "https://media.istockphoto.com/id/628096148/vector/auto-repair.jpg?s=612x612&w=0&k=20&c=GCVOh9kmmlYAoRvT_g86559RDmGA06w5m4nEYqsfE9w=", "Central repair center", 1 },
                    { 2, "https://mybayutcdn.bayut.com/mybayut/wp-content/uploads/Cars-lifted-in-a-service-centre.jpg", "Eastern repair center", 2 },
                    { 3, "https://conceptualminds.com/wp-content/uploads/2022/10/auto-repair-shop-bays.jpg ", "Western repair center", 3 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CategoryId", "Description", "EngineType", "FailureDescription", "ForCleaning", "ForRepearing", "ImageUrl", "IsActive", "Model", "MomenOfLeave", "MomenOfRent", "PricePerHour", "Rating", "RegistrationNumber", "RentedPeriod", "RenterId", "RentsCount", "RepairCenterId", "RepairsCount", "VehicleParkId", "WashingCenterId" },
                values: new object[,]
                {
                    { 1, 2, "Exellent transport solution for a city center.", "Electric", null, false, false, "https://bg.e-scooter.co/i/17/72/ed/d5015b9723a5397c924e7b797d.jpg", true, "Piaggo", null, null, 11.00m, 0.0, "Sk000001", 0.0, null, 0, null, 0, 2, null },
                    { 2, 2, "A realy good transport solution for a city.", "Petrol", null, false, false, "https://images.piaggio.com/piaggio/vehicles/nclp000u15/nclp8znu15/nclp8znu15-01-s.png", true, "Piaggo", null, null, 10.00m, 0.0, "Sk000002", 0.0, null, 0, null, 0, 1, null },
                    { 3, 2, "A very good transport solution for a city and center.", "Petrol", null, false, false, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT4TbIp4RJgECS2py-M_zNjwLrXYIbcZ07XQA&usqp=CAU", true, "Vespa", null, null, 9.00m, 0.0, "Sk000003", 0.0, null, 0, null, 0, 3, null },
                    { 4, 1, "A very good transport solution for sport people.", null, null, false, false, "https://www.home-max.bg/static/media/ups/cached/781e8afa44a58ec261abdd83455444f5c203f4c5.jpg", true, "Passati", null, null, 4.00m, 0.0, "B000001", 0.0, null, 0, null, 0, 1, null },
                    { 5, 1, "A very good luxury transport solution for beasy people.", null, null, false, false, "https://hips.hearstapps.com/hmg-prod/images/pinarello-dogma-f-tested-1624463882.jpg?crop=1.00xw:0.807xh;0,0.0629xh&resize=2048:*", true, "Pinarello", null, null, 7.00m, 0.0, "B000002", 0.0, null, 0, null, 0, 2, null },
                    { 6, 1, "A realy good transport solution for sport people.", null, null, false, false, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuinQIdRNjDVnCddYQFkMkFIkt3cyXVfVqPA&usqp=CAU", true, "Cross", null, null, 5.00m, 0.0, "B000003", 0.0, null, 0, null, 0, 3, null },
                    { 7, 3, "A very good and transport solution for a city center.", "Electric", null, false, false, "https://imgd.aeplcdn.com/1056x594/cw/ec/9692/Hyundai-Eon-Right-Front-Three-Quarter-94097.jpg?v=201711021421&q=75&wm=1", true, "Hynday EON", null, null, 20.00m, 0.0, "C000001", 0.0, null, 0, null, 0, 1, null },
                    { 8, 3, "A realy good and transport solution for a big family.", "Diesel", null, false, false, "https://www.topgear.com/sites/default/files/cars-car/carousel/2016/03/vw_7422.jpg?w=976&h=549", true, "VW Touran", null, null, 23.00m, 0.0, "C000002", 0.0, null, 0, null, 0, 2, null },
                    { 9, 3, "A realy good and luxury transport solution.", "Petrol", null, false, false, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFiWMRzQZJ4dYjRVlv-l25KWCVweGaWbIJOA&usqp=CAU", true, "Mercedes CLS 180", null, null, 25.00m, 0.0, "C000003", 0.0, null, 0, null, 0, 3, null }
                });

            migrationBuilder.InsertData(
                table: "WashingCenters",
                columns: new[] { "Id", "ImageUrl", "Name", "VehicleParkId" },
                values: new object[,]
                {
                    { 1, "https://tommys-express.com/wp-content/uploads/2022/11/hero.jpg", "Central washing center", 1 },
                    { 2, "http://ultrasonicexpress.com/wp-content/uploads/2020/12/DSC_4331-scaled.jpg", "Eastern washing center", 2 },
                    { 3, "https://imocarwash.com/media/5688/wetherill-park.png?anchor=center&mode=crop&width=851&height=381&rnd=133173853890000000", "Western washing center", 3 }
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
                name: "IX_Bills_VehicleId",
                table: "Bills",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersFeedbacks_VehicleId",
                table: "CustomersFeedbacks",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PartsOrderId",
                table: "Expenses",
                column: "PartsOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsOrders_VehicleId",
                table: "PartsOrders",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairCenters_VehicleParkId",
                table: "RepairCenters",
                column: "VehicleParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CategoryId",
                table: "Vehicles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_RepairCenterId",
                table: "Vehicles",
                column: "RepairCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleParkId",
                table: "Vehicles",
                column: "VehicleParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_WashingCenterId",
                table: "Vehicles",
                column: "WashingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_WashingCenters_VehicleParkId",
                table: "WashingCenters",
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
                name: "Bills");

            migrationBuilder.DropTable(
                name: "CustomersFeedbacks");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PartsOrders");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "RepairCenters");

            migrationBuilder.DropTable(
                name: "WashingCenters");

            migrationBuilder.DropTable(
                name: "VehicleParks");
        }
    }
}
