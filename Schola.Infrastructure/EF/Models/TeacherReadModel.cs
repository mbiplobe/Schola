namespace Schola.Infrastructure.EF.Models;

internal class TeacherReadModel : BaseModel
{
    public long? UserId { get; set; }
    public UserReadModel? User { get; set; }

    public string? EmployeeId { get; set; }

    public string? Designation { get; set; }

    public DateOnly? JoiningDate { get; set; }

    public decimal? Salary { get; set; }
}