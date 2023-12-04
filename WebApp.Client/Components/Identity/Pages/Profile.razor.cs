using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;

namespace WebApp.Backend.Components.Identity.Pages;

[Authorize]
public partial class Profile
{
	[Inject]
	private ProfileData ProfileData { get; set; }

	[Inject]
	private I18n I18n { get; set; }
}
