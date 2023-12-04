using Core.Configuration.Settings;
using Identity.Domain.Business;
using Methodic.Core.Configuration.Settings;
using Methodic.Identity.Domain.Business;
using Microsoft.EntityFrameworkCore;

namespace Identity.Contexts;

public class IdentityContext : Methodic.Identity.Contexts.IdentityContext<AppUser, AppRole, Domain.Business.UserRole>
{
	private readonly IdentitySettings _identitySettings;
	private bool _useOracle = true;

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
		if(_useOracle)
		{
			modelBuilder.Entity<UserNotificationSubscription>().ToTable("ASPNETUSERNOTIFICATIONSUBS");
			SetCapsNames(modelBuilder);
		}		
		modelBuilder.Model.SetMaxIdentifierLength(30);
		// builder.SetCapsTableNameConvention();
	}

	private void SetCapsNames(ModelBuilder modelBuilder)
	{
		foreach (var entity in modelBuilder.Model.GetEntityTypes())
		{
			entity.SetTableName(entity.GetTableName().ToUpper());
			foreach (var property in entity.GetProperties())
			{
				property.SetColumnName(property.GetColumnName().ToUpper());
			}
		}
	}

	protected void ConfigureUserRole(ModelBuilder builder)
	{
		builder.Entity<Domain.Business.UserRole>(x =>
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
		if(_useOracle)
		{
			optionsBuilder.UseSqlite("/todo", opts =>
			{
				opts.CommandTimeout(3600);
			});
		}
		else
		{
			optionsBuilder.UseSqlServer(_identitySettings.Database.ConnectionString, opts =>
			{
				opts.CommandTimeout(3600);
			});
		}
		base.OnConfiguring(optionsBuilder);
	}
}