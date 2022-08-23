using BlogSample.Data;

namespace BlogSample.Business.Commands;

public class AddBlogEntryCommentCommand
{
    public AddBlogEntryCommentCommand(
        BlogEntryComment entity)
    {
        this.Entity = entity;
    }

    public BlogEntryComment Entity { get; set; }

    public string? Referer { get; set; }
}