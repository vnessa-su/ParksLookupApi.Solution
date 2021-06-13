using Microsoft.EntityFrameworkCore;

namespace ParksLookupApi.Models
{
  public class ParksLookupApiContext : DbContext
  {
    public ParksLookupApiContext(DbContextOptions<ParksLookupApiContext> options) : base(options) { }

    public DbSet<Park> Parks { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>().HasData(
        new Park
        {
          ParkId = 1,
          Name = "Yosemite National Park",
          Address = "9035 Village Drive",
          City = "Yosemite Valley",
          State = "CA",
          Latitude = 37.7481M,
          Longitude = -119.585043M,
          CategoryId = 1
        },
        new Park
        {
          ParkId = 2,
          Name = "Boston Harbor Islands",
          Address = "191W Atlantic Ave",
          City = "Boston",
          State = "MA",
          Latitude = 42.3601M,
          Longitude = -71.052016M,
          CategoryId = 3
        },
        new Park
        {
          ParkId = 3,
          Name = "White Mountain National Forest",
          Address = "71 White Mountain Drive",
          City = "Campton",
          State = "NH",
          Latitude = 43.813494M,
          Longitude = -71.670031M,
          CategoryId = 2
        },
        new Park
        {
          ParkId = 4,
          Name = "Mount Rainier National Park",
          Address = "39000 State Route 706 E",
          City = "Ashford",
          State = "WA",
          Latitude = 46.740971951204436M,
          Longitude = -121.9183777100494M,
          CategoryId = 1
        },
        new Park
        {
          ParkId = 5,
          Name = "Cape Arago State Park",
          Address = "Cape Arago State Park",
          City = "Coos Bay",
          State = "OR",
          Latitude = 43.30631746486028M,
          Longitude = -124.39905271425728M,
          CategoryId = 4
        },
        new Park
        {
          ParkId = 6,
          Name = "Piedmont Park",
          Address = "1320 Monroe Dr NE",
          City = "Atlanta",
          State = "GA",
          Latitude = 33.788359813469214M,
          Longitude = -84.37293713315903M,
          CategoryId = 5
        }
      );

      builder.Entity<Category>().HasData(
        new Category
        {
          CategoryId = 1,
          Name = "National Park",
          Description = "Parks meant to preserve, unimpaired, natural and cultural resources for enjoyment, education, and inspiration of this and future generations."
        },
        new Category
        {
          CategoryId = 2,
          Name = "National Forest",
          Description = "Parks meant to sustain the health, diversity, and productivity of the Nation’s forests and grasslands to meet the needs of many purposes — timber, recreation, grazing, wildlife, fish and more."
        },
        new Category
        {
          CategoryId = 3,
          Name = "National Recreation Area",
          Description = "Park meant to preserve enhanced recreational opportunities in places with significant natural and scenic resources."
        },
        new Category
        {
          CategoryId = 4,
          Name = "State Park",
          Description = "Parks established by a state to preserve a location on account of its natural beauty, historic interest, or recreational potential."
        },
        new Category
        {
          CategoryId = 5,
          Name = "Urban Park",
          Description = "Parks in cities and other incorporated places to offer recreation and green space to residents of, and visitors to, the municipality."
        }
      );
    }
  }
}