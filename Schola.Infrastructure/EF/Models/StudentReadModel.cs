namespace Schola.Infrastructure.EF.Models;

internal class StudentReadModel : BaseModel
{
    public long Id { get; set; }

    public Guid? UserId { get; set; }
    public string StudentCode { get; set; } = null!;

    public long ClassId { get; set; }
    public long SectionId { get; set; }
    public long DivisionId { get; set; }

    public int? RollNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public long GenderId { get; set; }
    public DateTime? AdmissionDate { get; set; }
    public long? BloodGroupId { get; set; }

    public UserReadModel? User { get; set; }

    public ICollection<StudentGuardianMapReadModel> StudentGuardians { get; set; }
        = new List<StudentGuardianMapReadModel>();
}

internal class GuardianReadModel : BaseModel
{
    public long Id { get; set; }

    public string GuardianName { get; set; } = null!;
    public string? GuardianPhone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }

    public ICollection<StudentGuardianMapReadModel> StudentGuardians { get; set; }
        = new List<StudentGuardianMapReadModel>();
}

internal class GuardianRelationshipReadModel : BaseModel
{
    public long Id { get; set; }

    public string RelationshipName { get; set; } = null!;
    public bool IsActive { get; set; } = true;

    public ICollection<StudentGuardianMapReadModel> StudentGuardians { get; set; }
        = new List<StudentGuardianMapReadModel>();
}

internal class StudentGuardianMapReadModel : BaseModel
{
    public long Id { get; set; }

    public long StudentId { get; set; }
    public long GuardianId { get; set; }
    public long RelationshipId { get; set; }

    public bool IsPrimary { get; set; }

    public StudentReadModel Student { get; set; } = null!;
    public GuardianReadModel Guardian { get; set; } = null!;
    public GuardianRelationshipReadModel Relationship { get; set; } = null!;
}