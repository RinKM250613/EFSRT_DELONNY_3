using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad.Negocio.Entidad
{
    public class Pedido
    {
        [Display(Name = "Cod Pedido"), Required] public string codPedido { get; set; }
        [Display(Name = "Cod Cliente"), Required] public string codCliente { get; set; }
        [Display(Name = "Cod Empleado"), Required] public string codEmpleado { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fech Generado")] public DateTime fecPedido { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fech Entrega"), Required] public DateTime fecEntrega { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fech Envio"), Required] public DateTime fecEnvio { get; set; }
        [Display(Name = "Estado"), Required] public string estadoEnvio { get; set; }
        [Display(Name = "Cantidad"), Required] public int cantidad { get; set; }
        [Display(Name = "Destino"), Required] public string destino { get; set; }
        [Display(Name = "Dirección"), Required] public string direccionDestino { get; set; }
        [Display(Name = "Ciudad"), Required] public string ciudadDestino { get; set; }

        public Pedido()
        {
            this.fecPedido = DateTime.Now.Date;
            this.fecEnvio = DateTime.Now.Date;
            this.fecEntrega = DateTime.Now.Date;
        }
    }
}
