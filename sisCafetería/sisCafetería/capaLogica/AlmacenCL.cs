using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sisCafetería.capaDatos;

namespace sisCafetería.capaLogica
{
    internal class AlmacenCL
    {
        public int IdAlmacen { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public string UnidadMedida { get; set; }
    }
}
