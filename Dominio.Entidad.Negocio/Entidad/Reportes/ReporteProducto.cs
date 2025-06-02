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
        [Display(Name = "Código Producto"), Required] public string codProducto { get; set; }
        [Display(Name = "Nombre"), Required] public string nombre { get; set; }
        [Display(Name = "Código categoria"), Required] public string codCategoria { get; set; }
        [Display(Name = "Categoria"), Required] public string nomCategoria { get; set; }
        [Display(Name = "Stock"), Required] public int stock { get; set; }
        [Display(Name = "Precio"), Required] public decimal precio { get; set; }
        public int TotalVendido { get; set; }
    }
}
