using Prosper.MVVM.ViewModels;

namespace Prosper.MVVM.Views;

public partial class StatisticsPage : ContentPage
{
	public StatisticsPage()
	{
		InitializeComponent();
		BindingContext = new StatisticsViewModel();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		var vm = (StatisticsViewModel)BindingContext;
		vm.LoadStaticData();
	}

	private void AccountPicker_SelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
		int selectedIndex = picker.SelectedIndex;
		var curentVM = (StatisticsViewModel)BindingContext;
		var selected = curentVM.Accounts[selectedIndex];
		curentVM.Account = selected;
	}

	private async void Filter_Clicked(object sender, EventArgs e)
	{
		var vm = (StatisticsViewModel)BindingContext;
		vm.GetTransactionsSummary(out string message);
		if (message != null)
		{
			vm.Summary.Clear();
			await DisplayAlert("Info", message, "ok");
		}
	}


	private void Reset_Clicked(object sender, EventArgs e)
	{
		var vm = (StatisticsViewModel)BindingContext;
		vm.ResetTransactionsSummary();
	}
}
