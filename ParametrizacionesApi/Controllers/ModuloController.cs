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
    public class ModuloController : ControllerBase
    {
        private readonly IModuloService _service;
        private readonly ConfigurationSectionWebApi _config;
        public ModuloController(IOptions<ConfigurationSectionWebApi> config)
        {
            this._config = config.Value;
            _service = new ModuloService(_config);
        }
        [HttpGet]
        [Route("GetModulo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<Modulo>> GetModulo()
        {
            var response = _service.GetModulo();
            return response.Result;
        }

        [HttpPost]
        [Route("PostModulo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<int> PostModulo([FromBody] Modulo modulo)
        {
            var response = _service.AddModulo(modulo);
            return response.Result;
        }
        [HttpPost]
        [Route("PutModulo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> PutModulo([FromBody] Modulo modulo)
        {
            var response = _service.PutModulo(modulo);
            return response.Result;
        }
        [HttpPost]
        [Route("DeleteModulo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> DeleteModulo([FromForm] int id)
        {
            var response = _service.DeleteModulo(id);
            return response.Result;
        }
        [HttpPost]
        [Route("GetModuloComponente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<Componente>> GetModuloComponente([FromForm] int idModulo)
        {
            var response = _service.GetModuloComponente(idModulo);
            return response.Result;
        }

        [HttpPost]
        [Route("PostModuloComponente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> AddModuloComponente([FromBody] ModuloComponente moduloComponente)
        {
            var response = _service.AddModuloComponente(moduloComponente);
            return response.Result;
        }

        [HttpPost]
        [Route("PutModuloComponente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> PutModuloComponente([FromBody] ModuloComponente moduloComponente)
        {
            var response = _service.PutModuloComponente(moduloComponente);
            return response.Result;
        }

        [HttpPost]
        [Route("DeleteModuloComponente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> DeleteModuloComponente([FromBody] ModuloComponente moduloComponente)
        {
            var response = _service.DeleteModuloComponente(moduloComponente);
            return response.Result;
        }

        [HttpPost]
        [Route("GetImagenModulo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Imagen> GetImagenModulo([FromForm] int idModulo)
        {
            var response = _service.GetImagenModulo(idModulo);
            return response.Result;
        }

        [HttpPost]
        [Route("GetImagenCarrusel")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Imagen> GetImagenCarrusel([FromForm] int idCarrusel)
        {
            var response = _service.GetImagenCarrusel(idCarrusel);
            return response.Result;
        }

        [HttpPost]
        [Route("GetFileModulo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<FileMod> GetFileModulo([FromForm] int idModulo)
        {
            var response = _service.GetFileModulo(idModulo);
            return response.Result;
        }

    }
}
