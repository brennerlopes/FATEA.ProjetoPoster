using FATEA.ProjetoPoster.Web.ViewModels.Usuario;
using FATEA.ProjetoPoster.Web.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using FATEA.ProjetoPoster.Web.Models;

namespace FATEA.ProjetoPoster.Web.Controllers

{

    [AllowAnonymous]
    public class ContaController : Controller
    {
        public ActionResult CriarUsuario()
        {

            PopularPerfil();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarUsuario(UsuarioEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                UserStore<Usuario> userStore
                    = new UserStore<Usuario>(new ProjetoPosterIdentityDbContext());
                UserManager<Usuario> userManager
                    = new UserManager<Usuario>(userStore);
                Usuario user = new Usuario
                {
                    NomeUsuario = viewModel.NomeUsuario,
                    UserName = viewModel.EmailUsuario,
                    RgUsuario = viewModel.RgUsuario,
                    CpfUsuario = viewModel.CpfUsuario



                };

                IdentityResult result = userManager.Create(user, viewModel.Senha);
                if (result.Succeeded)
                {
                    RoleStore<IdentityRole> roleStore
                        = new RoleStore<IdentityRole>(new ProjetoPosterIdentityDbContext());
                    RoleManager<IdentityRole> roleManager
                        = new RoleManager<IdentityRole>(roleStore);
                    IdentityRole selectRole
                        = roleManager.Roles.Single(s => s.Id == viewModel.RoleId);
                    IdentityUser insertedUser = userManager.Find(viewModel.EmailUsuario, viewModel.Senha);
                    userManager.AddToRole(insertedUser.Id, selectRole.Name);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    PopularPerfil();
                    ModelState.AddModelError("identity_error", result.Errors.First());
                    return View(viewModel);
                }
            }
            PopularPerfil();
            return View(viewModel);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                UserStore<Usuario> userStore
                    = new UserStore<Usuario>(new ProjetoPosterIdentityDbContext());
                UserManager<Usuario> userManager
                    = new UserManager<Usuario>(userStore);

                Usuario user = userManager.Find(viewModel.EmailUsuario, viewModel.Senha);

                if (user != null)
                {
                    IAuthenticationManager authManager
                        = HttpContext.GetOwinContext().Authentication;
                    ClaimsIdentity userIdentity =
                        userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    authManager.SignIn(userIdentity);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("identity_error", "Nome de usuário ou senha incorreta");
                    return View(viewModel);
                }

            }

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Logout()
        {
            IAuthenticationManager authManager
                = HttpContext.GetOwinContext().Authentication;

            authManager.SignOut();
            return RedirectToAction("Login", "Conta");
        }

        private void PopularPerfil()
        {
            RoleStore<IdentityRole> roleStore
                = new RoleStore<IdentityRole>(new ProjetoPosterIdentityDbContext());
            RoleManager<IdentityRole> roleManager
                = new RoleManager<IdentityRole>(roleStore);
            ViewBag.Roles = new SelectList(roleManager.Roles, "Id", "Name");
        }

    }
}