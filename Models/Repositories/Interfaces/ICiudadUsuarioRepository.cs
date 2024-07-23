using Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Repositories.Interfaces
{
    public interface ICiudadUsuarioRepository
    {
        List<CiudadUsuario> GetCiudad();
        bool AddCiudad(CiudadUsuario ciudadUsuario);
        bool PutCiudad(CiudadUsuario ciudadUsuario);
        bool DeleteCiudad(int id);
    }
}
