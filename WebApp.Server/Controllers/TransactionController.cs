using Core.Common.Models;
using Core.Common.Queries;
using Core.Common.Util;
using Core.Services;
using Methodic.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ApiController
{
	private ITransactionService _transactionService;

	public TransactionController(ITransactionService transactionService)
	{
		_transactionService = transactionService;
	}

	[HttpPost(RouteHelper.Transaction.GetPage)]
	public ActionResult GetTransactionPage([FromBody] TransactionQueryInfo queryInfo)
	{
		var result = _transactionService.GetTransactionPage(queryInfo);
		return Result(result);
	}

	[HttpGet(RouteHelper.Transaction.GetById)]
	public ActionResult GetTransactionById(int id)
	{
		var result = _transactionService.GetTransactionById(id);
		return Result(result);
	}

	[HttpPost(RouteHelper.Transaction.GetStatistics)]
	public ActionResult GetStatistics([FromBody] TransactionQueryInfo queryInfo)
	{
		var result = _transactionService.GetStatistics(queryInfo);
		return Result(result);
	}

	[HttpPost(RouteHelper.Transaction.GetSummary)]
	public ActionResult GetSummary([FromBody] TransactionQueryInfo queryInfo)
	{
		var result = _transactionService.GetSummary(queryInfo);
		return Result(result);
	}

	[HttpPost(RouteHelper.Transaction.Save)]
	public async Task<ActionResult> SaveTransactionAsync(TransactionModel model)
	{
		var result = await _transactionService.SaveTransactionAsync(model);
		return Result(result);
	}

	[HttpPost(RouteHelper.Transaction.Delete)]
	public async Task<ActionResult> DeleteTransactionAsync(TransactionModel model)
	{
		var result = await _transactionService.DeleteTransactionAsync(model);
		return Result(result);
	}
}