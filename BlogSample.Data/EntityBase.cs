using System.ComponentModel.DataAnnotations;
using BlogSample.Localization;

namespace BlogSample.Data;

public abstract class EntityBase
{
    public EntityBase()
    {
        this.Id = Guid.NewGuid();
        this.CreatedOn = DateTimeOffset.UtcNow;
    }

    [Display(Name = nameof(Resources.Id), ResourceType = typeof(Resources))]
    [Key]
    public Guid Id { get; set; }

    [Display(Name = nameof(Resources.CreatedOn), ResourceType = typeof(Resources))]
    public DateTimeOffset CreatedOn { get; set; }
}