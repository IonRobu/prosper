using Core.Common.Models;
using Core.Common.Models.Enums;
using Methodic.Core.Common.Dispatching;
using Methodic.Core.Providers.Notifications.Attributes;

namespace Core.Providers.Notification.Events;

[Notification]
public class ApplicationFileUploadedAuthorityEvent : Event
{
	public ApplicationModel Application { get; set; }
	public EnumFileType FileType { get; set; }

	public ApplicationFileUploadedAuthorityEvent(ApplicationModel model, EnumFileType fileType)
	{
		Application = model;
		FileType = fileType;
	}
}
