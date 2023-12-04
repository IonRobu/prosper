using Core.Common.Models;
using Methodic.Core.Common.Dispatching;
using Methodic.Core.Providers.Notifications.Attributes;

namespace Core.Providers.Notification.Events;

[Notification]
public class ApplicationApprovedEvent : Event
{
	public ApplicationModel Application { get; set; }

	public ApplicationApprovedEvent(ApplicationModel model)
	{
		Application = model;
	}
}
