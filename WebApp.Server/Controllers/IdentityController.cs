using Core.Common.Models.Util;
using Core.Common.Util;
using Core.Services;
using Methodic.Common.Models.Identity;
using Methodic.Common.Queries;
using Methodic.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class IdentityController : ApiController
{
	private readonly IIdentityService _identityService;

	public IdentityController(
		IIdentityService identityService
	)
	{
		_identityService = identityService;
	}

	[HttpPost(RouteHelper.Identity.GetUserPage)]
	public async Task<ActionResult> GetUserPageAsync([FromBody] UserQueryInfo queryInfo = null)
	{
		var result = await _identityService.GetUserPageAsync(queryInfo);
		return Result(result);
	}

	[HttpGet]
	[Route(RouteHelper.Identity.GetUserByUsername)]
	public async Task<ActionResult> GetUserByUserNameAsync(string username)
	{
		var result = await _identityService.GetUserByUserNameAsync(username);
		return Result(result);
	}

	[HttpGet(RouteHelper.Identity.GetUserById)]
	public async Task<ActionResult> GetUserByIdAsync(int id)
	{
		var result = await _identityService.GetUserByIdAsync(id);
		return Result(result);
	}

	[HttpPost(RouteHelper.Identity.SaveUser)]
	public async Task<ActionResult> SaveUserAsync([FromBody] Core.Common.Models.Identity.UserModel model)
	{
		var result = await _identityService.SaveUserAsync(model);
		return Result(result);
	}


	[HttpPost(RouteHelper.Identity.SaveLogo)]
	public async Task<ActionResult> SaveProfileLogoAsync(UploadedFileModel uploadedFile)
	{
		var result = await _identityService.UpdateUserAsync(x =>
		{
			x.LogoContent = uploadedFile.FileContent;
		});
		return Result(result);
	}


	[HttpPost(RouteHelper.Identity.SetDarkMode)]
	public async Task<ActionResult> SetDarkModeAsync([FromBody] bool dark)
	{
		var result = await _identityService.UpdateUserAsync(x =>
		{
			x.DarkMode = dark;
		});
		return Result(result);
	}

	[HttpPost(RouteHelper.Identity.ChangePassword)]
	public async Task<ActionResult> ChangePasswordAsync([FromBody] PasswordModel model)
	{
		var result = await _identityService.ChangePasswordAsync(model.Password, model.NewPassword, model.NewPasswordRepeat);
		return Result(result);
	}
}
