namespace Schola.Infrastructure.EF.Models;

internal class BaseModel
{
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = default!;
    public DateTime? UpdatedDate { get; set; }
    public string? UpdatedBy { get; set; }
}
