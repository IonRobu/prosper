using Core.Common.Models.Identity;
using Core.Common.Util;
using Core.Services;
using Methodic.Core.Configuration.Settings;
using Methodic.WebApi.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController : ApiController
{
    private readonly IIdentityService _identityService;

    public IdentityController(
        IIdentityService identityService,
        AppSettings appSettings
    )
    {
        _identityService = identityService;
    }

    [HttpPost(RouteHelper.Identity.Login)]
    public async Task<ActionResult> LoginAsync([FromBody] LoginModel model)
    {
        var result = await _identityService.LoginAsync(model.UserName, model.Password);
        if (result.Data?.Token != null)
        {
            var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
            identity.AddClaim(new(ClaimTypes.Name, model.UserName));
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }
        return Result(result);
    }

    [HttpPost(RouteHelper.Identity.Logoff)]
    public async Task<ActionResult> LogoffAsync()
    {
        await _identityService.LogoffAsync();
        return Result(true);
	}

	[HttpGet(RouteHelper.Identity.GetUserByUsername)]
	public async Task<ActionResult> GetUserByUserNameAsync(string username)
	{
		var result = await _identityService.GetUserByUserNameAsync(username);
		return Result(result);
	}
}
