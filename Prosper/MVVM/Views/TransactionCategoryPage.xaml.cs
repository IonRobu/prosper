using Prosper.MVVM.Models;
using Prosper.MVVM.ViewModels;
namespace Prosper.MVVM.Views;
public partial class TransactionCategoryPage : ContentPage
{
	public TransactionCategoryPage(TransactionCategory item = null)
	{
		InitializeComponent();
		var model = new SettingsViewModel();
		if(item != null)
		{
			model.TransactionCategory = item;
		}
		BindingContext = model;
	}

	private async void Save_Clicked(object sender, EventArgs e)
	{
		var curentVM = (SettingsViewModel)BindingContext;
		var message = curentVM.SaveTransactionCategory(out bool succeeded);
		await DisplayAlert("Info", message ?? "Operation succeeded", "ok");
		if (succeeded)
		{
			await Navigation.PopToRootAsync();
		}
	}


	private async void Cancel_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopToRootAsync();
	}
}
