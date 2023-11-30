using Methodic.Blazor.UI.Configuration;
using Methodic.Blazor.UI.Shared.Base;
using Methodic.Common.Messages;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;

namespace WebApp.UI.Shared.Controls;

public partial class Info : IDisposable
{
	private TelerikNotification Notification { get; set; }

	[Parameter]
	public Func<string, string> Translate { get; set; }

	[Parameter]
	public int CloseAfter { get; set; } = 10000;

	[Inject]
	private AppSettings AppSettings { get; set; }

	private List<Message> Messages { get; set; } = new();

	private string GetMessage(string source)
	{
		return Translate == null ? source : Translate?.Invoke(source);
	}

	protected async override Task OnInitializedAsync()
	{
		AppSettings.OnNotify += Changed;
		await base.OnInitializedAsync();
	}

	private static ControlStyle GetStyle(Message message)
	{
		return message.Type switch
		{
			EnumMessageType.Error or EnumMessageType.Warning or EnumMessageType.Critical => ControlStyle.Warning,
			EnumMessageType.NotDefined => ControlStyle.Secondary,
			EnumMessageType.Success => ControlStyle.Success,
			_ => ControlStyle.Info,
		};
	}

	private void Changed(List<Message> messages)
	{
		Messages = messages;
		ShowNotifications();
	}

	void ShowNotifications()
	{
		var notEmptyMessages = Messages.Where(x => x.Body != null).ToList();
		if (!notEmptyMessages.Any())
		{
			return;
		}
		var body = string.Empty;
		foreach (var item in notEmptyMessages)
		{
			body += $"{GetMessage(item.Body)}<br />";
		}
		body = body.Remove(body.LastIndexOf("<br />"));
		Notification.HideAll();
		Notification.Show(new NotificationModel
		{
			Text = $"{GetMessage(body)}",
			ThemeColor = "primary",
			CloseAfter = CloseAfter
		});
		Messages.Clear();
	}

	public void Dispose()
	{
		AppSettings.OnNotify += Changed;
	}
}
