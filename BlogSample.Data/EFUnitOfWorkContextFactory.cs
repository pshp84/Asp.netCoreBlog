using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BlogSample.Data;

public class EFUnitOfWorkContextFactory : IDesignTimeDbContextFactory<EFUnitOfWork>
{
    public EFUnitOfWork CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<EFUnitOfWork>();

        builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlogSampleDb;Trusted_Connection=True;MultipleActiveResultSets=true;application name=BlogSampleDb");
        return new EFUnitOfWork(builder.Options);
    }

#pragma warning disable SA1204 // Static elements should appear before instance elements
    public static void Main(string[] args)
#pragma warning restore SA1204 // Static elements should appear before instance elements
    {
    }
}