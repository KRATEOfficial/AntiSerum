using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AntiSerum.Client.Models;
using AntiSerum.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AntiSerum.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchWordController : ControllerBase
    {
        public SearchWordController(WordSearchService wordSearchService) 
        {
            this.WordSearchService = wordSearchService;
    
        }

        public WordSearchService WordSearchService { get; }

        /// <summary>
        /// Method to simply call the search method inside WordSearchService and return the appriorate response
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] string word)
        {
            bool isFound = WordSearchService.search(word);

            if (isFound)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
