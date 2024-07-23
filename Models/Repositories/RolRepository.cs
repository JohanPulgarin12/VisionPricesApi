using Dapper;
using Entities.Core;
using Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Repositories
{
    public class RolRepository : Repository, IRolRepository
    {
        public List<Rol> GetRol()
        {
            var response = GetDataListOfProcedure<Rol>("SpVt_GetRol");
            return response;
        }

        public List<Permiso> GetPermiso()
        {
            var response = GetDataListOfProcedure<Permiso>("SpVt_GetPermiso");
            return response;
        }

        public int PostRol(Rol rol)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Titulo", rol.Titulo);
            prms.Add("Descripcion", rol.Descripcion);
            string sql = @"INSERT INTO Rol (Titulo, Descripcion)
                            VALUES (@Titulo, @Descripcion)
                            SELECT @@IDENTITY";
            var response = Get<int>(sql, prms);
            return response;
        }

        public bool PutRol(Rol rol)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Id", rol.Id);
            prms.Add("Titulo", rol.Titulo);
            prms.Add("Descripcion", rol.Descripcion);
            string sql = @"UPDATE Rol
                            SET Titulo = @Titulo,
                            Descripcion = @Descripcion
                            WHERE Id = @Id";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;
        }


        public bool DeleteRol(int id)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Id", id);
            string sql = @"DELETE FROM Rol
                            WHERE Id = @Id";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;
        }

        public List<Permiso> GetRolPermiso(int idRol)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("IdRol", idRol);
            string sql = @" SELECT P.Id, P.Nombre FROM RolPermiso RP
                    INNER JOIN Rol R ON R.Id = RP.IdRol
                    INNER JOIN Permiso P ON P.Id = RP.IdPermiso
                    WHERE R.Id = @IdRol";
            var response = GetList<Permiso>(sql, prms);
            return response;
        }

        public bool AddRolPermiso(RolPermiso rolPermiso)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("IdRol", rolPermiso.IdRol);
            prms.Add("IdPermiso", rolPermiso.IdPermiso);
            string sql = @"INSERT INTO RolPermiso(IdRol, IdPermiso) VALUES(@IdRol, @IdPermiso)";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;
        }

        public bool DeleteRolPermiso(int idRol)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("IdRol", idRol);
            string sql = @"DELETE FROM RolPermiso
                            WHERE IdRol = @IdRol";
            var response = Execute<bool>(sql, prms) > 0 ? true : false;
            return response;
        }
    }
}
