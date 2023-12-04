using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace WebApp.Client.Components.Settings.Pages;

[Authorize]
public partial class SettingsPage
{
	[Parameter]
	public long Id { get; set; }

	private int StepIndex = 0;
}