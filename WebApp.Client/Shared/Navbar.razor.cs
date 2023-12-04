using Blazored.LocalStorage;
using Methodic.Blazor.UI.Configuration;
using Methodic.Common.Messages;
using Microsoft.AspNetCore.Components;

namespace WebApp.Client.Shared;

public partial class Navbar
{
	//[Inject]
	//private IdentityService IdentityService { get; set; }

	//[Inject]
	//private AuthService AuthService { get; set; }

	[Inject]
	private Navigation Navigation { get; set; }

	//[Inject]
	//private I18n I18n { get; set; }

	//[Inject]
	//private ProfileData ProfileData { get; set; }

	[Inject]
	private ILocalStorageService LocalStorage { get; set; }

	private List<Message> Messages { get; set; } = new();

	
}
