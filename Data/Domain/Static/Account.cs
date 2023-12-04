using Methodic.Data.Domain.Base;

namespace Data.Domain.Static;

public class Account : StaticEntity<int>
{
	public string Description { get; set; }

}