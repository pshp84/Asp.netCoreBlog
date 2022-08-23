using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlogSample.Data.Validation;
using Microsoft.AspNetCore.Identity;

namespace BlogSample.Data;

public class EFUnitOfWork : IdentityDbContext<User, AspNetRole, string, IdentityUserClaim<string>, AspNetUserRole,
        IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    public EFUnitOfWork(DbContextOptions<EFUnitOfWork> options)
        : base(options)
    {
    }

    public DbSet<BlogEntry> BlogEntries { get; set; } = null!;

    public DbSet<BlogEntryComment> BlogEntryComments { get; set; } = null!;

    public DbSet<BlogEntryFile> BlogEntryFiles { get; set; } = null!;

    public DbSet<Image> Images { get; set; } = null!;

    public DbSet<Tag> Tags { get; set; } = null!;

    public DbSet<BlogEntryTag> BlogEntryTags { get; set; } = null!;

    public override int SaveChanges()
    {
        this.ValidateEntitíes();

        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        this.ValidateEntitíes();

        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        this.ValidateEntitíes();

        return base.SaveChangesAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        this.ValidateEntitíes();

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Cascade;
        }

        modelBuilder.Entity<BlogEntryTag>()
            .HasKey(m => new { m.BlogEntryId, m.TagId });

        modelBuilder.Entity<BlogEntry>()
            .HasIndex(m => new { m.Permalink })
            .IsUnique(true);

        modelBuilder.Entity<Tag>()
            .HasIndex(m => new { m.Name })
            .IsUnique(true);

        modelBuilder.Entity<AspNetRole>().HasData(new AspNetRole
        {
            Id = AuthRoles.Administrator,
            Name = AuthRoles.Administrator,
            NormalizedName = AuthRoles.Administrator.ToUpper(),
            ConcurrencyStamp = "292b0f61-4649-4fa2-986f-d369442a9236"
        });
        modelBuilder.Entity<AspNetRole>().HasData(new AspNetRole
        {
            Id = AuthRoles.User,
            Name = AuthRoles.User,
            NormalizedName = AuthRoles.User.ToUpper(),
            ConcurrencyStamp = "292b0f61-4649-4fa2-986f-d369442a9237"
        });

        modelBuilder.Entity<User>().HasData(new User("Admin", "User")
        {
            Id = "00000000-0000-0000-0000-000000000001",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            ConcurrencyStamp = "00000000-0000-0000-0000-000000000001",
            EmailConfirmed = true,
            SecurityStamp = "00000000-0000-0000-0000-000000000001",
            UserName = "admin@admin.com",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            PasswordHash = "AQAAAAEAACcQAAAAEJBNhQ6ShUsmfqT2WHQ+TkQBRNgeJj9nl9L6u+M295KLJ6odLEgbCaQE+FKSgnV93g==" //Test105*
        });

        modelBuilder.Entity<AspNetUserRole>().HasData(new AspNetUserRole
        {
            RoleId = AuthRoles.Administrator,
            UserId = "00000000-0000-0000-0000-000000000001"
        });

        base.OnModelCreating(modelBuilder);
    }

    private void ValidateEntitíes()
    {
        var addedOrModifiedEntities = this.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        var errors = new List<EntityValidationResult>();
        var validationResults = new List<ValidationResult>();
        foreach (var entity in addedOrModifiedEntities)
        {
            if (!Validator.TryValidateObject(entity.Entity, new ValidationContext(entity.Entity), validationResults))
            {
                errors.Add(new EntityValidationResult(entity.Entity, validationResults));
                validationResults = new List<ValidationResult>();
            }
        }

        if (errors.Count > 0)
        {
            throw new Validation.ValidationException(errors);
        }
    }
}