using Methodic.Common.Models;

namespace Core.Common.Models;

public class AccountModel : Model
{
	public int Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }
}