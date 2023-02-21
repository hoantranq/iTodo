using FluentValidation;

namespace iTodo.Application.Features.ItemFeatures.CreateItem;

public sealed class CreateItemValidator : AbstractValidator<CreateItemRequest>
{
	public CreateItemValidator()
	{
		RuleFor(x => x.Title).NotEmpty().MinimumLength(1).MaximumLength(100);
	}
}

