using Dominio.Entidad.Negocio.Abstraccion;
using Dominio.Entidad.Negocio.Entidad;
using Dominio.Entidad.Negocio.Entidad.Lista;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.SQL.Negocios
{
    public class proveedorDTO : IProveedor
    {
        public string Add(Proveedor registro)
        {
            throw new NotImplementedException();
        }

        public string Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Proveedor Find(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProveedorLista> GetAll()
        {
            List<ProveedorLista> temporal = new List<ProveedorLista>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("USP_LISTAR_PROVEEDORES_CBO", con))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            temporal.Add(new ProveedorLista()
                            {
                                codigo = reader.GetString(0),
                                nombre = reader.GetString(1)

                            });
                        }
                    }
                }
            }
            return temporal;
        }

        public string Update(Proveedor registro)
        {
            throw new NotImplementedException();
        }
    }
}
