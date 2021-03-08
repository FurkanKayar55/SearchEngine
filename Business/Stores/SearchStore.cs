using Domain;
using Helper;
using System.Collections.Generic;

namespace Business
{
    public class SearchStore : ISearchStore
    {
        private readonly IConvertResult _convertResult;
        private readonly RequestService _requestService;

        public SearchStore(IConvertResult convertResult)
        {
            _requestService = new RequestService(Constants.GoogleUrl, Constants.Num);
            _convertResult = convertResult;
        }

        public SearchResponse GetSearchResult(SearchFilter filter)
        {
            var data = _requestService.SendRequest<string>(filter);
            return _convertResult.ConvertSearchResult(data,filter.Url);
        }
    }
}
