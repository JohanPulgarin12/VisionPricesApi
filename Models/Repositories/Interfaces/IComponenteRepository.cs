using Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Repositories.Interfaces
{
    public interface IComponenteRepository
    {
        List<Componente> GetComponente();
        bool AddComponente(Componente componente);
        bool PutComponente(Componente componente);
        bool DeleteComponente(int id);
        Imagen GetImagenComponente(int idComponente);

    }
}
