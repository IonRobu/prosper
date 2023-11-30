using Core.Services;
using Methodic.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Backend.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AdminController : ApiController
	{
		private IAdminService _adminService;

		public AdminController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		[HttpPost("data-providers")]
		public ActionResult GetDataProviders()
		{
			var response = _adminService.GetDataProviders();
			return Result(response);
		}

		//[HttpPost("app-rebuild")]
		//public ActionResult AppRebuild()
		//{
		//	var builder = WebApplication.CreateBuilder();
		//	builder.RunApplication();
		//	return Result(true);
		//}
	}
}