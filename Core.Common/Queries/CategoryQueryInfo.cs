using Methodic.Common.Util;

namespace Core.Common.Queries;

public class CategoryQueryInfo : QueryInfo
{
	public string Name { get; set; }

	public bool? IsFixed { get; set; }
}
