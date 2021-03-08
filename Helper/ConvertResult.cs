using Domain;
using System.Collections.Generic;

namespace Helper
{
    public class ConvertResult : IConvertResult
    {
        public SearchResponse ConvertSearchResult(string searchResult, string url)
        {
            List<string> webSites = new List<string>();
            List<int> pageNumbers = new List<int>();
            int count = 0;
            int pageNumber = 1;
            int pageCount = 1;
            int urlCount = 0;
            for (int i = 0; i < searchResult.Length; i++)
            {
                int startofIndex = searchResult.IndexOf("/url?q=");
                if (startofIndex != -1 && urlCount <= 100)
                {
                    urlCount++;
                    int endofIndex = searchResult.IndexOf(">", startofIndex);
                    webSites.Add(searchResult.Substring(startofIndex + 7, endofIndex - startofIndex + 1));
                    searchResult = searchResult.Substring(endofIndex, searchResult.Length - endofIndex);
                }
            }
            foreach (var item in webSites)
            {
                if (item.Contains(url))
                {
                    count++;
                    if (!pageNumbers.Contains(pageNumber))
                    {
                        pageNumbers.Add(pageNumber);
                    }
                }
                if (pageCount % 10 == 0)
                {
                    pageNumber++;
                }
                pageCount++;
            }
            if (pageNumbers.Count == 0)
            {
                pageNumbers.Add(0);
            }
            return new SearchResponse { Pages = pageNumbers , Count = count };
        }
    }
}
