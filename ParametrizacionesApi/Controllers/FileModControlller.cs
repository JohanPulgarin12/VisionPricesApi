using Entities.DTO;
using Microsoft.Extensions.Options;
using Models.Services.Interface;
using Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities.Core;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ParametrizacionesApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FileModController: Controller
    {
        private readonly ConfigurationSectionWebApi _config;
        private readonly IFileModService _service;

        public FileModController(IOptions<ConfigurationSectionWebApi> config)
        {
            this._config = config.Value;
            _service = new FileModService(_config);
        }

        [HttpGet]
        [Route("GetFile")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<FileMod>> GetFile()
        {
            var response = _service.GetFile();
            return response.Result;
        }

        [HttpPost]
        [Route("PostFile")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<int> PostFile([FromBody] FileMod fileMod)
        {
            var response = _service.AddFile(fileMod);
            return response.Result;
        }

        [HttpPost]
        [Route("PutFile")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> PutFile([FromBody] FileMod fileMod)
        {
            var response = _service.PutFile(fileMod);
            return response.stateOperation;

        }

    }
}
