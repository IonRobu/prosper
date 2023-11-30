using Core.Common.Models.Util;
using Core.Common.Util;
using Methodic.Blazor.UI.Configuration;
using Methodic.Blazor.UI.Services;
using Methodic.Common.Models.Identity;
using Methodic.Common.Queries;
using Methodic.Common.Util;
using System.Security.Principal;

namespace WebApp.Backend.Services;

public class IdentityService : HttpServiceBase
{
	protected override string BaseUrl => "api/identity";

	public IdentityService(
		HttpClient client,
		AppSettings appSettings
	) : base(client, appSettings)
	{
		
	}

	private static Core.Common.Models.Identity.UserModel _user = new();

	public async Task<PageList<Core.Common.Models.Identity.UserModel>> GetUserPageAsync(UserQueryInfo queryInfo)
{
		var result = await RequestAsync(RouteHelper.Identity.GetUserPage, queryInfo, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<PageList<Core.Common.Models.Identity.UserModel>>();
		return result;
	}

	public async Task<Core.Common.Models.Identity.UserModel> GetUserAsync(string userName)
	{
		var result = await RequestAsync($"{RouteHelper.Identity.GetUserByUsername}?username={userName}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<Core.Common.Models.Identity.UserModel>();
		return result;
	}

	public async Task<Core.Common.Models.Identity.UserModel> GetUserAsync(long id)
	{
		var result = await RequestAsync($"{RouteHelper.Identity.GetUserById}?id={id}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<Core.Common.Models.Identity.UserModel>();
		return result;
	}

	public async Task<Core.Common.Models.Identity.UserModel> GetCurrentUserAsync(IIdentity identity)
	{
		if (identity.IsAuthenticated && string.IsNullOrEmpty(_user?.UserName))
		{
			_user = await GetUserAsync(identity.Name);
			if(_user == null)
			{
				_user = new Core.Common.Models.Identity.UserModel();
			}
		}
		return _user;
	}

	public async Task<Core.Common.Models.Identity.UserModel> SaveUserAsync(Core.Common.Models.Identity.UserModel model)
	{
		var result = await RequestAsync(RouteHelper.Identity.SaveUser, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<Core.Common.Models.Identity.UserModel>();
		return result;
	}

	public void ResetUser()
	{
		_user = new Core.Common.Models.Identity.UserModel();
	}

	public async Task<bool> SaveLogoAsync(UploadedFileModel model)
	{
		var result = await RequestAsync(RouteHelper.Identity.SaveLogo, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<bool> SetDarkModeAsync(bool dark)
	{
		var result = await RequestAsync(RouteHelper.Identity.SetDarkMode, dark, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<bool> ChangePasswordAsync(PasswordModel model)
	{
		var result = await RequestAsync(RouteHelper.Identity.ChangePassword, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}
}