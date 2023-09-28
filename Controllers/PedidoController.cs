using Sl1_Front.Models;
using Sl1_Front.ServiceAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sl1_Front.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        PedidoService servicePedido = new PedidoService();
        public ActionResult Pedido()
        {
            var model = new Pedido();
            var serviceDonas = new DonasService();
            var getDonas = serviceDonas.GetDonas();
            ViewBag.IdDona = new SelectList(getDonas, "Id", "Nombre", 0);
            return View(model);
        }
        [HttpPost]
        public JsonResult CrearPedido(Pedido pedido)
        {
            try
            {
                var pedidoService = new PedidoService();
                var response = pedidoService.CrearPedido(pedido);
            }
            catch (Exception ex)
            {
                _ = ex.ToString();
                return Json(new { status = 500, message = "Error", error = ex.ToString() });
            }
            return Json(new {status = 200, message = "Ok" });
        }
        public ActionResult Ventakrispy()
        {
            ViewBag.Message = "Esta consulta recupera las ventas de chocolate y con cantidad mayores a 10 ";
            var model = new List<Pedido>();
            var pedidos = servicePedido.GetPedidos();
            model = pedidos.Where(x => x.IdDona == 1 && x.Cantidad > 10).ToList();
            return View(model);
        }
    }
}