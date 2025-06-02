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
                                codProducto = reader.GetString(0),
                                nombre = reader.GetString(1),
                                stock = reader.GetInt32(2),
                                precio = reader.GetDecimal(3),
                                codCategoria = reader.GetString(4),
                                nomCategoria = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return tempo;
        }

        public IEnumerable<ReporteProducto> FiltroFechas(ReporteProducto registro)
        {
            throw new NotImplementedException();
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
                                nombre =  reader.GetString(1),
                                codCategoria = reader.GetString(2),
                                nomCategoria = reader.GetString(3),
                                TotalVendido = reader.GetInt32(4)
                            });
                        }
                    }
                }
            }
            return tempo;
        }
    }
}
