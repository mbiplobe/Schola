namespace Schola.Infrastructure.EF.Models;

internal class FeeTypeReadModel : BaseModel
{
    public string Name { get; set; } = default!;
    public decimal Amount { get; set; }
}


internal class PaymentStatusReadModel : BaseModel
{
    public string Status { get; set; } = default!;
}


internal class StudentFeeReadModel : BaseModel
{
    public long StudentId { get; set; }
    public StudentReadModel Student { get; set; } = default!;

    public long FeeTypeId { get; set; }
    public FeeTypeReadModel FeeType { get; set; } = default!;

    public decimal Amount { get; set; }
    public DateOnly? DueDate { get; set; }

    public long PaymentStatusId { get; set; }
    public PaymentStatusReadModel PaymentStatus { get; set; } = default!;
}


internal class PaymentMethodReadModel : BaseModel
{
    public string Method { get; set; } = default!;
}


internal class PaymentReadModel : BaseModel
{
    public long StudentFeeId { get; set; }
    public StudentFeeReadModel StudentFee { get; set; } = default!;

    public decimal PaidAmount { get; set; }

    public long PaymentMethodId { get; set; }
    public PaymentMethodReadModel PaymentMethod { get; set; } = default!;

    public string? TransactionId { get; set; }

    public DateTime PaymentDate { get; set; }
}