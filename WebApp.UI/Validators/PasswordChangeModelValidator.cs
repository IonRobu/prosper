using FluentValidation;
using Methodic.Common.Models.Identity;
using Methodic.Common.Util;

namespace WebApp.Backend.Validators;

public class PasswordChangeModelValidator : ModelValidator<PasswordModel>
{
	public PasswordChangeModelValidator()
	{
		SetRules();
	}

	protected override void SetRules()
	{
            ClassLevelCascadeMode = CascadeMode.Stop;

		RuleFor(x => x.Password)
			.NotEmpty()
			.WithMessage("Identity_CurrentPassword_Required");

		RuleFor(x => x.Password)
			.NotEqual(x => x.NewPassword)
			.When(x => !string.IsNullOrEmpty(x.Password))
			.WithMessage("Identity_Password_NotChanged");

		RuleFor(x => x.NewPassword)
			.NotEmpty()
			.WithMessage("Identity_NewPassword_Required");

		RuleFor(x => x.NewPassword)
			.Equal(x => x.NewPasswordRepeat)
			.WithMessage("Identity_RepeatPassword_NotMatch");
	}
}
