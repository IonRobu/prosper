using Blazored.LocalStorage;
using Core.Common.Models.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using WebApp.Backend.Services;

namespace WebApp.Backend.Configuration;

public class ProfileData
{
	private readonly AuthenticationStateProvider _stateProvider;
	private readonly IdentityService _identityService;
	private readonly ILocalStorageService _localStorage;

	public event Action OnChanged;

	public ProfileData
	(
		AuthenticationStateProvider stateProvider,
		IdentityService identityService,
		ILocalStorageService localStorage
	)
	{
		_stateProvider = stateProvider;
		_identityService = identityService;
		_localStorage = localStorage;
	}

	public UserModel User { get; set; } = new ();
	private ClaimsPrincipal _userClaims = new ();

	public async Task<UserModel> InitAsync()
	{
		var localDarkTheme = _localStorage.GetItemAsync<bool>("dark-theme");
		_userClaims = (await _stateProvider.GetAuthenticationStateAsync()).User;
		User = await _identityService.GetCurrentUserAsync(_userClaims.Identity);			
		OnChanged?.Invoke();
		return User;
	}

	public bool IsInRole(string role)
	{
		return _userClaims.IsInRole(role);
	}

	public void SetDarkMode(bool dark)
	{
		User.DarkMode = dark;
		OnChanged?.Invoke();
	}

	public void SetLogo(byte[] logo)
	{
		User.LogoContent = logo;
		OnChanged?.Invoke();
	}
}
