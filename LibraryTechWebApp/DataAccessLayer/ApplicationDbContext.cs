using LibraryTechWebApp.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.DataAccessLayer
{
    public class ApplicationDbContext : IdentityDbContext<AppUserModel>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> Categories { get; set; }
        public DbSet<BookSeries> Series { get; set; }
        public DbSet<BookAuthor> Authors { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUserModel>()
                    .HasMany(u => u.Books)
                    .WithMany(b => b.User)
                    .UsingEntity(j => j.ToTable("BookUser"));


            modelBuilder.Entity<AppUserModel>()
                    .HasMany(u => u.ReadRecentlyBySubs)
                    .WithMany(b => b.UserHowRecentlyReadBySubs)
                    .UsingEntity<BookUserBySubs>(
                   j => j
                    .HasOne(pt => pt.Book)
                    .WithMany(t => t.BookUserBySubs)
                    .HasForeignKey(pt => pt.BookId),
                j => j
                    .HasOne(pt => pt.User)
                    .WithMany(p => p.BookUserBySubs)
                    .HasForeignKey(pt => pt.UserId),
                j =>
                {
                    j.Property(pt => pt.DateLastRead).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.HasKey(t => new { t.BookId, t.UserId });
                    j.ToTable("BookUserBySubs");
                });
        }
    }
}
