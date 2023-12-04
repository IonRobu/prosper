using Methodic.Core.Components.Admin;

namespace Core.Components.Admin
{
	public class AdminClientProvider : IAdminClientProvider
	{
		public string GetBusinessDatabaseInfo()
		{
			return "Get Business Database Info";
		}

		public string GetIdentityDatabaseInfo()
		{
			return "Get Identity Database Info";
		}
	}
}
