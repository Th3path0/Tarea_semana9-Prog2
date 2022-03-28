using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Capa_Entidad;

namespace Capa_Acceso_Datos
{
    public class D_cat
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_cat> ListarCategorias(string Buscar)
        {
            SqlDataReader leerfilas;
            SqlCommand cmd = new SqlCommand("SP_BuscarCaterogria", conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Buscar", Buscar);
            leerfilas = cmd.ExecuteReader();

            List<E_cat> Listar = new List<E_cat>();
            while (leerfilas.Read()) {
                Listar.Add(new E_cat
                {
                    Idcategoria = leerfilas.GetInt32(0),
                    Codigocategoria = leerfilas.GetString(1),
                    Nombre = leerfilas.GetString(2),
                    Descripcion = leerfilas.GetString(3)
                });
                

            }
            conexion.Close();
            leerfilas.Close();
            return Listar;
        }
     public void InsertarCat(E_cat categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarCategoria", conexion);
            conexion.Open();

            cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public void EditarCat(E_cat categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_editarCategoria", conexion);
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDcategoria", categoria.Idcategoria);
            cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public void EliminarCat(E_cat categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_eliminarCategoria", conexion);
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDcategoria", categoria.Idcategoria);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }
    }
}
