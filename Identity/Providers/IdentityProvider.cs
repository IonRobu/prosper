using AutoMapper;
using Core.Common.Models.Identity;
using Core.Configuration.Settings;
using Core.Providers.Identity;
using Identity.Util;
using Methodic.Common.Messages;
using Methodic.Core.Configuration.Settings;
using Methodic.Identity.Providers;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Providers;

internal class IdentityProvider : IdentityProvider<Domain.Business.AppUser, Domain.Business.AppRole, UserModel>, IIdentityProvider
{
	private readonly IdentitySettings _identitySettings;


	public IdentityProvider(
	Messaging messaging,
	UserManager<Domain.Business.AppUser> userManager,
	SignInManager<Domain.Business.AppUser> signInManager,
	RoleManager<Domain.Business.AppRole> roleManager,
	ProfileSettings userSettings,
	AppSettings appSettings,
	IMapper mapper
) : base(userManager, signInManager, roleManager, messaging, userSettings, mapper)
	{
		_identitySettings = appSettings.GetSection<IdentitySettings>();
	}

	protected override bool IsDataEnabled => _identitySettings.IsEnabled;

	protected override long GenerateKey()
	{
		return 0;
	}

	public async Task<bool> InitMembershipAsync()
	{
		var userName = "admin";
		if ((await GetUserListAsync()).All(x => x.UserName != userName))
		{
			await CreateRoleAsync(Constants.AdministratorRole);
			await CreateRoleAsync(Constants.OwnerRole);
			await CreateRoleAsync(Constants.OperatorRole);
			var model = new UserModel
			{
				UserName = userName,
				Email = "irobu82@gmail.com",
				PhoneNumber = "+40723791174",
				LastName = "Razvan",
				FirstName = "Derliu",
				Workspace = null
			};
			await CreateUserAsync(model,
				Constants.DefaultPassword,
				true,
				Constants.AdministratorRole,
				Constants.OwnerRole);
		}
		return true;
	}

	public async Task<UserModel> LoginAsync(string userName, string password)
	{
		var result = await LoginAsync(userName, password, false);
		if (!result)
		{
			return new();
		}

		var model = await GetUserByUserNameAsync(userName);
		var roles = await GetUserRolesAsync(userName);

		var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
		identity.AddClaim(new Claim(ClaimTypes.Name, userName));
		foreach (var role in roles)
		{
			identity.AddClaim(new Claim(ClaimTypes.Role, role));
		}

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_identitySettings.Jwt.SecurityKey));
		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
		var expiry = DateTime.UtcNow.AddDays(_identitySettings.Jwt.ExpiryInDays);


		var token = new JwtSecurityToken(
			_identitySettings.Jwt.Issuer,
			_identitySettings.Jwt.Audience,
			identity.Claims,
			expires: expiry,
			signingCredentials: creds
		);

		var data = new JwtSecurityTokenHandler().WriteToken(token);
		model.Token = data;
		return model;
	}
}
