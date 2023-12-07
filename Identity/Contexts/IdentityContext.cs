using Core.Configuration.Settings;
using Identity.Domain.Business;
using Methodic.Core.Configuration.Settings;
using Microsoft.EntityFrameworkCore;

namespace Identity.Contexts;

public class IdentityContext : Methodic.Identity.Contexts.IdentityContext<AppUser, AppRole, Domain.Business.UserRole>
{
	private readonly IdentitySettings _identitySettings;

	public IdentityContext(AppSettings appSettings)
	{
		_identitySettings = appSettings.GetSection<IdentitySettings>();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		//call it after base method call, to override settings for UserRole
		ConfigureUserRole(modelBuilder);
		ConfigureUser(modelBuilder);
		modelBuilder.Model.SetMaxIdentifierLength(30);
	}

	protected void ConfigureUserRole(ModelBuilder builder)
	{
		builder.Entity<UserRole>(x =>
		{
			x.HasKey(y => new { y.UserId, y.RoleId });

			x.HasOne(x => x.Role)
				.WithMany(x => x.UserRoles)
				.HasForeignKey(x => x.RoleId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			x.HasOne(x => x.User)
				.WithMany(x => x.UserRoles)
				.HasForeignKey(x => x.UserId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);
		});
	}

	protected void ConfigureUser(ModelBuilder builder)
	{
		builder.Entity<AppUser>(x =>
		{
			x.Property(y => y.PhoneNumber).IsRequired();
		});
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite(string.Format(
			@"Data Source={0}\Configuration\Data\store.db",
			Directory.GetCurrentDirectory()
		), opts =>
		{
			opts.CommandTimeout(3600);//todo - add in DataConfig
		});
		base.OnConfiguring(optionsBuilder);
	}
}