using Core.Common.Models.Identity;
using Core.Components;
using Methodic.Common.Util;
using Methodic.Core.Services.Impl;

namespace Core.Services.Impl;

internal class IdentityService : Service, IIdentityService
{
	private readonly IdentityComponent _identityComponent;

	public IdentityService(
		IdentityComponent identityComponent
	)
	{
		_identityComponent = identityComponent;
	}

	public UserModel CurrentUser => _identityComponent.CurrentUser;

	public string CurrentUserName => _identityComponent.CurrentUserName;


	public async Task<Result<UserModel>> LoginAsync(string userName, string password)
	{
		return await _identityComponent.LoginAsync(userName, password);
	}

	public async Task LogoffAsync()
	{
		await _identityComponent.LogoffAsync();
	}

	public async Task<Result<UserModel>> GetUserByUserNameAsync(string userName)
	{
		return await _identityComponent.GetUserByUserNameAsync(userName);
	}


	public async Task InitMembershipAsync()
	{
		await _identityComponent.InitMembershipAsync();
	}
}
