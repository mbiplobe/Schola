namespace Schola.Infrastructure.EF.Models;

internal class ClassReadModel 
{
    public long Id { get; set; }
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;


    // public ICollection<SectionReadModel> Sections { get; set; } = new List<SectionReadModel>();

    // public ICollection<StudentReadModel> Students { get; set; } = new List<StudentReadModel>();

    // public ICollection<SubjectReadModel> Subjects { get; set; } = new List<SubjectReadModel>();

}