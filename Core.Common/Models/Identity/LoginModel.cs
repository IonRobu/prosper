using Methodic.Common.Models;

namespace Core.Common.Models.Identity;

public class LoginModel : Model
{
    public string UserName { get; set; }

    public string Password { get; set; }
}
