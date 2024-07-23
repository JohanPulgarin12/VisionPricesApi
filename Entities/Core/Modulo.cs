using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Core
{
    public class Modulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int ManoDeObra { get; set; }
        public string Resumen { get; set; }
        public int FileDetalles { get; set; }
        public int ImagenDetalles { get; set; }
        public int ImagenCarrusel { get; set; }

    }
}
