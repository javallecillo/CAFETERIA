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
    internal class SalidasCD
    {
        ConexionCD conexion;

        public SalidasCD()
        {
            conexion = new ConexionCD();
        }

        // Agregar una nueva salida
        public bool Agregar(SalidasCL oSalidasCL)
        {
            SqlTransaction transaccion = null;

            try
            {
                using (SqlConnection conn = conexion.EstablecerConexion())
                {
                    conn.Open();
                    transaccion = conn.BeginTransaction();

                    // Obtener el stock actual en el almacén
                    SqlCommand SQLComandoObtenerStock = new SqlCommand(
                        "SELECT Stock FROM Almacen WHERE IdAlmacen = @IdAlmacen",
                        conn, transaccion
                    );
                    SQLComandoObtenerStock.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = oSalidasCL.IdAlmacen;
                    int stockActual = (int)SQLComandoObtenerStock.ExecuteScalar();

                    // Verificar si hay suficiente stock para la salida
                    if (oSalidasCL.Cantidad > stockActual)
                    {
                        throw new Exception("No hay suficiente stock para realizar esta salida.");
                    }

                    // Insertar la nueva salida
                    SqlCommand SQLComandoSalida = new SqlCommand(
                        "INSERT INTO Salidas (IdAlmacen, FechaSalida, Cantidad, IdUsuario, Observaciones) VALUES (@IdAlmacen, @FechaSalida, @Cantidad, @IdUsuario, @Observaciones)",
                        conn, transaccion
                    );

                    SQLComandoSalida.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = oSalidasCL.IdAlmacen;
                    SQLComandoSalida.Parameters.Add("@FechaSalida", SqlDbType.DateTime).Value = DateTime.Parse(oSalidasCL.FechaSalida);
                    SQLComandoSalida.Parameters.Add("@Cantidad", SqlDbType.Int).Value = oSalidasCL.Cantidad;
                    SQLComandoSalida.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = oSalidasCL.IdUsuario;
                    SQLComandoSalida.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = oSalidasCL.Observaciones;

                    SQLComandoSalida.ExecuteNonQuery();

                    // Actualizar el stock en Almacen
                    SqlCommand SQLComandoStock = new SqlCommand(
                        "UPDATE Almacen SET Stock = Stock - @Cantidad WHERE IdAlmacen = @IdAlmacen",
                        conn, transaccion
                    );

                    SQLComandoStock.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = oSalidasCL.IdAlmacen;
                    SQLComandoStock.Parameters.Add("@Cantidad", SqlDbType.Int).Value = oSalidasCL.Cantidad;

                    SQLComandoStock.ExecuteNonQuery();

                    // Confirmar la transacción
                    transaccion.Commit();

                    return true; // Operación exitosa
                }
            }
            catch (Exception ex)
            {
                transaccion?.Rollback(); // Revertir la transacción en caso de error
                Console.WriteLine("Error al agregar salida y actualizar stock: " + ex.Message);
                return false;
            }
        }



        // Eliminar un producto
        public bool Eliminar(SalidasCL oSalidasCL)
        {
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Salidas WHERE IdSalidas = @IdSalidas");
            SQLComando.Parameters.Add("@IdEntrada", SqlDbType.Int).Value = oSalidasCL.IdSalida;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        // Editar una salida existente
        public bool Editar(SalidasCL oSalidasCL)
        {
            SqlTransaction transaccion = null;

            try
            {
                using (SqlConnection conn = conexion.EstablecerConexion())
                {
                    conn.Open();
                    transaccion = conn.BeginTransaction();

                    // Obtener la cantidad actual de la salida
                    SqlCommand SQLComandoObtenerCantidad = new SqlCommand(
                        "SELECT Cantidad, IdAlmacen FROM Salidas WHERE IdSalida = @IdSalida",
                        conn, transaccion
                    );
                    SQLComandoObtenerCantidad.Parameters.Add("@IdSalida", SqlDbType.Int).Value = oSalidasCL.IdSalida;

                    SqlDataReader reader = SQLComandoObtenerCantidad.ExecuteReader();
                    if (!reader.Read())
                    {
                        throw new Exception("No se encontró la salida.");
                    }

                    int cantidadAnterior = (int)reader["Cantidad"];
                    int idAlmacen = (int)reader["IdAlmacen"];
                    reader.Close();

                    // Obtener el stock actual en el almacén
                    SqlCommand SQLComandoObtenerStock = new SqlCommand(
                        "SELECT Stock FROM Almacen WHERE IdAlmacen = @IdAlmacen",
                        conn, transaccion
                    );
                    SQLComandoObtenerStock.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = idAlmacen;
                    int stockActual = (int)SQLComandoObtenerStock.ExecuteScalar();

                    // Verificar si hay suficiente stock para la nueva salida
                    if (oSalidasCL.Cantidad > stockActual + cantidadAnterior)
                    {
                        throw new Exception("No hay suficiente stock para realizar esta salida.");
                    }

                    // Calcular la diferencia de cantidad
                    int diferenciaCantidad = oSalidasCL.Cantidad - cantidadAnterior;

                    // Actualizar la salida
                    SqlCommand SQLComandoSalida = new SqlCommand(
                        "UPDATE Salidas SET IdAlmacen = @IdAlmacen, FechaSalida = @FechaSalida, Cantidad = @Cantidad, IdUsuario = @IdUsuario, Observaciones = @Observaciones WHERE IdSalida = @IdSalida",
                        conn, transaccion
                    );

                    SQLComandoSalida.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = oSalidasCL.IdAlmacen;
                    SQLComandoSalida.Parameters.Add("@FechaSalida", SqlDbType.DateTime).Value = DateTime.Parse(oSalidasCL.FechaSalida);
                    SQLComandoSalida.Parameters.Add("@Cantidad", SqlDbType.Int).Value = oSalidasCL.Cantidad;
                    SQLComandoSalida.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = oSalidasCL.IdUsuario;
                    SQLComandoSalida.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = oSalidasCL.Observaciones;
                    SQLComandoSalida.Parameters.Add("@IdSalida", SqlDbType.Int).Value = oSalidasCL.IdSalida;

                    SQLComandoSalida.ExecuteNonQuery();

                    // Actualizar el stock en Almacen según la diferencia
                    SqlCommand SQLComandoStock = new SqlCommand(
                        "UPDATE Almacen SET Stock = Stock - @DiferenciaCantidad WHERE IdAlmacen = @IdAlmacen",
                        conn, transaccion
                    );

                    SQLComandoStock.Parameters.Add("@IdAlmacen", SqlDbType.Int).Value = oSalidasCL.IdAlmacen;
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
                Console.WriteLine("Error al actualizar salida y stock: " + ex.Message);
                return false;
            }
        }

        public DataSet MostrarSalidas()
        {
            SqlCommand sentencia = new SqlCommand(
                "SELECT s.IdSalida, a.Nombre AS Producto, s.FechaSalida, CONCAT(CAST (s.Cantidad AS NVARCHAR), ' ', a.UnidadMedida) AS CantidadMedida, u.Usuario AS Usuario, s.Observaciones " +
                "FROM Salidas s " +
                "INNER JOIN Almacen a ON s.IdAlmacen = a.IdAlmacen " +
                "INNER JOIN Usuarios u ON s.IdUsuario = u.IdUsuario"
            );
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet BuscarSalidaPorNombre(string producto)
        {
            SqlCommand sentencia = new SqlCommand(
                "SELECT s.IdSalida, a.Nombre AS Producto, s.FechaSalida, CONCAT(CAST (s.Cantidad AS NVARCHAR), ' ', a.UnidadMedida) AS CantidadMedida, u.Usuario AS Usuario, s.Observaciones " +
                "FROM Salidas s " +
                "INNER JOIN Almacen a ON s.IdAlmacen = a.IdAlmacen " +
                "INNER JOIN Usuarios u ON s.IdUsuario = u.IdUsuario " +
                "WHERE a.Nombre LIKE @NombreProducto"
            );
            sentencia.Parameters.AddWithValue("@NombreProducto", "%" + producto + "%");
            return conexion.EjecutarSentencia(sentencia);
        }


    }
}
