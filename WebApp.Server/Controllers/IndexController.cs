using Core.Services;
using Methodic.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IndexController : ApiController
{
	private ITransactionService _transactionService;
	private IIdentityService _identityService;

	public IndexController(
		ITransactionService transactionService,
		IIdentityService identityService
	)
	{
		_transactionService = transactionService;
		_identityService = identityService;
	}


	[HttpGet("check")]
	public ActionResult Index()
	{
		return Result("OK");
	}

	[HttpGet("create-mock-data")]
	public async Task<ActionResult> CreateMockDataAsync()
	{
		var result = await _transactionService.CreateMockTransactionsAsync();
		return Result(result);
	}

	[HttpGet("init-membership")]
	public async Task<ActionResult> InitMembershipAsync()
	{
		await _identityService.InitMembershipAsync();
		return Result(true);
	}
}
