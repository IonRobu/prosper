using Microsoft.AspNetCore.Components;

namespace WebApp.Client.Components.Settings.Views;

public partial class StaticDataPanel
{
	[Parameter]
	public Action<string> OnSelected { get; set; }


	private void SelectStaticData(string type)
	{
		OnSelected?.Invoke(type);
	}
}
