using Core.Common.Models;
using Core.Common.Queries;
using Core.Common.Util;
using Methodic.Blazor.UI.Configuration;
using Methodic.Blazor.UI.Services;
using Methodic.Common.Util;

namespace WebApp.Backend.Services;

public class ApplicationService : HttpServiceBase
{
	protected override string BaseUrl => "api/application";

	public ApplicationService(
		HttpClient client,
		AppSettings appSettings
	) : base(client, appSettings)
	{

	}

	public async Task<PageList<ApplicationModel>> GetApplicationPageAsync(ApplicationQueryInfo queryInfo)
	{
		var result = await RequestAsync(RouteHelper.Application.GetPage, queryInfo, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<PageList<ApplicationModel>>();
		return result;
	}

	public async Task<ApplicationModel> GetApplicationByIdAsync(long id)
	{
		var result = await RequestAsync($"{RouteHelper.Application.GetById}?id={id}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<ApplicationModel>();
		return result;
	}

	public async Task<ApplicationModel> SaveApplicationAsync(ApplicationModel model)
	{
		var result = await RequestAsync(RouteHelper.Application.Save, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<ApplicationModel>();
		return result;
	}

	public async Task<bool> DeleteApplicationAsync(ApplicationModel model)
	{
		var result = await RequestAsync(RouteHelper.Application.Delete, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<ApplicationExtraDataModel> SaveApplicationExtraDataAsync(ApplicationExtraDataModel model)
	{
		var result = await RequestAsync(RouteHelper.Application.SaveExtraData, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<ApplicationExtraDataModel>();
		return result;
	}

	public async Task<bool> ApproveApplicationAsync(string publicId)
	{
		var result = await RequestAsync($"{RouteHelper.Application.Approve}?publicId={publicId}", opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<bool> RejectApplicationAsync(string publicId)
	{
		var result = await RequestAsync($"{RouteHelper.Application.Reject}?publicId={publicId}", opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<bool> ValidateApplicationAsync(string publicId)
	{
		var result = await RequestAsync($"{RouteHelper.Application.Validate}?publicId={publicId}", opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<bool> RequestApplicationExtraDataAsync(string publicId)
	{
		var result = await RequestAsync($"{RouteHelper.Application.RequestExtraDataAsync}?publicId={publicId}", opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<bool> CompleteExtraDataApplicationAsync(string publicId)
	{
		var result = await RequestAsync($"{RouteHelper.Application.CompleteExtraData}?publicId={publicId}", opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}
}