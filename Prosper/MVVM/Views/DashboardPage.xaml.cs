using Prosper.MVVM.ViewModels;
namespace Prosper.MVVM.Views;
public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
		BindingContext = new DashBoardViewModel();
	}

	async void AddTransaction_Clicked(System.Object sender, System.EventArgs e)
	{
		await Navigation.PushAsync(new TransactionsPage());
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		var vm = (DashBoardViewModel)BindingContext;
		vm.FillData();
	}
}
