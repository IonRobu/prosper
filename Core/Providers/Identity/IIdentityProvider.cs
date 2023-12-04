using Core.Common.Models.Identity;
using System.Threading.Tasks;

namespace Core.Providers.Identity;

public interface IIdentityProvider : Methodic.Core.Providers.Identity.IIdentityProvider<UserModel>
{
	Task<bool> InitMembershipAsync();

	Task<UserModel> SaveUserAsync(UserModel model);

        Task<UserModel> LoginAsync(string userName, string password);
    }
