using Methodic.Blazor.UI.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;

namespace WebApp.Backend.Components.Application.Pages;

[Authorize]
public partial class ApplicationPage
{
	[Parameter]
	public long Id { get; set; }

	[RouteName]
	public const string RouteApplicationDetail = "application-detail";

	[Inject]
	private I18n I18n { get; set; }

	public async Task GoToDetailAsync(long id)
	{
		await Navigation.GoToAsync(RouteApplicationDetail, id);
	}
}