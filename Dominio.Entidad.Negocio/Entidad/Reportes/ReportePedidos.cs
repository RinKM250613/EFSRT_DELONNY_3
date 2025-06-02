using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad.Negocio.Entidad.Reportes
{
    public class ReportePedidos 
    {
        // Reporte x Fecha
        public string codPedido { get; set; }
        public string codCliente { get; set; }
        public string codEmpleado { get; set; }
        public DateTime fechaPedido { get; set; }
        public DateTime? fechaEntrega { get; set; }
        public DateTime? fechaEnvio { get; set; }
        public DateTime? fechaInicio { get; set; }
        public DateTime? fechaFin { get; set; }
        public string estadoEnvio { get; set; }
        public short cantidadPedido { get; set; }
        public string direccionDestino { get; set; }
        public string ciudadDestino { get; set; }
        public bool estadoPedido { get; set; }

    }
}
