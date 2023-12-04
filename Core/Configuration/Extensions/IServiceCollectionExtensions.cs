using Core.Components.Admin;
using Methodic.Common.Models.Scheduling;
using Methodic.Core.Components.Admin;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class IServiceCollectionExtensions
{
	public static IServiceCollection AddClientCore(this IServiceCollection services)
	{
		services.AddCore();
		services.AddScoped<IAdminClientProvider, AdminClientProvider>();
		services.AddScoped<JobInstanceModel>();
		return services;
	}
}
