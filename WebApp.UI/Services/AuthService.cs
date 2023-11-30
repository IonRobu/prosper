using Blazored.SessionStorage;
using Core.Common.Util;
using Methodic.Blazor.UI.Configuration;
using Methodic.Blazor.UI.Configuration.Identity;
using Methodic.Blazor.UI.Services;
using Methodic.Common.Models.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using WebApp.Backend.Configuration.Models;

namespace WebApp.Backend.Services;

public class AuthService : HttpServiceBase
{
	private AuthenticationStateProvider _authStateProvider;
	private readonly ISessionStorageService _sessionStorage;

	protected override string BaseUrl => "api/auth";

	public AuthService(
		HttpClient client,
		AuthenticationStateProvider authStateProvider,
		ISessionStorageService sessionStorage,
		AppSettings appSettings
	) : base(client, appSettings)
	{
		_authStateProvider = authStateProvider;
		_sessionStorage = sessionStorage;
	}

	public async Task<Core.Common.Models.Identity.UserModel> LoginAsync(LoginModel model)
	{
		var result = await RequestAsync(RouteHelper.Auth.Login, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<Core.Common.Models.Identity.UserModel>();
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
		var result = await RequestAsync(RouteHelper.Auth.Logoff, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		await _sessionStorage.RemoveItemAsync("authToken");
		Http.DefaultRequestHeaders.Authorization = null;
		((ApiAuthenticationStateProvider)_authStateProvider).MarkUserAsLoggedOut();
	}

	public async Task<bool> GetPasswordTokenAsync(string email)
	{
		var result = await RequestAsync(RouteHelper.Auth.GetPasswordToken, email, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<bool> ConfirmPasswordAsync(PasswordModel model)
	{
		var result = await RequestAsync(RouteHelper.Auth.ConfirmPassword, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<bool> ConfirmEmailAsync(Core.Common.Models.Identity.UserModel model)
	{
		var result = await RequestAsync(RouteHelper.Auth.ConfirmEmail, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}
}