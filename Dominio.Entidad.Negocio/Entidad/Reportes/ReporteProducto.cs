using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad.Negocio.Entidad.Reportes
{
    public class ReporteProducto
    {
        public string codProducto { get; set; }
        public string nombreProducto { get; set; }
        public string codCategoria { get; set; }

        [Display(Name = "Cod Prod"), Required]
        public string codigo { get; set; }
        [Display(Name = "Nombre"), Required] public string nombre { get; set; }
        [Display(Name = "Stock"), Required] public int stock { get; set; }
        [Display(Name = "Precio"), Required] public decimal precio { get; set; }
        [Display(Name = "Desc"), Required] public string descripcion { get; set; }
        public int TotalVendido { get; set; }
    }
}
