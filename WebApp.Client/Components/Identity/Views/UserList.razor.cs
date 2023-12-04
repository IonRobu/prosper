using Core.Common.Models.Identity;
using Methodic.Common.Queries;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;

namespace WebApp.Backend.Components.Identity.Views
{
	public partial class UserList
	{
		[Parameter]
		public Action<long> OnEdit { get; set; }

		[Parameter]
		public Action OnAdd { get; set; }

		[Inject]
		private IdentityService IdentityService { get; set; }

		[Inject]
		private I18n I18n { get; set; }

		private UserQueryInfo QueryInfo { get; set; } = new();

		public UserList()
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
			Source = await IdentityService.GetUserPageAsync(QueryInfo);
		}

		private void Edit(UserModel model)
		{
			OnEdit?.Invoke(model.Id);
		}

		private void Form()
		{
			OnAdd?.Invoke();
		}
	}
}
