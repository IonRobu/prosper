using Prosper.MVVM.ViewModels;
namespace Prosper.MVVM.Views;
public partial class TransactionsPage : ContentPage
{
	public TransactionsPage()
	{
		InitializeComponent();
		BindingContext = new TransactionsViewModel();
	}

    private async void Save_Clicked(System.Object sender, System.EventArgs e)
    {
        var curentVM = (TransactionsViewModel)BindingContext;
        var message = curentVM.SaveTransaction();
        await DisplayAlert("Info", message, "ok");
        await Navigation.PopToRootAsync();
    }


    private async void Cancel_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

	private void AccountPicker_SelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
		var curentVM = (TransactionsViewModel)BindingContext;
		var selected = curentVM.Accounts[selectedIndex];
        curentVM.Transaction.Account = selected;
		curentVM.Transaction.AccountId = selected.Id;
	}

	private void CardPicker_SelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
		int selectedIndex = picker.SelectedIndex;
		var curentVM = (TransactionsViewModel)BindingContext;
		var selected = curentVM.Cards[selectedIndex];
		curentVM.Transaction.Card = selected;
		curentVM.Transaction.CardId = selected.Id;
	}

	private void CategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
		int selectedIndex = picker.SelectedIndex;
		var curentVM = (TransactionsViewModel)BindingContext;
		var selected = curentVM.Categories[selectedIndex];
		curentVM.Transaction.Category = selected;
		curentVM.Transaction.AccountId = selected.Id;
	}
}
