using Entities.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Models.Repositories.Interfaces
{
    public interface IImagenRepository
    {
        List<Imagen> GetImage();
        int AddImage(Imagen imagen);
        bool PutImage(Imagen imagen);

    }
}
