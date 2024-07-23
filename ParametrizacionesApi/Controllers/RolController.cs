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
using Utils.Util;

namespace ParametrizacionesApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly ConfigurationSectionWebApi _config;
        private readonly IRolService _service;

        public RolController(IOptions<ConfigurationSectionWebApi> config)
        {
            this._config = config.Value;
            _service = new RolService(_config);
        }

        [HttpGet]
        [Route("GetRol")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<Rol>> GetRol()
        {
            var response = _service.GetRol();
            return response.Result;
        }

        [HttpGet]
        [Route("GetPermiso")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<Permiso>> GetPermiso()
        {
            var response = _service.GetPermiso();
            return response.Result;
        }

        [HttpPost]
        [Route("PostRol")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<int> PostRol([FromBody] Rol rol)
        {
            var response = _service.PostRol(rol);
            return response.Result;
        }

        [HttpPost]
        [Route("PutRol")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> PutRol([FromBody] RolPermiso rolPermiso)
        {
            var response = _service.PutRol(rolPermiso);
            return response.Result;
        }

        [HttpPost]
        [Route("DeleteRol")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> DeleteRol([FromForm] int id)
        {
            var response = _service.DeleteRol(id);
            return response.Result;
        }


        [HttpPost]
        [Route("GetRolPermiso")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<Permiso>> GetRolPermiso([FromForm] int idRol)
        {
            var response = _service.GetRolPermiso(idRol);
            return response.Result;
        }

        [HttpPost]
        [Route("PostRolPermiso")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> PostRolPermiso([FromBody] RolPermiso rolPermiso)
        {
            var response = _service.AddRolPermiso(rolPermiso);
            return response.Result;
        }

        [HttpPost]
        [Route("DeleteRolPermiso")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> DeleteRolPermiso([FromForm] int idRol)
        {
            var response = _service.DeleteRolPermiso(idRol);
            return response.Result;
        }



    }
}
