﻿using System;
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
        public List<Articulo> listar()
        {

            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //datos.setearConsulta("Select A.Codigo, A.Nombre, A.Descripcion, A.Precio, I.ImagenUrl, C.Descripcion Categoria, M.Descripcion Marca from ARTICULOS AS A INNER JOIN IMAGENES I ON I.IdArticulo = A.Id INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria INNER JOIN MARCAS M ON M.Id = A.IdMarca"); //ESTA NO ME TRAE DOS REGISTROS PORQUE TIENE NULL EN CATEGORIA
                datos.setearConsulta("SELECT A.Codigo, A.Nombre, A.Descripcion, A.Precio, I.ImagenUrl, ISNULL(C.Descripcion, 'Sin Descripcion') Categoria, C.Id IDCategoria, M.Descripcion Marca, M.Id IDMarca FROM ARTICULOS A LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id LEFT JOIN CATEGORIAS C ON C.Id = A.IdCategoria LEFT JOIN MARCAS M ON M.Id = A.IdMarca"); // ESTA CAMBIA EL ISNNUL POR LA PALABRA SIN DESCRIPCION
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    aux.imagen = datos.Lector["ImagenUrl"] != System.DBNull.Value ? (string)datos.Lector["ImagenUrl"] : $"https://bub.bh/wp-content/uploads/2018/02/image-placeholder.jpg";

                    //IMPORTANTE PARA COMPOSICION y PARA TRAER COSAS DE OTRAS TABLAS REGISTROS COMPUESTOS
                    aux.categoria = new Categoria();
                    aux.categoria.nombre = (string)datos.Lector["Categoria"];
                    aux.categoria.id = (int)datos.Lector["IDCategoria"];

                    aux.marca = new Marca();
                    aux.marca.nombre = (string)datos.Lector["Marca"];//PARA LA LISTA DESPLEGABLE Y MODIFICAR
                    aux.marca.id = (int)datos.Lector["IDMarca"];//PARA LA LISTA DESPLEGABLE Y MODIFICAR

                    lista.Add(aux);
                }
            }

            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            
            return lista;
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Codigo,Nombre, Descripcion , IdMarca, IdCategoria, Precio) values ('" + nuevo.codigo + "', '" + nuevo.nombre + "','" + nuevo.descripcion + "' , @IDMarca , @IDCategoria , @Precio)");
                datos.setearParametros("@IDMarca", nuevo.marca.id);
                datos.setearParametros("@IDCategoria", nuevo.categoria.id);
                datos.setearParametros("@Precio", nuevo.precio);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
