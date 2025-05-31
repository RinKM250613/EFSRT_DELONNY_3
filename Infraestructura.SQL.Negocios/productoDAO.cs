using Dominio.Entidad.Negocio.Abstraccion;
using Dominio.Entidad.Negocio.Entidad;
using Dominio.Entidad.Negocio.Entidad.Lista;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Repositorio;

namespace Infraestructura.SQL.Negocios
{
    public class productoDAO : IProducto
    {
        public string Add(Producto registro)
        {
            string mensaje = "";
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("USP_MERGE_PRODUCTOS", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProducto", registro.codigo);
                        cmd.Parameters.AddWithValue("@NomProducto", registro.nombre);
                        cmd.Parameters.AddWithValue("@StockProducto", registro.stock);
                        cmd.Parameters.AddWithValue("@Precio", registro.precio);
                        cmd.Parameters.AddWithValue("@Descripcion", registro.descripcion);
                        cmd.Parameters.AddWithValue("@IdCategoria", registro.codCategoria);
                        cmd.Parameters.AddWithValue("@IdProveedor", registro.codProveedor);
                        cmd.Parameters.AddWithValue("@Foto", registro.foto);

                        int c = cmd.ExecuteNonQuery();
                        mensaje = $"Se ha registrado {c} producto";
                    }
                }
                catch (Exception ex)
                {
                    return mensaje = ex.Message;
                }
            }
            return mensaje;
        }

        public string Update(Producto registro)
        {
            string mensaje = "";
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("USP_MERGE_PRODUCTOS", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProducto", registro.codigo);
                        cmd.Parameters.AddWithValue("@NomProducto", registro.nombre);
                        cmd.Parameters.AddWithValue("@StockProducto", registro.stock);
                        cmd.Parameters.AddWithValue("@Precio", registro.precio);
                        cmd.Parameters.AddWithValue("@Descripcion", registro.descripcion);
                        cmd.Parameters.AddWithValue("@IdCategoria", registro.codCategoria);
                        cmd.Parameters.AddWithValue("@IdProveedor", registro.codProveedor);
                        cmd.Parameters.AddWithValue("@Foto", registro.foto);

                        int c = cmd.ExecuteNonQuery();
                        mensaje = $"Se ha actualizado {c} producto";
                    }
                }
                catch (Exception ex)
                {
                    return mensaje = ex.Message;
                }
            }
            return mensaje;
        }
        public Producto Find(string id)
        {
            Producto reg = new Producto();
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("USP_BUSCAR_PRODUCTO_X_ID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            reg = new Producto()
                            {
                                codigo = reader.GetString(0),
                                nombre = reader.GetString(1),
                                codCategoria = reader.GetString(2),
                                stock = reader.GetInt32(3),
                                precio = reader.GetDecimal(4),
                                descripcion = reader.GetString(5),
                                codProveedor = reader.GetString(6),
                                foto = reader.IsDBNull(7) ? "" : reader.GetString(7)
                            };
                        }
                    }
                }
            }
            return reg;
        }
        public string Delete(string id)
        {
            string mensaje = "";
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("USP_ELIMINAR_PRODUCTO", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProducto", id);

                        int c = cmd.ExecuteNonQuery();
                        mensaje = $"Se ha eliminado {c} producto";
                    }
                }
                catch (Exception ex)
                {
                    return mensaje = ex.Message;
                }
            }
            return mensaje;
        }

        public IEnumerable<ProductoLista> GetAll()
        {
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            List<ProductoLista> tempo = new List<ProductoLista>();
            using (SqlConnection con = new SqlConnection(cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("USP_LISTAR_PRODUCTOS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tempo.Add(new ProductoLista()
                            {
                                codigo = reader.GetString(0),
                                nombre = reader.GetString(1),
                                stock = reader.GetInt32(2),
                                precio = reader.GetDecimal(3),
                                descripcion = reader.GetString(4),
                                nomCategoria = reader.GetString(5),
                                nomProveedor = reader.GetString(6),
                                foto = reader.IsDBNull(7) ? "" : reader.GetString(7)
                            });
                        }
                    }
                }
            }
            return tempo;
        }

        public IEnumerable<Producto> GetByNameAndCombo(Producto registro)
        {
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            List<Producto> tempo = new List<Producto>();
            using (SqlConnection con = new SqlConnection(cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("USP_FILTRAR_CATEGORIA_CBO", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodCat", registro.codCategoria);
                    cmd.Parameters.AddWithValue("@NombreProd", registro.nombre);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tempo.Add(new Producto()
                            {
                                codigo = reader.GetString(0),
                                nombre = reader.GetString(1),
                                stock = reader.GetInt32(2),
                                precio = reader.GetDecimal(3),
                                descripcion = reader.GetString(4),
                                codCategoria = reader.GetString(5),
                                codProveedor = reader.GetString(6)
                            });
                        }
                    }
                }
            }
            return tempo;
        }


    }
}
