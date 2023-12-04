using Core.Common.Models;
using FluentValidation;
using Methodic.Common.Util;

namespace WebApp.Backend.Validators;

public class CollectionTypeModelValidator : ModelValidator<CollectionTypeModel>
{
	public CollectionTypeModelValidator()
	{
		SetRules();
	}

	protected override void SetRules()
	{
		ClassLevelCascadeMode = CascadeMode.Continue;

		RuleFor(x => x.Name)
			.NotEmpty()
			.WithMessage("CollectionType_Name_Required");
	}
}
