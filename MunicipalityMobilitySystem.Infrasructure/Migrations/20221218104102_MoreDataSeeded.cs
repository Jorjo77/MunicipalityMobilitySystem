using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityMobilitySystem.Infrasructure.Migrations
{
    public partial class MoreDataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb60e72d-4faf-4e11-922a-3ee926b02347", "AQAAAAEAACcQAAAAEJOmqZPIUVb2O+3xgUjlxYZzulwQvpyVInrDkZHSu0Ucd/neFxQtbVKzUtiPmtM00A==", "14593ab0-15de-4ca7-b6e3-4346e39a8f44" });

            migrationBuilder.UpdateData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuinQIdRNjDVnCddYQFkMkFIkt3cyXVfVqPA&usqp=CAU", 7.00m, 6, "Cross" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "PricePerHour", "Type" },
                values: new object[] { "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFiWMRzQZJ4dYjRVlv-l25KWCVweGaWbIJOA&usqp=CAU", 25.00m, "Mercedes CLS 180" });

            migrationBuilder.UpdateData(
                table: "Scooters",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EngineType", "ImageUrl", "PricePerHour", "Type" },
                values: new object[] { "Petrol", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT4TbIp4RJgECS2py-M_zNjwLrXYIbcZ07XQA&usqp=CAU", 9.00m, "Vespa" });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Rating", "Type" },
                values: new object[] { "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQb4pdFmd8vMzEsFxaFaonBFAQhs3EA2P9r_Q&usqp=CAU", 6, "Mercedes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3de65bc5-d44c-418c-ad58-c01d4d9e6b52", "AQAAAAEAACcQAAAAEPK7wMgYdMAQQNce6BuQ8i/8m/IHOUApmhQ1SjWqsaTTydIAKVlt24naANq9IzjfJA==", "27ed42d5-b1bf-4dbb-b913-68c3137f8403" });

            migrationBuilder.UpdateData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { "https://www.google.com/imgres?imgurl=https%3A%2F%2Fpassati.com%2Fimages%2Fstories%2Fvirtuemart%2Fproduct%2FEGBERT27.5-29%2520DISK%2520BLUE%2520Front.jpg&imgrefurl=https%3A%2F%2Fpassati.com%2Findex.php%3Foption%3Dcom_virtuemart%26view%3Dproductdetails%26virtuemart_product_id%3D203%26virtuemart_category_id%3D2%26lang%3Dbg&tbnid=F1pd6OQdaNHHfM&vet=12ahUKEwia-avZ5vj7AhUunv0HHSr8DY8QMygHegUIARDLAQ..i&docid=zUMwW1b5u_0RHM&w=4750&h=3123&q=passati%20%D0%BA%D0%BE%D0%BB%D0%B5%D0%BB%D0%BE&ved=2ahUKEwia-avZ5vj7AhUunv0HHSr8DY8QMygHegUIARDLAQ", 8.00m, 4, "Passati" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "PricePerHour", "Type" },
                values: new object[] { "https://www.google.com/imgres?imgurl=https%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fcommons%2F5%2F52%2FMercedes-Benz_C_200_Avantgarde_%2528W_205%2529_%25E2%2580%2593_Frontansicht%252C_26._April_2014%252C_D%25C3%25BCsseldorf.jpg&imgrefurl=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FMercedes-Benz_C-Class_(W205)&tbnid=wz3T3Jbg3NRb1M&vet=12ahUKEwjw97il6fj7AhUunv0HHSr8DY8QMygCegUIARDGAQ..i&docid=W-hhnTTjUDZfoM&w=3418&h=1711&q=mercedes%20c%20class%20w205&ved=2ahUKEwjw97il6fj7AhUunv0HHSr8DY8QMygCegUIARDGAQ", 20.00m, "Mercedes C 180" });

            migrationBuilder.UpdateData(
                table: "Scooters",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EngineType", "ImageUrl", "PricePerHour", "Type" },
                values: new object[] { "Electric", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fbg.e-scooter.co%2Fwp-content%2Fuploads%2F2021%2F06%2Fcuckgo.com_-e1623030797433.jpeg&imgrefurl=https%3A%2F%2Fbg.e-scooter.co%2Fpiaggio-one%2F&tbnid=xM2wRoaEPhPNHM&vet=12ahUKEwiD_cOT5Pj7AhVxyrsIHaqtCpUQMygBegUIARC6AQ..i&docid=zsJorUwAg6RoyM&w=753&h=771&q=Piaggio&ved=2ahUKEwiD_cOT5Pj7AhVxyrsIHaqtCpUQMygBegUIARC6AQ", 10.00m, "Piaggo" });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Rating", "Type" },
                values: new object[] { "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.volvotrucks.us%2F-%2Fmedia%2Fvtna%2Fimages%2Fshared%2Ftab-content%2Fvnl%2Ftabbed-feature%2Fvolvo-vnl-25th-aerodynamics.jpg%3Fh%3D410%26w%3D725%26rev%3D4a1b9e19a65e418ba2bcffc4b952005a%26hash%3D78C61F2B39C62E7464AAA1FC051487C0&imgrefurl=https%3A%2F%2Fwww.volvotrucks.us%2Ftrucks%2Fvnl%2F&tbnid=4lteSbMPeJB2jM&vet=12ahUKEwj3jKWa6vj7AhUykv0HHaDKC88QMygPegUIARDgAQ..i&docid=cXhpx2BnsyvK8M&w=725&h=410&q=volvo%20truck%202021&ved=2ahUKEwj3jKWa6vj7AhUykv0HHaDKC88QMygPegUIARDgAQ", 5, "Volvo" });
        }
    }
}
