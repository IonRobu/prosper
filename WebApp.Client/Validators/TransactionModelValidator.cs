using Core.Common.Models;
using FluentValidation;
using Methodic.Common.Util;

namespace WebApp.Client.Validators;

public class TransactionModelValidator : ModelValidator<TransactionModel>
{
	public TransactionModelValidator()
	{
		SetRules();
	}

	protected override void SetRules()
	{
		ClassLevelCascadeMode = CascadeMode.Continue;

		RuleFor(x => x.Name)
			.NotEmpty()
			.WithMessage("Transaction name required");
	}
}
