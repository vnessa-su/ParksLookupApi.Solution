using Microsoft.EntityFrameworkCore;

namespace ParksLookupApi.Models
{
  public class ParksLookupApiContext : DbContext
  {
    public ParksLookupApiContext(DbContextOptions<ParksLookupApiContext> options) : base(options) { }

    public DbSet<Park> Parks { get; set; }
    public DbSet<Category> Categories { get; set; }
  }
}