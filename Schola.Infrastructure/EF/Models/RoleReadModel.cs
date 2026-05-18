namespace Schola.Infrastructure.EF.Models;

internal class RoleReadModel : BaseModel
{
    public string Name { get; set; } = default!;
    public ICollection<AssignedRoleReadModel> AssignedRoles { get; set; } = new List<AssignedRoleReadModel>();
}


internal class AssignedRoleReadModel : BaseModel
{
    public long UserId { get; set; }

    public long RoleId { get; set; }
    public UserReadModel User { get; set; } = default!;

    public RoleReadModel Role { get; set; } = default!;
}