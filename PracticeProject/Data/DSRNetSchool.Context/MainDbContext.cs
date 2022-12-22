using DSRNetSchool.Context.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DSRNetSchool.Context
{
    public class MainDbContext : IdentityDbContext<User, UserRole, Guid>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorDetail> AuthorDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<UserRole>().ToTable("user_roles");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("user_role_owners");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("user_role_claims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");

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
