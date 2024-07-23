using Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Repositories.Interfaces
{
    public interface IRolRepository
    {
        List<Rol> GetRol();
        List<Permiso> GetPermiso();
        int PostRol(Rol rol);
        bool PutRol(Rol rol);
        bool DeleteRol(int id);
        List<Permiso> GetRolPermiso(int idRol);
        bool AddRolPermiso(RolPermiso rolPermiso);
        bool DeleteRolPermiso(int idRol);
    }
}
