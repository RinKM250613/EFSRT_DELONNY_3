using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad.Negocio.Entidad.Lista
{
    public class ProveedorLista
    {
        [Display(Name = "Cod Prov")]
        public string codigo { get; set; }
        [Display(Name = "Nombre")] public string nombre { get; set; }

        [Display(Name = "Distrito")]
        public string codDistrito { get; set; }
        [Display(Name = "Telefóno")] public string fono { get; set; }
    }
}
