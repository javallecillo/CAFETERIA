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
    public partial class PedidosDelDia : Form
    {
        public PedidosDelDia()
        {
            InitializeComponent();
        }

        private void PedidosDelDia_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSetPrincipal.MostrarPedidosDelDia' Puede moverla o quitarla según sea necesario.
            this.mostrarPedidosDelDiaTableAdapter.Fill(this.dataSetPrincipal.MostrarPedidosDelDia);

            this.reportViewer1.RefreshReport();
        }
    }
}
