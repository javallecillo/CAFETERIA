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
    public partial class PedidosPorFechaGeneral : Form
    {
        public PedidosPorFechaGeneral()
        {
            InitializeComponent();
        }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        private void PedidosPorFechaGeneral_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSetPrincipal.MostrarPedidosDelDiaPorUsuario' Puede moverla o quitarla según sea necesario.
            this.mostrarPedidosPorFechaGeneralTableAdapter.Fill(this.dataSetPrincipal.MostrarPedidosPorFechaGeneral, FechaInicio, FechaFin);

            this.reportViewer1.RefreshReport();
        }
    }
}
