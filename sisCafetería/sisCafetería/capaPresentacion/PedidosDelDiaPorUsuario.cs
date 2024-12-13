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
    public partial class PedidosDelDiaPorUsuario : Form
    {
        public PedidosDelDiaPorUsuario()
        {
            InitializeComponent();
        }

        public int IdUsuario {  get; set; }

        private void PedidosDelDiaPorUsuario_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSetPrincipal.MostrarPedidosDelDiaPorUsuario' Puede moverla o quitarla según sea necesario.
            this.mostrarPedidosDelDiaPorUsuarioTableAdapter.Fill(this.dataSetPrincipal.MostrarPedidosDelDiaPorUsuario, IdUsuario);

            this.reportViewer1.RefreshReport();
        }
    }
}
