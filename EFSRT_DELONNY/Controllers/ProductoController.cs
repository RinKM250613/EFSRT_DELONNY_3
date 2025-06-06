using Dominio.Entidad.Negocio.Entidad;
using Infraestructura.SQL.Negocios;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;

namespace EFSRT_DELONNY.Controllers
{
    public class ProductoController : Controller
    {
        categoriaDTO _categoria = new categoriaDTO();
        proveedorDTO _proveedor = new proveedorDTO();
        productoDAO _producto = new productoDAO();
        public ActionResult MantLstProductos(string categoria = "", string nombre = "")
        {
            ViewBag.Categorias = new SelectList(_categoria.GetAll(), "codigo", "nombre");

            Producto objProducto = new Producto();
            objProducto.codCategoria = categoria;
            objProducto.nombre = nombre;

            return View(_producto.GetByNameAndCombo(objProducto));
        }

        [HttpGet]
        public ActionResult CrearProducto()
        {
            ViewBag.Categorias = new SelectList(_categoria.GetAll(), "codigo", "nombre");
            ViewBag.Proveedores = new SelectList(_proveedor.GetAll(), "codigo", "nombre");

            return View(new Producto());
        }

        [HttpPost]
        public ActionResult CrearProducto(Producto registro)
        {
            if (registro.foto != null && registro.foto.ContentLength > 0)
            {
                // Define la carpeta donde se guardarán las imágenes
                var path = Server.MapPath("~/Content/Images");

                // Asegúrate de que la carpeta exista
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Genera un nombre único para el archivo
                var fileName = Path.GetFileName(registro.foto.FileName);
                var filePath = Path.Combine(path, fileName);

                // Guarda el archivo en la carpeta
                registro.foto.SaveAs(filePath);

                // Guarda la ruta relativa en la propiedad 'foto'
                registro.fotoRuta = "/Content/Images/" + fileName;
            }

            // Llama al método DAO para agregar el producto
            ViewBag.mensaje = _producto.Add(registro);
            ViewBag.Categorias = new SelectList(_categoria.GetAll(), "codigo", "nombre", registro.codCategoria);
            ViewBag.Proveedores = new SelectList(_proveedor.GetAll(), "codigo", "nombre", registro.codProveedor);

            return View(registro);
        }


        [HttpGet]
        public ActionResult ActualizarProducto(string id = "")
        {
            Producto registro = _producto.Find(id);
            ViewBag.Categorias = new SelectList(_categoria.GetAll(), "codigo", "nombre", registro.codCategoria);
            ViewBag.Proveedores = new SelectList(_proveedor.GetAll(), "codigo", "nombre", registro.codProveedor);

            return View(registro);
        }

        [HttpPost]
        public ActionResult ActualizarProducto(Producto registro)
        {
            ViewBag.mensaje = _producto.Update(registro);

            ViewBag.Categorias = new SelectList(_categoria.GetAll(), "codigo", "nombre", registro.codCategoria);
            ViewBag.Proveedores = new SelectList(_proveedor.GetAll(), "codigo", "nombre", registro.codProveedor);


            return View(registro);
        }

        [HttpGet]
        public ActionResult DetallesProducto(string id = "")
        {
            Producto registro = _producto.Find(id);

            return View(registro);
        }

        [HttpGet]
        public ActionResult EliminarProducto(string id = "")
        {
            Producto registro = _producto.Find(id);

            return View(registro);
        }

        [HttpPost, ActionName("EliminarProducto")]
        public ActionResult EliminarProducto_Confirmacion(string id)
        {
            TempData["mensaje"] = _producto.Delete(id);
            return RedirectToAction("MantLstProductos");
        }


    }
}