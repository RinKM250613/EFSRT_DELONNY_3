using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad.Negocio.Entidad
{
    public class DetallePedido
    {
        [Display(Name = "Id Artefacto"), Required] public string IdArtefacto { get; set; }
    }
}
