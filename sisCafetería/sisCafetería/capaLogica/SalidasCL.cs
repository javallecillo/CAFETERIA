using sisCafetería.capaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisCafetería.capaLogica
{
    internal class SalidasCL
    {
        public int IdSalida { get; set; }
        public int IdAlmacen { get; set; }
        public string FechaSalida { get; set; }
        public int Cantidad { get; set; }
        public int IdUsuario { get; set; }
        public string Observaciones { get; set; }
    }
}
