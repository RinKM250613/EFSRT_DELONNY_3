using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Entidad.Negocio.Entidad;
using Infraestructura.SQL.Negocios;

namespace EFSRT_DELONNY.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte

        categoriaDTO _categoria = new categoriaDTO();
        productoDAO _producto = new productoDAO();



        public ActionResult ReporteStock(string categoria = "")
        {
            ViewBag.Categorias = new SelectList(_categoria.GetAll(), "codigo", "nombre");

            Producto objProducto = new Producto();
            objProducto.codCategoria = categoria;
           

            return View(_producto.ComboCategoriaStock(objProducto));
        }


        public ActionResult DescargarPDFStock(string categoria = "" )
        {
            Producto objProducto = new Producto();
            objProducto.codCategoria = categoria;
            
            var productos = _producto.ComboCategoriaStock(objProducto); 

            return new Rotativa.ViewAsPdf("DescargarPDFStock", productos)
            {
                FileName = $"ReporteStock_{categoria}.pdf",
                PageSize = Rotativa.Options.Size.A4,
                PageOrientation = Rotativa.Options.Orientation.Portrait,
             
            };
        }







    }
}