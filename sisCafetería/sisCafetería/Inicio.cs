using sisCafetería.capaLogica;
using sisCafetería.capaPresentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sisCafetería
{
    public partial class Inicio : Form
    {
        private Timer timer;

        public Inicio()
        {
            InitializeComponent();
            customizarDisenio();
            abrirFormularios(new capaPresentacion.Inicio());
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // 1000 ms = 1 segundo
            timer.Tick += new EventHandler(UpdateDateTime);
            timer.Start();
        }

        private void UpdateDateTime(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy"); // Actualiza la fecha
            lblHora.Text = DateTime.Now.ToString("hh:mm     tt"); // Actualiza la hora
        }

        private void customizarDisenio()
        {
            submenuAlmacen.Visible = false;
        }

        private void esconderSubmenu()
        {
            if (submenuAlmacen.Visible == true)
                submenuAlmacen.Visible = false;
        }

        private void mostrarSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                esconderSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void panelLateral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            if (UsuariosCL.UsuarioActual != null && !string.IsNullOrEmpty(UsuariosCL.UsuarioActual.Usuario))
            {
                lblUsuario.Text = $"{UsuariosCL.UsuarioActual.Usuario}";
            }
            else
            {
                lblUsuario.Text = "Desconocido";
            }
        }

        private Form formularioActivo = null;
        private void abrirFormularios(Form Formulario)
        {
            if (formularioActivo != null)
                formularioActivo.Close();

            formularioActivo = Formulario;
            Formulario.TopLevel = false;
            Formulario.FormBorderStyle= FormBorderStyle.None;
            Formulario.Dock = DockStyle.Fill;
            panelFormularios.Controls. Add(Formulario);
            panelFormularios.Tag = Formulario;
            Formulario.BringToFront();
            Formulario.Show();

        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            abrirFormularios(new capaPresentacion.Almacen());
            lblTitulo.Text = "ALMACEN";
            mostrarSubmenu(submenuAlmacen);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            abrirFormularios(new capaPresentacion.Inicio());
            lblTitulo.Text = "¡BIENVENIDO!";

            // COLOCAR ESTE COMANDO A TODOS LOS BOTONES PARA ESCONDER EL SUBMENU DE ALMACEN
            esconderSubmenu();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            abrirFormularios(new capaPresentacion.Pedidos());
            lblTitulo.Text = "PEDIDOS";

            esconderSubmenu();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            abrirFormularios(new capaPresentacion.Productos());
            lblTitulo.Text = "PRODUCTOS";
            esconderSubmenu();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            abrirFormularios(new capaPresentacion.Categorias());
            lblTitulo.Text = "CATEGORIAS";
            esconderSubmenu();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            abrirFormularios(new capaPresentacion.Reportes());
            lblTitulo.Text = "REPORTES";
            esconderSubmenu();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            abrirFormularios(new capaPresentacion.Usuarios());
            lblTitulo.Text = "USUARIOS";
            esconderSubmenu();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de cerrar la sesión?", "CERRAR SESION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                abrirFormularios(new capaPresentacion.Inicio());
                lblTitulo.Text = "¡BIENVENIDO!";

                // COLOCAR ESTE COMANDO A TODOS LOS BOTONES PARA ESCONDER EL SUBMENU DE ALMACEN
                esconderSubmenu();

                this.Hide();

                Login loginForm = new Login();

                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Actualiza el nombre de usuario después de iniciar sesión nuevamente
                    if (UsuariosCL.UsuarioActual != null && !string.IsNullOrEmpty(UsuariosCL.UsuarioActual.Usuario))
                    {
                        lblUsuario.Text = $"{UsuariosCL.UsuarioActual.Usuario}";
                    }

                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void panelSuperior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalidas_Click(object sender, EventArgs e)
        {
            abrirFormularios(new capaPresentacion.Salidas());
            lblTitulo.Text = "SALIDAS";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de cerrar la sesión?", "CERRAR SESION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                abrirFormularios(new capaPresentacion.Inicio());
                lblTitulo.Text = "¡BIENVENIDO!";

                // COLOCAR ESTE COMANDO A TODOS LOS BOTONES PARA ESCONDER EL SUBMENU DE ALMACEN
                esconderSubmenu();

                this.Hide();

                Login loginForm = new Login();

                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Actualiza el nombre de usuario después de iniciar sesión nuevamente
                    if (UsuariosCL.UsuarioActual != null && !string.IsNullOrEmpty(UsuariosCL.UsuarioActual.Usuario))
                    {
                        lblUsuario.Text = $"{UsuariosCL.UsuarioActual.Usuario}";
                    }

                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btnEntradas_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario Entradas
            Entradas entradasForm = new Entradas();

            // Llamar al método para llenar los campos automáticamente
            entradasForm.LlenarCamposDeEntrada();

            abrirFormularios(new capaPresentacion.Entradas());
            lblTitulo.Text = "ENTRADAS";
        }
    }
}
