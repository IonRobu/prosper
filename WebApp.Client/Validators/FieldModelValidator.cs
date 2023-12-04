using Core.Common.Models;
using Core.Common.Models.Enums;
using FluentValidation;
using Methodic.Common.Util;

namespace WebApp.Backend.Validators;

public class FieldModelValidator : ModelValidator<FieldModel>
{
	public FieldModelValidator()
	{
		SetRules();
	}

	protected override void SetRules()
	{
            ClassLevelCascadeMode = CascadeMode.Continue;

		RuleFor(x => x.Name)
			.NotEmpty()
			.WithMessage("Field_Name_Required");

		RuleFor(x => x.Title)
			.NotEmpty()
			.WithMessage("Field_Title_Required");

		RuleFor(x => x.Type)
			.IsInEnum()
			.WithMessage("Field_Type_Invalid");

		RuleFor(x => x.ListType)
			.NotEmpty()
			.When(x => new[] { EnumFieldType.Question, EnumFieldType.DropDown }.Contains(x.Type))
			.WithMessage("Field_ListType_Required");

		RuleFor(x => x.ListType)
			.IsInEnum()
			.When(x => new[] { EnumFieldType.Question, EnumFieldType.DropDown }.Contains(x.Type))
			.WithMessage("Field_ListType_Invalid");
	}
}
