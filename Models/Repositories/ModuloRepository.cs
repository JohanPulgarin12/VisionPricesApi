using Dapper;
using Entities.Core;
using Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Repositories
{
    public class ModuloRepository : Repository, IModuloRepository
    {
        public List<Modulo> GetModulo()
        {
            var response = GetDataListOfProcedure<Modulo>("SpVt_GetModulo");
            return response;
        }

        public int AddModulo(Modulo modulo) 
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Codigo", modulo.Codigo);
            prms.Add("Descripcion", modulo.Descripcion);
            prms.Add("ManoDeObra", modulo.ManoDeObra);
            prms.Add("Resumen", modulo.Resumen);
            prms.Add("FileDetalles", modulo.FileDetalles);
            prms.Add("ImagenDetalles", modulo.ImagenDetalles);
            prms.Add("ImagenCarrusel", modulo.ImagenCarrusel);
            string sql = @"INSERT INTO Modulo
                            (Codigo, Descripcion, ManoDeObra, Resumen, FileDetalles, ImagenDetalles, ImagenCarrusel)
                            VALUES (@Codigo, @Descripcion, @ManoDeObra, @Resumen, @FileDetalles, @ImagenDetalles, @ImagenCarrusel)
                            SELECT @@IDENTITY";
            var response = Get<int>(sql, prms);
            return response;
        }

        public bool PutModulo(Modulo modulo)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Id", modulo.Id);
            prms.Add("Codigo", modulo.Codigo);
            prms.Add("Descripcion", modulo.Descripcion);
            prms.Add("ManoDeObra", modulo.ManoDeObra);
            prms.Add("Resumen",modulo.Resumen);
            prms.Add("FileDetalles", modulo.FileDetalles);
            prms.Add("ImagenDetalles", modulo.ImagenDetalles);
            prms.Add("ImagenCarrusel", modulo.ImagenCarrusel);
            string sql = @"UPDATE Modulo
                            SET Codigo = @Codigo,
                            Descripcion = @Descripcion,
                            ManoDeObra = @ManoDeObra,
                            Resumen = @Resumen,
                            FileDetalles = @FileDetalles,
                            ImagenDetalles = @ImagenDetalles,
                            ImagenCarrusel = @ImagenCarrusel
                        WHERE Id = @Id";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;
        }
        public bool DeleteModulo(int id)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Id", id);
            string sql = @"DELETE FROM Modulo
                            WHERE Id = @Id";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;
        }

        public List<Componente> GetModuloComponente(int idModulo)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("IdModulo", idModulo);
            string sql = @"SELECT C.id, C.Codigo, C.Descripcion, C.Costo, MC. Cantidad, MC. Categoria, C.Estado, C.Opcional FROM ModuloComponente MC
                            INNER JOIN Modulo M ON M.Id = MC.IdModulo
                            INNER JOIN Componente C ON C.Id = MC.IdComponente
                            WHERE MC.IdModulo = @IdModulo";
            var response = GetList<Componente>(sql, prms);
            return response;
        }

        public bool AddModuloComponente(ModuloComponente moduloComponente) 
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("IdModulo", moduloComponente.IdModulo);
            prms.Add("IdComponente", moduloComponente.IdComponente);
            prms.Add("Cantidad", moduloComponente.Cantidad);
            prms.Add("Categoria", moduloComponente.Categoria);
            string sql = @"INSERT INTO ModuloComponente(IdModulo, IdComponente, Cantidad, Categoria)
                            VALUES (@IdModulo, @IdComponente, @Cantidad, @Categoria)";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;
        }

        public bool PutModuloComponente(ModuloComponente moduloComponente)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("IdModulo", moduloComponente.IdModulo);
            prms.Add("IdComponente", moduloComponente.IdComponente);
            prms.Add("Cantidad", moduloComponente.Cantidad);
            prms.Add("Categoria", moduloComponente.Categoria);
            string sql = @"UPDATE ModuloComponente
                   SET Cantidad = @Cantidad,
                   Categoria = @Categoria
                   Where IdModulo = @IdModulo AND IdComponente = @IdComponente";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;

        }

        public bool DeleteModuloComponente( ModuloComponente moduloComponente)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("IdModulo", moduloComponente.IdModulo);
            prms.Add("IdComponente", moduloComponente.IdComponente);
            string sql = @"DELETE FROM ModuloComponente
                            WHERE IdModulo = @IdModulo AND IdComponente = @IdComponente";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;
        }

        public Imagen GetImagenModulo(int idModulo)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("IdModulo", idModulo);
            string sql = @"SELECT I.id, I.ImagenNombre, I.ImagenExtension, I.ImagenByte FROM Modulo M
                            INNER JOIN ImgModulo I ON I.Id = M.ImagenDetalles
                            WHERE M.Id = @IdModulo";
            var response = Get<Imagen>(sql, prms);
            return response;
        }
        public Imagen GetImagenCarrusel(int idCarrusel)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("IdCarrusel", idCarrusel);
            string sql = @"SELECT I.id, I.ImagenNombre, I.ImagenExtension, I.ImagenByte FROM Modulo M
                            INNER JOIN ImgModulo I ON I.Id = M.ImagenCarrusel
                            WHERE M.Id = @IdCarrusel";
            var response = Get<Imagen>(sql, prms);
            return response;
        }

        public FileMod GetFileModulo(int idModulo)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("IdModulo", idModulo);
            string sql = @"SELECT F.id, F.FileNameMod, F.FileExtension, F.FileByte FROM Modulo M
                            INNER JOIN FileMod F ON F.Id = M.FileDetalles
                            WHERE M.Id = @IdModulo";
            var response = Get<FileMod>(sql, prms);
            return response;
        }
    }
}