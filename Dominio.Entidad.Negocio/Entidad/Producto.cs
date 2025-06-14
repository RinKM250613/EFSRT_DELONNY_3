﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dominio.Entidad.Negocio.Entidad
{
    public class Producto
    {
        [Display(Name = "Cod Prod"), Required]
        public string codigo { get; set; }
        [Display(Name = "Nombre"), Required] public string nombre { get; set; }

        [Display(Name = "Categoria"), Required]
        public string codCategoria { get; set; }
        [Display(Name = "Stock"), Required] public int stock { get; set; }
        [Display(Name = "Precio"), Required] public decimal precio { get; set; }
        [Display(Name = "Desc"), Required] public string descripcion { get; set; }

        [Display(Name = "Proveedor"), Required]
        public string codProveedor { get; set; }

        [Display(Name = "Foto"), Required]
        public HttpPostedFileBase foto { get; set; }

        // Mantén esta propiedad para guardar la ruta o nombre de la imagen en la BD
        public string fotoRuta { get; set; }
        public string nomCat { get; set; }

    }
}
