using Core.Common.Models.Identity;
using Core.Providers.Identity;
using Methodic.Common.Messages;
using Methodic.Common.Util;
using Methodic.Core.Components;
using Methodic.Core.Configuration.Settings;

namespace Core.Components;

internal class IdentityComponent : Component
{
	private readonly IIdentityProvider _identityProvider;

	public IdentityComponent(
		Messaging messaging,
		IIdentityProvider identityProvider,
		AppSettings appSettings
) : base(messaging, appSettings)
	{
		_identityProvider = identityProvider;
	}	

	public UserModel CurrentUser => _identityProvider.CurrentUser;

	public string CurrentUserName => _identityProvider.CurrentUserName;

	public async Task<Result<UserModel>> LoginAsync(string userName, string password)
	{
		return await ExecuteAsync<UserModel>(async result =>
		{
			result.Data = await _identityProvider.LoginAsync(userName, password);
		});
	}

	public async Task LogoffAsync()
	{
		await _identityProvider.LogoffAsync();
	}

	public async Task<Result<UserModel>> GetUserByUserNameAsync(string userName)
	{
		return await ExecuteAsync<UserModel>(async result =>
		{
			result.Data = await _identityProvider.GetUserByUserNameAsync(userName);

		});
	}

	public async Task<Result<bool>> InitMembershipAsync()
	{
		return await ExecuteAsync<bool>(async result =>
		{
			result.Data = await _identityProvider.InitMembershipAsync();
		});
	}
}