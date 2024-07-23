using Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Util;

namespace Models.Services.Interface
{
    public interface IModuloService
    {
        ResultOperation<List<Modulo>> GetModulo();
        ResultOperation<int> AddModulo(Modulo modulo);
        ResultOperation<bool> PutModulo(Modulo modulo);
        ResultOperation<bool> DeleteModulo(int id);
        ResultOperation<List<Componente>> GetModuloComponente(int idModulo);
        ResultOperation<bool> AddModuloComponente(ModuloComponente moduloComponente);
        public ResultOperation<bool> PutModuloComponente(ModuloComponente moduloComponente);
        ResultOperation<bool> DeleteModuloComponente(ModuloComponente moduloComponente);
        ResultOperation<Imagen> GetImagenModulo(int idModulo);
        ResultOperation<Imagen> GetImagenCarrusel(int idCarrusel);
        ResultOperation<FileMod> GetFileModulo(int idModulo);
    }
}
