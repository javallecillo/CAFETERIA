using sisCafetería.capaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisCafetería.capaLogica
{
    internal class ProductosCL
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public int? Stock { get; set; }

    }
}
