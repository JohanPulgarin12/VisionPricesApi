using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Core
{
    public class RolPermiso
    {
        public Rol Rol { get; set; }
        public List<int> Permiso { get; set; }
        public int IdRol { get; set; }
        public int IdPermiso { get; set; }
    }
}
