using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sisCafetería.capaDatos;
using sisCafetería.capaLogica;

namespace sisCafetería.capaPresentacion
{
    public partial class DetallePedidos : Form
    {
        private int idPedido;
        private PedidosCD oPedidosCD;

        public DetallePedidos(int idPedido)
        {
            InitializeComponent();
            this.idPedido = idPedido; // Asignar el ID del pedido recibido
            oPedidosCD = new PedidosCD(); // Inicializar la capa de datos
        }

        private void DetallePedidos_Load(object sender, EventArgs e)
        {
            // Llenar el DataGridView con los detalles del pedido
            CargarDetalles();
        }

        private void CargarDetalles()
        {
            try
            {
                // Obtener los detalles del pedido
                DataSet detalles = oPedidosCD.MostrarDetallePedidos(idPedido);

                // Mostrar los detalles en el DataGridView
                dataDetallesPedido.DataSource = detalles.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los detalles del pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
