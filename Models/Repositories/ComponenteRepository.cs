        using Dapper;
using Entities.Core;
using Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Repositories
{
    public class ComponenteRepository : Repository, IComponenteRepository
    {
        public List<Componente> GetComponente()
        {
            var response = GetDataListOfProcedure<Componente>("SpVt_GetComponente");
            return response;
        }

        public bool AddComponente(Componente componente)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Codigo", componente.Codigo);
            prms.Add("Descripcion", componente.Descripcion);
            prms.Add("Costo", componente.Costo);
            prms.Add("Estado", componente.Estado);
            prms.Add("Opcional", componente.Opcional);
            prms.Add("ImagenComponente", componente.ImagenComponente);
            string sql = @"INSERT INTO Componente
                            (Codigo, Descripcion, Costo, Estado, Opcional, ImagenComponente)
                            VALUES (@Codigo, @Descripcion, @Costo, @Estado, @Opcional, @ImagenComponente)";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;
        }

        public bool PutComponente(Componente componente)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("id", componente.id);
            prms.Add("Codigo", componente.Codigo);
            prms.Add("Descripcion", componente.Descripcion);
            prms.Add("Costo", componente.Costo);
            prms.Add("Estado", componente.Estado);
            prms.Add("Opcional", componente.Opcional);
            prms.Add("ImagenComponente", componente.ImagenComponente);
            string sql = @"UPDATE Componente
                            SET Codigo = @Codigo,
                            Descripcion = @Descripcion,
                            Costo = @Costo,
                            Estado = @Estado,
                            Opcional = @Opcional,
                            ImagenComponente = @ImagenComponente
                        WHERE id = @id";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;
        }

        public bool DeleteComponente(int id)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Id", id);
            string sql = @"DELETE FROM Componente
                            WHERE Id = @id";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;
        }
        public Imagen GetImagenComponente(int idComponente)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("IdComponente", idComponente);
            string sql = @"SELECT I.id, I.ImagenNombre, I.ImagenExtension, I.ImagenByte FROM Componente C
                            INNER JOIN ImgModulo I ON I.Id = C.ImagenComponente
                            WHERE C.Id = @IdComponente";
            var response = Get<Imagen>(sql, prms);
            return response;
        }

    }
}
