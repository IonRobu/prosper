using Methodic.Blazor.UI.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;

namespace WebApp.Backend.Components.Form.Pages;

[Authorize]
public partial class FormPage
{
	[Parameter]
	public long Id { get; set; }

	[RouteName]
	public const string RouteFormForm = "form-form";

	[RouteName]
	public const string RouteFormDetail = "form-detail";

	[RouteName]
	public const string RouteFormStepDetail = "form-step-detail";

	[Inject]
	private I18n I18n { get; set; }

	public async Task GoToFormAsync(long? id = null)
	{
		if (id == null)
		{
			await Navigation.GoToAsync(RouteFormForm);
		}
		else
		{
			await Navigation.GoToAsync(RouteFormForm, id);
		}
	}

	public async Task GoToDetailAsync(long id)
	{
		await Navigation.GoToAsync(RouteFormDetail, id);
	}

	public async Task GoToStepDetailAsync(long id)
	{
		await Navigation.GoToAsync(RouteFormStepDetail, id);
	}
}