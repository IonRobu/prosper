using Blazored.SessionStorage;
using Core.Common.Models.Identity;
using Core.Common.Util;
using Methodic.Blazor.UI.Configuration;
using Methodic.Blazor.UI.Configuration.Identity;
using Methodic.Blazor.UI.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Principal;

namespace WebApp.Client.Services;

public class IdentityService : HttpServiceBase
{
	private AuthenticationStateProvider _authStateProvider;
	private readonly ISessionStorageService _sessionStorage;
	private static UserModel _user = new();

	protected override string BaseUrl => "api/identity";

	public IdentityService(
		HttpClient client,
		AuthenticationStateProvider authStateProvider,
		ISessionStorageService sessionStorage,
		AppSettings appSettings
	) : base(client, appSettings)
	{
		_authStateProvider = authStateProvider;
		_sessionStorage = sessionStorage;
	}

	public async Task<UserModel> LoginAsync(LoginModel model)
	{
		var result = await RequestAsync(RouteHelper.Identity.Login, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<UserModel>();
		if (result == null)
		{
			return result;
		}
		await _sessionStorage.SetItemAsync("authToken", result.Token);
		Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
		((ApiAuthenticationStateProvider)_authStateProvider).MarkUserAsAuthenticated(model.UserName);
		return result;
	}

	public async Task LogoutAsync()
	{
		var result = await RequestAsync(RouteHelper.Identity.Logoff, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		await _sessionStorage.RemoveItemAsync("authToken");
		Http.DefaultRequestHeaders.Authorization = null;
		((ApiAuthenticationStateProvider)_authStateProvider).MarkUserAsLoggedOut();
	}
	public async Task<UserModel> GetCurrentUserAsync(IIdentity identity)
	{
		if (identity.IsAuthenticated && string.IsNullOrEmpty(_user?.UserName))
		{
			_user = await GetUserAsync(identity.Name);
			if (_user == null)
			{
				_user = new();
			}
		}
		return _user;
	}
	public async Task<UserModel> GetUserAsync(string userName)
	{
		var result = await RequestAsync($"{RouteHelper.Identity.GetUserByUsername}?username={userName}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<UserModel>();
		return result;
	}
}