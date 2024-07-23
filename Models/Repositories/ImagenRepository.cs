using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using Dapper;
using Entities.Core;
using Models.Repositories.Interfaces;


namespace Models.Repositories
{
    public class ImagenRepository : Repository, IImagenRepository
    {

        public List<Imagen> GetImage()
        {
            string sql = @"SELECT * FROM ImgModulo";
            var response = GetList<Imagen>(sql);
            return response;

        }

        public int AddImage(Imagen imagen)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("ImagenNombre", imagen.ImagenNombre);
            prms.Add("ImagenExtension", imagen.ImagenExtension);
            prms.Add("ImagenByte", imagen.ImagenByte);
            string sql = @"INSERT INTO ImgModulo (ImagenNombre, ImagenExtension, ImagenByte) values (@ImagenNombre, @ImagenExtension, @ImagenByte)
                        SELECT @@IDENTITY";
            var response = Get<int>(sql, prms);
            return response;
        }

        public bool PutImage(Imagen imagen)
        {
            DynamicParameters prms = new DynamicParameters();
            prms.Add("Id", imagen.Id);
            prms.Add("ImagenNombre", imagen.ImagenNombre);
            prms.Add("ImagenExtension", imagen.ImagenExtension);
            prms.Add("ImagenByte", imagen.ImagenByte);
            string sql = @"UPDATE ImgModulo
                            SET ImagenNombre = @ImagenNombre,
                                ImagenExtension = @ImagenExtension,
                                ImagenByte = @ImagenByte
                        WHERE Id = @Id";
            var response = Execute<bool>(sql, prms) == 1 ? true : false;
            return response;

        }



    }
}
