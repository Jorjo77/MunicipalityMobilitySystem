using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityMobilitySystem.Infrasructure.Migrations
{
    public partial class SeedAdititionalData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e83d888-141b-497a-be99-151c94ea398f", "AQAAAAEAACcQAAAAEPilQxVaRmBigKd2y8Of6TUWcBHBWZakqH5aKmh2ATog12G+bdi7eLq4InA51RN8+w==", "14ac3f14-9d65-407c-bc07-e045f778e89e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "552f5c83-dccb-495e-81f1-32232f6bb403", "AQAAAAEAACcQAAAAEMjNrKeLMGTPQ/qqui9R5FtNl2TIuZ3nQqRsIlW5XomfylzFRD/NuQVwegTC5UKSDA==", "f2782906-f4a3-4a53-949b-3c768fa2fccb" });
        }
    }
}
