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
    internal class CategoriasCD
    {
        ConexionCD conexion;

        public CategoriasCD()
        {
            conexion = new ConexionCD();
        }

        // Agregar una nueva categoría
        public bool Agregar(CategoriasCL oCategoriasCL)
        {
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Categorias (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)");
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oCategoriasCL.Nombre;
            SQLComando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = oCategoriasCL.Descripcion;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        // Eliminar una categoría
        public bool Eliminar(CategoriasCL oCategoriasCL)
        {
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Categorias WHERE IdCategoria = @IdCategoria");
            SQLComando.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = oCategoriasCL.IdCategoria;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        // Editar una categoría existente
        public bool Editar(CategoriasCL oCategoriasCL)
        {
            SqlCommand SQLComando = new SqlCommand("UPDATE Categorias SET Nombre = @Nombre, Descripcion = @Descripcion WHERE IdCategoria = @IdCategoria");
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = oCategoriasCL.Nombre;
            SQLComando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = oCategoriasCL.Descripcion;
            SQLComando.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = oCategoriasCL.IdCategoria;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);
        }

        // Mostrar todas las categorías
        public DataSet MostrarCategorias()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Categorias");
            return conexion.EjecutarSentencia(sentencia);
        }

        // Buscar categorías por nombre
        public DataSet BuscarCategoriasPorNombre(string nombre)
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Categorias WHERE Nombre LIKE @Nombre");
            sentencia.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
