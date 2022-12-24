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
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    VehicleWashId = table.Column<int>(type: "int", nullable: false)
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
                    VehicleWParkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_VehicleParks_VehicleWParkId",
                        column: x => x.VehicleWParkId,
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
                values: new object[] { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "09cda48e-4aa5-4465-bb2b-549ac9fbedad", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAELwQq7Dq02Ty220q3lWjqw0iq/zX3q/qPurA5h95u1sB8UaZqOi8hVOHBI1P6P1WtA==", null, false, "b4f53236-28a2-49f1-a7fb-4d17fdea43df", false, "guest@mail.com" });

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
                columns: new[] { "Id", "Adress", "Email", "Name", "Phone", "ServiceId", "VehicleWashId" },
                values: new object[] { 1, "Bulgaria, Sofia City, Iskar Str. 36", "vehicles_for_rent@abv.bg", "Central", "+359878128344", 0, 0 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CategoryId", "Description", "EngineType", "FailureDescription", "ForCleaning", "ForRepearing", "ImageUrl", "Model", "PricePerHour", "Rating", "RenterId", "RentsCount", "RepairingTerm", "RepairsCount", "ServiceId", "VehicleParkId", "VehicleWashId" },
                values: new object[,]
                {
                    { 1, 2, "Exellent transport solution for a city center.", "Electric", null, false, false, "https://www.google.com/imgres?imgurl=https%3A%2F%2Fbg.e-scooter.co%2Fi%2F17%2F72%2Fed%2Fd5015b9723a5397c924e7b797d.jpg&imgrefurl=https%3A%2F%2Fbg.e-scooter.co%2Fpiaggio-one-active%2F&tbnid=yaQ2lq0vl1LETM&vet=12ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygZegUIARCZAg..i&docid=LeZmqaBlOwjRIM&w=474&h=415&q=Piaggio&ved=2ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygZegUIARCZAg", "Piaggo", 11.00m, 5, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, null, 0, null, 1, null },
                    { 2, 2, "A realy good transport solution for a city center.", "Petrol", null, false, false, "https://www.google.com/imgres?imgurl=https%3A%2F%2Fimages.piaggio.com%2Fpiaggio%2Fvehicles%2Fnclp000u15%2Fnclp8znu15%2Fnclp8znu15-01-s.png&imgrefurl=https%3A%2F%2Fwww.piaggio.com%2Fbg_BG%2Fmodels%2Fliberty%2Fliberty-50-4s3v-2021%2F&tbnid=dIb-qyhP2vh5mM&vet=12ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygFegUIARDsAQ..i&docid=un13zXQdXG3kwM&w=750&h=500&q=Piaggio&ved=2ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygFegUIARDsAQ", "Piaggo", 10.00m, 5, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, null, 0, null, 1, null },
                    { 3, 2, "A very good transport solution for a city center.", "Petrol", null, false, false, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT4TbIp4RJgECS2py-M_zNjwLrXYIbcZ07XQA&usqp=CAU", "Vespa", 9.00m, 6, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, null, 0, null, 1, null },
                    { 4, 1, "A very good transport solution for sport people.", null, null, false, false, "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.home-max.bg%2Fstatic%2Fmedia%2Fups%2Fcached%2F781e8afa44a58ec261abdd83455444f5c203f4c5.jpg&imgrefurl=https%3A%2F%2Fwww.home-max.bg%2Fvelosiped-passati-26-mtb-3700%2F&tbnid=kA6ZVlURPKhh4M&vet=12ahUKEwj8q-zhyYX8AhXlxwIHHRaND0gQMygBegUIARC1AQ..i&docid=CRixMubXhzLYzM&w=640&h=480&q=Passati&ved=2ahUKEwj8q-zhyYX8AhXlxwIHHRaND0gQMygBegUIARC1AQ", "Passati", 4.00m, 4, null, 0, null, 0, null, 1, null },
                    { 5, 1, "A very good luxury transport solution for beasy people.", null, null, false, false, "https://www.google.com/imgres?imgurl=https%3A%2F%2Fhips.hearstapps.com%2Fhmg-prod%2Fimages%2Fpinarello-dogma-f-tested-1624463882.jpg&imgrefurl=https%3A%2F%2Fwww.bicycling.com%2Fbikes-gear%2Fa36815265%2Fpinarello-dogma-f-review%2F&tbnid=gkQMZzUwYV_bTM&vet=12ahUKEwjNk57LyYX8AhXdxgIHHYRAAgwQMygBegUIARDdAQ..i&docid=w0vXcmsF9jyIAM&w=7030&h=4912&q=Pinarello&ved=2ahUKEwjNk57LyYX8AhXdxgIHHYRAAgwQMygBegUIARDdAQ", "Pinarello", 7.00m, 6, null, 0, null, 0, null, 1, null },
                    { 6, 1, "A realy good transport solution for sport people.", null, null, false, false, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuinQIdRNjDVnCddYQFkMkFIkt3cyXVfVqPA&usqp=CAU", "Cross", 5.00m, 5, null, 0, null, 0, null, 1, null },
                    { 7, 3, "A very good and transport solution for a city center.", "Electric", null, false, false, "https://www.google.com/imgres?imgurl=https%3A%2F%2Ffichasmotor.com%2Fimages%2Fhyundai%2Fhyundai-eon-0-8-56-cv.webp&imgrefurl=https%3A%2F%2Ffichasmotor.com%2Fen%2Fhyundai%2Fhyundai-eon-0-8-56-cv%2F&tbnid=b5rmBwPhiJED7M&vet=12ahUKEwjonf6Hy4X8AhXSQeUKHaRRCAsQMygTegUIARCHAg..i&docid=VCMCK7OUZxeDiM&w=960&h=542&q=Hynday%20EON&ved=2ahUKEwjonf6Hy4X8AhXSQeUKHaRRCAsQMygTegUIARCHAg", "Hynday EON", 20.00m, 4, null, 0, null, 0, null, 1, null },
                    { 8, 3, "A realy good and transport solution for a big family.", "Diesel", null, false, false, "https://www.google.com/imgres?imgurl=https%3A%2F%2Fm.atcdn.co.uk%2Fect%2Fmedia%2Fw1920%2Fbrand-store%2Fvolkswagen%2Ftouran%2Fhero.jpg&imgrefurl=https%3A%2F%2Fwww.autotrader.co.uk%2Fcars%2Fuk%2Fvolkswagen%2Ftouran&tbnid=iBeoqxiXOpMDuM&vet=12ahUKEwjsp8L6y4X8AhV0_rsIHYlCCyMQMygJegUIARDxAQ..i&docid=C8aG3aQ2P98X8M&w=1920&h=980&q=VW%20Touran&ved=2ahUKEwjsp8L6y4X8AhV0_rsIHYlCCyMQMygJegUIARDxAQ", "VW Touran", 23.00m, 5, null, 0, null, 0, null, 1, null },
                    { 9, 3, "A realy good and luxury transport solution.", "Petrol", null, false, false, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFiWMRzQZJ4dYjRVlv-l25KWCVweGaWbIJOA&usqp=CAU", "Mercedes CLS 180", 25.00m, 6, null, 0, null, 0, null, 1, null }
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
                name: "IX_Service_VehicleWParkId",
                table: "Service",
                column: "VehicleWParkId",
                unique: true);

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
                column: "VehicleParkId",
                unique: true);
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
