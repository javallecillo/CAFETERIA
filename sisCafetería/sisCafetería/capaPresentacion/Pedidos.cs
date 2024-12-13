using sisCafetería.capaDatos;
using sisCafetería.capaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sisCafetería.capaPresentacion
{
    public partial class Pedidos : Form
    {
        PedidosCD oPedidosCD;

        public Pedidos()
        {
            oPedidosCD = new PedidosCD();
            InitializeComponent();
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
                        txtSubTotal.Clear();  // Limpiar el campo de PrecioTotal si cantidad está vacía
                    }
                    else
                    {
                        // Si la cantidad no está vacía, recalcular el PrecioTotal
                        decimal cantidad = Convert.ToDecimal(txtCantidad.Text);
                        decimal costoTotal = precioUnitario * cantidad;
                        txtSubTotal.Text = costoTotal.ToString("0.00");
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
                    string query = "SELECT Precio FROM Productos WHERE IdProducto = @IdProducto";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);

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
                    txtSubTotal.Text = costoTotal.ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                txtSubTotal.Text = "0.00"; // Restablecer si hay error
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

        private void btnBuscarFrm_Click(object sender, EventArgs e)
        {
            BuscarProducto buscarProductoForm = new BuscarProducto();
            buscarProductoForm.Owner = this; // Establece el formulario principal como propietario
            buscarProductoForm.ShowDialog(); // Muestra el formulario como diálogo modal
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            // Definir las columnas del DataGridView si no se han definido en el diseñador
            if (dataPedidos.Columns.Count == 0) // Solo agregar columnas si no existen
            {
                dataPedidos.Columns.Add("IdProducto", "ID");
                dataPedidos.Columns.Add("Producto", "Producto");
                dataPedidos.Columns.Add("PrecioUnitario", "Precio Unitario");
                dataPedidos.Columns.Add("Cantidad", "Cantidad");
                dataPedidos.Columns.Add("SubTotal", "Subtotal");

                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "Eliminar"; // Nombre de la columna
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true; // El texto es fijo (Eliminar)
                dataPedidos.Columns.Add(btnEliminar);

            }

            cbNombreProducto.Items.Clear();

            ProductosCD objProducto = new ProductosCD();

            cbNombreProducto.DataSource = objProducto.MostrarProductosParaComboBox().Tables[0];
            cbNombreProducto.DisplayMember = "Nombre";
            cbNombreProducto.ValueMember = "IdProducto";

            UsuariosCD objUsuario = new UsuariosCD();

            cbUsuario.DataSource = objUsuario.MostrarUsuarios().Tables[0];
            cbUsuario.DisplayMember = "Usuario";
            cbUsuario.ValueMember = "IdUsuario";

            LlenarCamposDeEntrada();
            LimpiarTextBox();
        }

        private void LimpiarTextBox()
        {
            btnTomarPedido.Enabled = true;
            btnCancelarPedido.Enabled = false;
            btnGuardarPedido.Enabled = false;

            grupoDatosPedido.Enabled = false;
            grupoProductos.Enabled = false;

            txtCambio.Enabled = false;
            txtTotal.Enabled = false;
            txtRecibido.Enabled = false;

            cbNombreProducto.SelectedIndex = -1;
            cbUsuario.SelectedIndex = -1;
            cbFormaPago.SelectedIndex = -1;
            cbTipoPedido.SelectedIndex = -1;
            txtIdPedido.Clear();
            txtIdDetallePedido.Clear();
            txtSubTotal.Clear();
            txtTotal.Clear();
            txtRecibido.Clear();
            txtCambio.Clear();
            txtFecha.Clear();
            txtNumeroMesa.Clear();
            txtPrecioUnitario.Clear();
            txtCantidad.Clear();

            dataPedidos.Rows.Clear();

        }

        private void activarBox()
        {
            btnTomarPedido.Enabled = false;
            btnCancelarPedido.Enabled = true;
            btnGuardarPedido.Enabled = true;

            grupoDatosPedido.Enabled = true;
            grupoProductos.Enabled = true;

            txtCambio.Enabled = true;
            txtTotal.Enabled = true;
            txtRecibido.Enabled = true;
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void btnTomarPedido_Click(object sender, EventArgs e)
        {
            activarBox();
            LlenarCamposDeEntrada();
        }

        private void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            LimpiarTextBox();
        }

        private void btnGuardarPedido_Click(object sender, EventArgs e)
        {
            // Validar que haya datos en el DataGridView
            if (dataPedidos.Rows.Count == 0 || dataPedidos.Rows[0].IsNewRow)
            {
                MessageBox.Show("No hay productos en el pedido. Agrega al menos un producto antes de guardar.");
                return;
            }

            // Crear el objeto PedidoCL
            PedidosCL nuevoPedido = new PedidosCL
            {
                Fecha = DateTime.Now.ToString(),
                TipoPedido = cbTipoPedido.SelectedItem.ToString(),
                NumeroMesa = !string.IsNullOrWhiteSpace(txtNumeroMesa.Text) ? (int?)Convert.ToInt32(txtNumeroMesa.Text) : null,
                FormaPago = cbFormaPago.SelectedItem.ToString(),
                IdUsuario = Convert.ToInt32(cbUsuario.SelectedValue), // Cambia esto para obtener el ID del usuario actualmente logueado
                Total = Convert.ToDecimal(txtTotal.Text) // Suponiendo que lblTotal contiene el total calculado
            };

            // Obtener los detalles del pedido desde el DataGridView
            List<DetallePedidosCL> detalles = RecuperarDetallesDesdeDataGrid();

            // Intentar guardar el pedido y sus detalles
            PedidosCD pedidosCD = new PedidosCD();
            bool resultado = pedidosCD.GuardarPedidoConDetalles(nuevoPedido, detalles);

            if (resultado)
            {
                MessageBox.Show("Pedido guardado correctamente.");

                // Limpiar DataGridView y campos del formulario
                LimpiarTextBox();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al guardar el pedido. Intenta nuevamente.");
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó un producto
            if (cbNombreProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un producto.");
                return; // Salir del método si no hay selección
            }

            // Verificar si los campos de cantidad y precio son válidos
            if (string.IsNullOrEmpty(txtCantidad.Text) || string.IsNullOrEmpty(txtPrecioUnitario.Text))
            {
                MessageBox.Show("Por favor, ingrese la cantidad y el precio unitario.");
                return;
            }

            // Calcular el subtotal
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            decimal precioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
            decimal subTotal = cantidad * precioUnitario;
            txtSubTotal.Text = subTotal.ToString("0.00");

            // Guardar el detalle del pedido
            //oDetallePedidosCD.GuardarDetallePedidos(RecuperarInformacionDetallePedidos());

            // Agregar la fila al DataGridView
            dataPedidos.Rows.Add(
                cbNombreProducto.SelectedValue,  // ID del producto
                cbNombreProducto.Text,                // Cantidad
                txtPrecioUnitario.Text,           // Nombre del producto
                txtCantidad.Text,          // Precio unitario
                txtSubTotal.Text                // Subtotal
            );

            // Calcular el total
            CalcularTotal();

            // Limpiar los campos para la siguiente entrada
            cbNombreProducto.SelectedIndex = -1;
            txtIdDetallePedido.Clear();
            txtSubTotal.Clear();
            txtPrecioUnitario.Clear();
            txtCantidad.Clear();
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            // Sumamos todos los subtotales del DataGridView
            foreach (DataGridViewRow row in dataPedidos.Rows)
            {
                total += Convert.ToDecimal(row.Cells["SubTotal"].Value);
            }

            // Mostrar el total
            txtTotal.Text = total.ToString("0.00");
        }


        private void btnQuitar_Click(object sender, EventArgs e)
        {

        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            // Asegúrate de que la fila seleccionada sea válida
            if (indice >= 0 && indice < dataPedidos.Rows.Count)
            {
                dataPedidos.ClearSelection();

                btnAgregar.Enabled = false;
                btnQuitar.Enabled = true;

                // Asignamos valores a los TextBox correspondientes
                txtIdDetallePedido.Text = dataPedidos.Rows[indice].Cells[0].Value.ToString();
                txtIdPedido.Text = dataPedidos.Rows[indice].Cells[1].Value.ToString();
                cbNombreProducto.Text = dataPedidos.Rows[indice].Cells[2].Value.ToString();
                txtCantidad.Text = dataPedidos.Rows[indice].Cells[3].Value.ToString();
                txtPrecioUnitario.Text = dataPedidos.Rows[indice].Cells[4].Value.ToString();
                txtSubTotal.Text = dataPedidos.Rows[indice].Cells[5].Value.ToString();

            }
        }

        private void dataPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo clic en la columna de eliminar (su índice es el último)
            if (e.ColumnIndex == dataPedidos.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                // Eliminar la fila seleccionada
                dataPedidos.Rows.RemoveAt(e.RowIndex);

                // Recalcular el total después de eliminar una fila
                CalcularTotal();
            }
        }

        private List<DetallePedidosCL> RecuperarDetallesDesdeDataGrid()
        {
            List<DetallePedidosCL> detalles = new List<DetallePedidosCL>();

            foreach (DataGridViewRow row in dataPedidos.Rows)
            {
                if (!row.IsNewRow) // Ignorar la fila vacía de edición
                {
                    detalles.Add(new DetallePedidosCL
                    {
                        IdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value),
                        Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                        PrecioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value),
                        Subtotal = Convert.ToDecimal(row.Cells["SubTotal"].Value)
                    });
                }
            }

            return detalles;
        }
    }
}
