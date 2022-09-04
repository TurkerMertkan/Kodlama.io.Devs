using FluentValidation;

namespace Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommand>
    {
        public UpdateLanguageCommandValidator()
        {
            RuleFor(r => r.Id).NotNull();
            RuleFor(r => r.Id).GreaterThan(0);

            RuleFor(r => r.Name).NotNull();
            RuleFor(r => r.Name).MinimumLength(2);
        }
    }
}
