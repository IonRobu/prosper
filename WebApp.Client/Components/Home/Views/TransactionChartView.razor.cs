using Core.Common.Models;
using Microsoft.AspNetCore.Components;
using WebApp.Client.Services;

namespace WebApp.Client.Components.Home.Views;

public partial class TransactionChartView
{
	[Inject]
	private TransactionService TransactionService { get; set; }

	private List<TransactionAnalysisModel> Source { get; set; } = new();

	protected async override Task OnInitializedAsync()
	{
		Source = await TransactionService.GetTransactionAnalysisAsync();
		await base.OnInitializedAsync();
	}
}
