using System.Collections.Generic;

namespace Identity.Domain.Business;

public class AppRole : Methodic.Identity.Domain.Business.Role
{
	public virtual new List<UserRole> UserRoles { get; set; } = new List<UserRole>();
}