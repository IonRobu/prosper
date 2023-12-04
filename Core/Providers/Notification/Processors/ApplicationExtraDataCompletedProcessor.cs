using Core.Common.Models;
using Core.Common.Models.Identity;
using Core.Configuration.Settings;
using Core.Providers.Notification.Events;
using Methodic.Core.Configuration.Settings;
using Methodic.Core.Providers.Identity;
using Methodic.Core.Providers.Notifications;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Providers.Notification.Processors;

public class ApplicationExtraDataCompletedProcessor : NotificationProcessor<ApplicationExtraDataCompletedEvent, UserModel>
{
	private readonly AppSettings _appSettings;

	public ApplicationExtraDataCompletedProcessor(
		INotificationProvider provider,
		IServiceScopeFactory factory,
		AppSettings appSettings
	) : base(provider, appSettings, factory)
	{
		_appSettings = appSettings;
	}

	protected override async Task<List<UserModel>> GetUsersAsync(ApplicationExtraDataCompletedEvent source)
	{
		var generalSettings = _appSettings.GetSection<GeneralSettings>();
		var result = new List<UserModel>();
		var user = new UserModel
		{
			Email = generalSettings.Application.OfficeEmail,
			UserName = generalSettings.Application.OfficeEmail
		};
		result.Add(user);
		return await Task.FromResult(result);
	}

	protected override object GetTitle(ApplicationExtraDataCompletedEvent source, UserModel user)
	{
		return new
		{
			source.Application.Solicitant.ContactPerson
		};
	}

	protected override object GetBody(ApplicationExtraDataCompletedEvent source, UserModel user)
	{
		var settings = _appSettings.GetSection<GeneralSettings>();
		return new
		{
			source.Application.Id,
			source.Application.Solicitant.ContactPerson,
			source.Application.Solicitant.Email,
			source.Application.Solicitant.Phone,
			ApplicationUrl = $"{settings.Application.InternApplicationUrl}/application/application-detail/{source.Application.Id}",
			CreationDate = DateTime.Now
		};
	}

	protected override object DeserializeTitle(string value)
	{
		return Deserialize<SolicitantModel>(value);
	}

	protected override object DeserializeBody(string value)
	{
		var body = Deserialize<SolicitantModel>(value);
		return body;
	}
}
