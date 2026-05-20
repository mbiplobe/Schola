namespace Schola.Infrastructure.EF.Models;

internal class DivisionReadModel : BaseModel
{
    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public ICollection<SectionReadModel> Sections { get; set; } = new List<SectionReadModel>();
}