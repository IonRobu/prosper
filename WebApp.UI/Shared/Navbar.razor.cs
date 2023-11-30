using Blazored.LocalStorage;
using Methodic.Blazor.UI.Configuration;
using Methodic.Common.Messages;
using Microsoft.AspNetCore.Components;

namespace WebApp.UI.Shared;

public partial class Navbar
{
	[Inject]
	private Navigation Navigation { get; set; }

	[Inject]
	private ILocalStorageService LocalStorage { get; set; }

	private List<Message> Messages { get; set; } = new();
}
