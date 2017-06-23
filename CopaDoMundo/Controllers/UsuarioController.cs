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
        public ActionResult Login(LoginModel model, string returnUrl)
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
                    ModelState.AddModelError("", "Usuario e senha está incorreto.");
                }
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("", "Erro ao registrar");
                }
            }
            return View(model);
        }

        //get usuarioPassword

        public ActionResult ChangePassword()
        {
            return View();
        }

        //post usuarioPassword
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser correntUser = Membership.GetUser(User.Identity.Name, true);
                    changePasswordSucceeded = correntUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }
                if (changePasswordSucceeded)
                {
                    return RedirectToAction("changePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "Senha atual ou a confirmação está incorreta");
                }
            }
            return View(model);
        }

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        private IEnumerable<string> GetErrorsFromModelState()
        {
            return ModelState.SelectMany(x => x.Value.Errors.Select(erro => erro.ErrorMessage));
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            switch (createStatus)
            {
                case MembershipCreateStatus.Success:
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    return "Usuário invalido";
                case MembershipCreateStatus.InvalidPassword:
                    return "Senha invalida";
                case MembershipCreateStatus.InvalidQuestion:
                    return "Questão invalida para recuperar senha";
                case MembershipCreateStatus.InvalidAnswer:
                    return "Resposta invalida para recuperar senha";
                case MembershipCreateStatus.InvalidEmail:
                    return "Email invalido";
                case MembershipCreateStatus.DuplicateUserName:
                    return "Usuário já existente, defina outro usuário";
                case MembershipCreateStatus.DuplicateEmail:
                    return "Email já existente, defina outro email";
                case MembershipCreateStatus.UserRejected:
                    return "Usuario cancelado";
                case MembershipCreateStatus.ProviderError:
                    return "Problema a autenticar";
                default:
                    break;
            }
            return "Um erro inesperado aconteceu.";
            #endregion
        }
    }
}
