using CopaDoMundo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CopaDoMundo.Controllers
{
    public class JogadorController : Controller
    {
        UnitOfWork unitOdWork = new UnitOfWork();
        public ActionResult Create()
        {
            ViewBag.SelecaoId = new SelectList(unitOdWork.SelecaoRepository.Selecoes, "Id", "Pais");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                unitOdWork.JogadorRepository.Adicionar(jogador);
                unitOdWork.Salvar();
                return RedirectToAction("Index");
            }
            ViewBag.SelecaoId = new SelectList(unitOdWork.SelecaoRepository.Selecoes, "Id", "Pais");
            return View();
        }

        public ActionResult Index()
        {
            ViewBag.SelecaoId = new SelectList(unitOdWork.SelecaoRepository.Selecoes, "Id", "Pais");
            return View(unitOdWork.JogadorRepository.Jogadores);
        }

        public ActionResult Delete(int id)
        {
            Jogador jogador = unitOdWork.JogadorRepository.Buscar(id);
            ViewBag.SelecaoId = new SelectList(unitOdWork.SelecaoRepository.Selecoes, "Id", "Pais");
            return View(jogador);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOdWork.JogadorRepository.Remove(id);
            unitOdWork.Salvar();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOdWork.Dispose();
            base.Dispose(disposing);
        }
    }
}