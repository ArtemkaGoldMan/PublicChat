using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ServerLibrary.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the relationship
            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)            // Message has one User
                .WithMany(u => u.Messages)     // User has many Messages
                .HasForeignKey(m => m.UserId); // Foreign key in Message
        }
    }
}
