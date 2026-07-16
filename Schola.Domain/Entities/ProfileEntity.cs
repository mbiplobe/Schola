using Schola.Shared.Abstractions.Domains;

public sealed class ProfileEntity : AggregateRoot<long>
{
    public string FirstName { get; private set; }
    public string? MiddleName { get; private set; }
    public string LastName { get; private set; }

    public int? GenderId { get; private set; }

    public string? Nid { get; private set; }
    public string? BirthRegNo { get; private set; }
    public DateTime? DateOfBirth { get; private set; }

    public string? Mobile { get; private set; }
    public string? Email { get; private set; }

    public string? PhotoUrl { get; private set; }

    public bool IsActive { get; private set; }


    public DateTime? CreatedDate { get; private set; }
    public string? CreatedBy { get; private set; }
    public DateTime? UpdatedDate { get; private set; }
    public string? UpdatedBy { get; private set; }

    private ProfileEntity()
    {
    }

    public ProfileEntity(
        string firstName,
        string? middleName,
        string lastName,
        int? genderId,
        string? nid,
        string? birthRegNo,
        DateTime? dateOfBirth,
        string? mobile,
        string? email,
        string? photoUrl,
        string createdBy)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;

        GenderId = genderId;

        Nid = nid;
        BirthRegNo = birthRegNo;
        DateOfBirth = dateOfBirth;

        Mobile = mobile;
        Email = email;

        PhotoUrl = photoUrl;

        IsActive = true;

        CreatedBy = createdBy;
        CreatedDate = DateTime.UtcNow;
    }

    public void Update(
        string firstName,
        string? middleName,
        string lastName,
        int? genderId,
        string? nid,
        string? birthRegNo,
        DateTime? dateOfBirth,
        string? mobile,
        string? email,
        string? photoUrl,
        string updatedBy)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;

        GenderId = genderId;

        Nid = nid;
        BirthRegNo = birthRegNo;
        DateOfBirth = dateOfBirth;

        Mobile = mobile;
        Email = email;

        PhotoUrl = photoUrl;

        UpdatedBy = updatedBy;
        UpdatedDate = DateTime.UtcNow;
    }

    public void Activate(string updatedBy)
    {
        IsActive = true;
        UpdatedBy = updatedBy;
        UpdatedDate = DateTime.UtcNow;
    }

    public void Deactivate(string updatedBy)
    {
        IsActive = false;
        UpdatedBy = updatedBy;
        UpdatedDate = DateTime.UtcNow;
    }

    public string FullName =>
        string.Join(" ",
            new[] { FirstName, MiddleName, LastName }
            .Where(x => !string.IsNullOrWhiteSpace(x)));
}