using Methodic.Common.Models;

namespace Core.Common.Models;

public class CardModel : Model
{
	public int Id { get; set; }

	public string Name { get; set; }

	public string Number { get; set; }

	public string Description { get; set; }
}