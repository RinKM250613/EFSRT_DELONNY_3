using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidad.Negocio.Abstraccion;
using Dominio.Entidad.Negocio.Entidad.Reportes;
using Dominio.Repositorio;

namespace Infraestructura.SQL.Negocios
{
    public class reportePedidosDAO : IReportePedido
    {
    
        public IEnumerable<ReportePedidos>  ComboCategoriaStock (ReportePedidos registro)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportePedidos> FiltroFechas(ReportePedidos registro)
        {
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            List<ReportePedidos> tempo = new List<ReportePedidos>();
            using (SqlConnection con = new SqlConnection(cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerPedidosPorFecha", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", registro.fechaInicio ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaFin", registro.fechaFin ?? (object)DBNull.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tempo.Add(new ReportePedidos()
                            {
                                codPedido = reader.GetString(0),
                                codCliente = reader.GetString(1),
                                codEmpleado = reader.GetString(2),
                                fechaPedido = reader.GetDateTime(3),
                                fechaEntrega = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                                fechaEnvio = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5),
                                estadoEnvio = reader.GetString(6),
                                cantidadPedido = reader.GetInt16(7),
                                destino = reader.GetString(8),
                                direccionDestino = reader.GetString(9),
                                ciudadDestino = reader.GetString(10),
                                estadoPedido = reader.GetBoolean(11),
                            


                            });
                        }
                    }
                }
            }
            return tempo;
        }

        public IEnumerable<ReportePedidos>GetCategoriaVentas(ReportePedidos registro)
        {
            throw new NotImplementedException();
        }
    }
}
