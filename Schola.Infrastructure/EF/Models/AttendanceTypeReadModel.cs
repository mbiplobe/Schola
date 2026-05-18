namespace Schola.Infrastructure.EF.Models;

internal class AttendanceTypeReadModel : BaseModel
{
    public string TypeName { get; set; } = default!;
}


internal class AttendanceReadModel : BaseModel
{
    public long StudentId { get; set; }
    public StudentReadModel Student { get; set; } = default!;

    public DateOnly AttendanceDate { get; set; }

    public long AttendanceTypeId { get; set; }
    public AttendanceTypeReadModel AttendanceType { get; set; } = default!;
}