using CopaDoMundo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CopaDoMundo.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Login()
        {
            return View();
        }
        // POST : Usuario

        [HttpPost]
        public ActionResult Login(LoginModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/"))
                    {
                        return Redirect(returnUrl); 
                    }
                    else
                    {
                        return RedirectToAction("Index");       
                    }
                }
                else
                {
                    ModelState.AddModelError("","Usuario e senha está incorreto.");
                }
            }return View(model);
        }
    }
}