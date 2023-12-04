using Methodic.Blazor.UI.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;

namespace WebApp.Backend.Components.Form.Pages;

[Authorize]
public partial class FieldPage
{
	[Parameter]
	public long Id { get; set; }

	[RouteName]
	public const string RouteFieldForm = "field-form";

	[RouteName]
	public const string RouteFieldDetail = "field-detail";

	[Inject]
	private I18n I18n { get; set; }

	public async Task GoToFormAsync(long? id = null)
	{
		if (id == null)
		{
			await Navigation.GoToAsync(RouteFieldForm);
		}
		else
		{
			await Navigation.GoToAsync(RouteFieldForm, id);
		}
	}

	public async Task GoToDetailAsync(long id, bool instead)
	{
		await (instead ? 
			Navigation.GoInsteadAsync(RouteFieldDetail, id) :
			Navigation.GoToAsync(RouteFieldDetail, id)
		);
	}
}