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
    internal class PedidosCD
    {
        ConexionCD conexion;

        public PedidosCD()
        {
            conexion = new ConexionCD();
        }

        // Nuevo método para guardar pedido con sus detalles
        public bool GuardarPedidoConDetalles(PedidosCL oPedidosCL, List<DetallePedidosCL> detalles)
        {
            SqlConnection connection = conexion.AbrirConexion();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // Guardar el pedido
                SqlCommand guardarPedidoCmd = new SqlCommand(
                    "INSERT INTO Pedidos (Fecha, TipoPedido, NumeroMesa, FormaPago, IdUsuario, Total) " +
                    "OUTPUT INSERTED.IdPedido " +
                    "VALUES (@Fecha, @TipoPedido, @NumeroMesa, @FormaPago, @IdUsuario, @Total)",
                    connection, transaction);

                guardarPedidoCmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = DateTime.Parse(oPedidosCL.Fecha);
                guardarPedidoCmd.Parameters.Add("@TipoPedido", SqlDbType.VarChar).Value = oPedidosCL.TipoPedido;
                guardarPedidoCmd.Parameters.Add("@NumeroMesa", SqlDbType.Int).Value = oPedidosCL.NumeroMesa.HasValue ? oPedidosCL.NumeroMesa.Value : (object)DBNull.Value;
                guardarPedidoCmd.Parameters.Add("@FormaPago", SqlDbType.VarChar).Value = oPedidosCL.FormaPago;
                guardarPedidoCmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = oPedidosCL.IdUsuario;
                guardarPedidoCmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = oPedidosCL.Total;

                int idPedido = (int)guardarPedidoCmd.ExecuteScalar(); // Obtener el ID del pedido recién insertado

                // Guardar los detalles del pedido
                foreach (var detalle in detalles)
                {
                    SqlCommand guardarDetalleCmd = new SqlCommand(
                        "INSERT INTO DetallePedidos (IdPedido, IdProducto, Cantidad, PrecioUnitario, SubTotal) " +
                        "VALUES (@IdPedido, @IdProducto, @Cantidad, @PrecioUnitario, @SubTotal)",
                        connection, transaction);

                    guardarDetalleCmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = idPedido;
                    guardarDetalleCmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = detalle.IdProducto;
                    guardarDetalleCmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = detalle.Cantidad;
                    guardarDetalleCmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = detalle.PrecioUnitario;
                    guardarDetalleCmd.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = detalle.Subtotal;

                    guardarDetalleCmd.ExecuteNonQuery();
                }

                // Confirmar la transacción
                transaction.Commit();
                return true;
            }
            catch
            {
                // Revertir la transacción si ocurre un error
                transaction.Rollback();
                return false;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public DataSet MostrarPedidosDelDia()
        {
            SqlCommand sentencia = new SqlCommand(@"
                SELECT p.IdPedido AS 'ID', p.Fecha, p.Total, u.Usuario AS Usuario, 
                       p.TipoPedido AS 'Tipo de pedido', p.FormaPago AS 'Forma de Pago'
                FROM Pedidos p
                INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario
                WHERE CAST(p.Fecha AS DATE) = CAST(GETDATE() AS DATE)"); // Filtra pedidos del día actual
            
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet MostrarPedidosPorUsuario(int idUsuario)
        {
            SqlCommand sentencia = new SqlCommand(@"
                SELECT p.IdPedido AS 'ID', p.Fecha, p.Total, u.Usuario AS Usuario, 
                       p.TipoPedido AS 'Tipo de pedido', p.FormaPago AS 'Forma de Pago'
                FROM Pedidos p
                INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario
                WHERE p.IdUsuario = @IdUsuario"); // Filtra por el usuario especificado
            sentencia.Parameters.AddWithValue("@IdUsuario", idUsuario);
            return conexion.EjecutarSentencia(sentencia);
        }


        public DataSet MostrarPedidosPorFechaYUsuario(int idUsuario, DateTime fechaInicio, DateTime fechaFin)
        {
            SqlCommand sentencia = new SqlCommand(@"
                SELECT p.IdPedido AS 'ID', p.Fecha, p.Total, u.Usuario AS Usuario, 
                       p.TipoPedido AS 'Tipo de pedido', p.FormaPago AS 'Forma de Pago'
                FROM Pedidos p
                INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario
                WHERE p.IdUsuario = @IdUsuario
                AND CAST(p.Fecha AS DATE) BETWEEN @FechaInicio AND @FechaFin");
            sentencia.Parameters.AddWithValue("@IdUsuario", idUsuario);
            sentencia.Parameters.AddWithValue("@FechaInicio", fechaInicio);
            sentencia.Parameters.AddWithValue("@FechaFin", fechaFin);
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet MostrarPedidosDelDiaPorUsuario(int idUsuario)
        {
            SqlCommand sentencia = new SqlCommand(@"
                SELECT p.IdPedido AS 'ID', p.Fecha, p.Total, u.Usuario AS Usuario, 
                       p.TipoPedido AS 'Tipo de pedido', p.FormaPago AS 'Forma de Pago'
                FROM Pedidos p
                INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario
                WHERE CAST(p.Fecha AS DATE) = CAST(GETDATE() AS DATE) -- Ventas del día actual
                AND p.IdUsuario = @IdUsuario");
            sentencia.Parameters.AddWithValue("@IdUsuario", idUsuario);
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet MostrarPedidosPorFechaGeneral(DateTime fechaInicio, DateTime fechaFin)
        {
            SqlCommand sentencia = new SqlCommand(@"
                SELECT p.IdPedido AS 'ID', p.Fecha, p.Total, u.Usuario AS Usuario, 
                       p.TipoPedido AS 'Tipo de pedido', p.FormaPago AS 'Forma de Pago'
                FROM Pedidos p
                INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario
                WHERE CAST(p.Fecha AS DATE) BETWEEN @FechaInicio AND @FechaFin");
            sentencia.Parameters.AddWithValue("@FechaInicio", fechaInicio);
            sentencia.Parameters.AddWithValue("@FechaFin", fechaFin);
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet MostrarDetallePedidos(int idPedido)
        {
            SqlCommand sentencia = new SqlCommand(@"SELECT p.Nombre AS Producto, d.PrecioUnitario AS 'Precio unitario', d.Cantidad, d.Subtotal FROM DetallePedidos d INNER JOIN Productos p ON d.IdProducto = p.IdProducto WHERE d.IdPedido = @IdPedido"); // Filtra los detalles por el IdPedido
            sentencia.Parameters.AddWithValue("@IdPedido", idPedido);
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
