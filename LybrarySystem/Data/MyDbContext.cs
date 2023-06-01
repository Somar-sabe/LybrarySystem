using LybrarySystem.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LybrarySystem.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Librarymodel> Library { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Librarymodel>().HasKey(l => l.Id);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Subcategory)
                .WithMany(s => s.Books)
                .HasForeignKey(b => b.SubcategoryId);
        }
    }
}

