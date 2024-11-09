using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace sisCafetería.capaDatos
{
    internal class ConexionCD
    {
        private readonly string CadenaConexion = "Data Source= ARTURO\\SQLEXPRESS; Initial Catalog=db_cafeteria; Integrated Security =True";
        private SqlConnection Conexion;

        public SqlConnection EstablecerConexion()
        {
            this.Conexion = new SqlConnection(this.CadenaConexion);
            return this.Conexion;
        }

        // Método para ejecutar comandos sin retorno de datos
        public bool EjecutarComandoSinRetornoDatos(string strComando)
        {
            try
            {
                using (SqlCommand Comando = new SqlCommand(strComando, EstablecerConexion()))
                {
                    Conexion.Open();
                    Comando.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
            finally
            {
                Conexion.Close();
            }
        }

        // Método para ejecutar comandos SQL que devuelven datos
        public DataSet EjecutarSentencia(SqlCommand sqlComando)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter Adaptador = new SqlDataAdapter();

            try
            {
                sqlComando.Connection = EstablecerConexion();
                Adaptador.SelectCommand = sqlComando;
                Conexion.Open();
                Adaptador.Fill(DS);
                return DS;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return DS;
            }
            finally
            {
                Conexion.Close();
            }
        }
    }
}
