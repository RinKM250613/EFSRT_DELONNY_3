using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad.Negocio.Entidad.Lista
{
    public class PedidoLista
    {
        [Display(Name = "Pedido")] public string codPedido { get; set; }
        [Display(Name = "Cliente")] public string nomCliente { get; set; }

        [Display(Name = "DNI")] public string dniCli { get; set; }
        [Display(Name = "Empleado")] public string nomEmpleado { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fech Generado")] public DateTime fecPedido { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fech Entrega")] public DateTime fecEntrega { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fech Envio")] public DateTime fecEnvio { get; set; }
        [Display(Name = "Estado")] public string estadoEnvio { get; set; }
        [Display(Name = "Cantidad")] public int cantidad { get; set; }
        [Display(Name = "Dirección")] public string direccionDestino { get; set; }
        [Display(Name = "Ciudad")] public string ciudadDestino { get; set; }
    }
}
