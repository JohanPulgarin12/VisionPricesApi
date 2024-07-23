using Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Util;

namespace Models.Services.Interface
{
    public interface IComponenteService
    {
        ResultOperation<List<Componente>> GetComponente();
        ResultOperation<bool> AddComponente(Componente componente);
        ResultOperation<bool> PutComponente(Componente componente);
        ResultOperation<bool> DeleteComponente(int id);
        ResultOperation<Imagen> GetImagenComponente(int idComponente);

    }
}
