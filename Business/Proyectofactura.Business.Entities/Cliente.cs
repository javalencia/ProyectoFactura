using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLayer
{
    public class Cliente
    {

        public int id{ get; set; }
        public String nombre{ get; set; }
        public String cedula { get; set; }
        public String direccion { get; set; }
        public String telefono { get; set; }
        public String email { get; set; }
        public List<int> clientes { get; set; }
    }
}
