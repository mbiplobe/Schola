namespace Schola.Infrastructure.EF.Models;

internal class SubjectReadModel
{
    public long Id { get; set; }

    public string Name { get; set; } = default!;
    public string? Code { get; set; }

    public long? ClassId { get; set; }
    public ClassReadModel? Class { get; set; }

    public ICollection<TeacherSubjectReadModel> TeacherSubjects { get; set; } = new List<TeacherSubjectReadModel>();
}


internal class TeacherSubjectReadModel
{
    public long Id { get; set; }

    public long TeacherId { get; set; }
    public TeacherReadModel Teacher { get; set; } = default!;

    public long SubjectId { get; set; }
    public SubjectReadModel Subject { get; set; } = default!;

    public long SectionId { get; set; }
    public SectionReadModel Section { get; set; } = default!;

    public long DivisionId { get; set; }
    public DivisionReadModel Division { get; set; } = default!;

    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = default!;
}