using Prosper.MVVM.Models;
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

	private async void EditTransactionCategory_Clicked(object sender, EventArgs e)
	{
		TransactionCategory item = null;
		var button = (Button)sender;
		if(button.CommandParameter != null)
		{
			var id = (int)button.CommandParameter;
			var vm = (SettingsViewModel)BindingContext;
			item = vm.TransactionCategories.SingleOrDefault(x => x.Id == id);
		}
		await Navigation.PushAsync(new TransactionCategoryPage(item));
	}

	private async void DeleteTransactionCategory_Clicked(object sender, EventArgs e)
	{
		var button = (Button)sender;
		var result = await DisplayAlert("Confirm","Do you want to delete?", "ok", "cancel");
		if(result)
		{
			var id = (int)button.CommandParameter;
			var vm = (SettingsViewModel)BindingContext;
			var item = vm.TransactionCategories.SingleOrDefault(x => x.Id == id);
			vm.DeleteTransactionCategory(item);
			vm.FillData();
		}
	}

	private async void EditAccount_Clicked(object sender, EventArgs e)
	{
		Account item = null;
		var button = (Button)sender;
		if (button.CommandParameter != null)
		{
			var id = (int)button.CommandParameter;
			var vm = (SettingsViewModel)BindingContext;
			item = vm.Accounts.SingleOrDefault(x => x.Id == id);
		}
		await Navigation.PushAsync(new AccountPage(item));
	}

	private async void DeleteAccount_Clicked(object sender, EventArgs e)
	{
		var button = (Button)sender;
		var result = await DisplayAlert("Confirm", "Do you want to delete?", "ok", "cancel");
		if (result)
		{
			var id = (int)button.CommandParameter;
			var vm = (SettingsViewModel)BindingContext;
			var item = vm.Accounts.SingleOrDefault(x => x.Id == id);
			vm.DeleteAccount(item);
			vm.FillData();
		}
	}

	private async void EditCard_Clicked(object sender, EventArgs e)
	{
		Card item = null;
		var button = (Button)sender;
		if (button.CommandParameter != null)
		{
			var id = (int)button.CommandParameter;
			var vm = (SettingsViewModel)BindingContext;
			item = vm.Cards.SingleOrDefault(x => x.Id == id);
		}
		await Navigation.PushAsync(new CardPage(item));
	}

	private async void DeleteCard_Clicked(object sender, EventArgs e)
	{
		var button = (Button)sender;
		var result = await DisplayAlert("Confirm", "Do you want to delete?", "ok", "cancel");
		if (result)
		{
			var id = (int)button.CommandParameter;
			var vm = (SettingsViewModel)BindingContext;
			var item = vm.Cards.SingleOrDefault(x => x.Id == id);
			vm.DeleteCard(item);
			vm.FillData();
		}
	}
}
