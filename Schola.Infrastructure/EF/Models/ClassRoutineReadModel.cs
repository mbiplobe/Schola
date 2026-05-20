namespace Schola.Infrastructure.EF.Models;

internal class ClassRoutineReadModel : BaseModel
{

    public long ClassId { get; set; }
    public ClassReadModel Class { get; set; } = default!;

    public long SectionId { get; set; }
    public SectionReadModel Section { get; set; } = default!;

    public long SubjectId { get; set; }
    public SubjectReadModel Subject { get; set; } = default!;

    public long DivisionId { get; set; }
    public DivisionReadModel Division { get; set; } = default!;

    public long TeacherId { get; set; }
    public TeacherReadModel Teacher { get; set; } = default!;

    public string? DayOfWeek { get; set; }

    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }
}