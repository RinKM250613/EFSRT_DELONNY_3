using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Entidad.Negocio.Entidad;
using Dominio.Entidad.Negocio.Entidad.Reportes;
using Infraestructura.SQL.Negocios;

namespace EFSRT_DELONNY.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte

        categoriaDTO _categoria = new categoriaDTO();
        productoDAO _producto = new productoDAO();
        reporteProductoDAO _rep = new reporteProductoDAO();
        


        public ActionResult ReporteStock(string categoria = "")
        {
            ViewBag.Categorias = new SelectList(_categoria.GetAll(), "codigo", "nombre");

            ReporteProducto objProducto = new ReporteProducto();
            objProducto.codCategoria = categoria;
            return View(_rep.ComboCategoriaStock(objProducto));
        }
        public ActionResult ReporteVenta(string categoria = "")
        {
            ViewBag.Categorias = new SelectList(_categoria.GetAll(), "codigo", "nombre");

            ReporteProducto objProducto = new ReporteProducto();
            objProducto.codCategoria = categoria;
            return View(_rep.GetCategoriaVentas(objProducto));
        }


        public ActionResult DescargarPDFStock(string categoria = "" )
        {
            ReporteProducto objProducto = new ReporteProducto();
            objProducto.codCategoria = categoria;
            
            var productos = _rep.ComboCategoriaStock(objProducto); 

            return new Rotativa.ViewAsPdf("DescargarPDFStock", productos)
            {
                FileName = $"ReporteStock_{categoria}.pdf",
                PageSize = Rotativa.Options.Size.A4,
                PageOrientation = Rotativa.Options.Orientation.Portrait,
             
            };
        }
        public ActionResult DescargarPDFVentas(string categoria = "")
        {
            ReporteProducto objProducto = new ReporteProducto();
            objProducto.codCategoria = categoria;

            var productos = _rep.GetCategoriaVentas(objProducto);

            return new Rotativa.ViewAsPdf("DescargarPDFVentas", productos)
            {
                FileName = $"ReporteVentas_{categoria}.pdf",
                PageSize = Rotativa.Options.Size.A4,
                PageOrientation = Rotativa.Options.Orientation.Portrait,

            };
        }
    }
}