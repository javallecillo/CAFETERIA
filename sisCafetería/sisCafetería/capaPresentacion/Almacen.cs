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
    public partial class Almacen : Form
    {
        AlmacenCD oAlmacenCD;

        public Almacen()
        {
            oAlmacenCD = new AlmacenCD();
            InitializeComponent();
            LlenarData();
            LimpiarTextBox();
        }

        private void LimpiarTextBox()
        {
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;

            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
            txtUnidad.Enabled = false;

            txtId.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtUnidad.Clear();
            txtBuscar.Clear();

            label2.Visible = false;
            txtStock.Visible = false;
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LlenarData()
        {
            dataAlmacen.DataSource = oAlmacenCD.MostrarAlmacen().Tables[0];

            dataAlmacen.Columns[0].HeaderText = "ID";
            dataAlmacen.Columns[1].HeaderText = "Nombre";
            dataAlmacen.Columns[2].HeaderText = "Descripción";
            dataAlmacen.Columns[3].HeaderText = "Precio unitario";
            dataAlmacen.Columns[4].HeaderText = "Stock";

            // Ocultar la columna "IdAlmacen"
            if (dataAlmacen.Columns["IdAlmacen"] != null)
            {
                dataAlmacen.Columns["IdAlmacen"].Visible = false;
            }
        }

        private AlmacenCL RecuperarInformacion()
        {
            AlmacenCL oAlmacenCL = new AlmacenCL();

            int id = 0, stock = 0;
            decimal precioUnitario = 0;

            int.TryParse(txtId.Text, out id);
            int.TryParse(txtStock.Text, out stock);
            decimal.TryParse(txtPrecio.Text, out precioUnitario);

            oAlmacenCL.IdAlmacen = id;
            oAlmacenCL.Nombre = txtNombre.Text;
            oAlmacenCL.Descripcion = txtDescripcion.Text;
            oAlmacenCL.PrecioUnitario = precioUnitario;
            oAlmacenCL.Stock = stock;
            oAlmacenCL.UnidadMedida = txtUnidad.Text;

            return oAlmacenCL;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            // Asegúrate de que la fila seleccionada sea válida
            if (indice >= 0 && indice < dataAlmacen.Rows.Count)
            {
                dataAlmacen.ClearSelection();

                btnAgregar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnCancelar.Enabled = true;

                label2.Visible = true;
                txtStock.Visible = true;

                // Asignamos valores a los TextBox correspondientes
                txtId.Text = dataAlmacen.Rows[indice].Cells[0].Value.ToString();
                txtNombre.Text = dataAlmacen.Rows[indice].Cells[1].Value.ToString();
                txtDescripcion.Text = dataAlmacen.Rows[indice].Cells[2].Value.ToString();
                txtPrecio.Text = dataAlmacen.Rows[indice].Cells[3].Value.ToString();

                // Separar el campo Stock/Unidad
                string stockUnidad = dataAlmacen.Rows[indice].Cells[4].Value.ToString(); // "50 unidades"

                // Separar el número (stock) y la unidad
                string[] partes = stockUnidad.Split(' ');  // Divide en el espacio

                if (partes.Length == 2)  // Si se pudo separar correctamente
                {
                    txtStock.Text = partes[0];  // El número (50)
                    txtUnidad.Text = partes[1];  // La unidad ("unidades")
                }
                else
                {
                    // En caso de que no se pueda separar correctamente
                    txtStock.Text = stockUnidad;  // Dejar todo el valor en Stock si no se puede separar
                    txtUnidad.Text = string.Empty;  // Dejar Unidad vacío
                }
            }
            else
            {
                MessageBox.Show("Fila no válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void activarBox()
        {
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;
            txtUnidad.Enabled = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (btnAgregar.Text == "Agregar")
            {
                activarBox();

                btnAgregar.Text = "Guardar";
                btnCancelar.Enabled = true;
            }
            else if (btnAgregar.Text == "Guardar")
            {
                oAlmacenCD.Agregar(RecuperarInformacion());
                LlenarData();

                LimpiarTextBox();

                MostrarMensaje("Agregado con éxito.");

                btnAgregar.Text = "Agregar";
                btnCancelar.Enabled = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (btnEditar.Text == "Editar")
            {
                activarBox();
                btnEditar.Text = "Guardar";
                btnAgregar.Enabled = false;
                btnEliminar.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else if (btnEditar.Text == "Guardar")
            {
                oAlmacenCD.Editar(RecuperarInformacion());
                LlenarData(); // Llamar para volver a llenar los datos con el formato combinado

                LimpiarTextBox();
                MostrarMensaje("El almacen ha sido actualizado.");

                btnEditar.Text = "Editar";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarTextBox();
            btnEditar.Text = "Editar";
            btnAgregar.Text = "Agregar";
            LlenarData();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                oAlmacenCD.Eliminar(RecuperarInformacion());
                LimpiarTextBox();
                MostrarMensaje("El registro ha sido eliminado.");
                LlenarData();
            }
            else
            {
                LimpiarTextBox();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string almacenABuscar = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(almacenABuscar))
            {
                DataSet resultados = oAlmacenCD.BuscarAlmacenPorNombre(almacenABuscar);

                dataAlmacen.DataSource = resultados.Tables[0];

                dataAlmacen.Columns[0].HeaderText = "ID";
                dataAlmacen.Columns[1].HeaderText = "Nombre";
                dataAlmacen.Columns[2].HeaderText = "Descripción";
                dataAlmacen.Columns[3].HeaderText = "Precio unitario";
                dataAlmacen.Columns[4].HeaderText = "Stock";

                LimpiarTextBox();
                btnCancelar.Enabled = true;
                btnAgregar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un nombre para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataIngredientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
