using Dapper;
using Entities.Core;
using Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Repositories
{
    public class UsuarioRepository : Repository, IUsuarioRepository
    {
        public List<Usuario> GetUsuario()
        {
            var response = GetDataListOfProcedure<Usuario>("SpVt_GetUsuario");
            return response;
        }

        public bool AddUser(Usuario usuario)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Nombre", usuario.Nombre);
            prms.Add("Apellido", usuario.Apellido);
            prms.Add("Username", usuario.Username);
            prms.Add("Email", usuario.Email);
            prms.Add("Pass", usuario.Pass);
            prms.Add("Rol", usuario.Rol);
            prms.Add("Estado", usuario.Estado);
            prms.Add("NewUser", usuario.NewUser);
            prms.Add("Identificacion", usuario.Identificacion);
            prms.Add("Telefono", usuario.Telefono);
            prms.Add("Ciudad", usuario.Ciudad);
            string sql = @"INSERT INTO Usuario
                            (Nombre, Apellido, Username, Email, Pass, Rol, Estado, NewUser,Identificacion,Telefono,Ciudad)
                            VALUES (@Nombre, @Apellido, @Username, @Email, @Pass, @Rol, @Estado, @NewUser, @Identificacion, @Telefono, @Ciudad)";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;
        }

        public bool PutUser(Usuario usuario)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Nombre", usuario.Nombre);
            prms.Add("Apellido", usuario.Apellido);
            prms.Add("Username", usuario.Username);
            prms.Add("Email", usuario.Email);
            prms.Add("Pass", usuario.Pass);
            prms.Add("Rol", usuario.Rol);
            prms.Add("Estado", usuario.Estado);
            prms.Add("NewUser", usuario.NewUser);
            prms.Add("Identificacion", usuario.Identificacion);
            prms.Add("Telefono", usuario.Telefono);
            prms.Add("Ciudad", usuario.Ciudad);
            string sql = @"UPDATE Usuario
                            SET Nombre = @Nombre,
                            Apellido = @Apellido,
                            Username = @Username,
                            Email = @Email,
                            Pass = @Pass,
                            Rol = @Rol,
                            Estado = @Estado,
                            NewUser = @NewUser,
                            Telefono = @Telefono,
                            Ciudad = @Ciudad
                            WHERE Identificacion = @Identificacion";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;
        }

        public bool DeleteUser(int id)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Id", id);
            string sql = @"DELETE FROM Usuario
                            WHERE Id = @Id";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;
        }

        public Usuario GetUsuarioByIdentificacion(string identificacion)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Identificacion", identificacion);
            var sql = @" SELECT Id, Nombre, Apellido, Username, Email, Pass, Rol, Estado, NewUser, Identificacion, Telefono, Ciudad FROM Usuario WHERE Identificacion = @Identificacion";
            return Get<Usuario>(sql, prms);
        }

        public List<int> GetUsuarioPermiso(string identiUser)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Identificacion", identiUser);
            string sql = @"SELECT P.Id From Usuario U
                            INNER JOIN RolPermiso RP ON RP.IdRol = U.Rol
                            INNER JOIN Permiso P ON P.Id = RP.IdPermiso
                            WHERE U.Identificacion = @Identificacion";
            var response = GetList<int>(sql, prms);
            return response;
        }

        public List<CiudadUsuario> GetUsuarioCiudad (int idUsuario)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("IdCiudad", idUsuario);
            string sql = @" SELECT C.Id, C.Ciudad FROM Usuario U 
                    INNER JOIN Ciudad C ON C.Id = U.Ciudad 
                    WHERE U.Id = @IdCiudad";
            var response = GetList<CiudadUsuario>(sql, prms);
            return response;
        }
    }
}
