using Microsoft.AspNetCore.Components;
using WebApp.Backend.Configuration;

namespace WebApp.Backend.Components.Identity.Pages
{
	public partial class PasswordRecoveryPage
	{
		[Inject]
		private I18n I18n { get; set; }

		public async Task GoToLoginAsync()
		{
			await Navigation.GoToAsync(RouteIndex, typeof(LoginPage));
		}
	}
}
