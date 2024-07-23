using Entities.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Util;

namespace Models.Services.Interface
{
    public interface IUsuarioService
    {
        ResultOperation<List<Usuario>> GetUsuario();
        ResultOperation<bool> AddUser(Usuario usuario);
        ResultOperation<bool> DeleteUser(int id);
        ResultOperation<bool> PutUser(Usuario usuario);
        ResultOperation<bool> UpdateState(string identi);
        ResultOperation<Usuario> GetUsuarioByIdentificacion(string identificacion);
        ResultOperation<UsuarioLogin> Login(string identificacion, string password);
        bool SendEmail(string fromEmail, string server, string fromPass, string identificacion);
        bool ForgotEmail(string fromEmail, string server, string fromPass, string username, string identificacion, string telefono);
        bool ChangeEmail(string fromEmail, string server, string fromPass, string oldPass, string newPass, string identificacion);
        ResultOperation<List<CiudadUsuario>> GetUsuarioCiudad(int idUsuario);
        ResultOperation<List<int>> GetUsuarioPermiso(string identiUser);
    }
}
