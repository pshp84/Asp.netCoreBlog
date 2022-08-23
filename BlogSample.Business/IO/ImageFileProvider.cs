using Microsoft.Extensions.Hosting;

namespace BlogSample.Business.IO;

public class ImageFileProvider : FileProviderBase, IImageFileProvider
{
    private const string ImagesBaseDirectory = "wwwroot/blogimages";

    public ImageFileProvider(IHostEnvironment hostEnvironment)
        : base(hostEnvironment, ImagesBaseDirectory)
    {
    }
}