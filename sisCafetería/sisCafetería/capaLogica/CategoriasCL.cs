using sisCafetería.capaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisCafetería.capaLogica
{
    internal class CategoriasCL
    {
        private readonly CategoriasCD categoriasCD = new CategoriasCD();

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
