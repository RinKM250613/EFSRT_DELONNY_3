using Dominio.Entidad.Negocio.Abstraccion;
using Dominio.Entidad.Negocio.Entidad;
using Dominio.Entidad.Negocio.Entidad.Lista;
using Infraestructura.SQL.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFSRT_DELONNY.Controllers
{
    public class PedidoController : Controller
    {
        pedidoDAO _pedido = new pedidoDAO();
        clienteDTO _cliente = new clienteDTO();
        empleadoDTO _empleado = new empleadoDTO();
        public ActionResult ListaPedido(DateTime? fecha = null, string cliente = "", int p = 0)
        {
            //Paginacion

            IEnumerable<PedidoLista> lst = _pedido.GetByDateAndDni(fecha, cliente);


            int c = lst.Count();
            int f = 10;

            int npags = c % f == 0 ? c / f : c / f + 1;

            ViewBag.p = p;
            ViewBag.fecha = fecha;
            ViewBag.cliente = cliente;
            ViewBag.npags = npags;

            return View(lst.Skip(f * p).Take(f));
        }


        [HttpGet]
        public ActionResult CrearPedido()
        {
            ViewBag.Cliente = new SelectList(_cliente.GetAll(), "codigo", "nombre");
            ViewBag.Empleado = new SelectList(_empleado.GetAll(), "codigo", "nombre");

            var estados = new List<string> { "ENTREGADO", "ESPERANDO", "CANCELADO" };
            ViewBag.EstadoEnvio = new SelectList(estados);

            return View(new Pedido());
        }

        [HttpPost]
        public ActionResult CrearPedido(Pedido ped)
        {

            ViewBag.mensaje = _pedido.Add(ped);
            ViewBag.Empleado = new SelectList(_empleado.GetAll(), "codigo", "nombre", ped.codEmpleado);
            ViewBag.Cliente = new SelectList(_cliente.GetAll(), "codigo", "nombre", ped.codCliente);

            var estados = new List<string> { "ENTREGADO", "ESPERANDO", "CANCELADO" };
            ViewBag.EstadoEnvio = new SelectList(estados, ped.estadoEnvio);

            return View(ped);
        }

        [HttpGet]
        public ActionResult ActualizarPedido(string id = "")
        {
            Pedido ped = _pedido.Find(id);

            ViewBag.Empleado = new SelectList(_empleado.GetAll(), "codigo", "nombre", ped.codEmpleado);
            ViewBag.Cliente = new SelectList(_cliente.GetAll(), "codigo", "nombre", ped.codCliente);

            var estados = new List<string> { "ENTREGADO", "ESPERANDO", "CANCELADO" };
            ViewBag.EstadoEnvio = new SelectList(estados, ped.estadoEnvio);

            return View(ped);
        }


        [HttpPost]
        public ActionResult ActualizarPedido(Pedido ped)
        {
            ViewBag.mensaje = _pedido.Update(ped);

            ViewBag.Empleado = new SelectList(_empleado.GetAll(), "codigo", "nombre", ped.codEmpleado);
            ViewBag.Cliente = new SelectList(_cliente.GetAll(), "codigo", "nombre", ped.codCliente);

            var estados = new List<string> { "ENTREGADO", "ESPERANDO", "CANCELADO" };
            ViewBag.EstadoEnvio = new SelectList(estados, ped.estadoEnvio); 

            return View(ped);
        }

        [HttpGet]
        public ActionResult DetallesPedido(string id = "")
        {
            Pedido ped = _pedido.Find(id);

            return View(ped);
        }

        [HttpGet]
        public ActionResult EliminarPedido(string id = "")
        {
            Pedido pedido = _pedido.Find(id);

            return View(pedido);
        }

        [HttpPost, ActionName("EliminarPedido")]
        public ActionResult EliminarPedido_Confirmacion(string id)
        {
            TempData["mensaje"] = _pedido.Delete(id);
            return RedirectToAction("ListaPedido");
        }
    }
}