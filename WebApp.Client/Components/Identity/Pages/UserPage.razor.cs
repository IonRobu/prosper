using Methodic.Blazor.UI.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;

namespace WebApp.Backend.Components.Identity.Pages
{
	[Authorize]
	public partial class UserPage
	{
		[Parameter]
		public int Id { get; set; }

		[Inject]
		private I18n I18n { get; set; }

		[RouteName]
		public const string RouteUserList = "user-list";

		[RouteName]
		public const string RouteUserForm = "user-form";

		public async Task GoToFormAsync(long? id = null)
		{
			if (id == null)
			{
				await Navigation.GoToAsync(RouteUserForm);
			}
			else
			{
				await Navigation.GoToAsync(RouteUserForm, id);
			}
		}
	}
}
