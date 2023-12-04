using FluentValidation;
using Methodic.Common.Models.Identity;
using Methodic.Common.Util;

namespace WebApp.Backend.Validators;

public class PasswordResetModelValidator : ModelValidator<PasswordModel>
{
	public PasswordResetModelValidator()
	{
		SetRules();
	}

	protected override void SetRules()
	{
            ClassLevelCascadeMode = CascadeMode.Continue;

		RuleFor(x => x.NewPassword)
			.NotEmpty()
			.WithMessage("Identity_NewPassword_Required");

		RuleFor(x => x.NewPassword)
			.Equal(x => x.NewPasswordRepeat)
			.WithMessage("Identity_RepeatPassword_NotMatch");
	}
}
