using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo>listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true"; 
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select A.Codigo, A.Nombre, A.Descripcion, A.Precio, I.ImagenUrl, C.Descripcion Categoria, M.Descripcion Marca from ARTICULOS AS A INNER JOIN IMAGENES I ON I.IdArticulo = A.Id INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria INNER JOIN MARCAS M ON M.Id = A.IdMarca";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while(lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.codigo = (string)lector["Codigo"];
                    aux.nombre = (string)lector["Nombre"];
                    aux.descripcion = (string)lector["Descripcion"];
                    aux.precio = (decimal)lector["Precio"];
                    aux.imagen = (string)lector["ImagenUrl"];
                    

                    //IMPORTANTE PARA COMPOSICION y PARA TRAER COSAS DE OTRAS TABLAS REGISTROS COMPUESTOS
                    aux.categoria = new Categoria();
                    aux.categoria.nombre = (string)lector["Categoria"];
              
                    aux.marca = new Marca();
                    aux.marca.nombre = (string)lector["Marca"];//PARA LA LISTA DESPLEGABLE Y MODIFICAR
                   




                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }

            catch (Exception ex)
            {
                throw ex; 
            }
        }
    }
}
