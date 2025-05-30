using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidad.Negocio.Abstraccion;
using Dominio.Entidad.Negocio.Entidad;

namespace Infraestructura.SQL.Negocios
{
    public class distritoDTO :IDistrito
    {
        public IEnumerable<Distrito> GetAll()
        {
            List<Distrito> temporal = new List<Distrito>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("USP_LISTAR_DISTRITOS_CBO", con))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            temporal.Add(new Distrito()
                            {
                                codigo = reader.GetInt32(0),
                                nombre = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return temporal;
        }
    }
}
