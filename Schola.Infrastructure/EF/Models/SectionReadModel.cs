namespace Schola.Infrastructure.EF.Models;

internal class SectionReadModel : BaseModel
{
    public string Name { get; set; } = default!;
    public long ClassId { get; set; }
    public ClassReadModel Class { get; set; } = default!;

    public long DivisionId { get; set; }
    public DivisionReadModel Division { get; set; } = default!;

    public ICollection<StudentReadModel> Students { get; set; } = new List<StudentReadModel>();
}