using Core.Common.Models;
using Core.Common.Util;
using Methodic.Blazor.UI.Configuration;
using Methodic.Blazor.UI.Services;
using Methodic.Common.Util;

namespace WebApp.Backend.Services;

public class FormService : HttpServiceBase
{
	protected override string BaseUrl => "api/form";

	public FormService(
		HttpClient client,
		AppSettings appSettings
	) : base(client, appSettings)
	{

	}

	public async Task<PageList<FormModel>> GetFormPageAsync(QueryInfo queryInfo)
	{
		var result = await RequestAsync(RouteHelper.Form.GetPage, queryInfo, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<PageList<FormModel>>();
		return result;
	}

	public async Task<FormModel> GetFormByIdAsync(long id)
	{
		var result = await RequestAsync($"{RouteHelper.Form.GetById}?id={id}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<FormModel>();
		return result;
	}

	public async Task<FormModel> SaveFormAsync(FormModel model)
	{
		var result = await RequestAsync(RouteHelper.Form.Save, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<FormModel>();
		return result;
	}

	public async Task<bool> DeleteFormAsync(FormModel model)
	{
		var result = await RequestAsync(RouteHelper.Form.Delete, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<FormStepModel> GetFormStepByIdAsync(long id)
	{
		var result = await RequestAsync($"{RouteHelper.Form.GetStepById}?id={id}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<FormStepModel>();
		return result;
	}

	public async Task<FormStepModel> SaveFormStepAsync(FormStepModel model)
	{
		var result = await RequestAsync(RouteHelper.Form.SaveStep, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<FormStepModel>();
		return result;
	}

	public async Task<bool> DeleteFormStepAsync(FormStepModel model)
	{
		var result = await RequestAsync(RouteHelper.Form.DeleteStep, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<FormStepModel> SetStepPositionAsync(FormStepModel model, int newPosition)
	{
		var result = await RequestAsync($"{RouteHelper.Form.SetStepPosition}?newPosition={newPosition}", model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<FormStepModel>();
		return result;
	}

	public async Task<StepFieldModel> GetStepFieldByIdAsync(long id)
	{
		var result = await RequestAsync($"{RouteHelper.Form.GetStepFieldById}?id={id}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<StepFieldModel>();
		return result;
	}

	public async Task<StepFieldModel> SaveStepFieldAsync(StepFieldModel model)
	{
		var result = await RequestAsync(RouteHelper.Form.SaveStepField, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<StepFieldModel>();
		return result;
	}

	public async Task<bool> DeleteStepFieldAsync(StepFieldModel model)
	{
		var result = await RequestAsync(RouteHelper.Form.DeleteStepField, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<StepFieldModel> SetStepFieldPositionAsync(StepFieldModel model, int newPosition)
	{
		var result = await RequestAsync($"{RouteHelper.Form.SetStepFieldPosition}?newPosition={newPosition}", model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<StepFieldModel>();
		return result;
	}

	public async Task<PageList<FieldModel>> GetFieldPageAsync(QueryInfo queryInfo)
	{
		var result = await RequestAsync(RouteHelper.Form.GetFieldPage, queryInfo, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<PageList<FieldModel>>();
		return result;
	}

	public async Task<List<FieldModel>> GetFieldListAsync(QueryInfo queryInfo)
	{
		var result = await RequestAsync(RouteHelper.Form.GetFieldList, queryInfo, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<List<FieldModel>>();
		return result;
	}

	public async Task<FieldModel> GetFieldByIdAsync(long id)
	{
		var result = await RequestAsync($"{RouteHelper.Form.GetFieldById}?id={id}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<FieldModel>();
		return result;
	}

	public async Task<FieldModel> SaveFieldAsync(FieldModel model)
	{
		var result = await RequestAsync(RouteHelper.Form.SaveField, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<FieldModel>();
		return result;
	}

	public async Task<bool> DeleteFieldAsync(FieldModel model)
	{
		var result = await RequestAsync(RouteHelper.Form.DeleteField, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<FieldExplanationModel> SaveFieldExplanationAsync(FieldExplanationModel model)
	{
		var result = await RequestAsync(RouteHelper.Form.SaveFieldExplanation, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<FieldExplanationModel>();
		return result;
	}

	public async Task<bool> DeleteFieldExplanationAsync(FieldExplanationModel model)
	{
		var result = await RequestAsync(RouteHelper.Form.DeleteFieldExplanation, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}

	public async Task<FormUsageModel> GetFormUsageByIdAsync(long id)
	{
		var result = await RequestAsync($"{RouteHelper.Form.GetUsageById}?id={id}", opts =>
		{
			opts.AsGetMethod();
		})
		.ResponseAsync<FormUsageModel>();
		return result;
	}

	public async Task<FormUsageModel> SaveFormUsageAsync(FormUsageModel model)
	{
		var result = await RequestAsync(RouteHelper.Form.SaveUsage, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<FormUsageModel>();
		return result;
	}

	public async Task<bool> DeleteFormUsageAsync(FormUsageModel model)
	{
		var result = await RequestAsync(RouteHelper.Form.DeleteUsage, model, opts =>
		{
			opts.AsPostMethod();
		})
		.ResponseAsync<bool>();
		return result;
	}
}