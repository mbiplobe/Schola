using Schola.Shared.Abstractions.Domains;

public sealed class GuardianEntity : AggregateRoot<long>
{
    public long ProfileId { get; private set; }

    public string? Occupation { get; private set; }
    public decimal? MonthlyIncome { get; private set; }

    public bool IsActive { get; private set; }


    public DateTime? CreatedDate { get; private set; }
    public string? CreatedBy { get; private set; }
    public DateTime? UpdatedDate { get; private set; }
    public string? UpdatedBy { get; private set; }

    private GuardianEntity()
    {
    }

    public GuardianEntity(
        long profileId,
        string? occupation,
        decimal? monthlyIncome,
        string createdBy)
    {
        ProfileId = profileId;
        Occupation = occupation;
        MonthlyIncome = monthlyIncome;

        IsActive = true;

        CreatedBy = createdBy;
        CreatedDate = DateTime.UtcNow;
    }

    public void Update(
        string? occupation,
        decimal? monthlyIncome,
        string updatedBy)
    {
        Occupation = occupation;
        MonthlyIncome = monthlyIncome;

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
}