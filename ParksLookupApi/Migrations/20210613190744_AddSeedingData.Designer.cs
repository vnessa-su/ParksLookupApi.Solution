// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParksLookupApi.Models;

namespace ParksLookupApi.Migrations
{
    [DbContext(typeof(ParksLookupApiContext))]
    [Migration("20210613190744_AddSeedingData")]
    partial class AddSeedingData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ParksLookupApi.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Description = "Parks meant to preserve, unimpaired, natural and cultural resources for enjoyment, education, and inspiration of this and future generations.",
                            Name = "National Park"
                        },
                        new
                        {
                            CategoryId = 2,
                            Description = "Parks meant to sustain the health, diversity, and productivity of the Nation’s forests and grasslands to meet the needs of many purposes — timber, recreation, grazing, wildlife, fish and more.",
                            Name = "National Forest"
                        },
                        new
                        {
                            CategoryId = 3,
                            Description = "Park meant to preserve enhanced recreational opportunities in places with significant natural and scenic resources.",
                            Name = "National Recreation Area"
                        },
                        new
                        {
                            CategoryId = 4,
                            Description = "Parks established by a state to preserve a location on account of its natural beauty, historic interest, or recreational potential.",
                            Name = "State Park"
                        },
                        new
                        {
                            CategoryId = 5,
                            Description = "Parks in cities and other incorporated places to offer recreation and green space to residents of, and visitors to, the municipality.",
                            Name = "Urban Park"
                        });
                });

            modelBuilder.Entity("ParksLookupApi.Models.Park", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("State")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ParkId");

                    b.ToTable("Parks");

                    b.HasData(
                        new
                        {
                            ParkId = 1,
                            Address = "9035 Village Drive",
                            CategoryId = 1,
                            City = "Yosemite Valley",
                            Latitude = 37.7481m,
                            Longitude = -119.585043m,
                            Name = "Yosemite National Park",
                            State = "CA"
                        },
                        new
                        {
                            ParkId = 2,
                            Address = "191W Atlantic Ave",
                            CategoryId = 3,
                            City = "Boston",
                            Latitude = 42.3601m,
                            Longitude = -71.052016m,
                            Name = "Boston Harbor Islands",
                            State = "MA"
                        },
                        new
                        {
                            ParkId = 3,
                            Address = "71 White Mountain Drive",
                            CategoryId = 2,
                            City = "Campton",
                            Latitude = 43.813494m,
                            Longitude = -71.670031m,
                            Name = "White Mountain National Forest",
                            State = "NH"
                        },
                        new
                        {
                            ParkId = 4,
                            Address = "39000 State Route 706 E",
                            CategoryId = 1,
                            City = "Ashford",
                            Latitude = 46.740971951204436m,
                            Longitude = -121.9183777100494m,
                            Name = "Mount Rainier National Park",
                            State = "WA"
                        },
                        new
                        {
                            ParkId = 5,
                            Address = "Cape Arago State Park",
                            CategoryId = 4,
                            City = "Coos Bay",
                            Latitude = 43.30631746486028m,
                            Longitude = -124.39905271425728m,
                            Name = "Cape Arago State Park",
                            State = "OR"
                        },
                        new
                        {
                            ParkId = 6,
                            Address = "1320 Monroe Dr NE",
                            CategoryId = 5,
                            City = "Atlanta",
                            Latitude = 33.788359813469214m,
                            Longitude = -84.37293713315903m,
                            Name = "Piedmont Park",
                            State = "GA"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
