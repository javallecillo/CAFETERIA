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
    public partial class BuscarAlmacen : Form
    {
        AlmacenCD oAlmacenCD;

        public BuscarAlmacen()
        {
            oAlmacenCD = new AlmacenCD();
            InitializeComponent();
            LlenarData();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LlenarData()
        {
            dataAlmacenBuscar.DataSource = oAlmacenCD.MostrarAlmacenBuscar().Tables[0];

            dataAlmacenBuscar.Columns[1].HeaderText = "Nombre";

            // Ocultar la columna "IdAlmacen"
            if (dataAlmacenBuscar.Columns["IdAlmacen"] != null)
            {
                dataAlmacenBuscar.Columns["IdAlmacen"].Visible = false;
            }
        }

        
        private void dataAlmacenBuscar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegúrate de que no sea el encabezado
            {
                // Obtén el valor de la celda que contiene el ID del producto
                int idProducto = Convert.ToInt32(dataAlmacenBuscar.Rows[e.RowIndex].Cells["IdAlmacen"].Value);

                // Verificar si el formulario principal tiene un control cbNombreProducto
                if (this.Owner != null)
                {
                    var comboBox = this.Owner.Controls.Find("cbNombreProducto", true).FirstOrDefault() as ComboBox;

                    if (comboBox != null)
                    {
                        // Asignar el valor seleccionado al ComboBox
                        comboBox.SelectedValue = idProducto;

                        // Cierra el formulario de búsqueda
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El formulario principal no contiene un ComboBox llamado 'cbNombreProducto'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo identificar el formulario principal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BuscarAlmacen_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string almacenABuscar = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(almacenABuscar))
            {
                DataSet resultados = oAlmacenCD.BuscarAlmacenPorNombre_MostrarSoloNombre(almacenABuscar);

                dataAlmacenBuscar.DataSource = resultados.Tables[0];

                dataAlmacenBuscar.Columns[1].HeaderText = "Nombre";

            }
            else
            {
                MessageBox.Show("Por favor, ingrese un nombre para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
