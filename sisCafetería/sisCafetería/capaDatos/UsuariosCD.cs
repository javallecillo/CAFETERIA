using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sisCafetería.capaDatos
{
    internal class UsuariosCD
    {
        private readonly ConexionCD conexion = new ConexionCD();

        public bool ValidarUsuario(string usuario, string contrasenia)
        {
            try
            {
                using (SqlConnection conn = conexion.EstablecerConexion())
                {
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Contrasenia = @Contrasenia";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Contrasenia", contrasenia);

                    conn.Open();
                    int result = (int)cmd.ExecuteScalar();
                    return result > 0; // Devuelve true si el usuario existe
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al validar el usuario: " + ex.Message);
                return false; // Retorna false si hubo un error
            }
        }
    }
}
