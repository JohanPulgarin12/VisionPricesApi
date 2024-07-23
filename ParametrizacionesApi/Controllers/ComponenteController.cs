using Entities.Core;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.Services;
using Models.Services.Interface;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ParametrizacionesApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ComponenteController : Controller
    {

        private readonly ConfigurationSectionWebApi _config;
        private readonly IComponenteService _service;

        public ComponenteController(IOptions<ConfigurationSectionWebApi> config)
        {
            this._config = config.Value;
            _service = new ComponenteService(_config);
        }

        [HttpGet]
        [Route("GetComponente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<Componente>> GetComponente()
        {
            var response = _service.GetComponente();
            return response.Result;
        }

        [HttpPost]
        [Route("PostComponente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> PostComponente([FromBody] Componente componente)
        {
            var response = _service.AddComponente(componente);
            return response.stateOperation;
        }

        [HttpPost]
        [Route("PutComponente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> PutComponente([FromBody] Componente componente)
        {
            var response = _service.PutComponente(componente);
            return response.stateOperation;
        }

        [HttpPost]
        [Route("DeleteComponente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> DeleteComponente([FromForm] int id)
        {
            var response = _service.DeleteComponente(id);
            return response.stateOperation;
        }

        [HttpPost]
        [Route("GetImagenComponente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Imagen> GetImagenComponente([FromForm] int idComponente)
        {
            var response = _service.GetImagenComponente(idComponente);
            return response.Result;
        }

    }
}