namespace Schola.Infrastructure.EF.Models;

internal class DivisionReadModel
{
    public long Id { get; set; }

    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = default!;

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public ICollection<SectionReadModel> Sections { get; set; } = new List<SectionReadModel>();
}