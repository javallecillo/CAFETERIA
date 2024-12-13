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
    internal class AlmacenCD
    {
        ConexionCD conexion;

        public AlmacenCD()
        {
            conexion = new ConexionCD();
        }

        public bool Agregar(AlmacenCL oAlmacenCL)
        {
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Almacen (Nombre, Descripcion, PrecioUnitario, Stock, UnidadMedida) VALUES (@Nombre, @Descripcion, @PrecioUnitario, @Stock, @UnidadMedida)");
            
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oAlmacenCL.Nombre;
            SQLComando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = oAlmacenCL.Descripcion;
            SQLComando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = oAlmacenCL.PrecioUnitario;
            SQLComando.Parameters.Add("@Stock", SqlDbType.Int).Value = oAlmacenCL.Stock;
            SQLComando.Parameters.Add("@UnidadMedida", SqlDbType.VarChar).Value = oAlmacenCL.UnidadMedida;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        // Eliminar un producto
        public bool Eliminar(AlmacenCL oAlmacenCL)
        {
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Almacen WHERE IdAlmacen = @IdAlmacen");
            SQLComando.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = oAlmacenCL.IdAlmacen;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        // Editar un producto existente
        public bool Editar(AlmacenCL oAlmacenCL)
        {
            SqlCommand SQLComando = new SqlCommand("UPDATE Almacen SET Nombre = @Nombre, Descripcion = @Descripcion, PrecioUnitario = @PrecioUnitario, Stock = @Stock, UnidadMedida = @UnidadMedida WHERE IdAlmacen = @IdAlmacen");
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oAlmacenCL.Nombre;
            SQLComando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = oAlmacenCL.Descripcion;
            SQLComando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = oAlmacenCL.PrecioUnitario;
            SQLComando.Parameters.Add("@Stock", SqlDbType.Int).Value = oAlmacenCL.Stock;
            SQLComando.Parameters.Add("@UnidadMedida", SqlDbType.VarChar).Value = oAlmacenCL.UnidadMedida;
            SQLComando.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = oAlmacenCL.IdAlmacen;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        public DataSet MostrarAlmacen()
        {
            SqlCommand sentencia = new SqlCommand("SELECT IdAlmacen, Nombre, Descripcion, PrecioUnitario, CONCAT(CAST(Stock AS NVARCHAR), ' ', UnidadMedida) AS StockMedida FROM Almacen");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet MostrarAlmacenBuscar()
        {
            SqlCommand sentencia = new SqlCommand("SELECT IdAlmacen, Nombre FROM Almacen");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet MostrarAlmacenParaComboBox()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Almacen");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet BuscarAlmacenPorNombre(string almacen)
        {
            SqlCommand sentencia = new SqlCommand("SELECT IdAlmacen, Nombre, Descripcion, PrecioUnitario, CONCAT(CAST(Stock AS NVARCHAR), ' ', UnidadMedida) AS StockMedida FROM Almacen WHERE Nombre LIKE @Nombre");
            sentencia.Parameters.AddWithValue("@Nombre", "%" + almacen + "%");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet BuscarAlmacenPorNombre_MostrarSoloNombre(string almacen)
        {
            SqlCommand sentencia = new SqlCommand("SELECT IdAlmacen, Nombre FROM Almacen WHERE Nombre LIKE @Nombre");
            sentencia.Parameters.AddWithValue("@Nombre", "%" + almacen + "%");
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
