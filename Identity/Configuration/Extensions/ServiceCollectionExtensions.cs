using Core.Configuration.Settings;
using Core.Providers.Identity;
using Identity.Providers;
using Methodic.Core.Configuration.Settings;
using Methodic.Identity.Contexts;
using Methodic.Identity.Providers.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Ident = Identity;
using IdentityContext = Identity.Contexts.IdentityContext;

namespace Microsoft.Extensions.DependencyInjection
{
	public static partial class ConfigurationExtensions
	{
		private static string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

		public static IServiceCollection AddIdentityClient(this IServiceCollection services, IdentitySettings identitySettings)
		{
			return services
				.AddIdentity()
                .AddServices()
				.Configure(identitySettings);
		}

		private static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IIdentityContext, IdentityContext>();
			services.AddScoped<IIdentityProvider, IdentityProvider>();
			services.AddDbContext<IdentityContext>();
			services.AddIdentity<Ident.Domain.Business.AppUser, Ident.Domain.Business.AppRole>()
				.AddEntityFrameworkStores<IdentityContext>()
				.AddDefaultTokenProviders()
				.AddErrorDescriber<CustomIdentityErrorDescriber>();
			return services;
		}

		private static IServiceCollection Configure(this IServiceCollection services, IdentitySettings identitySettings)
		{
			services.Configure<IdentityOptions>(options =>
			{
				// Password settings
				options.Password.RequireDigit = identitySettings.Password.RequireDigit;
				options.Password.RequireLowercase = identitySettings.Password.RequireLowercase;
				options.Password.RequireNonAlphanumeric = identitySettings.Password.RequireNonAlphanumeric;
				options.Password.RequireUppercase = identitySettings.Password.RequireUppercase;
				options.Password.RequiredLength = (int)identitySettings.Password.RequiredLength;
				options.Password.RequiredUniqueChars = (int)identitySettings.Password.RequiredUniqueChars;

				// Lockout settings
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(identitySettings.Lockout.TimeSpan);
				options.Lockout.MaxFailedAccessAttempts = (int)identitySettings.Lockout.MaxFailedAccessAttempts;
				options.Lockout.AllowedForNewUsers = identitySettings.Lockout.AllowedForNewUsers;

				// User settings
				options.User.AllowedUserNameCharacters = identitySettings.User.UserAllowedUserNameCharacters;
				options.User.RequireUniqueEmail = identitySettings.User.UserRequireUniqueEmail;

				// Sign in settings
				options.SignIn.RequireConfirmedEmail = true;
				options.SignIn.RequireConfirmedAccount = true;
				options.SignIn.RequireConfirmedPhoneNumber = false;
			});

			services.Configure<DataProtectionTokenProviderOptions>(options =>
			{
				options.TokenLifespan = TimeSpan.FromHours(identitySettings.Token.Lifespan);
			});

			services.ConfigureApplicationCookie(options =>
			{
				// Cookie settings
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
				if (!string.IsNullOrEmpty(identitySettings.Jwt.CookieName))
				{
					options.Cookie.Name = identitySettings.Jwt.CookieName;
				}
				//options.LoginPath = "/account/login";
				//options.LogoutPath = "/account/login";
				//options.AccessDeniedPath = "/account/accessdenied";
				options.SlidingExpiration = true;
			});

			services.AddScoped<ProfileSettings>();

			var authBuilder = services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			});
			authBuilder.AddCookie();
			authBuilder.AddJwtBearer(options =>
				{
					var Key = Encoding.UTF8.GetBytes(identitySettings.Jwt.SecurityKey);
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = identitySettings.Jwt.Issuer,
						ValidAudience = identitySettings.Jwt.Audience,
						IssuerSigningKey = new SymmetricSecurityKey(Key)
					};
				});
			services.AddAuthorization();

			services.AddCors(options =>
				options.AddPolicy(name: MyAllowSpecificOrigins,
								builder =>
								{
									builder.AllowAnyOrigin();
									builder.AllowAnyHeader();
									builder.AllowAnyMethod();
								})
			);

			return services;
		}

		public static IApplicationBuilder UseIdentity(this IApplicationBuilder app)
		{
			app.UseCors(MyAllowSpecificOrigins);

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseProfileSettings();

			return app;
		}
	}
}