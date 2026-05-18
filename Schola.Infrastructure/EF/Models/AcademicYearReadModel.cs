namespace Schola.Infrastructure.EF.Models;

internal class AcademicYearReadModel : BaseModel
{
    public string Name { get; set; } = default!;

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool IsActive { get; set; }
    public ICollection<ExamReadModel> Exams { get; set; } = new List<ExamReadModel>();
}