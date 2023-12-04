using Core.Common.Models;
using FluentValidation;
using Methodic.Common.Util;

namespace WebApp.Client.Validators;

public class CategoryModelValidator : ModelValidator<CategoryModel>
{
	public CategoryModelValidator()
	{
		SetRules();
	}

	protected override void SetRules()
	{
		ClassLevelCascadeMode = CascadeMode.Continue;

		RuleFor(x => x.Name)
			.NotEmpty()
			.WithMessage("Category name required");
	}
}
