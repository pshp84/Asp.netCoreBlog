using BlogSample.Data;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Microsoft.Extensions.Configuration;

var client = new RestClient("https://sq1-api-test.herokuapp.com");
var request = new RestRequest("posts");
var response = await client.GetAsync<PostDataMain>(request);
if (response != null && response.Data != null)
{
    var adminUserId = "00000000-0000-0000-0000-000000000001";
    var configuration = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile($"appsettings.json");
    var config = configuration.Build();
    var connectionString = config.GetConnectionString("EFUnitOfWork");
    var builder = new DbContextOptionsBuilder<EFUnitOfWork>();
    builder.UseSqlServer(connectionString);
    using var context = new EFUnitOfWork(builder.Options);
    context!.Database.Migrate();

    foreach (var item in response.Data)
    {
        var id = Guid.NewGuid();
        await context.BlogEntries.AddAsync(new BlogEntry
        {
            AuthorId = adminUserId,
            Content = item.Description,
            ShortContent = (item.Description?.Length > 50 ? item.Description?.Substring(0, 50) + "..." : item?.Description) ?? string.Empty,
            Header = item?.Title ?? string.Empty,
            PublishDate = Convert.ToDateTime(item?.Publication_Date ?? DateTime.UtcNow.ToString()),
            Visible = true,
            Permalink = id.ToString().Substring(0, 8),
            Id = id
        });
    }
    await context.SaveChangesAsync();
}

public class PostData
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Publication_Date { get; set; }
}

public class PostDataMain
{
    public List<PostData>? Data { get; set; }
}

