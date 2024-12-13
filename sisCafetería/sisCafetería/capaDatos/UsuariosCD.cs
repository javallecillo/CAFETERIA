using sisCafetería.capaLogica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sisCafetería.capaDatos
{
    internal class UsuariosCD
    {
        //private readonly ConexionCD conexion = new ConexionCD();
        ConexionCD conexion;

        public UsuariosCD()
        {
            conexion = new ConexionCD();
        }

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

        // Agregar un nuevo usuario
        public bool Agregar(UsuariosCL oUsuariosCL)
        {
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Usuarios (Usuario, Contrasenia, Rol) VALUES (@Usuario, @Contrasenia, @Rol)");

            SQLComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = oUsuariosCL.Usuario;
            SQLComando.Parameters.Add("@Contrasenia", SqlDbType.VarChar).Value = oUsuariosCL.Contrasenia;
            SQLComando.Parameters.Add("@Rol", SqlDbType.VarChar).Value = oUsuariosCL.Rol;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        public bool Eliminar(UsuariosCL oUsuariosCL)
        {
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario");
            SQLComando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = oUsuariosCL.IdUsuario;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        public bool Editar(UsuariosCL oUsuariosCL)
        {
            SqlCommand SQLComando = new SqlCommand("UPDATE Usuarios SET Usuario = @Usuario, Contrasenia = @Contrasenia, Rol = @Rol WHERE IdUsuario = @IdUsuario");
            SQLComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = oUsuariosCL.Usuario;
            SQLComando.Parameters.Add("@Contrasenia", SqlDbType.VarChar).Value = oUsuariosCL.Contrasenia;
            SQLComando.Parameters.Add("@Rol", SqlDbType.VarChar).Value = oUsuariosCL.Rol;
            SQLComando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = oUsuariosCL.IdUsuario;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        public DataSet MostrarUsuarios()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Usuarios");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet BuscarUsuariosPorNombre(string usuario)
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Usuarios WHERE Usuario LIKE @Usuario");
            sentencia.Parameters.AddWithValue("@Usuario", "%" + usuario + "%");
            return conexion.EjecutarSentencia(sentencia);
        }

        public int ObtenerIdUsuarioPorNombre(string nombreUsuario)
        {
            try
            {
                using (SqlConnection conn = conexion.EstablecerConexion())
                {
                    string query = "SELECT IdUsuario FROM Usuarios WHERE Usuario = @Usuario";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Usuario", nombreUsuario);

                    conn.Open();
                    object result = cmd.ExecuteScalar(); // Obtiene el IdUsuario

                    if (result != null)
                    {
                        return Convert.ToInt32(result); // Retorna el IdUsuario
                    }
                    else
                    {
                        return -1; // Retorna -1 si no se encuentra el usuario
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al obtener el IdUsuario: " + ex.Message);
                return -1; // Retorna -1 si hubo un error en la consulta
            }
        }
    }
}
