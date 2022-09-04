using FluentValidation;

namespace Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageCommandValidator : AbstractValidator<CreateLanguageCommand>
    {
        public CreateLanguageCommandValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Name).MinimumLength(2);
        }
    }
}
