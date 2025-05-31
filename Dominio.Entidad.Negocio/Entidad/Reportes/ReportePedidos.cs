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



        [Display(Name = "Cod Pedido"), Required]
        public string codPedido { get; set; }

        [Display(Name = "Cod Cliente"), Required]
        public string codCliente { get; set; }

        [Display(Name = "Cod Empleado"), Required]
        public string codEmpleado { get; set; }

        [Display(Name = "Fecha Pedido"), Required]
        public DateTime fechaPedido { get; set; }

        [Display(Name = "Fecha Entrega")]
        public DateTime? fechaEntrega { get; set; }

        [Display(Name = "Fecha Envío")]
        public DateTime? fechaEnvio { get; set; }
        [Display(Name = "Fecha Inicio")]
        public DateTime? fechaInicio { get; set; }
        [Display(Name = "Fecha Fin")]
        public DateTime? fechaFin { get; set; }

        [Display(Name = "Estado Fin")]
        public string estadoEnvio { get; set; }

        [Display(Name = "Cantidad Pedido")]
        public short cantidadPedido { get; set; }

        [Display(Name = "Destino")]
        public string destino { get; set; }

        [Display(Name = "Dirección Destino")]
        public string direccionDestino { get; set; }

        [Display(Name = "Ciudad Destino")]
        public string ciudadDestino { get; set; }

        [Display(Name = "Estado Pedido")]
        public bool estadoPedido { get; set; }

        [Display(Name = "Cod Detalle Pedido")]
        public int codDetallePedido { get; set; }

        [Display(Name = "Cod Producto")]
        public string codProducto { get; set; }

        [Display(Name = "Nombre Producto")]
        public string nombreProducto { get; set; }

        [Display(Name = "Cantidad Detalle")]
        public byte cantidadDetalle { get; set; }

        [Display(Name = "Precio Unitario")]
        public decimal precioUnitario { get; set; }

        [Display(Name = "Estado Detalle")]
        public bool estadoDetalle { get; set; }





    }
}
