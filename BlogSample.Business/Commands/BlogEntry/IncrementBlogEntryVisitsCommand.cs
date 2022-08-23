namespace BlogSample.Business.Commands;

public class IncrementBlogEntryVisitsCommand
{
    public IncrementBlogEntryVisitsCommand(Guid id)
    {
        this.Id = id;
    }

    public Guid Id { get; set; }
}