using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using sisCafetería.capaDatos;
using sisCafetería.capaLogica;

namespace sisCafetería.capaPresentacion
{
    public partial class BuscarProducto : Form
    {
        ProductosCD oProductosCD;

        public BuscarProducto()
        {
            oProductosCD = new ProductosCD();
            InitializeComponent();
            LlenarData();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LlenarData()
        {
            dataProductosBuscar.DataSource = oProductosCD.MostrarProductosBuscar().Tables[0];

            dataProductosBuscar.Columns[1].HeaderText = "Nombre";
            dataProductosBuscar.Columns[2].HeaderText = "Precio";
            dataProductosBuscar.Columns[3].HeaderText = "Descripción";


            // Ocultar la columna "IdAlmacen"
            if (dataProductosBuscar.Columns["IdProducto"] != null)
            {
                dataProductosBuscar.Columns["IdProducto"].Visible = false;
            }
        }

        private void dataProductosBuscar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegúrate de que no sea el encabezado
            {
                // Obtén el valor de la celda que contiene el ID del producto
                int idProducto = Convert.ToInt32(dataProductosBuscar.Rows[e.RowIndex].Cells["IdProducto"].Value);

                // Pasa el valor al ComboBox del formulario principal (pedidos)
                ((Pedidos)this.Owner).cbNombreProducto.SelectedValue = idProducto;

                // Cierra el formulario de búsqueda
                this.Close();
            }
            else
            {
                MessageBox.Show("El formulario principal no contiene un ComboBox llamado 'cbNombreProducto'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string productoABuscar = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(productoABuscar))
            {
                DataSet resultados = oProductosCD.BuscarProductoPorNombre_MostrarSoloNombre(productoABuscar);

                dataProductosBuscar.DataSource = resultados.Tables[0];

                dataProductosBuscar.Columns[1].HeaderText = "Nombre";
                dataProductosBuscar.Columns[2].HeaderText = "Precio";
                dataProductosBuscar.Columns[3].HeaderText = "Descripción";

            }
            else
            {
                MessageBox.Show("Por favor, ingrese un nombre para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
