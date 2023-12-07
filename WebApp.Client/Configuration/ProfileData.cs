using Core.Common.Models.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using WebApp.Client.Services;

namespace WebApp.Client.Configuration;

public class ProfileData
{
	private readonly AuthenticationStateProvider _stateProvider;
	private readonly IdentityService _identityService;

	public event Action OnChanged;

	public ProfileData
	(
		AuthenticationStateProvider stateProvider,
		IdentityService identityService
	)
	{
		_stateProvider = stateProvider;
		_identityService = identityService;
	}

	public UserModel User { get; set; } = new ();
	private ClaimsPrincipal _userClaims = new ();

	public async Task<UserModel> InitAsync()
	{
		_userClaims = (await _stateProvider.GetAuthenticationStateAsync()).User;
		User = await _identityService.GetCurrentUserAsync(_userClaims.Identity);			
		OnChanged?.Invoke();
		return User;
	}

	public bool IsInRole(string role)
	{
		return _userClaims.IsInRole(role);
	}
}
