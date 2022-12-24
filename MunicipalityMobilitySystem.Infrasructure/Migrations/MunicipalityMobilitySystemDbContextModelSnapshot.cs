﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MunicipalityMobilitySystem.Data;

#nullable disable

namespace MunicipalityMobilitySystem.Infrasructure.Migrations
{
    [DbContext(typeof(MunicipalityMobilitySystemDbContext))]
    partial class MunicipalityMobilitySystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            ConcurrencyStamp = "09cda48e-4aa5-4465-bb2b-549ac9fbedad",
                            Email = "guest@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "guest@mail.com",
                            NormalizedUserName = "guest@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAELwQq7Dq02Ty220q3lWjqw0iq/zX3q/qPurA5h95u1sB8UaZqOi8hVOHBI1P6P1WtA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b4f53236-28a2-49f1-a7fb-4d17fdea43df",
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

                    b.HasKey("Id");

                    b.ToTable("Categorys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bike"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Scooter"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Car"
                        });
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.PartsOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DeliveryTerm")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("PartsOrder");
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VehicleWParkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleWParkId")
                        .IsUnique();

                    b.ToTable("Service");
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Vehicle", b =>
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
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FailureDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ForCleaning")
                        .HasColumnType("bit");

                    b.Property<bool>("ForRepearing")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PricePerHour")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("RenterId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RentsCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RepairingTerm")
                        .HasColumnType("datetime2");

                    b.Property<int>("RepairsCount")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleParkId")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleWashId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("VehicleParkId");

                    b.HasIndex("VehicleWashId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            Description = "Exellent transport solution for a city center.",
                            EngineType = "Electric",
                            ForCleaning = false,
                            ForRepearing = false,
                            ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fbg.e-scooter.co%2Fi%2F17%2F72%2Fed%2Fd5015b9723a5397c924e7b797d.jpg&imgrefurl=https%3A%2F%2Fbg.e-scooter.co%2Fpiaggio-one-active%2F&tbnid=yaQ2lq0vl1LETM&vet=12ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygZegUIARCZAg..i&docid=LeZmqaBlOwjRIM&w=474&h=415&q=Piaggio&ved=2ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygZegUIARCZAg",
                            Model = "Piaggo",
                            PricePerHour = 11.00m,
                            Rating = 5,
                            RenterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            RentsCount = 0,
                            RepairsCount = 0,
                            VehicleParkId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "A realy good transport solution for a city center.",
                            EngineType = "Petrol",
                            ForCleaning = false,
                            ForRepearing = false,
                            ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fimages.piaggio.com%2Fpiaggio%2Fvehicles%2Fnclp000u15%2Fnclp8znu15%2Fnclp8znu15-01-s.png&imgrefurl=https%3A%2F%2Fwww.piaggio.com%2Fbg_BG%2Fmodels%2Fliberty%2Fliberty-50-4s3v-2021%2F&tbnid=dIb-qyhP2vh5mM&vet=12ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygFegUIARDsAQ..i&docid=un13zXQdXG3kwM&w=750&h=500&q=Piaggio&ved=2ahUKEwiGv_ypyIX8AhX9l_0HHZzBBOYQMygFegUIARDsAQ",
                            Model = "Piaggo",
                            PricePerHour = 10.00m,
                            Rating = 5,
                            RenterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            RentsCount = 0,
                            RepairsCount = 0,
                            VehicleParkId = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "A very good transport solution for a city center.",
                            EngineType = "Petrol",
                            ForCleaning = false,
                            ForRepearing = false,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT4TbIp4RJgECS2py-M_zNjwLrXYIbcZ07XQA&usqp=CAU",
                            Model = "Vespa",
                            PricePerHour = 9.00m,
                            Rating = 6,
                            RenterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            RentsCount = 0,
                            RepairsCount = 0,
                            VehicleParkId = 1
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "A very good transport solution for sport people.",
                            ForCleaning = false,
                            ForRepearing = false,
                            ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.home-max.bg%2Fstatic%2Fmedia%2Fups%2Fcached%2F781e8afa44a58ec261abdd83455444f5c203f4c5.jpg&imgrefurl=https%3A%2F%2Fwww.home-max.bg%2Fvelosiped-passati-26-mtb-3700%2F&tbnid=kA6ZVlURPKhh4M&vet=12ahUKEwj8q-zhyYX8AhXlxwIHHRaND0gQMygBegUIARC1AQ..i&docid=CRixMubXhzLYzM&w=640&h=480&q=Passati&ved=2ahUKEwj8q-zhyYX8AhXlxwIHHRaND0gQMygBegUIARC1AQ",
                            Model = "Passati",
                            PricePerHour = 4.00m,
                            Rating = 4,
                            RentsCount = 0,
                            RepairsCount = 0,
                            VehicleParkId = 1
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "A very good luxury transport solution for beasy people.",
                            ForCleaning = false,
                            ForRepearing = false,
                            ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fhips.hearstapps.com%2Fhmg-prod%2Fimages%2Fpinarello-dogma-f-tested-1624463882.jpg&imgrefurl=https%3A%2F%2Fwww.bicycling.com%2Fbikes-gear%2Fa36815265%2Fpinarello-dogma-f-review%2F&tbnid=gkQMZzUwYV_bTM&vet=12ahUKEwjNk57LyYX8AhXdxgIHHYRAAgwQMygBegUIARDdAQ..i&docid=w0vXcmsF9jyIAM&w=7030&h=4912&q=Pinarello&ved=2ahUKEwjNk57LyYX8AhXdxgIHHYRAAgwQMygBegUIARDdAQ",
                            Model = "Pinarello",
                            PricePerHour = 7.00m,
                            Rating = 6,
                            RentsCount = 0,
                            RepairsCount = 0,
                            VehicleParkId = 1
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Description = "A realy good transport solution for sport people.",
                            ForCleaning = false,
                            ForRepearing = false,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuinQIdRNjDVnCddYQFkMkFIkt3cyXVfVqPA&usqp=CAU",
                            Model = "Cross",
                            PricePerHour = 5.00m,
                            Rating = 5,
                            RentsCount = 0,
                            RepairsCount = 0,
                            VehicleParkId = 1
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Description = "A very good and transport solution for a city center.",
                            EngineType = "Electric",
                            ForCleaning = false,
                            ForRepearing = false,
                            ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Ffichasmotor.com%2Fimages%2Fhyundai%2Fhyundai-eon-0-8-56-cv.webp&imgrefurl=https%3A%2F%2Ffichasmotor.com%2Fen%2Fhyundai%2Fhyundai-eon-0-8-56-cv%2F&tbnid=b5rmBwPhiJED7M&vet=12ahUKEwjonf6Hy4X8AhXSQeUKHaRRCAsQMygTegUIARCHAg..i&docid=VCMCK7OUZxeDiM&w=960&h=542&q=Hynday%20EON&ved=2ahUKEwjonf6Hy4X8AhXSQeUKHaRRCAsQMygTegUIARCHAg",
                            Model = "Hynday EON",
                            PricePerHour = 20.00m,
                            Rating = 4,
                            RentsCount = 0,
                            RepairsCount = 0,
                            VehicleParkId = 1
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Description = "A realy good and transport solution for a big family.",
                            EngineType = "Diesel",
                            ForCleaning = false,
                            ForRepearing = false,
                            ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fm.atcdn.co.uk%2Fect%2Fmedia%2Fw1920%2Fbrand-store%2Fvolkswagen%2Ftouran%2Fhero.jpg&imgrefurl=https%3A%2F%2Fwww.autotrader.co.uk%2Fcars%2Fuk%2Fvolkswagen%2Ftouran&tbnid=iBeoqxiXOpMDuM&vet=12ahUKEwjsp8L6y4X8AhV0_rsIHYlCCyMQMygJegUIARDxAQ..i&docid=C8aG3aQ2P98X8M&w=1920&h=980&q=VW%20Touran&ved=2ahUKEwjsp8L6y4X8AhV0_rsIHYlCCyMQMygJegUIARDxAQ",
                            Model = "VW Touran",
                            PricePerHour = 23.00m,
                            Rating = 5,
                            RentsCount = 0,
                            RepairsCount = 0,
                            VehicleParkId = 1
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Description = "A realy good and luxury transport solution.",
                            EngineType = "Petrol",
                            ForCleaning = false,
                            ForRepearing = false,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFiWMRzQZJ4dYjRVlv-l25KWCVweGaWbIJOA&usqp=CAU",
                            Model = "Mercedes CLS 180",
                            PricePerHour = 25.00m,
                            Rating = 6,
                            RentsCount = 0,
                            RepairsCount = 0,
                            VehicleParkId = 1
                        });
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.VehiclePark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleWashId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VehicleParks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "Bulgaria, Sofia City, Iskar Str. 36",
                            Email = "vehicles_for_rent@abv.bg",
                            Name = "Central",
                            Phone = "+359878128344",
                            ServiceId = 0,
                            VehicleWashId = 0
                        });
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.VehicleWash", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VehicleParkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleParkId")
                        .IsUnique();

                    b.ToTable("VehicleWash");
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

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.PartsOrder", b =>
                {
                    b.HasOne("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Vehicle", "Vehicle")
                        .WithMany("OrderedParts")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Service", b =>
                {
                    b.HasOne("MunicipalityMobilitySystem.Infrasructure.Data.Entities.VehiclePark", "VehiclePark")
                        .WithOne("Service")
                        .HasForeignKey("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Service", "VehicleWParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehiclePark");
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Vehicle", b =>
                {
                    b.HasOne("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Category", "Category")
                        .WithMany("Vehicles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Service", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("ServiceId");

                    b.HasOne("MunicipalityMobilitySystem.Infrasructure.Data.Entities.VehiclePark", "VehiclePark")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MunicipalityMobilitySystem.Infrasructure.Data.Entities.VehicleWash", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleWashId");

                    b.Navigation("Category");

                    b.Navigation("VehiclePark");
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.VehicleWash", b =>
                {
                    b.HasOne("MunicipalityMobilitySystem.Infrasructure.Data.Entities.VehiclePark", "VehiclePark")
                        .WithOne("VehicleWash")
                        .HasForeignKey("MunicipalityMobilitySystem.Infrasructure.Data.Entities.VehicleWash", "VehicleParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehiclePark");
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Category", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Service", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.Vehicle", b =>
                {
                    b.Navigation("OrderedParts");
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.VehiclePark", b =>
                {
                    b.Navigation("Service")
                        .IsRequired();

                    b.Navigation("VehicleWash")
                        .IsRequired();

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("MunicipalityMobilitySystem.Infrasructure.Data.Entities.VehicleWash", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
