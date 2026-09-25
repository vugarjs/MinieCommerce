using MinieCommerce.Core.Entities.Common;
using MinieCommerce.Core.Enums.Roles;

namespace MinieCommerce.Core.Entities;

internal class User : AuditAble
{
    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public UserRole Role { get; set; } 

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}


