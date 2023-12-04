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

		RuleFor(x => x.Frequency)
			.NotEmpty()
			.When(x => x.IsFixed)
			.WithMessage("Frequency required");

		RuleFor(x => x.Amount)
			.NotEmpty()
			.When(x => x.IsFixed)
			.WithMessage("Amount required");

		RuleFor(x => x.Frequency)
			.Empty()
			.When(x => !x.IsFixed)
			.WithMessage("Frequency incorrectly completed");

		RuleFor(x => x.Amount)
			.Empty()
			.When(x => !x.IsFixed)
			.WithMessage("Amount incorrectly completed");
	}
}
