using Core.Common.Models;
using Methodic.Core.Common.Dispatching;
using Methodic.Core.Providers.Notifications.Attributes;

namespace Core.Providers.Notification.Events;

[Notification]
public class ApplicationExtraDataRequestedEvent : Event
{
	public ApplicationModel Application { get; set; }

	public ApplicationExtraDataRequestedEvent(ApplicationModel model)
	{
		Application = model;
	}
}
