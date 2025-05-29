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

namespace Infraestructura.SQL.Negocios
{
    public class proveedorDAO : IProveedor
    {
        public string Add(Proveedor registro)
        {
            string mensaje = "";
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("USP_MERGE_PROVEEDORES", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProveedor", registro.codigo);
                        cmd.Parameters.AddWithValue("@NomProveedor", registro.nombre);
                        cmd.Parameters.AddWithValue("@IdDistrito", registro.codDistrito);
                        cmd.Parameters.AddWithValue("@FonoProveedor", registro.fono);
                       

                        int c = cmd.ExecuteNonQuery();
                        mensaje = $"Se ha registrado {c} proveedor";
                    }
                }
                catch (Exception ex)
                {
                    return mensaje = ex.Message;
                }
            }
            return mensaje;






        }
        public string Update(Proveedor registro)
        {
            string mensaje = "";
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cadena))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("USP_MERGE_PROVEEDORES", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProveedor", registro.codigo);
                        cmd.Parameters.AddWithValue("@NomProveedor", registro.nombre);
                        cmd.Parameters.AddWithValue("@IdDistrito", registro.codDistrito);
                        cmd.Parameters.AddWithValue("@FonoProveedor", registro.fono);
                        

                        int c = cmd.ExecuteNonQuery();
                        mensaje = $"Se ha actualizado {c} proveedor";
                    }
                }
                catch (Exception ex)
                {
                    return mensaje = ex.Message;
                }
            }
            return mensaje;





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
                    using (SqlCommand cmd = new SqlCommand("USP_ELIMINAR_PROVEEDOR", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProveedor", id);

                        int c = cmd.ExecuteNonQuery();
                        mensaje = $"Se ha eliminado {c} proveedor";
                    }
                }
                catch (Exception ex)
                {
                    return mensaje = ex.Message;
                }
            }
            return mensaje;
        }

        public Proveedor Find(string id)
        {
            Proveedor reg = new Proveedor();
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("USP_BUSCAR_PROVEEDOR_X_ID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProveedor", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            reg = new Proveedor()
                            {
                                codigo = reader.GetString(0),
                                nombre = reader.GetString(1),
                                codDistrito = reader.GetInt32(2),
                                fono = reader.GetString(3)

                            };
                        }
                    }
                }
            }
            return reg;
        }

        public IEnumerable<ProveedorLista> GetAll()
        {
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            List<ProveedorLista> tempo = new List<ProveedorLista>();
            using (SqlConnection con = new SqlConnection(cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("USP_LISTAR_PROVEEDORES", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tempo.Add(new ProveedorLista()
                            {
                                codigo = reader.GetString(0),
                                nombre = reader.GetString(1),
                                codDistrito = reader.GetString(2),
                                fono = reader.GetString(3)
                               
                            });
                        }
                    }
                }
            }

	
            return tempo;
        }

        public IEnumerable<ProveedorLista> GetByName(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
