using Domain;
using System.Collections.Generic;

namespace Business
{
    public interface ISearchStore
    {
        SearchResponse GetSearchResult(SearchFilter filter);
    }
}
