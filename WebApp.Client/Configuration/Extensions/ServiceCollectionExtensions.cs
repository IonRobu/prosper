using System.Reflection;
using Telerik.Blazor.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	internal static void DisableTrialForTelerik(this IServiceCollection services)
	{
		var prop = typeof(TrialService).GetField("isTrial", BindingFlags.NonPublic | BindingFlags.Instance);
		prop.SetValue(TrialService.Instance, false);
	}
}
