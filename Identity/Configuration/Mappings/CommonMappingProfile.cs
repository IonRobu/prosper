using AutoMapper;
using Methodic.Common.Models.Identity;
using Methodic.Common.Models.Notifications;
using Methodic.Identity.Domain.Business;

namespace Identity.Configuration.Mappings
{
	public class CommonMappingProfile : Profile
	{
		public CommonMappingProfile()
		{
			MapUsers();
		}
	
		private void MapUsers()
		{
			CreateMap<Domain.Business.AppUser, Core.Common.Models.Identity.UserModel>(MemberList.Source)
				.AfterMap((src, dest) => {
					dest.Roles = src.UserRoles.Select(x => x.Role.Name).ToList();
					dest.IsLocked = src.LockoutEnd != null;
				});
			CreateMap<Core.Common.Models.Identity.UserModel, Domain.Business.AppUser>(MemberList.Source);

			CreateMap<Workspace, WorkspaceModel>(MemberList.Source);
			CreateMap<WorkspaceModel, Workspace>(MemberList.Source);

			CreateMap<UserNotification, NotificationModel>(MemberList.Source);
			CreateMap<NotificationModel, UserNotification>(MemberList.Source);

			CreateMap<UserNotificationSubscription, NotificationSubscriptionModel>(MemberList.Source);
			CreateMap<NotificationSubscriptionModel, UserNotificationSubscription>(MemberList.Source);
		}
	}
}
