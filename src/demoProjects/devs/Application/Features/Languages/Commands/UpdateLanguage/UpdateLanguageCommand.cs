using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommand : IRequest<UpdatedLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdatedLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinnessRules _languageBusinnessRules;

            public UpdateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinnessRules languageBusinnessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinnessRules = languageBusinnessRules;
            }

            public async Task<UpdatedLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
            {
                Language? existingLanguage = await _languageRepository.GetAsync(x => x.Id == request.Id);
                _languageBusinnessRules.LanguageShouldExist(existingLanguage);
                await _languageBusinnessRules.LanguageNameCanNotBeDublicatedWhenUpdated(request.Id, request.Name);

                _mapper.Map(request, existingLanguage);

                Language updatedLanguage = await _languageRepository.UpdateAsync(existingLanguage);
                UpdatedLanguageDto updatedLanguageDto = _mapper.Map<UpdatedLanguageDto>(updatedLanguage);
                return updatedLanguageDto;
            }
        }
    }
}
