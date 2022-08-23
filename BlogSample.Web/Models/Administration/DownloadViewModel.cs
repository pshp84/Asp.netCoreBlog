using BlogSample.Data;
using BlogSample.Web.Infrastructure.Paging;

namespace BlogSample.Web.Models.Administration;

public class DownloadViewModel
{
    public string? SearchTerm { get; set; }

    public PagedResult<BlogEntry>? BlogEntries { get; set; }
}
