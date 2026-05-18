namespace Schola.Infrastructure.EF.Models;

internal class ExamReadModel : BaseModel
{
    public string? Name { get; set; }

    public long? AcademicYearId { get; set; }
    public AcademicYearReadModel? AcademicYear { get; set; }

    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }

    public ICollection<ExamMarkReadModel> ExamMarks { get; set; } = new List<ExamMarkReadModel>();
}


internal class ExamMarkReadModel : BaseModel
{
    public long ExamId { get; set; }
    public ExamReadModel Exam { get; set; } = default!;

    public long StudentId { get; set; }
    public StudentReadModel Student { get; set; } = default!;

    public long SubjectId { get; set; }
    public SubjectReadModel Subject { get; set; } = default!;

    public decimal Marks { get; set; }
    public decimal FullMarks { get; set; }
    public string? Grade { get; set; }
}