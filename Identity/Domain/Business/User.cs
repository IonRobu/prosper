namespace Identity.Domain.Business;

public class AppUser : Methodic.Identity.Domain.Business.User
{
	public string Function { get; set; }

	public bool DarkMode { get; set; }

	public virtual new List<UserRole> UserRoles { get; set; } = new();
}