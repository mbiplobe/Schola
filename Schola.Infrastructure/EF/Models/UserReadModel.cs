using System.ComponentModel.DataAnnotations.Schema;

namespace Schola.Infrastructure.EF.Models;

internal class UserReadModel 
{
    public Guid ID { get; set; }

    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }

    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public string Password { get; set; } = default!;

    [NotMapped]
    public string FullName =>
       $"{FirstName} {MiddleName} {LastName}"
           .Replace("  ", " ")
           .Trim();
    // public bool IsActive { get; set; }


    // public StudentReadModel? Student { get; set; }
    // public TeacherReadModel? Teacher { get; set; }

    // public ICollection<AssignedRoleReadModel> AssignedRoles { get; set; } = new List<AssignedRoleReadModel>();
    // public ICollection<MapUserAddressReadModel> UserAddresses { get; set; } = new List<MapUserAddressReadModel>();
}

internal class MapUserAddressReadModel
{

    public long UserId { get; set; }
    public long AddressId { get; set; }
    public AddressReadModel? Address { get; set; }

    public UserReadModel? User { get; set; }
}

internal class AddressReadModel : BaseModel
{
    public long AddressTypeId { get; set; }

    public string AddressLine1 { get; set; } = default!;
    public string? AddressLine2 { get; set; } = default!;
    public string City { get; set; } = default!;
    public string? PostalCode { get; set; } = default!;

    public string? District { get; set; } = default!;
    public string? StateDivision { get; set; } = default!;

    public string? Area { get; set; } = default!;

    public bool? IsDefault { get; set; }

    public AddressTypeReadModel? UserAddressType { get; set; }


    public ICollection<MapUserAddressReadModel> UserAddresses { get; set; }
        = new List<MapUserAddressReadModel>();
}

internal class AddressTypeReadModel : BaseModel
{
    public string AddressType { get; set; } = default!;

    public ICollection<AddressReadModel> Addresses { get; set; }
     = new List<AddressReadModel>();

}