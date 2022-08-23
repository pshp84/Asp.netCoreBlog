using BlogSample.Data;
using BlogSample.Web.Infrastructure.Paging;

namespace BlogSample.Web.Models.Administration;

public class UsersViewModel
{
    public string? SearchTerm { get; set; }

    public PagedResult<User>? Users { get; set; }
}
