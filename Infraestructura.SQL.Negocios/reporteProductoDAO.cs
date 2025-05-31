using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidad.Negocio.Abstraccion;
using Dominio.Entidad.Negocio.Entidad.Lista;
using Dominio.Entidad.Negocio.Entidad.Reportes;
using Dominio.Entidad.Negocio.Entidad;

namespace Infraestructura.SQL.Negocios
{
    public class reporteProductoDAO : IReporteProducto
    {
        public IEnumerable<ReporteProducto> ComboCategoriaStock(ReporteProducto registro)
        {
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            List<ReporteProducto> tempo = new List<ReporteProducto>();
            using (SqlConnection con = new SqlConnection(cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SP_REPORTE_STOCK", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodCategoria", registro.codCategoria);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tempo.Add(new ReporteProducto()
                            {
                                codigo = reader.GetString(0),
                                nombre = reader.GetString(1),
                                stock = reader.GetInt32(2),
                                precio = reader.GetDecimal(3),
                                codCategoria = reader.GetString(4),
                                descripcion = reader.GetString(5)

                            });
                        }
                    }
                }
            }
            return tempo;
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
                    cmd.Parameters.AddWithValue("@FechaInicio", registro.fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", registro.fechaFin);

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
                                codDetallePedido = reader.GetInt32(12),
                                codProducto = reader.GetString(13),
                                cantidadDetalle = reader.GetByte(14),
                                precioUnitario = reader.GetDecimal(15),
                                estadoDetalle = reader.GetBoolean(16),
                                nombreProducto = reader.GetString(17)


                            });
                        }
                    }
                }
            }
            return tempo;
        }

        public IEnumerable<ReporteProducto> GetCategoriaVentas(ReporteProducto registro)
        {
            string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            List<ReporteProducto> tempo = new List<ReporteProducto>();
            using (SqlConnection con = new SqlConnection(cadena))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ProductosMasVendidosPorCategoria", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodCat", registro.codCategoria);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tempo.Add(new ReporteProducto()
                            {
                              codProducto = reader.GetString(0),
                                nombreProducto =  reader.GetString(1),
                                codCategoria = reader.GetString(2),
                                TotalVendido = reader.GetInt32(3),

                            });
                        }
                    }
                }
            }
            return tempo;
        }
    }
}
