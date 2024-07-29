
using LibraryModel.Bogus;
using LibraryModel.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LibraryModel.Context
{
    public class LibraryDbContext : IdentityDbContext<LibraryUser>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserCheckout> UserCheckouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            FakeData.Init(100);

            modelBuilder.Entity<Book>(entity =>
            {

                entity.HasData(FakeData.Books);

                entity.HasKey(k => k.BookId);
                entity.Property(p => p.Title).IsRequired().HasMaxLength(500);
                entity.Property(p => p.Author).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Description).IsRequired().HasMaxLength(500);
                entity.Property(p => p.CoverImage).IsRequired();
                entity.Property(p => p.Publisher).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Isbn).IsRequired().HasMaxLength(25);
                entity.Property(p => p.PageCount).IsRequired();
                entity.Property(p => p.Locked).IsRequired();
                entity.Property(p => p.TotalStock).IsRequired();
                entity.Property(p => p.CurrentStock).IsRequired();
                entity.HasMany(p => p.Reviews)
                    .WithOne(p => p.Book);

            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(k => k.ReviewId);
                entity.Property(p => p.BookId).IsRequired();
                entity.Property(p => p.ReviewText).IsRequired().HasMaxLength(500);
                entity.Property(p => p.LibraryUserId).IsRequired();
                entity.HasOne(p => p.Book);
                entity.HasOne(p => p.LibraryUser);

            });

            modelBuilder.Entity<UserCheckout>(entity =>
            {
                entity.HasKey(k => k.UserCheckoutId);
                entity.Property(p => p.BookId).IsRequired();
                entity.Property(p => p.DateCheckedOut).IsRequired().HasMaxLength(500);
                entity.Property(p => p.LibraryUserId).IsRequired();
                entity.HasOne(p => p.Book);
                entity.HasOne(p => p.LibraryUser);
            });

        }

    }
}
