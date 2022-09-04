using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Languages.Rules
{
    public class LanguageBusinnessRules
    {
        private readonly ILanguageRepository _languageReporsitory;
        public LanguageBusinnessRules(ILanguageRepository languageReporsitory)
        {
            _languageReporsitory = languageReporsitory;
        }

        public async Task LanguageNameCanNotDublicatedWhenInserted(string name)
        {
            IPaginate<Language> result = await _languageReporsitory.GetListAsync(x => x.Name == name);
            if (result.Items.Any()) throw new BusinessException("Language name already exists.");
        }

        public void LanguageShouldExist(Language language)
        {
            if (language == null) throw new BusinessException("Requested Language does not exists.");
        }

        public async Task LanguageNameCanNotBeDublicatedWhenUpdated(int id, string name)
        {
            IPaginate<Language> result = await _languageReporsitory.GetListAsync(x => x.Name == name && x.Id == id);
            if (result.Items.Any() == true) throw new BusinessException("Language name already exists. Please use different programing language name");
        }
    }
}
