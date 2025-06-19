using System.Net;
using Microsoft.AspNetCore.Mvc;
using Sanura.Core.Interfaces.Services;

namespace Sanura.Server.Controllers
{
    [/*Authorize, */ApiController, Route("api/[controller]")]
    public class SyncController : ControllerBase
    {
        private readonly ISyncService syncService;

        public SyncController(ISyncService syncService)
        {
            this.syncService = syncService;
        }

        [HttpPost, Route("Download")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DownloadAsync(string idSeller)
        {
            var response = await this.syncService.DownloadAsync(idSeller);

            return Ok(response);
        }

        [HttpPost, Route("Upload")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UploadAsync(string fileBase64)
        {
            await this.syncService.UploadAsync(fileBase64);

            return Ok();
        }
    }
}