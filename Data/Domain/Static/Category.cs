using Methodic.Data.Domain.Base;

namespace Data.Domain.Static;

public class Category : StaticEntity<int>
{
	public string Description { get; set; }
}