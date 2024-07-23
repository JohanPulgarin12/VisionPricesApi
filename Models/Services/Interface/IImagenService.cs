using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Utils.Util;
using System.Drawing;
using Entities.Core;

namespace Models.Services.Interface
{
    public interface IImagenService
    {
        ResultOperation<List<Imagen>> GetImage();
        ResultOperation<int> AddImage(Imagen imagen);
        ResultOperation<bool> PutImage(Imagen imagen);

    }
}
