﻿using Core.Common.Models;
using FluentValidation;
using Methodic.Common.Util;

namespace WebApp.Client.Validators;

public class AccountModelValidator : ModelValidator<AccountModel>
{
	public AccountModelValidator()
	{
		SetRules();
	}

	protected override void SetRules()
	{
		ClassLevelCascadeMode = CascadeMode.Continue;

		RuleFor(x => x.Name)
			.NotEmpty()
			.WithMessage("Account name required");
	}
}
