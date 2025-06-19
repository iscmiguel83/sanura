using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sanura.Core.DTOs;
using Sanura.Core.Interfaces.Services;
using Sanura.Core.Model;

namespace Sanura.Server.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Request user collection
        /// </summary>
        /// <param name="options">Options to search records, pagination and export</param>
        /// <returns>User collection</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Options
        ///     {
        ///         "orderBy" : { "column": "", "isDesc":0 }, // Email, FirstName, LastName
        ///         "pagination" : { "pageNumber": 0, "pageSize" : 0 },
        ///         "filters": [
        ///                         { "key": "idUser",          "value": "int" },
        ///                         { "key": "Emaiil",          "value": "string" },
        ///                         { "key": "FirstName",       "value": "string" },
        ///                         { "key": "LastName",        "value": "string" },
        ///                         { "key": "Code",            "value": "string" },
        ///                         { "key": "Active",          "value": "boolean" },
        ///                    ]
        ///     }
        ///     
        /// </remarks>
        [HttpPost, Route("Get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseOptions<IEnumerable<UserDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromBody] RequestOptions options)
        {
            var response = await this.userService.GetAsync(options);

            return Ok(response);
        }

        [HttpPost, Route("Set")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SetAsync([FromBody] UserDto model)
        {
            await this.userService.SetAsync(model);

            return Ok();
        }
    }
}