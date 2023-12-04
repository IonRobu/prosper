using Core.Common.Models;
using Methodic.Core.Common.Dispatching;
using Methodic.Core.Providers.Notifications.Attributes;

namespace Core.Providers.Notification.Events;

[Notification]
public class ApplicationValidatedEvent : Event
{
	public ApplicationModel Application { get; set; }

	public ApplicationValidatedEvent(ApplicationModel model)
	{
		Application = model;
	}
}
