using DSRNetSchool.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRNetSchool.Context
{
    public class MainDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorDetail> AuthorDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().ToTable("authors");
            modelBuilder.Entity<Author>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Author>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<Author>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<AuthorDetail>().ToTable("author_details");
            modelBuilder.Entity<AuthorDetail>().HasOne(x => x.Author).WithOne(x => x.Detail).HasPrincipalKey<AuthorDetail>(x => x.Id);

            modelBuilder.Entity<Book>().ToTable("books");
            modelBuilder.Entity<Book>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<Book>().Property(x => x.Title).HasMaxLength(250);
            modelBuilder.Entity<Book>().HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<Category>().Property(x => x.Title).HasMaxLength(100);
            modelBuilder.Entity<Category>().HasMany(x => x.Books).WithMany(x => x.Categories).UsingEntity(t => t.ToTable("books_categories"));

        }
    }
}
