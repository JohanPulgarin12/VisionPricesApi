using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Core
{
    public class Rol
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public List<Permiso> ArrayPermiso { get; set; }
    }
}
