using Microsoft.Extensions.Hosting;

namespace BlogSample.Business.IO;

public class BlogEntryFileFileProvider : FileProviderBase, IBlogEntryFileFileProvider
{
    private const string FilesBaseDirectory = "wwwroot/blogfiles";

    public BlogEntryFileFileProvider(IHostEnvironment hostEnvironment)
        : base(hostEnvironment, FilesBaseDirectory)
    {
    }
}
