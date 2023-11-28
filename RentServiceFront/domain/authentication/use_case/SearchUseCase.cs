using System;
using RentServiceFront.domain.authentication.repository;

namespace RentServiceFront.domain.authentication.use_case;

public class SearchUseCase
{
    private ISearchRepository _searchRepository;

    public SearchUseCase(ISearchRepository searchRepository)
    {
        _searchRepository = searchRepository ?? throw new ArgumentException("Search repository can't be null");
    }
}