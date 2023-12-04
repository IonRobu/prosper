using Methodic.Common.Util;

namespace Telerik.DataSource;

public static class TelerikExtensions
{
	public static TQueryInfo GetQueryInfo<TQueryInfo>(this DataSourceRequest request)
		where TQueryInfo : QueryInfo, new()
	{
		var result = new TQueryInfo
		{
			Page = request.Page,
			PageSize = request.PageSize
		};
		if (request.Sorts != null)
		{
			result.SortInfo = request.Sorts
				.Select(x => new SortInfo
				{
					Field = x.Member,
					IsAscending = x.SortDirection == ListSortDirection.Ascending
				})
				.ToList();
		}
		return result;
	}
}