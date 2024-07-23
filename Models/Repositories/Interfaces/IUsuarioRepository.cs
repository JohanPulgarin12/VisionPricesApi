using Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetUsuario();
        bool AddUser(Usuario usuario);
        bool PutUser(Usuario usuario);
        bool DeleteUser(int id);
        Usuario GetUsuarioByIdentificacion(string identificacion);
        List<CiudadUsuario> GetUsuarioCiudad(int idUsuario);
        List<int> GetUsuarioPermiso(string identiUser);
        //bool AddUsuarioPermiso(UsuarioPermiso usuarioPermiso);

    }
}
