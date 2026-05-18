namespace Schola.Infrastructure.EF.Models;

internal class VehicleReadModel : BaseModel
{
    public string? VehicleNumber { get; set; }
    public string? DriverName { get; set; }
    public string? DriverPhone { get; set; }
}