using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace WebApp.Client.Components.Statistics.Pages;

[Authorize]
public partial class StatisticsPage
{
	[Parameter]
	public long Id { get; set; }

	private int StepIndex = 0;
}