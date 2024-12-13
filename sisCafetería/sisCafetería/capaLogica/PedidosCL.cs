using sisCafetería.capaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisCafetería.capaLogica
{
    internal class PedidosCL
    {
        public int IdPedido { get; set; }
        public string Fecha { get; set; }
        public string TipoPedido { get; set; }
        public int? NumeroMesa { get; set; }
        public string FormaPago { get; set; }
        public int IdUsuario { get; set; }
        public decimal Total { get; set; }
    }
}
