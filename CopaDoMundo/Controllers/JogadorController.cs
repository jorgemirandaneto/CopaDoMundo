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

        protected override void Dispose(bool disposing)
        {
            unitOdWork.Dispose();
            base.Dispose(disposing);
        }
    }
}