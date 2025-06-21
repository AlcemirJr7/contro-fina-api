namespace ControlFina.Core.Features.Categories.Contracts;

public sealed class CategoryResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
