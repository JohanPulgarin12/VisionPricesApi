using Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Repositories.Interfaces
{
    public interface IModuloRepository
    {
        List<Modulo> GetModulo();
        int AddModulo(Modulo modulo);
        bool PutModulo(Modulo modulo);
        bool DeleteModulo(int id);
        List<Componente> GetModuloComponente(int idModulo);
        bool AddModuloComponente(ModuloComponente moduloComponente);
        bool PutModuloComponente(ModuloComponente moduloComponente);
        bool DeleteModuloComponente(ModuloComponente moduloComponente);
        Imagen GetImagenModulo(int idModulo);
        Imagen GetImagenCarrusel(int idCarrusel);
        FileMod GetFileModulo(int idModulo);
    }
}
