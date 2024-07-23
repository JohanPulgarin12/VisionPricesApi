using Dapper;
using Entities.Core;
using Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Repositories
{
    public class CiudadUsuarioRepository: Repository, ICiudadUsuarioRepository
    {
        public List<CiudadUsuario> GetCiudad()
        {
            var response = GetDataListOfProcedure<CiudadUsuario>("SpVt_Ciudad");
            return response;
        }

        public bool AddCiudad(CiudadUsuario ciudadUsuario)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Ciudad", ciudadUsuario.Ciudad);
            string sql = @"INSERT INTO Ciudad
                            (Ciudad)
                            VALUES (@Ciudad)";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;
        }

        public bool PutCiudad(CiudadUsuario ciudadUsuario)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Id", ciudadUsuario.Id);
            prms.Add("Ciudad", ciudadUsuario.Ciudad);
            string sql = @"UPDATE Ciudad
                            SET Ciudad = @Ciudad
                        WHERE Id = @Id";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;
        }

        public bool DeleteCiudad(int id)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Id", id);
            string sql = @"DELETE FROM Ciudad
                            WHERE Id = @id";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;
        }

    }
}
