using Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Util;

namespace Models.Services.Interface
{
    public interface IRolService
    {
        ResultOperation<List<Rol>> GetRol();
        ResultOperation<List<Permiso>> GetPermiso();
        ResultOperation<int> PostRol(Rol rol);
        ResultOperation<bool> PutRol(RolPermiso rol);
        ResultOperation<bool> DeleteRol(int id);
        ResultOperation<List<Permiso>> GetRolPermiso(int idRol);
        ResultOperation<bool> AddRolPermiso(RolPermiso rolPermiso);
        ResultOperation<bool> DeleteRolPermiso(int idRol);
    }
}
