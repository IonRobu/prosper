using Methodic.Common.Models.Admin.Enums;
using Methodic.Core.Components.Attributes;
using Methodic.Core.Configuration.Settings;
using System.ComponentModel.DataAnnotations;

namespace Core.Configuration.Settings;

public class IdentitySettings : SectionSettingsBase
{
	[ConfigurationStep(Order = 1)]
	public DatabaseSettings Database { get; set; } = new();

	[ConfigurationStep(Order = 2)]
	public JwtSettings Jwt { get; set; } = new();

	[ConfigurationStep(Order = 3)]
	public PasswordSettings Password { get; set; } = new();

	[ConfigurationStep(Order = 4)]
	public LockoutSettings Lockout { get; set; } = new();

	[ConfigurationStep(Order = 5)]
	public UserSettings User { get; set; } = new();

	[ConfigurationStep(Order = 6)]
	public TokenSettings Token { get; set; } = new();

	public class DatabaseSettings
	{
		[Required, MaxLength(200), DataEndpoint("data-providers")]
		public string DatabaseProvider { get; set; }

		[Required, MaxLength(200), ControlSize(EnumConfigurationPropertyControlSize.Large)]
		public string ConnectionString { get; set; }

		public bool UsePreferences { get; set; }
	}


	public class JwtSettings
	{
		[Required, MaxLength(40)]
		public string SecurityKey { get; set; }

		[Required, MaxLength(200)]
		public string Issuer { get; set; }

		[Required, MaxLength(500), ControlSize(EnumConfigurationPropertyControlSize.Large)]
		public string Audience { get; set; }

		[Range(1, 7)]
		public long ExpiryInDays { get; set; }

		[MaxLength(20)]
		public string CookieName { get; set; }
	}


	public class PasswordSettings
	{

		public bool RequireDigit { get; set; } = true;

		public bool RequireLowercase { get; set; } = true;

		public bool RequireNonAlphanumeric { get; set; } = true;

		public bool RequireUppercase { get; set; } = true;

		public long RequiredLength { get; set; } = 8;

		public long RequiredUniqueChars { get; set; } = 1;
	}

	public class LockoutSettings
	{
		public long TimeSpan { get; set; } = 5;

		public long MaxFailedAccessAttempts { get; set; } = 5;

		public bool AllowedForNewUsers { get; set; } = true;
	}


	public class UserSettings
	{
		[ControlSize(EnumConfigurationPropertyControlSize.Large)]
		public string UserAllowedUserNameCharacters { get; set; } = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

		public bool UserRequireUniqueEmail { get; set; } = true;

		public bool SignInRequireConfirmedEmail { get; set; } = true;

		public bool SignInRequireConfirmedAccount { get; set; } = true;

		public bool SignInRequireConfirmedPhoneNumber { get; set; } = true;

	}

	public class TokenSettings
	{
		[ControlSize(EnumConfigurationPropertyControlSize.Small)]
		public long Lifespan { get; set; } = 2;

	}

	//public class PopulateIdentitySettings
	//{

	//}
}