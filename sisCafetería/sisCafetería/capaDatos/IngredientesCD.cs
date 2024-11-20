using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sisCafetería.capaLogica;

namespace sisCafetería.capaDatos
{
    internal class IngredientesCD
    {
        ConexionCD conexion;

        public IngredientesCD()
        {
            conexion = new ConexionCD();
        }

        public bool Agregar(IngredientesCL oIngredientesCL)
        {
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Ingredientes (Nombre, Descripcion, PrecioUnitario, Stock, UnidadMedida) VALUES (@Nombre, @Descripcion, @PrecioUnitario, @Stock, @UnidadMedida)");
            
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oIngredientesCL.Nombre;
            SQLComando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = oIngredientesCL.Descripcion;
            SQLComando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = oIngredientesCL.PrecioUnitario;
            SQLComando.Parameters.Add("@Stock", SqlDbType.Int).Value = oIngredientesCL.Stock;
            SQLComando.Parameters.Add("@UnidadMedida", SqlDbType.VarChar).Value = oIngredientesCL.UnidadMedida;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        // Eliminar un producto
        public bool Eliminar(IngredientesCL oIngredientesCL)
        {
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Ingredientes WHERE IdIngrediente = @IdIngrediente");
            SQLComando.Parameters.Add("@IdIngrediente", SqlDbType.Int).Value = oIngredientesCL.IdIngrediente;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        // Editar un producto existente
        public bool Editar(IngredientesCL oIngredientesCL)
        {
            SqlCommand SQLComando = new SqlCommand("UPDATE Ingredientes SET Nombre = @Nombre, Descripcion = @Descripcion, PrecioUnitario = @PrecioUnitario, Stock = @Stock, UnidadMedida = @UnidadMedida WHERE IdIngrediente = @IdIngrediente");
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oIngredientesCL.Nombre;
            SQLComando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = oIngredientesCL.Descripcion;
            SQLComando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = oIngredientesCL.PrecioUnitario;
            SQLComando.Parameters.Add("@Stock", SqlDbType.Int).Value = oIngredientesCL.Stock;
            SQLComando.Parameters.Add("@UnidadMedida", SqlDbType.VarChar).Value = oIngredientesCL.UnidadMedida;
            SQLComando.Parameters.Add("@IdIngrediente", SqlDbType.Int).Value = oIngredientesCL.IdIngrediente;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        public DataSet MostrarIngredientes()
        {
            SqlCommand sentencia = new SqlCommand("SELECT IdIngrediente, Nombre, Descripcion, PrecioUnitario, CONCAT(CAST(Stock AS NVARCHAR), ' ', UnidadMedida) AS StockMedida FROM Ingredientes");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet BuscarIngredientesPorNombre(string ingrediente)
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Ingredientes WHERE Nombre LIKE @Nombre");
            sentencia.Parameters.AddWithValue("@Nombre", "%" + ingrediente + "%");
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
