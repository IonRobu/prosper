using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;

namespace WebApp.Backend.Components.Common.Views;

public partial class StepTitle
{
	[Parameter]
	public string Title { get; set; }

	[Inject]
	private I18n I18n { get; set; }
}
