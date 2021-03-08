using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SearchResponse
    {
        public List<int> Pages { get; set; }
        public int Count { get; set; }
    }
}
