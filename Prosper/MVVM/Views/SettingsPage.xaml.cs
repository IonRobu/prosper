using Prosper.MVVM.ViewModels;

namespace Prosper.MVVM.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
		BindingContext = new SettingsViewModel();
	}

    protected override void OnAppearing()
    {
		base.OnAppearing();
		var vm = (SettingsViewModel)BindingContext;
		vm.FillData();
	}

	async void AddTransactionCategory_Clicked(System.Object sender, System.EventArgs e)
	{
		await Navigation.PushAsync(new TransactionCategoryPage());
	}

	async void AddAccount_Clicked(System.Object sender, System.EventArgs e)
	{
		await Navigation.PushAsync(new AccountPage());
	}

	async void AddCard_Clicked(System.Object sender, System.EventArgs e)
	{
		await Navigation.PushAsync(new CardPage());
	}
}
