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

public class SolicitantRegisteredProcessor : NotificationProcessor<SolicitantRegisteredEvent, UserModel>
{
	private readonly AppSettings _appSettings;

	public SolicitantRegisteredProcessor(
		INotificationProvider provider,
		IServiceScopeFactory factory,
		AppSettings appSettings
	) : base(provider, appSettings, factory)
	{
		_appSettings = appSettings;
	}

	protected override async Task<List<UserModel>> GetUsersAsync(SolicitantRegisteredEvent source)
	{
		var result = new List<UserModel>();
		var user = new UserModel
		{
			// FirstName = source.Solicitant.ContactPerson,
			Email = source.Application.Solicitant.Email,
			UserName = source.Application.Solicitant.Email
		};
		result.Add(user);
		return await Task.FromResult(result);
	}

	protected override object GetTitle(SolicitantRegisteredEvent source, UserModel user)
	{
		return new
		{
			source.Application.Solicitant.ContactPerson,
		};
	}

	protected override object GetBody(SolicitantRegisteredEvent source, UserModel user)
	{
		var settings = _appSettings.GetSection<GeneralSettings>();
		return new
		{
			source.Application.Solicitant.ContactPerson,
			source.Application.Solicitant.Email,
			source.Application.ConfirmCode,
			ApplicationUrl = $"{settings.Application.PublicApplicationUrl}/application/index/{source.Application.PublicId}",
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
