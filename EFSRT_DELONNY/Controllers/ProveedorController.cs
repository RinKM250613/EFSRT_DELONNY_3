using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Entidad.Negocio.Abstraccion;
using Dominio.Entidad.Negocio.Entidad;
using Infraestructura.SQL.Negocios;

namespace EFSRT_DELONNY.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        proveedorDAO _proveedor = new proveedorDAO();
        distritoDTO _distrito = new distritoDTO();



        public ActionResult MantLstProveedor()
        {
            return View(_proveedor.GetAll());
        }


        [HttpGet]
        public ActionResult CrearProveedor()
        {
            ViewBag.Distrito = new SelectList(_distrito.GetAll(), "codigo", "nombre");

            return View(new Proveedor());
        }

        [HttpPost]
        public ActionResult CrearProveedor(Proveedor registro)
        {
            ViewBag.mensaje = _proveedor.Add(registro);
            ViewBag.Distrito = new SelectList(_distrito.GetAll(), "codigo", "nombre", registro.codDistrito);

            return View(registro);
        }




        [HttpGet]
        public ActionResult ActualizarProveedor(string id = "")
        {
            Proveedor registro = _proveedor.Find(id);
            ViewBag.Distrito = new SelectList(_distrito.GetAll(), "codigo", "nombre", registro.codDistrito);


            return View(registro);
        }

        [HttpPost]
        public ActionResult ActualizarProveedor(Proveedor registro)
        {
            ViewBag.mensaje = _proveedor.Update(registro);

            ViewBag.Distrito = new SelectList(_distrito.GetAll(), "codigo", "nombre", registro.codDistrito);


            return View(registro);
        }


        [HttpGet]
        public ActionResult DetallesProveedor(string id = "")
        {
            Proveedor registro = _proveedor.Find(id);

            return View(registro);
        }


        [HttpGet]
        public ActionResult EliminarProveedor(string id = "")
        {
            Proveedor registro = _proveedor.Find(id);

            return View(registro);
        }

        [HttpPost, ActionName("EliminarProveedor")]
        public ActionResult EliminarProveedor_Confirmacion(string id)
        {
            TempData["mensaje"] = _proveedor.Delete(id);
            return RedirectToAction("MantLstProveedor");
        }




    }
}