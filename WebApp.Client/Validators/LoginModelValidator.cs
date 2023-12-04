using FluentValidation;
using Methodic.Common.Util;
using WebApp.Backend.Configuration.Models;

namespace WebApp.Backend.Validators;

public class LoginModelValidator : ModelValidator<LoginModel>
{
	public LoginModelValidator()
	{
		SetRules();
	}

	protected override void SetRules()
	{
		ClassLevelCascadeMode = CascadeMode.Continue;

		RuleFor(x => x.UserName)
			.NotEmpty()
			.WithMessage("Identity_UserName_Required");

		RuleFor(x => x.Password)
			.NotEmpty()
			.WithMessage("Identity_Password_Required");
	}
}
