using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using vannon_teste.Data;
using vannon_teste.Models;
using vannon_teste.Requests;
using vannon_teste.Services;

namespace vannon_teste.Controllers
{
    public class FilmeController : Controller
    {
        private vannonDBContext _context;
        private FilmeService _service;

        public FilmeController()
        {
            _context = new vannonDBContext();
            _service = new FilmeService(_context);
        }
        public FilmeController(vannonDBContext context, FilmeService filmeServices)
        {
            _context = context;
            _service = filmeServices;
        }

        // GET: Filme
        public ActionResult Index()
        {

            var model = _service.PegarFilmes();

            if (model != null)
            {
                return View(model);
            }
            else
            {
                ViewBag.Message = "Erro ao obter filmes";
                return View(Enumerable.Empty<Filme>());
            }

        }

        public ActionResult CriarFilme()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarFilme(FilmeRequest filme)
        {
            bool result = _service.CriarFilme(filme);

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Erro ao cadastrar Filme";
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult EditarFilme(int id)
        {
            var filme = _service.PegarFilmeId(id);
            if (filme == null)
            {
                return HttpNotFound();
            }

            return View(filme);
        }

        [HttpPost]
        public ActionResult EditarFilme(int id, Filme filmeAtualizado)
        {

            bool result = _service.AtualizarFilme(id, filmeAtualizado);

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Erro ao editar Filme";
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

        }

        public ActionResult DeletarFilme(int id)
        {

            try
            {
                bool result = _service.DeletarFilme(id);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage = "Erro ao deletar Filme";
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

    }
}