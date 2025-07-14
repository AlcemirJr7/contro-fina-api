using ControlFina.Core.Abstractions;

namespace ControlFina.Core.Features.Categories.Entities;

public sealed class Category
{
    public Guid Id { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public Category(string description)
    {
        Id = Guid.NewGuid();
        Description = description;
        IsActive = true;
        CreatedAt = DateTimeBr.Now;
        UpdatedAt = DateTimeBr.Now;
    }

    public void Update(string description, bool isActive)
    {
        Description = description;
        IsActive = isActive;
        UpdatedAt = DateTimeBr.Now;
    }
}
