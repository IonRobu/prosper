using Prosper.MVVM.ViewModels;
namespace Prosper.MVVM.Views;
public partial class AccountPage : ContentPage
{
	public AccountPage()
	{
		InitializeComponent();
		BindingContext = new SettingsViewModel();
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
