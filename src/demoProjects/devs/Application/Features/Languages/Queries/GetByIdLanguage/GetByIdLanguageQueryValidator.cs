using FluentValidation;

namespace Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQueryValidator : AbstractValidator<GetByIdLanguageQuery>
    {
        public GetByIdLanguageQueryValidator()
        {
            RuleFor(r => r.Id).NotNull();
            RuleFor(r => r.Id).GreaterThan(0);
        }
    }
}
