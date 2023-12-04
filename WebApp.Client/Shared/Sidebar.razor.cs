using Methodic.Blazor.UI.Configuration;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebApp.Client.Shared;

public partial class Sidebar
{
	[Inject]
	public Navigation Navigation { get; set; }

	[Inject]
	private IJSRuntime JS { get; set; }

	private async Task GoToItemAsync(Type itemType)
	{
		await Navigation.ClearAsync();
		await Navigation.GoToAsync("index", itemType);
	}
}
