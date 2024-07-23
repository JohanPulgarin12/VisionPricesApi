using Entities.Core;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly ConfigurationSectionWebApi _config;
        private readonly EmailConfiguration _configEmail;
        private readonly IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration, IOptions<ConfigurationSectionWebApi> config, IOptions<EmailConfiguration> configEmail)
        {
            this._config = config.Value;
            _configuration = configuration;
            _service = new UsuarioService(_config, _configEmail);
        }


        [HttpGet]
        [Route("GetUsuario")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<Usuario>> GetUsuario()
        {
            var response = _service.GetUsuario();
            return response.Result;
        }

        [HttpPost]
        [Route("PostUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> PostUser([FromBody] Usuario usuario)
        {
            var response = _service.AddUser(usuario);
            return response.Result;
        }

        [HttpPost]
        [Route("PutUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> PutUser([FromBody] Usuario usuario)
        {
            var response = _service.PutUser(usuario);
            return response.Result;
        }

        [HttpPost]
        [Route("DeleteUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> DeleteUser([FromForm] int id)
        {
            var response = _service.DeleteUser(id);
            return response.Result;
        }

        [HttpPost]
        [Route("UpdateState")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> UpdateState([FromForm] string identi)
        {
            var response = _service.UpdateState(identi);
            return response.Result;
        }

        [HttpPost]
        [Route("GetUserByIdentificacion")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Usuario> GetUserByIdentificacion([FromForm] string identi)
        {
            var response = _service.GetUsuarioByIdentificacion(identi);
            return response.Result;
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<UsuarioLogin> Login([FromForm] string identi, [FromForm] string password)
        {
            var response = _service.Login(identi, password);
            return response.Result;
        }

        [HttpPost]
        [Route("SendEmail")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> SendEmail([FromForm] string identificacion)
        {
            var response = _service.SendEmail(_configuration["EmailConfiguration:SmtpUsername"], _configuration["EmailConfiguration:SmtpServer"], _configuration["EmailConfiguration:SmtpPassword"], identificacion);
            return response;
        }

        [HttpPost]
        [Route("ForgotEmail")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> ForgotEmail([FromForm] string username, [FromForm] string identificacion, [FromForm] string telefono)
        {
            var response = _service.ForgotEmail(_configuration["EmailConfiguration:SmtpUsername"], _configuration["EmailConfiguration:SmtpServer"], _configuration["EmailConfiguration:SmtpPassword"], username, identificacion, telefono);
            return response;
        }

        [HttpPost]
        [Route("ChangeEmail")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> ChangeEmail([FromForm] string oldPass, [FromForm] string newPass, [FromForm] string identificacion)
        {
            var response = _service.ChangeEmail(_configuration["EmailConfiguration:SmtpUsername"], _configuration["EmailConfiguration:SmtpServer"], _configuration["EmailConfiguration:SmtpPassword"], oldPass, newPass, identificacion);
            return response;
        }

        [HttpPost]
        [Route("GetUsuarioCiudad")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<CiudadUsuario>> GetUsuarioCiudad([FromForm] int idUsuario)
        {
            var response = _service.GetUsuarioCiudad(idUsuario);
            return response.Result;
        }

        [HttpPost]
        [Route("GetUsuarioPermiso")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<int>> GetUsuarioPermiso([FromForm] string identiUser)
        {
            var response = _service.GetUsuarioPermiso(identiUser);
            return response.Result;
        }
    }
}