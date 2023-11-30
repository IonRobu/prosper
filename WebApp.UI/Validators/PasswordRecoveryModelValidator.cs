using Core.Common.Models.Identity;
using FluentValidation;
using Methodic.Common.Util;

namespace WebApp.Backend.Validators;

public class PasswordRecoveryModelValidator : ModelValidator<UserModel>
{
	public PasswordRecoveryModelValidator()
	{
		SetRules();
	}

	protected override void SetRules()
	{
            ClassLevelCascadeMode = CascadeMode.Continue;

		RuleFor(x => x.Email)
			.NotEmpty()
			.WithMessage("Identity_Email_Required");
	}
}
