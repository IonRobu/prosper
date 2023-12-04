using Blazored.LocalStorage;
using Core.Common.Models.Identity;
using Core.Common.Models.Util;
using Methodic.Blazor.UI.Shared.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using WebApp.Backend.Configuration;
using WebApp.Backend.Services;

namespace WebApp.Backend.Components.Identity.Views;

public partial class ProfileForm
{
	[Inject]
	private IdentityService IdentityService { get; set; }

	[CascadingParameter]
	Task<AuthenticationState> authenticationStateTask { get; set; }

	[Inject]
	private ProfileData ProfileData { get; set; }

	[Inject]
	private ILocalStorageService LocalStorage { get; set; }

	[Inject]
	private I18n I18n { get; set; }

	protected override Task<UserModel> SaveDataAsync()
	{
		return IdentityService.SaveUserAsync(Model);
	}

	protected override void OnInitialized()
	{
		ProfileData.OnChanged += StateHasChanged;
	}

	protected override async Task OnEntitySavedAsync(UserModel model)
	{
		IdentityService.ResetUser();
		await base.OnEntitySavedAsync(model);
	}

	public ControlStyle GetStatusTag()
	{
		return Model.IsLocked ?
			ControlStyle.Warning :
			ControlStyle.Success;
	}

	public ControlStyle GetRoleTag(string role)
	{
		switch (role)
		{
			case "Operator":
				return ControlStyle.Secondary;
			case "Owner":
				return ControlStyle.Info;
			default:
				return ControlStyle.Primary;
		}
	}

	private string ImageSrc
	{
		get
		{
			if (ProfileData.User.LogoContent != null && ProfileData.User.LogoContent.Length > 0)
			{
				var base64 = Convert.ToBase64String(ProfileData.User.LogoContent);
				return string.Format("data:image/gif;base64,{0}", base64);
			}
			else
			{
				return "/images/default-avatar.png";
			}
		}
	}

	public async Task<bool> DarkModeChangedHandlerAsync(bool value)
	{
		await IdentityService.SetDarkModeAsync(value);
		ProfileData.SetDarkMode(value);
		await LocalStorage.SetItemAsync("dark-theme", value);
		return ProfileData.User.DarkMode = value;
	}

	private async Task OnInputFileChangeAsync(InputFileChangeEventArgs e)
	{
		var uploaded = e.GetMultipleFiles(1);
		if (uploaded.Any())
		{
			var file = uploaded.First();
			using var stream = file.OpenReadStream();
			using var memoryStream = new MemoryStream();
			await stream.CopyToAsync(memoryStream);
			stream.Close();
			var uploadedFile = new UploadedFileModel
			{
				FileName = file.Name,
				FileContent = memoryStream.ToArray()
			};
			memoryStream.Close();
			var result = await IdentityService.SaveLogoAsync(uploadedFile);
			if (result)
			{
				ProfileData.SetLogo(uploadedFile.FileContent);
				StateHasChanged();
			}
		}
	}
}
