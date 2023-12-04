using Methodic.Data.Domain.Base;

namespace Core.Data.Domain.Static;

public class Card : StaticEntity<int>
{

	public string Number { get; set; }
}