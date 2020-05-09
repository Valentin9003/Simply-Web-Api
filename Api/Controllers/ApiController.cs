using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Api.Data.Models;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly IApiService apiService;
        public ApiController(IApiService apiService)
        {
            this.apiService = apiService;
        }
     
        [HttpGet]
        [Route(nameof(GetAuthor))]
        public async Task<ActionResult<AuthorModel>> GetAuthor(string id)
        {
           var  author = await apiService.GetAuthorAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        [Route(nameof(CreateAuthor))]
        public async Task<ActionResult> CreateAuthor([FromBody]AuthorModel author)
        {
            var isCreated = await apiService.CreateAuthorAsync(author);

            if (isCreated)
            {
                return Ok();
            }

            return BadRequest("Something went wrong! No user created.");
        }

        [HttpDelete]
        [Route(nameof(DeleteAuthor))]
        public async Task<HttpResponseMessage> DeleteAuthor(string id)
        {
           var isSuccessed = await apiService.DeleteAuthorAsync(id);

            return new HttpResponseMessage(isSuccessed ? HttpStatusCode.Created : HttpStatusCode.NotFound);
        }

        [HttpPut]
        [Route(nameof(UpdateAuthor))]
        public async Task<ActionResult> UpdateAuthor([FromBody]AuthorModel author) 
        {
           var isSuccessed = await apiService.UpdateAuthorAsync(author);

            if (isSuccessed)
            {
                return Ok();
            }

            return BadRequest("Something went wrong! No user updated.");
        }

        [HttpGet]
        [Route(nameof(GetAuthorList))]
        public async Task<ActionResult<List<AuthorModel>>> GetAuthorList([FromQuery]AuthorsListModel rules)
        {
            if (apiService.CheckPropertyExist(rules.OrderBy) || apiService.CheckPropertyExist(rules.FilterBy))
            {
                return BadRequest("Incorect property name: 'OrderBy' or 'FilterBy'");
            }
            var result = await apiService.GetAuthorListAsync(rules);

            if (result == null || result.Count == 0)
            {
                return NotFound("No authors found for this criteria!");
            }

            return Ok(result);
        }
    }
}
