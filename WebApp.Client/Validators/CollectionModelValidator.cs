using Core.Common.Models;
using FluentValidation;
using Methodic.Common.Util;

namespace WebApp.Backend.Validators;

public class CollectionModelValidator : ModelValidator<CollectionModel>
{
	public CollectionModelValidator()
	{
		SetRules();
	}

	protected override void SetRules()
	{
		ClassLevelCascadeMode = CascadeMode.Continue;

		RuleFor(x => x.Name)
			.NotEmpty()
			.WithMessage("Collection_Name_Required");
	}
}
