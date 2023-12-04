using Methodic.Common.Messages;
using Methodic.Core.Components;
using Methodic.Core.Configuration.Settings;

namespace Core.Components;

internal class TransactionComponent : Component
{
	public TransactionComponent(
		Messaging messaging, 
		AppSettings appSettings
	) : base(messaging, appSettings)
	{

	}
}
