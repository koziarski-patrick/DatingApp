using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext // The DbContext class is the class that will be used to access the database.
    {
        public DataContext(DbContextOptions options) : base(options) // Constructor that will be used to inject the DbContextOptions.
        {
        }

        public DbSet<AppUser> Users { get; set; } // DbSet is a collection of entities that we can query from our database
        // public DbSet<User> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Response> Responses { get; set; }
    }
}