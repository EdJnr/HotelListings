using Microsoft.EntityFrameworkCore;

namespace HotelListings.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder _modelBuilder)
        {
            _modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Ghana",
                    ShortName = "gh",
                },new Country
                {
                    Id = 2,
                    Name = "Nigeria",
                    ShortName = "ng",
                },new Country
                {
                    Id = 3,
                    Name = "Togo",
                    ShortName = "tg",
                }
            );

            _modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "La Palm Royal Beach",
                    Address = "La",
                    CountryId = 1,
                    Rating = 4
                },new Hotel
                {
                    Id = 2,
                    Name = "Naija Classic",
                    Address = "Lagos",
                    CountryId = 2,
                    Rating = 3.5
                },new Hotel
                {
                    Id = 3,
                    Name = "Sleeping Hippo",
                    Address = "Kokomlemle",
                    CountryId = 1,
                    Rating = 3.2
                }
            );
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
    }
}
