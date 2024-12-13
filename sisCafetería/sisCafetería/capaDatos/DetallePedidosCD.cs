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
    internal class DetallePedidosCD
    {
        ConexionCD conexion;

        public DetallePedidosCD()
        {
            conexion = new ConexionCD();
        }

        // Agregar un nuevo producto
        public bool GuardarDetallePedidos(DetallePedidosCL oDetallePedidosCL)
        {
            SqlCommand SQLComando = new SqlCommand("INSERT INTO DetallePedidos (IdPedido, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@IdPedido, @IdProducto, @Cantidad, @PrecioUnitario, @Subtotal)");

            SQLComando.Parameters.Add("@IdPedido", SqlDbType.Int).Value = oDetallePedidosCL.IdPedido;
            SQLComando.Parameters.Add("@IdProducto", SqlDbType.Int).Value = oDetallePedidosCL.IdProducto;
            SQLComando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = oDetallePedidosCL.Cantidad;
            SQLComando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = oDetallePedidosCL.PrecioUnitario;
            SQLComando.Parameters.Add("@Subtotal", SqlDbType.Decimal).Value = oDetallePedidosCL.Subtotal;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        public bool EliminarDetallePedido(DetallePedidosCL oDetallePedidosCL)
        {
            // Crear el comando SQL para eliminar el registro
            SqlCommand SQLComando = new SqlCommand("DELETE FROM DetallePedidos WHERE IdDetallePedido = @IdDetallePedido");

            // Agregar el parámetro para el identificador
            SQLComando.Parameters.Add("@IdDetallePedido", SqlDbType.Int).Value = oDetallePedidosCL.IdDetallePedido;

            // Ejecutar el comando
            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        
    }
}
