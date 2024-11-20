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
    public partial class Categorias : Form
    {
        CategoriasCD oCategoriasCD;

        public Categorias()
        {
            oCategoriasCD = new CategoriasCD();
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

            txtId.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtBuscar.Clear();
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LlenarData()
        {
            dataCategorias.DataSource = oCategoriasCD.MostrarCategorias().Tables[0];

            dataCategorias.Columns[0].HeaderText = "ID";
            dataCategorias.Columns[1].HeaderText = "Nombre";
            dataCategorias.Columns[2].HeaderText = "Descripción";
        }

        private CategoriasCL RecuperarInformacion()
        {
            CategoriasCL oCategoriasCL = new CategoriasCL();

            int id = 0;
            int.TryParse(txtId.Text, out id);

            oCategoriasCL.IdCategoria = id;
            oCategoriasCL.Nombre = txtNombre.Text;
            oCategoriasCL.Descripcion = txtDescripcion.Text;

            return oCategoriasCL;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            dataCategorias.ClearSelection();

            if (indice >= 0)
            {
                btnAgregar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnCancelar.Enabled = true;

                txtId.Text = dataCategorias.Rows[indice].Cells[0].Value.ToString();
                txtNombre.Text = dataCategorias.Rows[indice].Cells[1].Value.ToString();
                txtDescripcion.Text = dataCategorias.Rows[indice].Cells[2].Value.ToString();
            }
        }

        private void activarBox()
        {
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
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
                oCategoriasCD.Agregar(RecuperarInformacion());
                LlenarData();

                LimpiarTextBox();

                MostrarMensaje("Categoria agregada con éxito.");

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
                oCategoriasCD.Editar(RecuperarInformacion());
                LlenarData();

                LimpiarTextBox();

                MostrarMensaje("La categoría ha sido actualizada.");

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
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta categoría?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                oCategoriasCD.Eliminar(RecuperarInformacion());
                LimpiarTextBox();
                MostrarMensaje("La categoría ha sido eliminada.");
                LlenarData();
            }
            else
            {
                LimpiarTextBox();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string categoriaABuscar = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(categoriaABuscar))
            {
                DataSet resultados = oCategoriasCD.BuscarCategoriasPorNombre(categoriaABuscar);

                dataCategorias.DataSource = resultados.Tables[0];

                dataCategorias.Columns[0].HeaderText = "ID";
                dataCategorias.Columns[1].HeaderText = "Nombre";
                dataCategorias.Columns[2].HeaderText = "Descripción";

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
