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
    public partial class Usuarios : Form
    {
        UsuariosCD oUsuariosCD;

        public Usuarios()
        {
            oUsuariosCD = new UsuariosCD();
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

            txtUsuario.Enabled = false;
            txtContrasenia.Enabled = false;
            cmbRol.Enabled = false;

            txtId.Clear();
            txtUsuario.Clear();
            txtContrasenia.Clear();
            cmbRol.SelectedIndex = -1;
            txtBuscar.Clear();
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {

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
                oUsuariosCD.Agregar(RecuperarInformacion());
                LlenarData();

                LimpiarTextBox();

                MostrarMensaje("Usuario agregado con éxito.");

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
                oUsuariosCD.Editar(RecuperarInformacion());
                LlenarData();

                LimpiarTextBox();

                MostrarMensaje("La información del usuario ha sido actualizada.");

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
                oUsuariosCD.Eliminar(RecuperarInformacion());
                LimpiarTextBox();
                MostrarMensaje("El usuario ha sido eliminado.");
                LlenarData();
            }
            else
            {
                LimpiarTextBox();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string usuarioABuscar = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(usuarioABuscar))
            {
                DataSet resultados = oUsuariosCD.BuscarUsuariosPorNombre(usuarioABuscar);

                dataUsuarios.DataSource = resultados.Tables[0];

                dataUsuarios.Columns[0].HeaderText = "ID";
                dataUsuarios.Columns[1].HeaderText = "Usuario";
                dataUsuarios.Columns[2].HeaderText = "Contraseña";
                dataUsuarios.Columns[3].HeaderText = "Rol";

                LimpiarTextBox();
                btnCancelar.Enabled = true;
                btnAgregar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un nombre para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LlenarData()
        {
            dataUsuarios.DataSource = oUsuariosCD.MostrarUsuarios().Tables[0];

            dataUsuarios.Columns[0].HeaderText = "ID";
            dataUsuarios.Columns[1].HeaderText = "Usuario";
            dataUsuarios.Columns[2].HeaderText = "Contraseña";
            dataUsuarios.Columns[3].HeaderText = "Rol";
        }

        private UsuariosCL RecuperarInformacion()
        {
            UsuariosCL oUsuariosCL = new UsuariosCL();

            int id = 0;
            int.TryParse(txtId.Text, out id);

            oUsuariosCL.IdUsuario = id;
            oUsuariosCL.Usuario = txtUsuario.Text;
            oUsuariosCL.Contrasenia = txtContrasenia.Text;
            oUsuariosCL.Rol = cmbRol.Text;

            return oUsuariosCL;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            dataUsuarios.ClearSelection();

            if (indice >= 0)
            {
                btnAgregar.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnCancelar.Enabled = true;

                txtId.Text = dataUsuarios.Rows[indice].Cells[0].Value.ToString();
                txtUsuario.Text = dataUsuarios.Rows[indice].Cells[1].Value.ToString();
                txtContrasenia.Text = dataUsuarios.Rows[indice].Cells[2].Value.ToString();
                cmbRol.Text = dataUsuarios.Rows[indice].Cells[3].Value.ToString();
            }
        }

        private void activarBox()
        {
            txtUsuario.Enabled = true;
            txtContrasenia.Enabled = true;
            cmbRol.Enabled = true;
        }
    }
}
