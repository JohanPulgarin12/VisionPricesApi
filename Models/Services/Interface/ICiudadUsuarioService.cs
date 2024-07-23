using Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Util;

namespace Models.Services.Interface
{
    public interface ICiudadUsuarioService
    {
        ResultOperation<List<CiudadUsuario>> GetCiudad();
        ResultOperation<bool> AddCiudad(CiudadUsuario ciudadUsuario);
        ResultOperation<bool> PutCiudad(CiudadUsuario ciudadUsuario);
        ResultOperation<bool> DeleteCiudad(int id);
    }
}
