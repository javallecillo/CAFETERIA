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
    internal class ProductosCD
    {
        ConexionCD conexion;

        public ProductosCD()
        {
            conexion = new ConexionCD();
        }

        // Agregar un nuevo producto
        public bool Agregar(ProductosCL oProductosCL)
        {
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Productos (Nombre, IdCategoria, Precio, Descripcion, Stock) VALUES (@Nombre, @IdCategoria, @Precio, @Descripcion, @Stock)");

            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oProductosCL.Nombre;
            SQLComando.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = oProductosCL.IdCategoria;
            SQLComando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = oProductosCL.Precio;
            SQLComando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = oProductosCL.Descripcion ?? (object)DBNull.Value; // Permitir NULL en Descripción
            SQLComando.Parameters.Add("@Stock", SqlDbType.Int).Value = oProductosCL.Stock.HasValue ? oProductosCL.Stock.Value : (object)DBNull.Value; // Permitir NULL en Stock

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        // Eliminar un producto
        public bool Eliminar(ProductosCL oProductosCL)
        {
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Productos WHERE IdProducto = @IdProducto");
            SQLComando.Parameters.Add("@IdProducto", SqlDbType.Int).Value = oProductosCL.IdProducto;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        // Editar un producto existente
        public bool Editar(ProductosCL oProductosCL)
        {
            SqlCommand SQLComando = new SqlCommand("UPDATE Productos SET Nombre = @Nombre, IdCategoria = @IdCategoria, Precio = @Precio, Descripcion = @Descripcion, Stock = @Stock WHERE IdProducto = @IdProducto");
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oProductosCL.Nombre;
            SQLComando.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = oProductosCL.IdCategoria;
            SQLComando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = oProductosCL.Precio;
            SQLComando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = oProductosCL.Descripcion;
            SQLComando.Parameters.Add("@Stock", SqlDbType.Int).Value = oProductosCL.Stock;
            SQLComando.Parameters.Add("@IdProducto", SqlDbType.Int).Value = oProductosCL.IdProducto;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        // Mostrar todos los productos
        public DataSet MostrarProductos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT p.IdProducto, p.Nombre, c.Nombre AS Categoria, p.Precio, p.Descripcion, p.Stock FROM Productos p INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria");
            return conexion.EjecutarSentencia(sentencia);
        }

        // Buscar productos por nombre
        public DataSet BuscarProductosPorNombre(string nombre)
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Productos WHERE Nombre LIKE @Nombre");
            sentencia.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
            return conexion.EjecutarSentencia(sentencia);
        }

        // Mostrar todos los productos
        public DataSet MostrarProductosBuscar()
        {
            SqlCommand sentencia = new SqlCommand("SELECT IdProducto, Nombre, Precio, Descripcion FROM Productos");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet BuscarProductoPorNombre_MostrarSoloNombre(string nombre)
        {
            SqlCommand sentencia = new SqlCommand("SELECT IdProducto, Nombre, Precio, Descripcion FROM Productos WHERE Nombre LIKE @Nombre");
            sentencia.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
            return conexion.EjecutarSentencia(sentencia);
        }

        // Mostrar todos los productos
        public DataSet MostrarProductosParaComboBox()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Productos");
            return conexion.EjecutarSentencia(sentencia);
        }

    }
}