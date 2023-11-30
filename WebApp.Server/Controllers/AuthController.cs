using Core.Common.Util;
using Core.Services;
using Methodic.Common.Models.Identity;
using Methodic.Core.Configuration.Settings;
using Methodic.WebApi.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.Backend.Models;

namespace WebApp.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ApiController
{
    private readonly IIdentityService _identityService;

    public AuthController(
        IIdentityService identityService,
        AppSettings appSettings
    )
    {
        _identityService = identityService;
    }

    [HttpPost(RouteHelper.Auth.Login)]
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

    [HttpPost(RouteHelper.Auth.Logoff)]
    public async Task<ActionResult> LogoffAsync()
    {
        await _identityService.LogoffAsync();
        return Result(true);
    }


    [HttpPost(RouteHelper.Auth.GetPasswordToken)]
    public async Task<ActionResult> GetPasswordTokenAsync([FromBody] string email)
    {
        var data = await _identityService.GetPasswordTokenAsync(email);
        return Result(data);
    }

    [HttpPost(RouteHelper.Auth.ConfirmPassword)]
    public async Task<ActionResult> ConfirmPasswordAsync([FromBody] PasswordModel model)
    {
        var result = await _identityService.ConfirmPasswordAsync(model.Email, model.NewPassword, model.NewPasswordRepeat, model.Token);
        return Result(result);
    }

    [HttpPost(RouteHelper.Auth.ConfirmEmail)]
    public async Task<ActionResult> ConfirmEmailAsync([FromBody] EmailModel model)
    {
        var result = await _identityService.ConfirmEmailAsync(model.Email, model.NewEmail, model.Token);
        return Result(result);
    }
}
