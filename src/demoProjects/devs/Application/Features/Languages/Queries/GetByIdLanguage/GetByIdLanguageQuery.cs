using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQuery : IRequest<GetByIdLanguageDto>
    {
        public int Id { get; set; }

        public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, GetByIdLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinnessRules _languageBusinnessRules;

            public GetByIdLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinnessRules languageBusinnessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinnessRules = languageBusinnessRules;
            }

            public async Task<GetByIdLanguageDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
            {
                Language? language = await _languageRepository.GetAsync(g => g.Id == request.Id);
                _languageBusinnessRules.LanguageShouldExist(language);
                GetByIdLanguageDto getByIdLanguageDto = _mapper.Map<GetByIdLanguageDto>(language);
                return getByIdLanguageDto;
            }
        }
    }
}
