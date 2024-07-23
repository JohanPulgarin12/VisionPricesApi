using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Core
{
    public class Imagen
    {
        public int Id { get; set; }
        public string ImagenNombre { get; set; }
        public string ImagenExtension { get; set; }
        public byte[] ImagenByte { get; set;}
    }
}
