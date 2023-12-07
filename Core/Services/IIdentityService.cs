using Core.Common.Models.Identity;
using Methodic.Common.Util;
using Methodic.Core.Services;

namespace Core.Services;

public interface IIdentityService : IService
{
	Task<Result<UserModel>> LoginAsync(string userName, string password);

	Task LogoffAsync();

	Task<Result<UserModel>> GetUserByUserNameAsync(string userName);

	Task InitMembershipAsync();
}