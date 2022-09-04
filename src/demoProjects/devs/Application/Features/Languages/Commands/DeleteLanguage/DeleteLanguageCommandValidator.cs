using FluentValidation;

namespace Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommandValidator : AbstractValidator<DeleteLanguageCommand>
    {
        public DeleteLanguageCommandValidator()
        {
            RuleFor(r => r.Id).NotNull();
            RuleFor(r => r.Id).GreaterThan(0);
        }
    }
}
