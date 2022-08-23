using System.ComponentModel.DataAnnotations;
using BlogSample.Data;
using BlogSample.Localization;
using BlogSample.Web.Infrastructure.Paging;

namespace BlogSample.Web.Models.Administration;

public class ImagesViewModel
{
    public string? SearchTerm { get; set; }

    public PagedResult<Image>? Images { get; set; }

    [Required(ErrorMessageResourceName = nameof(Resources.Validation_Required), ErrorMessageResourceType = typeof(Resources))]
    public IFormFile? Image { get; set; }
}
