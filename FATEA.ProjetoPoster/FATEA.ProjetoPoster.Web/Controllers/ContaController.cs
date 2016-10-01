using FATEA.ProjetoPoster.Web.ViewModels.Usuario;
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
using FATEA.ProjetoPoster.Domain;
using FATEA.ProjetoPoster.DataAccess.Entity.Context;

namespace FATEA.ProjetoPoster.Web.Controllers

{

    [AllowAnonymous]
    public class ContaController : Controller
    {
        public ActionResult CriarUsuario()
        {
            CadastrarPerfil();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarUsuario(UsuarioEditViewModel viewModel)
        {
            RoleStore<IdentityRole> roleStore
                        = new RoleStore<IdentityRole>(new ProjetoPosterDbContext());
            RoleManager<IdentityRole> roleManager
                = new RoleManager<IdentityRole>(roleStore);
            var role = roleManager.FindByName("ALUNO");
            viewModel.RoleId = role.Id;
            if (ModelState.IsValid)
            {
                UserStore<Usuario> userStore
                    = new UserStore<Usuario>(new ProjetoPosterDbContext());
                UserManager<Usuario> userManager
                    = new UserManager<Usuario>(userStore);
                Usuario user = new Usuario
                {
                    NomeUsuario = viewModel.NomeUsuario,
                    UserName = viewModel.EmailUsuario,
                    RgUsuario = viewModel.RgUsuario,
                    CpfUsuario = viewModel.CpfUsuario,
                };
                IdentityResult result = userManager.Create(user, viewModel.Senha);
                if (result.Succeeded)
                {                  
                        
                    IdentityUser insertedUser = userManager.Find(viewModel.EmailUsuario, viewModel.Senha);
                    userManager.AddToRole(insertedUser.Id, role.Name);

                    return RedirectToAction("Login", "Conta");
                }
                else
                {
                   // PopularPerfil();
                    ModelState.AddModelError("identity_error", result.Errors.First());
                    return View(viewModel);
                }
            }
            //PopularPerfil();
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
                    = new UserStore<Usuario>(new ProjetoPosterDbContext());
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

        //private void PopularPerfil()
        //{
        //    RoleStore<IdentityRole> roleStore
        //        = new RoleStore<IdentityRole>(new ProjetoPosterDbContext());
        //    RoleManager<IdentityRole> roleManager
        //        = new RoleManager<IdentityRole>(roleStore);
        //    ViewBag.Roles = new SelectList(roleManager.Roles, "Id", "Name");
        //}

        private void CadastrarPerfil()
        {
            RoleStore<IdentityRole> roleStore
                = new RoleStore<IdentityRole>(new ProjetoPosterDbContext());
            RoleManager<IdentityRole> roleManager
                = new RoleManager<IdentityRole>(roleStore);

            var role = roleManager.FindByName("ADMINISTRADOR");
            if (role == null)
            {
                role = new IdentityRole("ADMINISTRADOR");
                roleManager.Create(role);
                role = new IdentityRole("PROFESSOR");
                roleManager.Create(role);
                role = new IdentityRole("ALUNO");
                roleManager.Create(role);
              //  PopularPerfil();
            }
            //PopularPerfil();
        }
    }

}
