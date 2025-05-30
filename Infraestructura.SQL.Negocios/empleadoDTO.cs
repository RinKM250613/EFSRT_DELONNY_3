using Dominio.Entidad.Negocio.Abstraccion;
using Dominio.Entidad.Negocio.Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.SQL.Negocios
{
    public class empleadoDTO : IEmpleado
    {
        public IEnumerable<Empleado> GetAll()
        {
            List<Empleado> temporal = new List<Empleado>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("USP_LISTAR_EMPLEADOS_CBO", con))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            temporal.Add(new Empleado()
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

    }
}
