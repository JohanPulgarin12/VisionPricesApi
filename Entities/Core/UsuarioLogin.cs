using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Core
{
    public class UsuarioLogin
    {
        public string Username { get; set; }
        public bool NewUser { get; set; }
        public List<int> Permiso { get; set; }
    }
}
