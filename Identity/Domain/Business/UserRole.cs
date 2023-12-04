namespace Identity.Domain.Business;

public class UserRole : Methodic.Identity.Domain.Business.UserRole
{
	public virtual new AppUser User { get; set; }

	public virtual new AppRole Role { get; set; }
}