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
    public partial class Entradas : Form
    {
        EntradasCD oEntradasCD;

        public Entradas()
        {
            oEntradasCD = new EntradasCD();
            InitializeComponent();
            LlenarData();
            LimpiarTextBox();
        }

        private void cbNombreProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Verifica si el SelectedValue es válido y diferente de null
                if (cbNombreProducto.SelectedValue != null && cbNombreProducto.SelectedValue is int idProducto)
                {
                    // Obtener el precio unitario desde la base de datos
                    decimal precioUnitario = ObtenerPrecioUnitario(idProducto);

                    // Muestra el precio unitario en un campo de texto
                    txtPrecioUnitario.Text = precioUnitario.ToString("0.00");

                    // Verificar si el campo de cantidad está vacío
                    if (string.IsNullOrWhiteSpace(txtCantidad.Text))
                    {
                        txtCosto.Clear();  // Limpiar el campo de PrecioTotal si cantidad está vacía
                    }
                    else
                    {
                        // Si la cantidad no está vacía, recalcular el PrecioTotal
                        decimal cantidad = Convert.ToDecimal(txtCantidad.Text);
                        decimal costoTotal = precioUnitario * cantidad;
                        txtCosto.Text = costoTotal.ToString("0.00");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el precio unitario: " + ex.Message);
            }
        }

        private decimal ObtenerPrecioUnitario(int idProducto)
        {
            decimal precioUnitario = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source= ARTURO\\SQLEXPRESS; Initial Catalog=db_cafeteria; Integrated Security =True"))
                {
                    string query = "SELECT PrecioUnitario FROM Almacen WHERE IdAlmacen = @IdAlmacen";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdAlmacen", idProducto);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        precioUnitario = Convert.ToDecimal(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar el precio unitario: " + ex.Message);
            }

            return precioUnitario;
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCantidad.Text) && cbNombreProducto.SelectedValue != null)
                {
                    int cantidad = int.Parse(txtCantidad.Text);
                    decimal precioUnitario = decimal.Parse(txtPrecioUnitario.Text); // Asumiendo que el precio está en txtPrecioUnitario

                    // Calcular el costo total
                    decimal costoTotal = cantidad * precioUnitario;

                    // Mostrar el resultado
                    txtCosto.Text = costoTotal.ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                txtCosto.Text = "0.00"; // Restablecer si hay error
                MessageBox.Show("Error al calcular el costo total: " + ex.Message);
            }
        }

        // Este método se llamará desde el formulario principal (Inicio)
        public void LlenarCamposDeEntrada()
        {
            // Obtener la fecha actual
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

            // Asegurarse de que el usuario esté logueado correctamente
            if (UsuariosCL.UsuarioActual != null)
            {
                // Usar el nombre de usuario guardado para obtener el IdUsuario
                int idUsuario = new UsuariosCD().ObtenerIdUsuarioPorNombre(UsuariosCL.UsuarioActual.Usuario);

                if (idUsuario != -1)
                {
                    // Asignar el IdUsuario al campo correspondiente (por ejemplo, en un ComboBox)
                    cbUsuario.SelectedValue = idUsuario;
                }
                else
                {
                    MessageBox.Show("Error al obtener el IdUsuario.");
                }
            }
        }



        private void LimpiarTextBox()
        {
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBuscarFrm.Enabled = false;

            cbNombreProducto.Enabled = false;
            txtCantidad.Enabled = false;
            txtObservaciones.Enabled = false;
            txtCosto.Enabled = false;

            cbNombreProducto.SelectedIndex = -1;
            txtFecha.Clear();
            txtObservaciones.Clear();
            txtCantidad.Clear();
            txtCosto.Clear();
            txtPrecioUnitario.Clear();
            cbUsuario.SelectedIndex = -1;
            

            txtBuscar.Clear();
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        public void LlenarData()
        {
            var dataset = oEntradasCD.MostrarEntradas();
            if (dataset.Tables.Count > 0)
            {
                dataEntradas.DataSource = dataset.Tables[0];

                dataEntradas.Columns[0].HeaderText = "ID";
                dataEntradas.Columns[1].HeaderText = "Producto";
                dataEntradas.Columns[2].HeaderText = "Fecha Entrada";
                dataEntradas.Columns[3].HeaderText = "Cantidad";
                dataEntradas.Columns[4].HeaderText = "Costo total";
                dataEntradas.Columns[5].HeaderText = "Usuario";
                dataEntradas.Columns[6].HeaderText = "Observaciones";

                // Ocultar la columna "IdAlmacen"
                if (dataEntradas.Columns["IdEntrada"] != null)
                {
                    dataEntradas.Columns["IdEntrada"].Visible = false;
                }
            }
            else
            {
                MessageBox.Show("No se encontraron registros.");
            };
        }

        private EntradasCL RecuperarInformacion()
        {
            EntradasCL oEntradasCL = new EntradasCL();

            int id =0 , cantidad = 0, idAlmacen = 0, idUsuario = 0;
            decimal costoTotal = 0;

            int.TryParse(txtId.Text, out id);
            int.TryParse(txtCantidad.Text, out cantidad);
            int.TryParse(cbNombreProducto.SelectedValue?.ToString(), out idAlmacen);
            int.TryParse(cbUsuario.SelectedValue?.ToString(), out idUsuario);
            decimal.TryParse(txtCosto.Text, out costoTotal);

            oEntradasCL.IdEntrada = id;
            oEntradasCL.IdAlmacen = idAlmacen;
            oEntradasCL.FechaEntrada = txtFecha.Text;
            oEntradasCL.Cantidad = cantidad;
            oEntradasCL.CostoTotal = costoTotal;
            oEntradasCL.IdUsuario = idUsuario;
            oEntradasCL.Observaciones = txtObservaciones.Text;

            return oEntradasCL;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            // Asegúrate de que la fila seleccionada sea válida
            if (indice >= 0 && indice < dataEntradas.Rows.Count)
            {
                dataEntradas.ClearSelection();

                btnAgregar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnCancelar.Enabled = true;
                btnBuscarFrm.Enabled = true;

                // Asignamos valores a los TextBox correspondientes
                txtId.Text = dataEntradas.Rows[indice].Cells[0].Value.ToString();
                cbNombreProducto.Text = dataEntradas.Rows[indice].Cells[1].Value.ToString();
                txtFecha.Text = dataEntradas.Rows[indice].Cells[2].Value.ToString();
                txtCantidad.Text = dataEntradas.Rows[indice].Cells[3].Value.ToString().Split(' ')[0];
                txtCosto.Text = dataEntradas.Rows[indice].Cells[4].Value.ToString();
                cbUsuario.Text = dataEntradas.Rows[indice].Cells[5].Value.ToString();
                txtObservaciones.Text = dataEntradas.Rows[indice].Cells[6].Value.ToString();

            }
        }

        private void activarBox()
        {
            txtCantidad.Enabled = true;
            txtObservaciones.Enabled = true;
            txtCosto.Enabled = true;
        }

        private void panelEntradas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                oEntradasCD.Eliminar(RecuperarInformacion());
                LimpiarTextBox();
                MostrarMensaje("El registro ha sido eliminado.");
                LlenarData();
            }
            else
            {
                LimpiarTextBox();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarTextBox();
            btnEditar.Text = "Editar";
            btnAgregar.Text = "Agregar";
            LlenarData();
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
                btnBuscarFrm.Enabled = true;
                LlenarCamposDeEntrada();
            }
            else if (btnEditar.Text == "Guardar")
            {
                oEntradasCD.Editar(RecuperarInformacion());
                LlenarData();

                LimpiarTextBox();

                MostrarMensaje("El registro ha sido actualizado.");

                btnEditar.Text = "Editar";
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            LlenarCamposDeEntrada();

            if (btnAgregar.Text == "Agregar")
            {
                activarBox();

                btnAgregar.Text = "Guardar";
                btnCancelar.Enabled = true;
                btnBuscarFrm.Enabled = true;
            }
            else if (btnAgregar.Text == "Guardar")
            {
                oEntradasCD.Agregar(RecuperarInformacion());
                LlenarData();

                LimpiarTextBox();

                MostrarMensaje("Registro agregado con éxito.");

                btnAgregar.Text = "Agregar";
                btnCancelar.Enabled = false;
                btnBuscarFrm.Enabled = false;
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarFrm_Click(object sender, EventArgs e)
        {
            BuscarAlmacen buscarAlmacenForm = new BuscarAlmacen();
            buscarAlmacenForm.Owner = this; // Establece el formulario principal como propietario
            buscarAlmacenForm.ShowDialog(); // Muestra el formulario como diálogo modal
        }

        private void Entradas_Load(object sender, EventArgs e)
        {
            cbNombreProducto.Items.Clear();

            AlmacenCD objAlmacen = new AlmacenCD();

            cbNombreProducto.DataSource = objAlmacen.MostrarAlmacenParaComboBox().Tables[0];
            cbNombreProducto.DisplayMember = "Nombre";
            cbNombreProducto.ValueMember = "IdAlmacen";

            UsuariosCD objUsuario = new UsuariosCD();

            cbUsuario.DataSource = objUsuario.MostrarUsuarios().Tables[0];
            cbUsuario.DisplayMember = "Usuario";
            cbUsuario.ValueMember = "IdUsuario";

            LlenarCamposDeEntrada();
            LimpiarTextBox();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string entradaABuscar = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(entradaABuscar))
            {
                DataSet resultados = oEntradasCD.BuscarEntradaPorNombre(entradaABuscar);

                dataEntradas.DataSource = resultados.Tables[0];

                dataEntradas.Columns[0].HeaderText = "ID";
                dataEntradas.Columns[1].HeaderText = "Producto";
                dataEntradas.Columns[2].HeaderText = "Fecha Entrada";
                dataEntradas.Columns[3].HeaderText = "Cantidad";
                dataEntradas.Columns[4].HeaderText = "Costo total";
                dataEntradas.Columns[5].HeaderText = "Usuario";
                dataEntradas.Columns[6].HeaderText = "Observaciones";

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
