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
    internal class EntradasCD
    {
        ConexionCD conexion;

        public EntradasCD()
        {
            conexion = new ConexionCD();
        }

        public bool Agregar(EntradasCL oEntradasCL)
        {
            SqlTransaction transaccion = null;

            try
            {
                using (SqlConnection conn = conexion.EstablecerConexion())
                {
                    conn.Open();
                    transaccion = conn.BeginTransaction();

                    // Insertar la nueva entrada
                    SqlCommand SQLComandoEntrada = new SqlCommand(
                        "INSERT INTO Entradas (IdAlmacen, FechaEntrada, Cantidad, CostoTotal, IdUsuario, Observaciones) VALUES (@IdAlmacen, @FechaEntrada, @Cantidad, @CostoTotal, @IdUsuario, @Observaciones)",
                        conn, transaccion
                    );

                    SQLComandoEntrada.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = oEntradasCL.IdAlmacen;
                    SQLComandoEntrada.Parameters.Add("@FechaEntrada", SqlDbType.DateTime).Value = DateTime.Parse(oEntradasCL.FechaEntrada);
                    SQLComandoEntrada.Parameters.Add("@Cantidad", SqlDbType.Int).Value = oEntradasCL.Cantidad;
                    SQLComandoEntrada.Parameters.Add("@CostoTotal", SqlDbType.Decimal).Value = oEntradasCL.CostoTotal;
                    SQLComandoEntrada.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = oEntradasCL.IdUsuario;
                    SQLComandoEntrada.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = oEntradasCL.Observaciones;

                    SQLComandoEntrada.ExecuteNonQuery();

                    // Actualizar el stock en Almacen
                    SqlCommand SQLComandoStock = new SqlCommand(
                        "UPDATE Almacen SET Stock = Stock + @Cantidad WHERE IdAlmacen = @IdAlmacen",
                        conn, transaccion
                    );

                    SQLComandoStock.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = oEntradasCL.IdAlmacen;
                    SQLComandoStock.Parameters.Add("@Cantidad", SqlDbType.Int).Value = oEntradasCL.Cantidad;

                    SQLComandoStock.ExecuteNonQuery();

                    // Confirmar la transacción
                    transaccion.Commit();

                    return true; // Operación exitosa
                }
            }
            catch (Exception ex)
            {
                transaccion?.Rollback(); // Revertir la transacción en caso de error
                Console.WriteLine("Error al agregar entrada y actualizar stock: " + ex.Message);
                return false;
            }
        }

        
        // Eliminar un producto
        public bool Eliminar(EntradasCL oEntradasCL)
        {
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Entradas WHERE IdEntrada = @IdEntrada");
            SQLComando.Parameters.Add("@IdEntrada", SqlDbType.Int).Value = oEntradasCL.IdEntrada;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        // Editar un producto existente
        public bool Editar(EntradasCL oEntradasCL)
        {
            SqlTransaction transaccion = null;

            try
            {
                using (SqlConnection conn = conexion.EstablecerConexion())
                {
                    conn.Open();
                    transaccion = conn.BeginTransaction();

                    // Obtener la cantidad actual de la entrada
                    SqlCommand SQLComandoObtenerCantidad = new SqlCommand(
                        "SELECT Cantidad FROM Entradas WHERE IdEntrada = @IdEntrada",
                        conn, transaccion
                    );
                    SQLComandoObtenerCantidad.Parameters.Add("@IdEntrada", SqlDbType.Int).Value = oEntradasCL.IdEntrada;

                    int cantidadAnterior = (int)SQLComandoObtenerCantidad.ExecuteScalar();

                    // Calcular la diferencia de cantidad
                    int diferenciaCantidad = oEntradasCL.Cantidad - cantidadAnterior;

                    // Actualizar la entrada
                    SqlCommand SQLComandoEntrada = new SqlCommand(
                        "UPDATE Entradas SET IdAlmacen = @IdAlmacen, FechaEntrada = @FechaEntrada, Cantidad = @Cantidad, CostoTotal = @CostoTotal, IdUsuario = @IdUsuario, Observaciones = @Observaciones WHERE IdEntrada = @IdEntrada",
                        conn, transaccion
                    );

                    SQLComandoEntrada.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = oEntradasCL.IdAlmacen;
                    SQLComandoEntrada.Parameters.Add("@FechaEntrada", SqlDbType.DateTime).Value = DateTime.Parse(oEntradasCL.FechaEntrada);
                    SQLComandoEntrada.Parameters.Add("@Cantidad", SqlDbType.Int).Value = oEntradasCL.Cantidad;
                    SQLComandoEntrada.Parameters.Add("@CostoTotal", SqlDbType.Decimal).Value = oEntradasCL.CostoTotal;
                    SQLComandoEntrada.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = oEntradasCL.IdUsuario;
                    SQLComandoEntrada.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = oEntradasCL.Observaciones;
                    SQLComandoEntrada.Parameters.Add("@IdEntrada", SqlDbType.Int).Value = oEntradasCL.IdEntrada;

                    SQLComandoEntrada.ExecuteNonQuery();

                    // Actualizar el stock en Almacen según la diferencia
                    SqlCommand SQLComandoStock = new SqlCommand(
                        "UPDATE Almacen SET Stock = Stock + @DiferenciaCantidad WHERE IdAlmacen = @IdAlmacen",
                        conn, transaccion
                    );

                    SQLComandoStock.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = oEntradasCL.IdAlmacen;
                    SQLComandoStock.Parameters.Add("@DiferenciaCantidad", SqlDbType.Int).Value = diferenciaCantidad;

                    SQLComandoStock.ExecuteNonQuery();

                    // Confirmar la transacción
                    transaccion.Commit();

                    return true;
                }
            }
            catch (Exception ex)
            {
                transaccion?.Rollback(); // Revertir la transacción en caso de error
                Console.WriteLine("Error al actualizar entrada y stock: " + ex.Message);
                return false;
            }
        }

        public DataSet MostrarEntradas()
        {
            SqlCommand sentencia = new SqlCommand("SELECT e.IdEntrada, a.Nombre AS Producto, e.FechaEntrada, CONCAT(CAST (e.Cantidad AS NVARCHAR), ' ', a.UnidadMedida) AS CantidadMedida, e.CostoTotal, u.Usuario AS Usuario, e.Observaciones FROM Entradas e INNER JOIN Almacen a ON e.IdAlmacen = a.IdAlmacen INNER JOIN Usuarios u ON e.IdUsuario = u.IdUsuario");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet BuscarEntradaPorNombre(string entrada)
        {
            SqlCommand sentencia = new SqlCommand("SELECT e.IdEntrada, a.Nombre AS Producto, e.FechaEntrada, CONCAT(CAST (e.Cantidad AS NVARCHAR), ' ', a.UnidadMedida) AS CantidadMedida, e.CostoTotal, u.Usuario AS Usuario, e.Observaciones FROM Entradas e INNER JOIN Almacen a ON e.IdAlmacen = a.IdAlmacen INNER JOIN Usuarios u ON e.IdUsuario = u.IdUsuario WHERE a.Nombre LIKE @NombreProducto");
            sentencia.Parameters.AddWithValue("@NombreProducto", "%" + entrada + "%");
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
