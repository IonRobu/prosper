using Core.Common.Models.Identity;

namespace Core.Providers.Identity;

public interface IIdentityProvider : Methodic.Core.Providers.Identity.IIdentityProvider<UserModel>
{
	Task<bool> InitMembershipAsync();

	Task<UserModel> LoginAsync(string userName, string password);
}
