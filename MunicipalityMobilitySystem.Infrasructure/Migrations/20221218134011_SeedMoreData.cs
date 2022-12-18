using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityMobilitySystem.Infrasructure.Migrations
{
    public partial class SeedMoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11db5be7-6e3e-4811-a150-9e248044789a", "AQAAAAEAACcQAAAAEB+Lgtysb9Do57BwjQ1tcR5pW3oqhibP48pRnrJmFZWUVK3cCRjW3bQPCZY9nwwydg==", "77216193-5282-454d-a838-6522b7ece3d8" });

            migrationBuilder.UpdateData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.home-max.bg%2Fstatic%2Fmedia%2Fups%2Fproducts%2Fmain%2F06054168_y.JPG%3Fv%3D0.31&imgrefurl=https%3A%2F%2Fwww.home-max.bg%2Faluminiev-mtb-velosiped-passati-24%2F&tbnid=2yQM2U2uluMNsM&vet=12ahUKEwiCgv78nYP8AhWFIMUKHXm7AhMQMygGegUIARDNAQ..i&docid=18h343pFLn71EM&w=4613&h=2843&q=Passaty&ved=2ahUKEwiCgv78nYP8AhWFIMUKHXm7AhMQMygGegUIARDNAQ", 4.00m, 4, "Passati" });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsForCleaning", "IsForRepearing", "IsNeedDayExchangeVehicleCard", "IsNeedHelmet", "PricePerHour", "Rating", "RenterId", "Type", "VehicleParkId" },
                values: new object[,]
                {
                    { 2, 2, "A realy good transport solution for sport people.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuinQIdRNjDVnCddYQFkMkFIkt3cyXVfVqPA&usqp=CAU", false, false, false, false, 5.00m, 5, null, "Cross", 1 },
                    { 3, 2, "A very good luxury transport solution for beasy people.", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fcyclist.b-cdn.net%2Fsites%2Fcyclist%2Ffiles%2Fstyles%2Farticle_main_wide_image%2Fpublic%2F2021%2F11%2Fpinarello-dogma-f-1.jpg%3Fitok%3DhYRlGtTu&imgrefurl=https%3A%2F%2Fwww.cyclist.co.uk%2Fin-depth%2F10256%2Fwhat-is-a-road-bike&tbnid=_oCCGbIDpZdqDM&vet=12ahUKEwihuZSjnoP8AhUBtaQKHckKCJ4QMygDegUIARDMAQ..i&docid=zcxxLnqOLHXrGM&w=1240&h=698&q=road%20bike&ved=2ahUKEwihuZSjnoP8AhUBtaQKHckKCJ4QMygDegUIARDMAQ", false, false, false, false, 7.00m, 6, null, "Pinarello", 1 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Description", "EngineType", "ImageUrl", "IsForCleaning", "IsForRepearing", "IsNeedDayBlueCard", "PricePerHour", "Rating", "RenterId", "Type", "VehicleParkId" },
                values: new object[,]
                {
                    { 2, 3, "A realy good and transport solution for a big family.", "Diesel", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fkolalok.com%2Fnewimage%2Fsmall%2F2015-touran-ii-volkswagen.jpg&imgrefurl=https%3A%2F%2Fkolalok.com%2Fgabariti%2Fvolkswagen%2Ftouran.html&tbnid=vv3QuTgJq6H87M&vet=12ahUKEwicyeOinIP8AhXFwQIHHR6MAcIQMygNegUIARDbAQ..i&docid=Cv2JajDnUh_gbM&w=322&h=215&q=Wv%20toaran&ved=2ahUKEwicyeOinIP8AhXFwQIHHR6MAcIQMygNegUIARDbAQ", false, false, false, 23.00m, 5, null, "VW Touran", 1 },
                    { 3, 1, "A very good and transport solution for a city center.", "Electric", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.ultimatespecs.com%2Fcargallery%2F67%2F4854%2Fw400_Hyundai-Eon-2.jpg&imgrefurl=https%3A%2F%2Fwww.ultimatespecs.com%2Fbg%2Fcar-specs%2FHyundai%2F14708%2FHyundai-Eon-08-MPi.html&tbnid=2p0LKtPnAW8CPM&vet=12ahUKEwjzidSanYP8AhWSNewKHTg5CxIQMygCegUIARC9AQ..i&docid=ZGGa2cS6QA17DM&w=400&h=225&itg=1&q=hunday%20eon&ved=2ahUKEwjzidSanYP8AhWSNewKHTg5CxIQMygCegUIARC9AQ", false, false, false, 20.00m, 4, null, "Hynday EON", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Scooters",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A very good transport solution for a city center.");

            migrationBuilder.InsertData(
                table: "Scooters",
                columns: new[] { "Id", "CategoryId", "Description", "EngineType", "ImageUrl", "IsForCleaning", "IsForRepearing", "IsNeedDayExchangeVehicleCard", "IsNeedHelmet", "PricePerHour", "Rating", "RenterId", "Type", "VehicleParkId" },
                values: new object[,]
                {
                    { 2, 1, "A realy good transport solution for a city center.", "Petrol", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fcdn.motor1.com%2Fimages%2Fmgl%2FP3GnXX%2Fs3%2F2022-vespa-elettrica-red---main.jpg&imgrefurl=https%3A%2F%2Fwww.rideapart.com%2Fnews%2F562600%2Fvespa-brand-906million-euros%2F&tbnid=CPQTR3BmwOmqPM&vet=12ahUKEwiTi8mXn4P8AhUYxgIHHRheDBwQMygQegUIARDWAQ..i&docid=oNKLqZ2kpDMT7M&w=1280&h=720&q=Piaggo&ved=2ahUKEwiTi8mXn4P8AhUYxgIHHRheDBwQMygQegUIARDWAQ", false, false, false, false, 10.00m, 5, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "Piaggo", 1 },
                    { 3, 2, "Exellent transport solution for a city center.", "Electric", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fbg.e-scooter.co%2Fi%2F96%2F0c%2F0a%2F95d8f798a27fb6ad77c11b8ec2.jpg&imgrefurl=https%3A%2F%2Fbg.e-scooter.co%2Fpiaggio-one%2F&tbnid=5Mt_ltA3Pdl3sM&vet=12ahUKEwiTi8mXn4P8AhUYxgIHHRheDBwQMygBegUIARC3AQ..i&docid=zsJorUwAg6RoyM&w=753&h=771&q=Piaggo&ved=2ahUKEwiTi8mXn4P8AhUYxgIHHRheDBwQMygBegUIARC3AQ", false, false, false, false, 11.00m, 5, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "Piaggo", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Rating", "Type" },
                values: new object[] { "A realy good transport solution for a big cargos.", 5, "Scania" });

            migrationBuilder.InsertData(
                table: "Trucks",
                columns: new[] { "Id", "CategoryId", "Description", "EngineType", "ImageUrl", "IsForCleaning", "IsForRepearing", "IsNeedDayBlueCard", "PricePerHour", "Rating", "RenterId", "Type", "VehicleParkId" },
                values: new object[,]
                {
                    { 2, 3, "Excelent transport solution for a big cargos.", "Diesel", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.kamioni.bg%2Fpictures%2F29618_2_scania%2Bbev2-650.jpg&imgrefurl=https%3A%2F%2Fwww.kamioni.bg%2Fmenu%2F10%2Fpost%2F29618%2FScania-predstavq-nova-gama-e-kamioni-za-regionalen-transport&tbnid=jkhfmffUYxtEHM&vet=12ahUKEwjcu_iPmIP8AhW2lv0HHavxCNsQMygGegUIARDOAQ..i&docid=iugoRchY4ROK5M&w=650&h=438&q=Scania&ved=2ahUKEwjcu_iPmIP8AhW2lv0HHavxCNsQMygGegUIARDOAQ", false, false, false, 50.00m, 6, null, "Mercedes", 1 },
                    { 3, 3, "A very good transport solution for a big cargos.", "Diesel", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.volvotrucks.us%2F-%2Fmedia%2Fvtna%2Fimages%2Fshared%2Ftab-content%2Fvnl%2Ftabbed-feature%2Fvolvo-vnl-25th-aerodynamics.jpg%3Fh%3D410%26w%3D725%26rev%3D4a1b9e19a65e418ba2bcffc4b952005a%26hash%3D78C61F2B39C62E7464AAA1FC051487C0&imgrefurl=https%3A%2F%2Fwww.volvotrucks.us%2Ftrucks%2Fvnl%2F&tbnid=4lteSbMPeJB2jM&vet=12ahUKEwjSvPvKmYP8AhU5nP0HHaRzDFsQMygPegUIARDkAQ..i&docid=cXhpx2BnsyvK8M&w=725&h=410&q=volvo%20truck%202021&ved=2ahUKEwjSvPvKmYP8AhU5nP0HHaRzDFsQMygPegUIARDkAQ", false, false, false, 35.00m, 4, null, "Volvo", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Scooters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Scooters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 3);

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
                table: "Scooters",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A realy good transport solution for a city center.");

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Rating", "Type" },
                values: new object[] { "A realy good transport solution for a big cargo.", 6, "Mercedes" });
        }
    }
}
