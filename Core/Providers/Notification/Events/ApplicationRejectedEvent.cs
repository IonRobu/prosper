using Core.Common.Models;
using Methodic.Core.Common.Dispatching;
using Methodic.Core.Providers.Notifications.Attributes;

namespace Core.Providers.Notification.Events;

[Notification]
public class ApplicationRejectedEvent : Event
{
	public ApplicationModel Application { get; set; }

	public ApplicationRejectedEvent(ApplicationModel model)
	{
		Application = model;
	}
}
