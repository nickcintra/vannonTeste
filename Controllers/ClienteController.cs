using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using vannon_teste.Data;
using vannon_teste.Models;
using vannon_teste.Requests;
using vannon_teste.Services;

namespace vannon_teste.Controllers
{
    public class ClienteController : Controller
    {
        private vannonDBContext _context;
        private ClienteService _service;

        public ClienteController()
        {
            _context = new vannonDBContext();
            _service = new ClienteService(_context);
        }

        public ClienteController(vannonDBContext context, ClienteService clienteService)
        {
            _context = context;
            _service = clienteService;
        }


        // GET: Cliente
        public ActionResult Index()
        {
            var model = _service.GetClientes();

            if (model != null)
            {
                return View(model);
            }
            else
            {
                ViewBag.Message = "Erro ao obter Clientes";
                return View(Enumerable.Empty<Cliente>());
            }
        }

        public ActionResult CriarCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarCliente(ClienteRequest cliente)
        {
            bool result = _service.CriarCliente(cliente);

            if(result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Erro ao cadastrar Cliente";
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult EditarCliente(int id)
        {
            var Cliente = _service.PegarClienteId(id);
            if (Cliente == null)
            {
                return HttpNotFound();
            }

            return View(Cliente);
        }

        [HttpPost]
        public ActionResult EditarCliente(int id, Cliente ClienteAtualizado)
        {

            bool result = _service.AtualizarCliente(id, ClienteAtualizado);

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Erro ao editar Cliente";
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

        }

        public ActionResult DeletarCliente(int id)
        {

            try
            {
                bool result = _service.DeletarCliente(id);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage = "Erro ao deletar Cliente";
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}