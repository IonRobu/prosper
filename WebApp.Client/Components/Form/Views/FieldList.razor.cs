using Core.Common.Models;
using Core.Common.Models.Enums;
using Methodic.Common.Queries;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using Telerik.FontIcons;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;

namespace WebApp.Backend.Components.Form.Views;

public partial class FieldList
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
	private FormService FormService { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	private UserQueryInfo QueryInfo { get; set; } = new();

	public FieldList()
	{
		LazyBinding = true;
	}

	protected async Task ReadItemsAsync(ListViewReadEventArgs args)
	{
		var info = args.Request.GetQueryInfo<UserQueryInfo>();
		QueryInfo.SortInfo = info.SortInfo;
		QueryInfo.Page = info.Page;
		QueryInfo.PageSize = info.PageSize;
		await LoadAsync();
		args.Data = Source.Items;
		args.Total = Source.Total;
	}

	protected override async Task LoadAsync()
	{
		Source = await FormService.GetFieldPageAsync(QueryInfo);
	}

	private void Edit(FieldModel model)
	{
		OnEdit?.Invoke(model.Id);
	}

	private void Detail(FieldModel model)
	{
		OnDetail?.Invoke(model.Id);
	}

	private async Task DeleteAsync(FieldModel item)
	{
		var confirmed = await Dialogs.ConfirmAsync(I18n.Text.DeleteItem, I18n.Text.DeleteItemTitle);
		if (confirmed)
		{
			var result = await FormService.DeleteFieldAsync(item);
			if (result)
			{
				await LoadAsync();
				StateHasChanged();
			}
		}
	}

	private void Form()
	{
		OnAdd?.Invoke();
	}

	private FontIcon GetFieldIcon(EnumFieldType type)
	{
		switch (type)
		{
			case EnumFieldType.Question:
				return FontIcon.QuestionCircle;
			case EnumFieldType.Textbox:
				return FontIcon.Textbox;
				case EnumFieldType.Textarea: 
				return FontIcon.Textarea;
			case EnumFieldType.DropDown: 
				return FontIcon.ListUnordered;
			default: 
				return FontIcon.BorderRadius;
		}
	}
}
