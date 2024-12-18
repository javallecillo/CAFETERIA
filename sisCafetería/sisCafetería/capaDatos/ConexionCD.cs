﻿using System;
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

        // INSERT, UPDATE, DELETE
        /*public bool ejecutarComandoSinRetornoDatos(string strComando)
        {
            try
            {
                SqlCommand Comando = new SqlCommand();

                Comando.CommandText = strComando;
                Comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();

                return true;

            }
            catch
            {

                return false;
            }
        }*/

        //Sobrecarga
        public bool ejecutarComandoSinRetornoDatos(SqlCommand SQLComando)
        {
            try
            {
                SqlCommand Comando = SQLComando;
                Comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la ejecución del comando: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //SELECT 
        public DataSet EjecutarSentencia(SqlCommand sqlComando)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter Adaptador = new SqlDataAdapter();

            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando = sqlComando;
                Comando.Connection = EstablecerConexion();
                Adaptador.SelectCommand = Comando;
                Conexion.Open();
                Adaptador.Fill(DS);
                Conexion.Close();

                return DS;

            }
            catch
            {
                return DS;
            }
        }

        // Método para abrir la conexión
        public SqlConnection AbrirConexion()
        {
            // Verificar si la conexión no ha sido inicializada
            if (Conexion == null)
            {
                Conexion = new SqlConnection(CadenaConexion);
            }

            // Abrir la conexión si está cerrada
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            return Conexion;
        }

        // Método para cerrar la conexión
        public void CerrarConexion()
        {
            if (Conexion.State == System.Data.ConnectionState.Open)
            {
                Conexion.Close();
            }
        }
    }
}
