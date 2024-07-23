using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Core
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int Rol { get; set; }
        public bool Estado { get; set; }
        public bool NewUser { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public int Ciudad { get; set; }

    }
}