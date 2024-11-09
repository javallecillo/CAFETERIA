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
        private System.Windows.Forms.Timer timer;

        public Inicio()
        {
            InitializeComponent();
            customizarDisenio();
            abrirFormularios(new capaPresentacion.Inicio());

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void customizarDisenio()
        {
            submenuIngredientes.Visible = false;
        }

        private void esconderSubmenu()
        {
            if (submenuIngredientes.Visible == true)
                submenuIngredientes.Visible = false;
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

        private void btnIngredientes_Click(object sender, EventArgs e)
        {
            mostrarSubmenu(submenuIngredientes);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            abrirFormularios(new capaPresentacion.Inicio());
            lblTitulo.Text = "¡BIENVENIDO!";

            // COLOCAR ESTE COMANDO A TODOS LOS BOTONES PARA ESCONDER EL SUBMENU DE INGREDIENTES
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
            esconderSubmenu();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            abrirFormularios(new capaPresentacion.Usuarios());
            lblTitulo.Text = "USUARIOS";
            esconderSubmenu();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de cerrar la sesión?", "CERRAR SESION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();

                Login loginForm = new Login();

                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de cerrar la sesión?", "CERRAR SESION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();

                Login loginForm = new Login();

                if (loginForm.ShowDialog() == DialogResult.OK)
                {
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

        }
    }
}
