using CopaDoMundo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CopaDoMundo.Controllers
{
    public class SelecaoController : Controller
    {
       private UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Create()    
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Selecao selecao)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SelecaoRepository.Adiciona(selecao);
                unitOfWork.Salvar();
                return RedirectToAction("Index");
            }
            return View(selecao);
        }

        public ActionResult Delete(int id)
        {
            Selecao selecao = unitOfWork.SelecaoRepository.Busca(id);
            return View(selecao);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult confirmaDeleta(int id)
        {
            unitOfWork.SelecaoRepository.Remove(id);
            unitOfWork.Salvar();
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            return View(unitOfWork.SelecaoRepository.Selecoes);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
        }
    }
}