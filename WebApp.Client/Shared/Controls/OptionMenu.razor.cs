using Microsoft.AspNetCore.Components;

namespace WebApp.Client.Shared.Controls;

public partial class OptionMenu
{
	[Parameter]
	public RenderFragment Items { get; set; }

	[Parameter]
	public RenderFragment Header { get; set; }

	[Parameter]
	public bool IsPrimary { get; set; }

	[Parameter]
	public bool IconButton { get; set; }

	private string cssClass = "btn-group k-button-icon";

	protected override Task OnParametersSetAsync()
	{
		if (IsPrimary)
		{
			cssClass += " k-primary";
		}
		return base.OnParametersSetAsync();
	}
}
