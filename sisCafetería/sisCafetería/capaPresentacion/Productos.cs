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
    public partial class Productos : Form
    {
        ProductosCD oProductosCD;


        public Productos()
        {
            oProductosCD = new ProductosCD();
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
            txtPrecio.Enabled = false;
            txtDescripcion.Enabled = false;
            txtStock.Enabled = false;
            cbCategoria.Enabled = false;

            txtId.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtDescripcion.Clear();
            txtStock.Clear();
            txtBuscar.Clear();
            cbCategoria.SelectedIndex = -1;
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LlenarData()
        {
            dataProductos.DataSource = oProductosCD.MostrarProductos().Tables[0];
            
            dataProductos.Columns[0].HeaderText = "ID";
            dataProductos.Columns[1].HeaderText = "Nombre";
            dataProductos.Columns[2].HeaderText = "Categoría";
            dataProductos.Columns[3].HeaderText = "Precio";
            dataProductos.Columns[4].HeaderText = "Descripción";
            dataProductos.Columns[5].HeaderText = "Stock";
            
        }

        private ProductosCL RecuperarInformacion()
        {
            ProductosCL oProductosCL = new ProductosCL();

            int id = 0, stock = 0, idCategoria = 0;
            decimal precio = 0;

            int.TryParse(txtId.Text, out id);
            int.TryParse(cbCategoria.SelectedValue?.ToString(), out idCategoria);
            decimal.TryParse(txtPrecio.Text, out precio);
            int.TryParse(txtStock.Text, out stock);

            oProductosCL.IdProducto = id;
            oProductosCL.Nombre = txtNombre.Text;
            oProductosCL.IdCategoria = idCategoria;
            oProductosCL.Precio = precio;
            oProductosCL.Descripcion = txtDescripcion.Text;
            oProductosCL.Stock = stock;

            return oProductosCL;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            dataProductos.ClearSelection();

            if (indice >= 0)
            {
                btnAgregar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnCancelar.Enabled = true;

                txtId.Text = dataProductos.Rows[indice].Cells[0].Value.ToString();
                txtNombre.Text = dataProductos.Rows[indice].Cells[1].Value.ToString();
                cbCategoria.Text = dataProductos.Rows[indice].Cells[2].Value.ToString();
                txtPrecio.Text = dataProductos.Rows[indice].Cells[3].Value.ToString();
                txtDescripcion.Text = dataProductos.Rows[indice].Cells[4].Value.ToString();
                txtStock.Text = dataProductos.Rows[indice].Cells[5].Value.ToString();
            }
        }

        private void activarBox()
        {
            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            txtDescripcion.Enabled = true;
            txtStock.Enabled = true;
            cbCategoria.Enabled = true;
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
                oProductosCD.Agregar(RecuperarInformacion());
                LlenarData();

                LimpiarTextBox();

                MostrarMensaje("Producto agregado con éxito.");

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
                oProductosCD.Editar(RecuperarInformacion());
                LlenarData();

                LimpiarTextBox();

                MostrarMensaje("El producto ha sido actualizado.");

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
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                oProductosCD.Eliminar(RecuperarInformacion());
                LimpiarTextBox();
                MostrarMensaje("El producto ha sido eliminado.");
                LlenarData();
            }
            else
            {
                LimpiarTextBox();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string productoABuscar = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(productoABuscar))
            {
                DataSet resultados = oProductosCD.BuscarProductosPorNombre(productoABuscar);

                dataProductos.DataSource = resultados.Tables[0];

                dataProductos.Columns[0].HeaderText = "ID";
                dataProductos.Columns[1].HeaderText = "Nombre";
                dataProductos.Columns[2].HeaderText = "Categoría";
                dataProductos.Columns[3].HeaderText = "Precio";
                dataProductos.Columns[4].HeaderText = "Descripción";
                dataProductos.Columns[5].HeaderText = "Stock";

                LimpiarTextBox();
                btnCancelar.Enabled = true;
                btnAgregar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un nombre para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataProductos_MouseClick(object sender, MouseEventArgs e)
        {

        }


        private void Productos_Load(object sender, EventArgs e)
        {
            CategoriasCD objCategorias = new CategoriasCD();

            cbCategoria.DataSource = objCategorias.MostrarCategorias().Tables[0];
            cbCategoria.DisplayMember = "Nombre";
            cbCategoria.ValueMember = "IdCategoria";
        }
    }
}
