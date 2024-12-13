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
    public partial class Salidas : Form
    {
        SalidasCD oSalidasCD;

        public Salidas()
        {
            oSalidasCD = new SalidasCD();
            InitializeComponent();
            LlenarData();
            LimpiarTextBox();
        }

        private void cbNombreProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Verificar si el SelectedValue es válido y diferente de null
                if (cbNombreProducto.SelectedValue != null && cbNombreProducto.SelectedValue is int idProducto)
                {
                    // Obtener el stock disponible desde la base de datos
                    int stockDisponible = ObtenerStockDisponible(idProducto);

                    // Mostrar el stock disponible en un campo de texto
                    txtStockDisponible.Text = stockDisponible.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el stock disponible: " + ex.Message);
            }
        }

        private int ObtenerStockDisponible(int idProducto)
        {
            int stockDisponible = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=ARTURO\\SQLEXPRESS; Initial Catalog=db_cafeteria; Integrated Security=True"))
                {
                    string query = "SELECT Stock FROM Almacen WHERE IdAlmacen = @IdAlmacen";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdAlmacen", idProducto);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        stockDisponible = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar el stock disponible: " + ex.Message);
            }

            return stockDisponible;
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCantidad.Text) && cbNombreProducto.SelectedValue != null)
                {
                    int cantidad = int.Parse(txtCantidad.Text);
                    int stockDisponible = int.Parse(txtStockDisponible.Text);

                    // Verificar si la cantidad solicitada es mayor que el stock disponible
                    if (cantidad > stockDisponible)
                    {
                        MessageBox.Show("No hay suficiente stock para realizar esta salida.");
                        txtCantidad.Clear(); // Limpiar la cantidad
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar la cantidad: " + ex.Message);
            }
        }

        // Este método se llamará desde el formulario principal (Inicio)
        public void LlenarCamposDeSalida()
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

            cbNombreProducto.SelectedIndex = -1;
            txtFecha.Clear();
            txtObservaciones.Clear();
            txtCantidad.Clear();
            txtStockDisponible.Clear();
            cbUsuario.SelectedIndex = -1;


            txtBuscar.Clear();
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LlenarData()
        {
            var dataset = oSalidasCD.MostrarSalidas(); // Llamar al método MostrarSalidas
            if (dataset.Tables.Count > 0)
            {
                dataSalidas.DataSource = dataset.Tables[0]; // Asignar el DataSet al DataGridView correspondiente

                // Configurar los encabezados de las columnas
                dataSalidas.Columns[0].HeaderText = "ID";
                dataSalidas.Columns[1].HeaderText = "Producto";
                dataSalidas.Columns[2].HeaderText = "Fecha Salida";
                dataSalidas.Columns[3].HeaderText = "Cantidad";
                dataSalidas.Columns[4].HeaderText = "Usuario";
                dataSalidas.Columns[5].HeaderText = "Observaciones";

                // Ocultar la columna "IdSalida" si es necesario
                if (dataSalidas.Columns["IdSalida"] != null)
                {
                    dataSalidas.Columns["IdSalida"].Visible = false;
                }
            }
            else
            {
                MessageBox.Show("No se encontraron registros.");
            }
        }

        private SalidasCL RecuperarInformacion()
        {
            SalidasCL oSalidasCL = new SalidasCL();

            int id = 0, cantidad = 0, idAlmacen = 0, idUsuario = 0;

            int.TryParse(txtId.Text, out id);
            int.TryParse(txtCantidad.Text, out cantidad);
            int.TryParse(cbNombreProducto.SelectedValue?.ToString(), out idAlmacen);
            int.TryParse(cbUsuario.SelectedValue?.ToString(), out idUsuario);

            oSalidasCL.IdSalida = id;
            oSalidasCL.IdAlmacen = idAlmacen;
            oSalidasCL.FechaSalida = txtFecha.Text;
            oSalidasCL.Cantidad = cantidad;
            oSalidasCL.IdUsuario = idUsuario;
            oSalidasCL.Observaciones = txtObservaciones.Text;

            return oSalidasCL;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            // Asegúrate de que la fila seleccionada sea válida
            if (indice >= 0 && indice < dataSalidas.Rows.Count)
            {
                dataSalidas.ClearSelection();

                btnAgregar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnCancelar.Enabled = true;
                btnBuscarFrm.Enabled = true;

                // Asignamos valores a los TextBox correspondientes
                txtId.Text = dataSalidas.Rows[indice].Cells[0].Value.ToString();
                cbNombreProducto.Text = dataSalidas.Rows[indice].Cells[1].Value.ToString();
                txtFecha.Text = dataSalidas.Rows[indice].Cells[2].Value.ToString();
                txtCantidad.Text = dataSalidas.Rows[indice].Cells[3].Value.ToString().Split(' ')[0];
                cbUsuario.Text = dataSalidas.Rows[indice].Cells[4].Value.ToString();
                txtObservaciones.Text = dataSalidas.Rows[indice].Cells[5].Value.ToString();

            }
        }

        private void activarBox()
        {
            txtCantidad.Enabled = true;
            txtObservaciones.Enabled = true;
        }

        private void Salidas_Load(object sender, EventArgs e)
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

            LlenarCamposDeSalida();
            LimpiarTextBox();
        }

        private void btnBuscarFrm_Click(object sender, EventArgs e)
        {
            BuscarAlmacen buscarAlmacenForm = new BuscarAlmacen();
            buscarAlmacenForm.Owner = this; // Establece el formulario principal como propietario
            buscarAlmacenForm.ShowDialog(); // Muestra el formulario como diálogo modal
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            LlenarCamposDeSalida();

            if (btnAgregar.Text == "Agregar")
            {
                activarBox();

                btnAgregar.Text = "Guardar";
                btnCancelar.Enabled = true;
                btnBuscarFrm.Enabled = true;
            }
            else if (btnAgregar.Text == "Guardar")
            {
                oSalidasCD.Agregar(RecuperarInformacion());
                LlenarData();

                LimpiarTextBox();

                MostrarMensaje("Registro agregado con éxito.");

                btnAgregar.Text = "Agregar";
                btnCancelar.Enabled = false;
                btnBuscarFrm.Enabled = false;
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
                btnBuscarFrm.Enabled = true;
                LlenarCamposDeSalida();
            }
            else if (btnEditar.Text == "Guardar")
            {
                oSalidasCD.Editar(RecuperarInformacion());
                LlenarData();

                LimpiarTextBox();

                MostrarMensaje("El registro ha sido actualizado.");

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
                oSalidasCD.Eliminar(RecuperarInformacion());
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
            string salidaABuscar = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(salidaABuscar))
            {
                // Llamar al método para buscar salidas por nombre
                DataSet resultados = oSalidasCD.BuscarSalidaPorNombre(salidaABuscar);

                if (resultados.Tables.Count > 0 && resultados.Tables[0].Rows.Count > 0)
                {
                    // Vincular los datos al DataGridView
                    dataSalidas.DataSource = resultados.Tables[0];

                    // Configurar los encabezados de las columnas
                    dataSalidas.Columns[0].HeaderText = "ID";
                    dataSalidas.Columns[1].HeaderText = "Producto";
                    dataSalidas.Columns[2].HeaderText = "Fecha Salida";
                    dataSalidas.Columns[3].HeaderText = "Cantidad";
                    dataSalidas.Columns[4].HeaderText = "Usuario";
                    dataSalidas.Columns[5].HeaderText = "Observaciones";

                    LimpiarTextBox();
                    btnCancelar.Enabled = true;
                    btnAgregar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No se encontraron registros con ese nombre.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un nombre para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
