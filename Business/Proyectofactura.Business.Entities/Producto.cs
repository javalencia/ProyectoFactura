using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLayer
{
    public class Producto
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String marca { get; set; }
        public String referencia { get; set; }
        public Decimal precio { get; set; }
        public int cantidad { get; set; }
        public int id_categoria{ get; set; }
    }
}
