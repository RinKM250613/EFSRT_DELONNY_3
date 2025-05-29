using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad.Negocio.Entidad.Lista
{
    public class ProductoLista
    {
        [Display(Name = "Cod Prod"), Required] public string codigo { get; set; }
        [Display(Name = "Nombre"), Required] public string nombre { get; set; }
        [Display(Name = "Categoria"), Required] public string nomCategoria { get; set; }
        [Display(Name = "Stock"), Required] public int stock { get; set; }
        [Display(Name = "Precio"), Required] public decimal precio { get; set; }
        [Display(Name = "Desc"), Required] public string descripcion { get; set; }
        [Display(Name = "Proveedor"), Required] public string nomProveedor { get; set; }
        [Display(Name = "Foto"), Required] public string foto { get; set; }
    }
}
