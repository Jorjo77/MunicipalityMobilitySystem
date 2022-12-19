using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityMobilitySystem.Infrasructure.Migrations
{
    public partial class DataAdititionalSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "552f5c83-dccb-495e-81f1-32232f6bb403", "AQAAAAEAACcQAAAAEMjNrKeLMGTPQ/qqui9R5FtNl2TIuZ3nQqRsIlW5XomfylzFRD/NuQVwegTC5UKSDA==", "f2782906-f4a3-4a53-949b-3c768fa2fccb" });

            migrationBuilder.UpdateData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.home-max.bg%2Fstatic%2Fmedia%2Fups%2Fcached%2F781e8afa44a58ec261abdd83455444f5c203f4c5.jpg&imgrefurl=https%3A%2F%2Fwww.home-max.bg%2Fvelosiped-passati-26-mtb-3700%2F&tbnid=kA6ZVlURPKhh4M&vet=12ahUKEwj8q-zhyYX8AhXlxwIHHRaND0gQMygBegUIARC1AQ..i&docid=CRixMubXhzLYzM&w=640&h=480&q=Passati&ved=2ahUKEwj8q-zhyYX8AhXlxwIHHRaND0gQMygBegUIARC1AQ");

            migrationBuilder.UpdateData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { "A very good luxury transport solution for beasy people.", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fhips.hearstapps.com%2Fhmg-prod%2Fimages%2Fpinarello-dogma-f-tested-1624463882.jpg&imgrefurl=https%3A%2F%2Fwww.bicycling.com%2Fbikes-gear%2Fa36815265%2Fpinarello-dogma-f-review%2F&tbnid=gkQMZzUwYV_bTM&vet=12ahUKEwjNk57LyYX8AhXdxgIHHYRAAgwQMygBegUIARDdAQ..i&docid=w0vXcmsF9jyIAM&w=7030&h=4912&q=Pinarello&ved=2ahUKEwjNk57LyYX8AhXdxgIHHYRAAgwQMygBegUIARDdAQ", 7.00m, 6, "Pinarello" });

            migrationBuilder.UpdateData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { "A realy good transport solution for sport people.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuinQIdRNjDVnCddYQFkMkFIkt3cyXVfVqPA&usqp=CAU", 5.00m, 5, "Cross" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "EngineType", "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { 1, "A very good and transport solution for a city center.", "Electric", "https://www.google.com/imgres?imgurl=https%3A%2F%2Ffichasmotor.com%2Fimages%2Fhyundai%2Fhyundai-eon-0-8-56-cv.webp&imgrefurl=https%3A%2F%2Ffichasmotor.com%2Fen%2Fhyundai%2Fhyundai-eon-0-8-56-cv%2F&tbnid=b5rmBwPhiJED7M&vet=12ahUKEwjonf6Hy4X8AhXSQeUKHaRRCAsQMygTegUIARCHAg..i&docid=VCMCK7OUZxeDiM&w=960&h=542&q=Hynday%20EON&ved=2ahUKEwjonf6Hy4X8AhXSQeUKHaRRCAsQMygTegUIARCHAg", 20.00m, 4, "Hynday EON" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.google.com/imgres?imgurl=https%3A%2F%2Fm.atcdn.co.uk%2Fect%2Fmedia%2Fw1920%2Fbrand-store%2Fvolkswagen%2Ftouran%2Fhero.jpg&imgrefurl=https%3A%2F%2Fwww.autotrader.co.uk%2Fcars%2Fuk%2Fvolkswagen%2Ftouran&tbnid=iBeoqxiXOpMDuM&vet=12ahUKEwjsp8L6y4X8AhV0_rsIHYlCCyMQMygJegUIARDxAQ..i&docid=C8aG3aQ2P98X8M&w=1920&h=980&q=VW%20Touran&ved=2ahUKEwjsp8L6y4X8AhV0_rsIHYlCCyMQMygJegUIARDxAQ");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "EngineType", "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { 2, "A realy good and luxury transport solution.", "Petrol", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFiWMRzQZJ4dYjRVlv-l25KWCVweGaWbIJOA&usqp=CAU", 25.00m, 6, "Mercedes CLS 180" });

            migrationBuilder.UpdateData(
                table: "Scooters",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "EngineType", "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { 2, "Exellent transport solution for a city center.", "Electric", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fbg.e-scooter.co%2Fi%2F17%2F72%2Fed%2Fd5015b9723a5397c924e7b797d.jpg&imgrefurl=https%3A%2F%2Fbg.e-scooter.co%2Fpiaggio-one-active%2F&tbnid=yaQ2lq0vl1LETM&vet=12ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygZegUIARCZAg..i&docid=LeZmqaBlOwjRIM&w=474&h=415&q=Piaggio&ved=2ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygZegUIARCZAg", 11.00m, 5, "Piaggo" });

            migrationBuilder.UpdateData(
                table: "Scooters",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.google.com/imgres?imgurl=https%3A%2F%2Fimages.piaggio.com%2Fpiaggio%2Fvehicles%2Fnclp000u15%2Fnclp8znu15%2Fnclp8znu15-01-s.png&imgrefurl=https%3A%2F%2Fwww.piaggio.com%2Fbg_BG%2Fmodels%2Fliberty%2Fliberty-50-4s3v-2021%2F&tbnid=dIb-qyhP2vh5mM&vet=12ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygFegUIARDsAQ..i&docid=un13zXQdXG3kwM&w=750&h=500&q=Piaggio&ved=2ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygFegUIARDsAQ");

            migrationBuilder.UpdateData(
                table: "Scooters",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "EngineType", "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { 1, "A very good transport solution for a city center.", "Petrol", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT4TbIp4RJgECS2py-M_zNjwLrXYIbcZ07XQA&usqp=CAU", 9.00m, 6, "Vespa" });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { "A very good transport solution for a big cargos.", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.nacaratotruckcenters.com%2Ffckimages%2Fvolvo-trucks%2Fvnl-series%2Fvo-vnl300-16-0003.jpg&imgrefurl=https%3A%2F%2Fwww.nacaratotruckcenters.com%2Fshop-nacarato-for-volvo--vnl-series&tbnid=VoeQjE1FuBwyUM&vet=12ahUKEwiS_oq2zIX8AhWEr6QKHX4kBMYQMygcegUIARChAg..i&docid=nempaaU2cirinM&w=725&h=410&q=Volvo%20truck&ved=2ahUKEwiS_oq2zIX8AhWEr6QKHX4kBMYQMygcegUIARChAg", 35.00m, 4, "Volvo" });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.mercedes-benz-trucks.com%2Fcontent%2Fdam%2Fmbo%2Fmarkets%2Fhq_HQ%2Fmodel-navigation-images%2Fproven%2Fmodelthumb-actros-slt.png&imgrefurl=https%3A%2F%2Fwww.mercedes-benz-trucks.com%2Fbg_BG%2Fhome.html&tbnid=YOUxhC-ziZz2TM&vet=12ahUKEwjWytWjzIX8AhWHjaQKHbkxC8gQMygEegUIARDnAQ..i&docid=Tb7v0QbAqHgN1M&w=450&h=341&q=mercedes%20truck&ved=2ahUKEwjWytWjzIX8AhWHjaQKHbkxC8gQMygEegUIARDnAQ");

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { "A realy good transport solution for a big cargos.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQb4pdFmd8vMzEsFxaFaonBFAQhs3EA2P9r_Q&usqp=CAU", 40.00m, 5, "Scania" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "ImageUrl",
                value: "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.home-max.bg%2Fstatic%2Fmedia%2Fups%2Fproducts%2Fmain%2F06054168_y.JPG%3Fv%3D0.31&imgrefurl=https%3A%2F%2Fwww.home-max.bg%2Faluminiev-mtb-velosiped-passati-24%2F&tbnid=2yQM2U2uluMNsM&vet=12ahUKEwiCgv78nYP8AhWFIMUKHXm7AhMQMygGegUIARDNAQ..i&docid=18h343pFLn71EM&w=4613&h=2843&q=Passaty&ved=2ahUKEwiCgv78nYP8AhWFIMUKHXm7AhMQMygGegUIARDNAQ");

            migrationBuilder.UpdateData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { "A realy good transport solution for sport people.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuinQIdRNjDVnCddYQFkMkFIkt3cyXVfVqPA&usqp=CAU", 5.00m, 5, "Cross" });

            migrationBuilder.UpdateData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { "A very good luxury transport solution for beasy people.", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fcyclist.b-cdn.net%2Fsites%2Fcyclist%2Ffiles%2Fstyles%2Farticle_main_wide_image%2Fpublic%2F2021%2F11%2Fpinarello-dogma-f-1.jpg%3Fitok%3DhYRlGtTu&imgrefurl=https%3A%2F%2Fwww.cyclist.co.uk%2Fin-depth%2F10256%2Fwhat-is-a-road-bike&tbnid=_oCCGbIDpZdqDM&vet=12ahUKEwihuZSjnoP8AhUBtaQKHckKCJ4QMygDegUIARDMAQ..i&docid=zcxxLnqOLHXrGM&w=1240&h=698&q=road%20bike&ved=2ahUKEwihuZSjnoP8AhUBtaQKHckKCJ4QMygDegUIARDMAQ", 7.00m, 6, "Pinarello" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "EngineType", "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { 2, "A realy good and luxury transport solution.", "Petrol", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFiWMRzQZJ4dYjRVlv-l25KWCVweGaWbIJOA&usqp=CAU", 25.00m, 6, "Mercedes CLS 180" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.google.com/imgres?imgurl=https%3A%2F%2Fkolalok.com%2Fnewimage%2Fsmall%2F2015-touran-ii-volkswagen.jpg&imgrefurl=https%3A%2F%2Fkolalok.com%2Fgabariti%2Fvolkswagen%2Ftouran.html&tbnid=vv3QuTgJq6H87M&vet=12ahUKEwicyeOinIP8AhXFwQIHHR6MAcIQMygNegUIARDbAQ..i&docid=Cv2JajDnUh_gbM&w=322&h=215&q=Wv%20toaran&ved=2ahUKEwicyeOinIP8AhXFwQIHHR6MAcIQMygNegUIARDbAQ");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "EngineType", "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { 1, "A very good and transport solution for a city center.", "Electric", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.ultimatespecs.com%2Fcargallery%2F67%2F4854%2Fw400_Hyundai-Eon-2.jpg&imgrefurl=https%3A%2F%2Fwww.ultimatespecs.com%2Fbg%2Fcar-specs%2FHyundai%2F14708%2FHyundai-Eon-08-MPi.html&tbnid=2p0LKtPnAW8CPM&vet=12ahUKEwjzidSanYP8AhWSNewKHTg5CxIQMygCegUIARC9AQ..i&docid=ZGGa2cS6QA17DM&w=400&h=225&itg=1&q=hunday%20eon&ved=2ahUKEwjzidSanYP8AhWSNewKHTg5CxIQMygCegUIARC9AQ", 20.00m, 4, "Hynday EON" });

            migrationBuilder.UpdateData(
                table: "Scooters",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "EngineType", "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { 1, "A very good transport solution for a city center.", "Petrol", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT4TbIp4RJgECS2py-M_zNjwLrXYIbcZ07XQA&usqp=CAU", 9.00m, 6, "Vespa" });

            migrationBuilder.UpdateData(
                table: "Scooters",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.google.com/imgres?imgurl=https%3A%2F%2Fcdn.motor1.com%2Fimages%2Fmgl%2FP3GnXX%2Fs3%2F2022-vespa-elettrica-red---main.jpg&imgrefurl=https%3A%2F%2Fwww.rideapart.com%2Fnews%2F562600%2Fvespa-brand-906million-euros%2F&tbnid=CPQTR3BmwOmqPM&vet=12ahUKEwiTi8mXn4P8AhUYxgIHHRheDBwQMygQegUIARDWAQ..i&docid=oNKLqZ2kpDMT7M&w=1280&h=720&q=Piaggo&ved=2ahUKEwiTi8mXn4P8AhUYxgIHHRheDBwQMygQegUIARDWAQ");

            migrationBuilder.UpdateData(
                table: "Scooters",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "EngineType", "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { 2, "Exellent transport solution for a city center.", "Electric", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fbg.e-scooter.co%2Fi%2F96%2F0c%2F0a%2F95d8f798a27fb6ad77c11b8ec2.jpg&imgrefurl=https%3A%2F%2Fbg.e-scooter.co%2Fpiaggio-one%2F&tbnid=5Mt_ltA3Pdl3sM&vet=12ahUKEwiTi8mXn4P8AhUYxgIHHRheDBwQMygBegUIARC3AQ..i&docid=zsJorUwAg6RoyM&w=753&h=771&q=Piaggo&ved=2ahUKEwiTi8mXn4P8AhUYxgIHHRheDBwQMygBegUIARC3AQ", 11.00m, 5, "Piaggo" });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { "A realy good transport solution for a big cargos.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQb4pdFmd8vMzEsFxaFaonBFAQhs3EA2P9r_Q&usqp=CAU", 40.00m, 5, "Scania" });

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.kamioni.bg%2Fpictures%2F29618_2_scania%2Bbev2-650.jpg&imgrefurl=https%3A%2F%2Fwww.kamioni.bg%2Fmenu%2F10%2Fpost%2F29618%2FScania-predstavq-nova-gama-e-kamioni-za-regionalen-transport&tbnid=jkhfmffUYxtEHM&vet=12ahUKEwjcu_iPmIP8AhW2lv0HHavxCNsQMygGegUIARDOAQ..i&docid=iugoRchY4ROK5M&w=650&h=438&q=Scania&ved=2ahUKEwjcu_iPmIP8AhW2lv0HHavxCNsQMygGegUIARDOAQ");

            migrationBuilder.UpdateData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "PricePerHour", "Rating", "Type" },
                values: new object[] { "A very good transport solution for a big cargos.", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.volvotrucks.us%2F-%2Fmedia%2Fvtna%2Fimages%2Fshared%2Ftab-content%2Fvnl%2Ftabbed-feature%2Fvolvo-vnl-25th-aerodynamics.jpg%3Fh%3D410%26w%3D725%26rev%3D4a1b9e19a65e418ba2bcffc4b952005a%26hash%3D78C61F2B39C62E7464AAA1FC051487C0&imgrefurl=https%3A%2F%2Fwww.volvotrucks.us%2Ftrucks%2Fvnl%2F&tbnid=4lteSbMPeJB2jM&vet=12ahUKEwjSvPvKmYP8AhU5nP0HHaRzDFsQMygPegUIARDkAQ..i&docid=cXhpx2BnsyvK8M&w=725&h=410&q=volvo%20truck%202021&ved=2ahUKEwjSvPvKmYP8AhU5nP0HHaRzDFsQMygPegUIARDkAQ", 35.00m, 4, "Volvo" });
        }
    }
}
