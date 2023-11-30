using Core.Common.Util;
using Core.Configuration.Settings;
using Methodic.Core.Configuration.Settings;
using Methodic.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Backend.Configuration.Utils;

namespace WebApi.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UtilsController : ApiController
{
	private IHttpClientFactory _httpClientFactory;
	private GeneralSettings _generalSettings;

	public UtilsController(
		IHttpClientFactory httpClientFactory, 
		AppSettings appSettings)
	{
		_httpClientFactory = httpClientFactory;
		_generalSettings = appSettings.GetSection<GeneralSettings>();
	}

	[HttpPost(RouteHelper.Utils.CheckCaptcha)]
	public async Task<ActionResult> CheckCaptchaAsync([FromBody] string data)
	{
		var content = new FormUrlEncodedContent(new Dictionary<string, string>
		{
			{"secret", _generalSettings.Captcha.SecretKey},
			{"response", data}
		});
		var httpClient = _httpClientFactory.CreateClient();
		var response = await httpClient.PostAsync(_generalSettings.Captcha.VerifyUrl, content);
		response.EnsureSuccessStatusCode();
		var verificationResponse = await response.Content.ReadFromJsonAsync<reCAPTCHAVerificationResponse>();
		return Result(verificationResponse.Success);
	}
}