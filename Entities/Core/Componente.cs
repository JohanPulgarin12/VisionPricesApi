using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Core
{
    public class Componente
    {
        public int id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Costo { get; set; }
        public int Cantidad { get; set; }
        public string Categoria { get; set; }
        public bool Estado { get; set; }
        public bool Opcional { get; set; }
        public int ImagenComponente { get; set; }
    }
}
