using Prosper.MVVM.Models;
using Prosper.MVVM.ViewModels;
namespace Prosper.MVVM.Views;
public partial class AccountPage : ContentPage
{
	public AccountPage(Account item = null)
	{
		InitializeComponent();
		var model = new SettingsViewModel();
		if (item != null)
		{
			model.Account = item;
		}
		BindingContext = model;
	}

    private async void Save_Clicked(object sender, EventArgs e)
    {
        var curentVM = (SettingsViewModel)BindingContext;
        var message = curentVM.SaveAccount(out bool succeeded);
        await DisplayAlert("Info", message ?? "Operation succeeded", "ok");
        if(succeeded)
        {
			await Navigation.PopToRootAsync();
		}        
	}


    private async void Cancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
	}
}
