using Core.Services;
using Methodic.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IndexController : ApiController
{
	private ITransactionService _transactionService;

	public IndexController(ITransactionService transactionService)
	{
		_transactionService = transactionService;
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
}
