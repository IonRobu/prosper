using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace WebApp.UI.Components.Home.Pages;

[Authorize]
public partial class IndexPage
{
	[Parameter]
	public long Id { get; set; }

	private int StepIndex = 0;
}