﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MunicipalityMobilitySystem.Data;

#nullable disable

namespace MunicipalityMobilitySystem.Infrasructure.Migrations
{
    [DbContext(typeof(MunicipalityMobilitySystemDbContext))]
    [Migration("20221219114440_DataAdititionalSeed")]
    partial class DataAdititionalSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "552f5c83-dccb-495e-81f1-32232f6bb403",
                            Email = "guest@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "guest@mail.com",
                            NormalizedUserName = "guest@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEMjNrKeLMGTPQ/qqui9R5FtNl2TIuZ3nQqRsIlW5XomfylzFRD/NuQVwegTC5UKSDA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f2782906-f4a3-4a53-949b-3c768fa2fccb",
                            TwoFactorEnabled = false,
                            UserName = "guest@mail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Bike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsForCleaning")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForRepearing")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNeedDayExchangeVehicleCard")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNeedHelmet")
                        .HasColumnType("bit");

                    b.Property<decimal>("PricePerHour")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("RenterId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VehicleParkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("VehicleParkId");

                    b.ToTable("Bikes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            Description = "A very good transport solution for sport people.",
                            ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.home-max.bg%2Fstatic%2Fmedia%2Fups%2Fcached%2F781e8afa44a58ec261abdd83455444f5c203f4c5.jpg&imgrefurl=https%3A%2F%2Fwww.home-max.bg%2Fvelosiped-passati-26-mtb-3700%2F&tbnid=kA6ZVlURPKhh4M&vet=12ahUKEwj8q-zhyYX8AhXlxwIHHRaND0gQMygBegUIARC1AQ..i&docid=CRixMubXhzLYzM&w=640&h=480&q=Passati&ved=2ahUKEwj8q-zhyYX8AhXlxwIHHRaND0gQMygBegUIARC1AQ",
                            IsForCleaning = false,
                            IsForRepearing = false,
                            IsNeedDayExchangeVehicleCard = false,
                            IsNeedHelmet = false,
                            PricePerHour = 4.00m,
                            Rating = 4,
                            Type = "Passati",
                            VehicleParkId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "A very good luxury transport solution for beasy people.",
                            ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fhips.hearstapps.com%2Fhmg-prod%2Fimages%2Fpinarello-dogma-f-tested-1624463882.jpg&imgrefurl=https%3A%2F%2Fwww.bicycling.com%2Fbikes-gear%2Fa36815265%2Fpinarello-dogma-f-review%2F&tbnid=gkQMZzUwYV_bTM&vet=12ahUKEwjNk57LyYX8AhXdxgIHHYRAAgwQMygBegUIARDdAQ..i&docid=w0vXcmsF9jyIAM&w=7030&h=4912&q=Pinarello&ved=2ahUKEwjNk57LyYX8AhXdxgIHHYRAAgwQMygBegUIARDdAQ",
                            IsForCleaning = false,
                            IsForRepearing = false,
                            IsNeedDayExchangeVehicleCard = false,
                            IsNeedHelmet = false,
                            PricePerHour = 7.00m,
                            Rating = 6,
                            Type = "Pinarello",
                            VehicleParkId = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "A realy good transport solution for sport people.",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuinQIdRNjDVnCddYQFkMkFIkt3cyXVfVqPA&usqp=CAU",
                            IsForCleaning = false,
                            IsForRepearing = false,
                            IsNeedDayExchangeVehicleCard = false,
                            IsNeedHelmet = false,
                            PricePerHour = 5.00m,
                            Rating = 5,
                            Type = "Cross",
                            VehicleParkId = 1
                        });
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsForCleaning")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForRepearing")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNeedDayBlueCard")
                        .HasColumnType("bit");

                    b.Property<decimal>("PricePerHour")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("RenterId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VehicleParkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("VehicleParkId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "A very good and transport solution for a city center.",
                            EngineType = "Electric",
                            ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Ffichasmotor.com%2Fimages%2Fhyundai%2Fhyundai-eon-0-8-56-cv.webp&imgrefurl=https%3A%2F%2Ffichasmotor.com%2Fen%2Fhyundai%2Fhyundai-eon-0-8-56-cv%2F&tbnid=b5rmBwPhiJED7M&vet=12ahUKEwjonf6Hy4X8AhXSQeUKHaRRCAsQMygTegUIARCHAg..i&docid=VCMCK7OUZxeDiM&w=960&h=542&q=Hynday%20EON&ved=2ahUKEwjonf6Hy4X8AhXSQeUKHaRRCAsQMygTegUIARCHAg",
                            IsForCleaning = false,
                            IsForRepearing = false,
                            IsNeedDayBlueCard = false,
                            PricePerHour = 20.00m,
                            Rating = 4,
                            Type = "Hynday EON",
                            VehicleParkId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            Description = "A realy good and transport solution for a big family.",
                            EngineType = "Diesel",
                            ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fm.atcdn.co.uk%2Fect%2Fmedia%2Fw1920%2Fbrand-store%2Fvolkswagen%2Ftouran%2Fhero.jpg&imgrefurl=https%3A%2F%2Fwww.autotrader.co.uk%2Fcars%2Fuk%2Fvolkswagen%2Ftouran&tbnid=iBeoqxiXOpMDuM&vet=12ahUKEwjsp8L6y4X8AhV0_rsIHYlCCyMQMygJegUIARDxAQ..i&docid=C8aG3aQ2P98X8M&w=1920&h=980&q=VW%20Touran&ved=2ahUKEwjsp8L6y4X8AhV0_rsIHYlCCyMQMygJegUIARDxAQ",
                            IsForCleaning = false,
                            IsForRepearing = false,
                            IsNeedDayBlueCard = false,
                            PricePerHour = 23.00m,
                            Rating = 5,
                            Type = "VW Touran",
                            VehicleParkId = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "A realy good and luxury transport solution.",
                            EngineType = "Petrol",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFiWMRzQZJ4dYjRVlv-l25KWCVweGaWbIJOA&usqp=CAU",
                            IsForCleaning = false,
                            IsForRepearing = false,
                            IsNeedDayBlueCard = false,
                            PricePerHour = 25.00m,
                            Rating = 6,
                            Type = "Mercedes CLS 180",
                            VehicleParkId = 1
                        });
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categorys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Small",
                            Size = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Middle",
                            Size = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Large",
                            Size = 0
                        });
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Scooter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsForCleaning")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForRepearing")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNeedDayExchangeVehicleCard")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNeedHelmet")
                        .HasColumnType("bit");

                    b.Property<decimal>("PricePerHour")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("RenterId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VehicleParkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("VehicleParkId");

                    b.ToTable("Scooters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            Description = "Exellent transport solution for a city center.",
                            EngineType = "Electric",
                            ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fbg.e-scooter.co%2Fi%2F17%2F72%2Fed%2Fd5015b9723a5397c924e7b797d.jpg&imgrefurl=https%3A%2F%2Fbg.e-scooter.co%2Fpiaggio-one-active%2F&tbnid=yaQ2lq0vl1LETM&vet=12ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygZegUIARCZAg..i&docid=LeZmqaBlOwjRIM&w=474&h=415&q=Piaggio&ved=2ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygZegUIARCZAg",
                            IsForCleaning = false,
                            IsForRepearing = false,
                            IsNeedDayExchangeVehicleCard = false,
                            IsNeedHelmet = false,
                            PricePerHour = 11.00m,
                            Rating = 5,
                            RenterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            Type = "Piaggo",
                            VehicleParkId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "A realy good transport solution for a city center.",
                            EngineType = "Petrol",
                            ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fimages.piaggio.com%2Fpiaggio%2Fvehicles%2Fnclp000u15%2Fnclp8znu15%2Fnclp8znu15-01-s.png&imgrefurl=https%3A%2F%2Fwww.piaggio.com%2Fbg_BG%2Fmodels%2Fliberty%2Fliberty-50-4s3v-2021%2F&tbnid=dIb-qyhP2vh5mM&vet=12ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygFegUIARDsAQ..i&docid=un13zXQdXG3kwM&w=750&h=500&q=Piaggio&ved=2ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygFegUIARDsAQ",
                            IsForCleaning = false,
                            IsForRepearing = false,
                            IsNeedDayExchangeVehicleCard = false,
                            IsNeedHelmet = false,
                            PricePerHour = 10.00m,
                            Rating = 5,
                            RenterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            Type = "Piaggo",
                            VehicleParkId = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "A very good transport solution for a city center.",
                            EngineType = "Petrol",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT4TbIp4RJgECS2py-M_zNjwLrXYIbcZ07XQA&usqp=CAU",
                            IsForCleaning = false,
                            IsForRepearing = false,
                            IsNeedDayExchangeVehicleCard = false,
                            IsNeedHelmet = false,
                            PricePerHour = 9.00m,
                            Rating = 6,
                            RenterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            Type = "Vespa",
                            VehicleParkId = 1
                        });
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsForCleaning")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForRepearing")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNeedDayBlueCard")
                        .HasColumnType("bit");

                    b.Property<decimal>("PricePerHour")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("RenterId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VehicleParkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("VehicleParkId");

                    b.ToTable("Trucks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 3,
                            Description = "A very good transport solution for a big cargos.",
                            EngineType = "Diesel",
                            ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.nacaratotruckcenters.com%2Ffckimages%2Fvolvo-trucks%2Fvnl-series%2Fvo-vnl300-16-0003.jpg&imgrefurl=https%3A%2F%2Fwww.nacaratotruckcenters.com%2Fshop-nacarato-for-volvo--vnl-series&tbnid=VoeQjE1FuBwyUM&vet=12ahUKEwiS_oq2zIX8AhWEr6QKHX4kBMYQMygcegUIARChAg..i&docid=nempaaU2cirinM&w=725&h=410&q=Volvo%20truck&ved=2ahUKEwiS_oq2zIX8AhWEr6QKHX4kBMYQMygcegUIARChAg",
                            IsForCleaning = false,
                            IsForRepearing = false,
                            IsNeedDayBlueCard = false,
                            PricePerHour = 35.00m,
                            Rating = 4,
                            Type = "Volvo",
                            VehicleParkId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            Description = "Excelent transport solution for a big cargos.",
                            EngineType = "Diesel",
                            ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.mercedes-benz-trucks.com%2Fcontent%2Fdam%2Fmbo%2Fmarkets%2Fhq_HQ%2Fmodel-navigation-images%2Fproven%2Fmodelthumb-actros-slt.png&imgrefurl=https%3A%2F%2Fwww.mercedes-benz-trucks.com%2Fbg_BG%2Fhome.html&tbnid=YOUxhC-ziZz2TM&vet=12ahUKEwjWytWjzIX8AhWHjaQKHbkxC8gQMygEegUIARDnAQ..i&docid=Tb7v0QbAqHgN1M&w=450&h=341&q=mercedes%20truck&ved=2ahUKEwjWytWjzIX8AhWHjaQKHbkxC8gQMygEegUIARDnAQ",
                            IsForCleaning = false,
                            IsForRepearing = false,
                            IsNeedDayBlueCard = false,
                            PricePerHour = 50.00m,
                            Rating = 6,
                            Type = "Mercedes",
                            VehicleParkId = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "A realy good transport solution for a big cargos.",
                            EngineType = "Diesel",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQb4pdFmd8vMzEsFxaFaonBFAQhs3EA2P9r_Q&usqp=CAU",
                            IsForCleaning = false,
                            IsForRepearing = false,
                            IsNeedDayBlueCard = false,
                            PricePerHour = 40.00m,
                            Rating = 5,
                            Type = "Scania",
                            VehicleParkId = 1
                        });
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.VehiclePark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ParkName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("VehicleParks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ParkName = "Central"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Bike", b =>
                {
                    b.HasOne("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Category", "Category")
                        .WithMany("Bikes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MunicipalityMobilitySystem.Infrasructure.Data.Entities.VehiclePark", "VehiclePark")
                        .WithMany("Bikes")
                        .HasForeignKey("VehicleParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("VehiclePark");
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Car", b =>
                {
                    b.HasOne("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Category", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MunicipalityMobilitySystem.Infrasructure.Data.Entities.VehiclePark", "VehiclePark")
                        .WithMany("Cars")
                        .HasForeignKey("VehicleParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("VehiclePark");
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Scooter", b =>
                {
                    b.HasOne("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Category", "Category")
                        .WithMany("Scooters")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MunicipalityMobilitySystem.Infrasructure.Data.Entities.VehiclePark", "VehiclePark")
                        .WithMany("Scooters")
                        .HasForeignKey("VehicleParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("VehiclePark");
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Truck", b =>
                {
                    b.HasOne("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Category", "Category")
                        .WithMany("Trucks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MunicipalityMobilitySystem.Infrasructure.Data.Entities.VehiclePark", "VehiclePark")
                        .WithMany("Trucks")
                        .HasForeignKey("VehicleParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("VehiclePark");
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Category", b =>
                {
                    b.Navigation("Bikes");

                    b.Navigation("Cars");

                    b.Navigation("Scooters");

                    b.Navigation("Trucks");
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.VehiclePark", b =>
                {
                    b.Navigation("Bikes");

                    b.Navigation("Cars");

                    b.Navigation("Scooters");

                    b.Navigation("Trucks");
                });
#pragma warning restore 612, 618
        }
    }
}
