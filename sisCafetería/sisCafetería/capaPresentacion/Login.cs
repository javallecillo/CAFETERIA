using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sisCafetería.capaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            // Configura los placeholders y sus eventos una vez
            InitializePlaceholders();

    
        }

        private void InitializePlaceholders()
        {
            // Establecer el uso de caracteres de sistema para ocultar la contraseña
            txtContrasenia.UseSystemPasswordChar = true; // Muestra los caracteres como puntos
            txtContrasenia.PasswordChar = '•';

            // Configura la etiqueta para txtUsuario
            txtUsuario.Text = "Escribe tu usuario...";
            txtUsuario.ForeColor = Color.Gray;
            txtUsuario.Enter += txtUsuario_Enter;
            txtUsuario.Leave += txtUsuario_Leave;

            // Configura la etiqueta para txtContrasenia
            txtContrasenia.Text = "Escribe tu contraseña...";
            txtContrasenia.ForeColor = Color.Gray;
            txtContrasenia.Enter += txtContrasenia_Enter;
            txtContrasenia.Leave += txtContrasenia_Leave;

            // Asignar el evento del botón solo una vez
            btnMostrar.Click -= btnMostrar_Click; // Asegúrate de que no haya suscripciones previas
            btnMostrar.Click += btnMostrar_Click;

            // Cargar icono inicial en el botón
            btnMostrar.Image = Image.FromFile("J://UTH//2024//3-2024//INGENIERIA_SOFTWARE//III_P//PROYECTO//sisCafetería//sisCafetería//capaPresentacion//img//ojo.png"); // Icono de ojo tachado

        }

        // eliminar la etiqueta cuando el usuario selecciona el TextBox
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Escribe tu usuario...")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.White;
            }
        }

        // restaurar la etiqueta cuando el TextBox queda vacío
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Text = "Escribe tu usuario...";
                txtUsuario.ForeColor = Color.Gray; 
            }
        }

        // Evento Enter para txtContrasenia
        private void txtContrasenia_Enter(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == "Escribe tu contraseña...")
            {
                txtContrasenia.Text = "";
                txtContrasenia.ForeColor = Color.White;
                txtContrasenia.UseSystemPasswordChar = false; // Oculta la contraseña
            }
        }

        // Evento Leave para txtContrasenia
        private void txtContrasenia_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContrasenia.Text))
            {
                txtContrasenia.Text = "Escribe tu contraseña...";
                txtContrasenia.ForeColor = Color.Gray;
                txtContrasenia.UseSystemPasswordChar = true; // Muestra el placeholder en texto claro
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Botón clickeado"); // Para pruebas
            //MessageBox.Show($"UseSystemPasswordChar: {txtContrasenia.UseSystemPasswordChar}"); // Verifica el estado actual

            // Alterna la visibilidad de la contraseña
            if (txtContrasenia.UseSystemPasswordChar)
            {
                txtContrasenia.UseSystemPasswordChar = false; // Muestra la contraseña
                btnMostrar.Image = Image.FromFile("J://UTH//2024//3-2024//INGENIERIA_SOFTWARE//III_P//PROYECTO//sisCafetería//sisCafetería//capaPresentacion//img//ojo.png"); // Icono de ojo tachado
            }
            else
            {
                txtContrasenia.UseSystemPasswordChar = true; // Oculta la contraseña
                btnMostrar.Image = Image.FromFile("J://UTH//2024//3-2024//INGENIERIA_SOFTWARE//III_P//PROYECTO//sisCafetería//sisCafetería//capaPresentacion//img//tachado.png"); // Icono de ojo tachado
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
