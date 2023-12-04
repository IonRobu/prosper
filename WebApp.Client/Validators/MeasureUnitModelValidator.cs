using Core.Common.Models;
using FluentValidation;
using Methodic.Common.Util;

namespace WebApp.Backend.Validators;

public class MeasureUnitModelValidator : ModelValidator<MeasureUnitModel>
{
	public MeasureUnitModelValidator()
	{
		SetRules();
	}

	protected override void SetRules()
	{
		ClassLevelCascadeMode = CascadeMode.Continue;

		RuleFor(x => x.Name)
			.NotEmpty()
			.WithMessage("MeasureUnit_Name_Required");
	}
}
