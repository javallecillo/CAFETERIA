using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sisCafetería.capaPresentacion
{
    public partial class PedidosPorFechaYUsuario : Form
    {
        public PedidosPorFechaYUsuario()
        {
            InitializeComponent();
        }

        public int IdUsuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }

        private void PedidosPorFechaYUsuario_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSetPrincipal.MostrarPedidosDelDiaPorUsuario' Puede moverla o quitarla según sea necesario.
            this.mostrarPedidosPorFechaYUsuarioTableAdapter.Fill(this.dataSetPrincipal.MostrarPedidosPorFechaYUsuario, IdUsuario, FechaInicio, FechaFin);

            this.reportViewer1.RefreshReport();
        }
    }
}
