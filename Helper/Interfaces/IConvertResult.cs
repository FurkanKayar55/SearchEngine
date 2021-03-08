using Domain;
using System.Collections.Generic;

namespace Helper
{
    public interface IConvertResult
    {
        SearchResponse ConvertSearchResult(string searchResult, string url);
    }
}
