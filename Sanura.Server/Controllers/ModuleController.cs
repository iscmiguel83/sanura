using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sanura.Core.DTOs;
using Sanura.Core.Interfaces.Services;
using Sanura.Core.Model;

namespace Sanura.Server.Controllers
{
    [/*Authorize, */ApiController, Route("api/[controller]")]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService moduleService;

        public ModuleController(IModuleService moduleService)
        {
            this.moduleService = moduleService;
        }

        /// <summary>
        /// Request module collection
        /// </summary>
        /// <param name="options">Options to search records, pagination and export</param>
        /// <returns>Module collection</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Options
        ///     {
        ///         "orderBy" : { "column": "", "isDesc":0 }, // Code
        ///         "pagination" : { "pageNumber": 0, "pageSize" : 0 },
        ///         "filters": [
        ///                         { "key": "IdModule",      "value": "int" },
        ///                         { "key": "Code",            "value": "string" },
        ///                         { "key": "Active",          "value": "boolean" },
        ///                    ]
        ///     }
        ///     
        /// </remarks>
        [HttpPost, Route("Get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseOptions<IEnumerable<ModuleDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync([FromBody] RequestOptions options)
        {
            var response = await this.moduleService.GetAsync(options);

            return Ok(response);
        }

        [HttpPost, Route("Set")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SetAsync([FromBody] ModuleDto model)
        {
            await this.moduleService.SetAsync(model);

            return Ok();
        }
    }
}