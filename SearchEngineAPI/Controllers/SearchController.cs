using Business;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchStore _searchStore;

        public SearchController(ISearchStore searchStore)
        {
            _searchStore = searchStore;
        }

        [Route("Index")]
        [HttpGet]
        public IActionResult Index([FromHeader]SearchFilter filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = _searchStore.GetSearchResult(filter);
            if (model == null) return NotFound();
            return Ok(model);
        }
    }
}
