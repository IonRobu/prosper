using Core.Common.Models;
using FluentValidation;
using Methodic.Common.Util;

namespace WebApp.Backend.Validators;

public class FormModelValidator : ModelValidator<FormModel>
{
	public FormModelValidator()
	{
		SetRules();
	}

	protected override void SetRules()
	{
            ClassLevelCascadeMode = CascadeMode.Continue;

		RuleFor(x => x.Name)
			.NotEmpty()
			.WithMessage("Field_Name_Required");

		//RuleFor(x => x.ApplicationType)
		//	.IsInEnum()
		//	.WithMessage("Form_ApplicationType_Invalid");

		//RuleFor(x => x.PersonType)
		//	.IsInEnum()
		//	.WithMessage("Form_PersonType_Invalid");
	}
}
