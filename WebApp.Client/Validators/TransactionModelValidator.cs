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
			.WithMessage("Name required");

		RuleFor(x => x.CategoryId)
			.NotEmpty()
			.WithMessage("Category required");

		RuleFor(x => x.CardId)
			.NotEmpty()
			.WithMessage("Card required");

		RuleFor(x => x.AccountId)
			.NotEmpty()
			.WithMessage("Account required");

		RuleFor(x => x.OperationDate)
			.GreaterThan(new DateTime(1900, 1, 1))
			.WithMessage("Operation date required");

		RuleFor(x => x.OperationDate)
			.LessThan(new DateTime(2100, 1, 1))
			.WithMessage("Operation date required");

		RuleFor(x => x.Amount)
			.GreaterThan(0)
			.WithMessage("Amount must be a positive value");
	}
}
