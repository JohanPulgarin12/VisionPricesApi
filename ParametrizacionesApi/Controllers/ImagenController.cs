using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.Services.Interface;
using Models.Services;
using Entities.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Collections.Generic;


namespace ParametrizacionesApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenController : Controller
    {
        private readonly ConfigurationSectionWebApi _config;
        private readonly IImagenService _service;

        public ImagenController(IOptions<ConfigurationSectionWebApi> config)
        {
            this._config = config.Value;
            _service = new ImagenService(_config);
        }

        [HttpGet]
        [Route("GetImagen")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<Imagen>> GetImage()
        {
            var response = _service.GetImage();
            return response.Result;
        }

        [HttpPost]
        [Route("PostImagen")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<int> PostImagen([FromBody] Imagen imagen)
        {
            var response = _service.AddImage(imagen);
            return response.Result;
        }

        [HttpPost]
        [Route("PutImagen")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> PutImage([FromBody] Imagen imagen)
        {
            var response = _service.PutImage(imagen);
            return response.stateOperation;

        }
    }
}
