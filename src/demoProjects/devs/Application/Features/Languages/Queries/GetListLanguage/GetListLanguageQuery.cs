using Application.Features.Languages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Languages.Queries.GetListLanguage
{
    public class GetListLanguageQuery : IRequest<GetListLanguageModel>
    {
        public PageRequest PageRequest{ get; set; }

        public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, GetListLanguageModel>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;

            public GetListLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }
            public async Task<GetListLanguageModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Language> language = await _languageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                GetListLanguageModel mappedLanguageListModel = _mapper.Map<GetListLanguageModel>(language);
                return mappedLanguageListModel;
            }
        }
    }
}
