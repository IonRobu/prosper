using Core.Common.Models;
using Core.Common.Models.Enums;
using Core.Common.Queries;
using Methodic.Common.Util;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;

namespace WebApp.Backend.Components.Application.Views;

public partial class ApplicationList
{
	[Parameter]
	public Action<long> OnDetail { get; set; }

	[Parameter]
	public Action<long> OnEdit { get; set; }

	[Parameter]
	public Action OnAdd { get; set; }

	[CascadingParameter]
	public DialogFactory Dialogs { get; set; }

	[Inject]
	private ApplicationService ApplicationService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	[Inject]
	private EnumData EnumData { get; set; }

	private ApplicationQueryInfo QueryInfo { get; set; } = new();

	private TelerikGrid<ApplicationModel> GridViewRef { get; set; }

	public ApplicationList()
	{
		LazyBinding = true;
	}

	protected async Task ReadItemsAsync(GridReadEventArgs args)
	{
		var info = args.Request.GetQueryInfo<QueryInfo>();
		QueryInfo.SortInfo = info.SortInfo;
		QueryInfo.Page = info.Page;
		QueryInfo.PageSize = info.PageSize;
		await LoadAsync();
		args.Data = Source.Items;
		args.Total = Source.Total;
	}

	protected override async Task LoadAsync()
	{
		Source = await ApplicationService.GetApplicationPageAsync(QueryInfo);
	}

	private void Edit(FormModel item)
	{
		OnEdit?.Invoke(item.Id);
	}

	private async Task DeleteAsync(ApplicationModel item)
	{
		var confirmed = await Dialogs.ConfirmAsync(I18n.Text.DeleteItem, I18n.Text.DeleteItemTitle);
		if (confirmed)
		{
			var result = await ApplicationService.DeleteApplicationAsync(item);
			if (result)
			{
				await LoadAsync();
				StateHasChanged();
			}
		}
	}

	private void Detail(ApplicationModel model)
	{
		OnDetail?.Invoke(model.Id);
	}

	private void Form()
	{
		OnAdd?.Invoke();
	}

	private string GetStatusTag(ApplicationModel item)
	{
		switch (item.Status)
		{
			case EnumApplicationStatus.Created:
				return "badge bg-primary";
			case EnumApplicationStatus.InWork:
				return "badge bg-secondary";
			case EnumApplicationStatus.Completed:
				return "badge bg-info";
			case EnumApplicationStatus.ExtraDataRequested:
				return "badge bg-warning";
			case EnumApplicationStatus.Rejected:
				return "badge bg-danger";
			case EnumApplicationStatus.Approved:
			case EnumApplicationStatus.Validated:
				return "badge bg-success";
			default:
				return "badge bg-secondary";
		}
	}

	private string GetPersonTypeTag(ApplicationModel item)
	{
		switch (item.Solicitant.PersonType.Id)
		{
			case EnumPersonType.LegalEntity:
				return "badge bg-primary";
			case EnumPersonType.NaturalPerson:
				return "badge bg-info";
			default:
				return "badge bg-secondary";
		}
	}

	protected void Filter()
	{
		GridViewRef.Rebind();
	}

	private void ResetFilter()
	{
		QueryInfo.SolicitantName = null;
		QueryInfo.SolicitantPhone = null;
		QueryInfo.SolicitantEmail = null;
		QueryInfo.SolicitantPersonType = null;
		QueryInfo.Status = null;
		Filter();
	}
}
