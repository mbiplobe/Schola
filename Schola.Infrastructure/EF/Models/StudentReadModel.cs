namespace Schola.Infrastructure.EF.Models;

internal class StudentReadModel : BaseModel
{
    public long? UserId { get; set; }
    public UserReadModel? User { get; set; }

    public string StudentCode { get; set; } = default!;

    public long ClassId { get; set; }
    public ClassReadModel Class { get; set; } = default!;

    public long SectionId { get; set; }
    public SectionReadModel Section { get; set; } = default!;

    public long DivisionId { get; set; }
    public DivisionReadModel Division { get; set; } = default!;

    public int? RollNumber { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public long GenderId { get; set; }
    public GenderReadModel Gender { get; set; } = default!;

    public DateOnly? AdmissionDate { get; set; }

    public long? BloodGroupId { get; set; }
    public BloodGroupReadModel? BloodGroup { get; set; }

    public string? GuardianName { get; set; }

    public string? GuardianPhone { get; set; }
}