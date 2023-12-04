using Methodic.Common.Models;

namespace WebApp.Backend.Configuration.Models;

public class LoginModel : Model
{
    public string UserName { get; set; }

    public string Password { get; set; }
}
