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
    public partial class Ingredientes : Form
    {
        IngredientesCD oIngredientesCD;

        public Ingredientes()
        {
            oIngredientesCD = new IngredientesCD();
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
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LlenarData()
        {
            dataIngredientes.DataSource = oIngredientesCD.MostrarIngredientes().Tables[0];

            dataIngredientes.Columns[0].HeaderText = "ID";
            dataIngredientes.Columns[1].HeaderText = "Nombre";
            dataIngredientes.Columns[2].HeaderText = "Descripción";
            dataIngredientes.Columns[3].HeaderText = "Precio unitario";
            dataIngredientes.Columns[4].HeaderText = "Stock";
        }

        private IngredientesCL RecuperarInformacion()
        {
            IngredientesCL oIngredientesCL = new IngredientesCL();

            int id = 0, stock = 0;
            decimal precioUnitario = 0;

            int.TryParse(txtId.Text, out id);
            int.TryParse(txtStock.Text, out stock);
            decimal.TryParse(txtPrecio.Text, out precioUnitario);

            oIngredientesCL.IdIngrediente = id;
            oIngredientesCL.Nombre = txtNombre.Text;
            oIngredientesCL.Descripcion = txtDescripcion.Text;
            oIngredientesCL.PrecioUnitario = precioUnitario;
            oIngredientesCL.Stock = stock;
            oIngredientesCL.UnidadMedida = txtUnidad.Text;

            return oIngredientesCL;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            // Asegúrate de que la fila seleccionada sea válida
            if (indice >= 0 && indice < dataIngredientes.Rows.Count)
            {
                dataIngredientes.ClearSelection();

                btnAgregar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnCancelar.Enabled = true;

                // Asignamos valores a los TextBox correspondientes
                txtId.Text = dataIngredientes.Rows[indice].Cells[0].Value.ToString();
                txtNombre.Text = dataIngredientes.Rows[indice].Cells[1].Value.ToString();
                txtDescripcion.Text = dataIngredientes.Rows[indice].Cells[2].Value.ToString();
                txtPrecio.Text = dataIngredientes.Rows[indice].Cells[3].Value.ToString();

                // Separar el campo Stock/Unidad
                string stockUnidad = dataIngredientes.Rows[indice].Cells[4].Value.ToString(); // "50 unidades"

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
                oIngredientesCD.Agregar(RecuperarInformacion());
                LlenarData();

                LimpiarTextBox();

                MostrarMensaje("Ingrediente agregado con éxito.");

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
                oIngredientesCD.Editar(RecuperarInformacion());
                LlenarData(); // Llamar para volver a llenar los datos con el formato combinado

                LimpiarTextBox();
                MostrarMensaje("El ingrediente ha sido actualizado.");

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
                oIngredientesCD.Eliminar(RecuperarInformacion());
                LimpiarTextBox();
                MostrarMensaje("El ingrediente ha sido eliminado.");
                LlenarData();
            }
            else
            {
                LimpiarTextBox();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string ingredienteABuscar = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(ingredienteABuscar))
            {
                DataSet resultados = oIngredientesCD.BuscarIngredientesPorNombre(ingredienteABuscar);

                dataIngredientes.DataSource = resultados.Tables[0];

                dataIngredientes.Columns[0].HeaderText = "ID";
                dataIngredientes.Columns[1].HeaderText = "Nombre";
                dataIngredientes.Columns[2].HeaderText = "Descripción";
                dataIngredientes.Columns[3].HeaderText = "Precio unitario";
                dataIngredientes.Columns[4].HeaderText = "Stock";

                LimpiarTextBox();
                btnCancelar.Enabled = true;
                btnAgregar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un nombre para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
