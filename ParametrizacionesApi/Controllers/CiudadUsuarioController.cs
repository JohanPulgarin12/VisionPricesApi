using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.Services.Interface;
using Models.Services;
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
    public class CiudadUsuarioController : Controller
    {
        private readonly ConfigurationSectionWebApi _config;
        private readonly ICiudadUsuarioService _service;

        public CiudadUsuarioController(IOptions<ConfigurationSectionWebApi> config)
        {
            this._config = config.Value;
            _service = new CiudadUsuarioService(_config);
        }

        [HttpGet]
        [Route("GetCiudad")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<CiudadUsuario>> GetCiudad()
        {
            var response = _service.GetCiudad();
            return response.Result;
        }

        [HttpPost]
        [Route("PostCiudad")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> PostComponente([FromBody] CiudadUsuario ciudadUsuario)
        {
            var response = _service.AddCiudad(ciudadUsuario);
            return response.stateOperation;
        }

        [HttpPost]
        [Route("PutCiudad")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> PutCiudad([FromBody] CiudadUsuario ciudadUsuario)
        {
            var response = _service.PutCiudad(ciudadUsuario);
            return response.stateOperation;
        }

        [HttpPost]
        [Route("DeleteCiudad")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> DeleteCiudad([FromForm] int id)
        {
            var response = _service.DeleteCiudad(id);
            return response.stateOperation;
        }


    }
}
