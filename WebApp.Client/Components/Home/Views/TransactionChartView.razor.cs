using Core.Common.Models;
using Core.Common.Queries;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor;
using Telerik.Blazor.Components;
using WebApp.Client.Configuration;
using WebApp.Client.Services;

namespace WebApp.Client.Components.Home.Views;

public partial class TransactionChartView
{
	[Inject]
	private I18n I18n { get; set; }

	[Inject]
	private StaticDataService StaticDataService { get; set; }

	[Inject]
	private TransactionService TransactionService { get; set; }

	private TransactionQueryInfo QueryInfo { get; set; } = new();


	private TelerikListView<TransactionSummaryModel> list;

	private bool IsAscending { get; set; } = true;

	private bool IsWindowVisible { get; set; }

	private string SortText => "Name " + (IsAscending ? "descending" : "ascending");

	ProductsAggregationModel ChartData { get; set; } = new ProductsAggregationModel();

	//public DateTime? StartValue { get; set; } = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(-7);
	//public DateTime? EndValue { get; set; } = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
	public CalendarView View { get; set; } = CalendarView.Decade;
	public TelerikDateRangePicker<DateTime?> PickerRef { get; set; }

	public TransactionChartView()
	{
		ChartData = GetData();
	}

	public ProductsAggregationModel GetData()
	{
		var data = new ProductsAggregationModel()
		{
			ProductAggregation = new List<ProductAggregationModel>()
			{
				new ProductAggregationModel()
				{
					ProductName = "HL Mountain Rear Wheel",
					ProductRevenueAndSales = new List<ProductRevenueAndSalesModel>()
					{
						new ProductRevenueAndSalesModel()
						{
							Revenue = 13422.621072m,
							SalesCount = 69,
							Category = "May"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 23559.48m,
							SalesCount = 120,
							Category = "Jun"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 20056.31621m,
							SalesCount = 104,
							Category = "Jul"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 10798.095m,
							SalesCount = 55,
							Category = "Aug"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 17080.623m,
							SalesCount = 87,
							Category = "Sep"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 13154.043m,
							SalesCount = 67,
							Category = "Oct"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 8049.489m,
							SalesCount = 41,
							Category = "Nov"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 10012.779m,
							SalesCount = 51,
							Category = "Dec"
						},
					}
				},
				new ProductAggregationModel()
				{
					ProductName = "ML Mountain Rear Wheel",
					ProductRevenueAndSales = new List<ProductRevenueAndSalesModel>()
					{
						new ProductRevenueAndSalesModel()
						{
							Revenue = 8616.04542m,
							SalesCount = 62,
							Category = "May"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 16621.06932m,
							SalesCount = 118,
							Category = "Jun"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 15166.35369m,
							SalesCount = 110,
							Category = "Jul"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 6231.06m,
							SalesCount = 44,
							Category = "Aug"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 11895.66m,
							SalesCount = 84,
							Category = "Sep"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 11470.815m,
							SalesCount = 81,
							Category = "Oct"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 5381.37m,
							SalesCount = 38,
							Category = "Nov"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 6231.06m,
							SalesCount = 44,
							Category = "Dec"
						},
					}
				},
				new ProductAggregationModel()
				{
					ProductName = "LL Road Rear Wheel",
					ProductRevenueAndSales = new List<ProductRevenueAndSalesModel>()
					{
						new ProductRevenueAndSalesModel()
						{
							Revenue = 3849.723m,
							SalesCount = 57,
							Category = "May"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 8577.453m,
							SalesCount = 127,
							Category = "Jun"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 5470.659m,
							SalesCount = 81,
							Category = "Jul"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 4525.113m,
							SalesCount = 67,
							Category = "Aug"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 7226.673m,
							SalesCount = 107,
							Category = "Sep"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 3782.184m,
							SalesCount = 56,
							Category = "Oct"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 2026.17m,
							SalesCount = 30,
							Category = "Nov"
						},
						new ProductRevenueAndSalesModel()
						{
							Revenue = 4525.113m,
							SalesCount = 67,
							Category = "Dec"
						},
					}
				},
			},
			TotalAggregation = new List<ProductRevenueAndSalesModel>()
			{
				new ProductRevenueAndSalesModel()
				{
					Revenue = 25888.389492m,
					SalesCount = 188,
					Category = "May"
				},
				new ProductRevenueAndSalesModel()
				{
					Revenue = 48758.00232m,
					SalesCount = 365,
					Category = "Jun"
				},
				new ProductRevenueAndSalesModel()
				{
					Revenue = 40693.3289m,
					SalesCount = 295,
					Category = "Jul"
				},
				new ProductRevenueAndSalesModel()
				{
					Revenue = 21554.268m,
					SalesCount = 166,
					Category = "Aug"
				},
				new ProductRevenueAndSalesModel()
				{
					Revenue = 36202.956m,
					SalesCount = 278,
					Category = "Sep"
				},
				new ProductRevenueAndSalesModel()
				{
					Revenue = 28407.042m,
					SalesCount = 204,
					Category = "Oct"
				},
				new ProductRevenueAndSalesModel()
				{
					Revenue = 15457.029m,
					SalesCount = 109,
					Category = "Nov"
				},
				new ProductRevenueAndSalesModel()
				{
					Revenue = 20768.952m,
					SalesCount = 162,
					Category = "Dec"
				}
			}
		};

		return data;
	}

	public class ProductsAggregationModel
	{
		public List<ProductAggregationModel> ProductAggregation { get; set; }

		public List<ProductRevenueAndSalesModel> TotalAggregation { get; set; }
	}

	public class ProductAggregationModel
	{
		public string ProductName { get; set; }

		public List<ProductRevenueAndSalesModel> ProductRevenueAndSales { get; set; }
	}

	public class ProductRevenueAndSalesModel
	{
		public decimal Revenue { get; set; }

		public int SalesCount { get; set; }

		public string Category { get; set; }
	}
}
