using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FATEA.ProjetoPoster.Domain;
using FATEA.ProjetoPoster.Web.Models;
using FATEA.ProjetoPoster.Repository.Common;
using FATEA.ProjetoPoster.Repository;
using FATEA.ProjetoPoster.DataAccess.Entity.Context;
using FATEA.ProjetoPoster.Web.ViewModels.Poster;
using AutoMapper;
using System.IO;
using FATEA.ProjetoPoster.Web.ViewModels.Curso;
using Microsoft.AspNet.Identity.EntityFramework;
using FATEA.ProjetoPoster.Web.Identity;
using Microsoft.AspNet.Identity;
using FATEA.ProjetoPoster.Web.ViewModels.Evento;

namespace FATEA.ProjetoPoster.Web.Controllers
{
    public class PostersController : Controller
    {
        private ICrudRepositorio<Poster, long> _repositorio = new PosterRepository(new ProjetoPosterDbContext());
        private ICrudRepositorio<Curso, long> _repositorioCurso = new CursoRepository(new ProjetoPosterDbContext());
        private ICrudRepositorio<Evento, long> _repositorioEvento = new EventoRepository(new ProjetoPosterDbContext());
        private ICrudRepositorio<Avaliacao, long> _repositorioAvaliacao = new AvaliacaoRepository(new ProjetoPosterDbContext());

        // GET: Posters
        public ActionResult Index()
        {
            List<PosterIndexViewModel> viewModels = new List<PosterIndexViewModel>();
            List<Poster> posters = _repositorio.Select();
            viewModels = Mapper.Map<List<Poster>, List<PosterIndexViewModel>>(posters);
            return View(viewModels);
        }

        // GET: Posters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poster poster = _repositorio.ById(id.Value);
            if (poster == null)
            {
                return HttpNotFound();
            }
            PosterEdicaoViewModel viewModel = Mapper.Map<Poster, PosterEdicaoViewModel>(poster);
            return View(viewModel);
        }

        // GET: Posters/Create
        public ActionResult Create()
        {
            CriarListaDeEventos();
            CriarListaDeCursos();
            return View();


        }
		
        private void CriarListaDeEventos()
        {
            List<Evento> eventos = _repositorioEvento.Select(where: x => x.Status != false);
            List<EventoIndexViewModel> eventoViewModels = Mapper.Map<List<Evento>, List<EventoIndexViewModel>>(eventos);
            ViewBag.EventoId = new SelectList(eventoViewModels, "Id", "Nome");
        }

        private void CriarListaDeCursos()
        {
            List<Curso> cursos = _repositorioCurso.Select();
            List<CursoIndexViewModel> cursoViewModels = Mapper.Map<List<Curso>, List<CursoIndexViewModel>>(cursos);
            ViewBag.CursoId = new SelectList(cursoViewModels, "Id", "Nome");

        }

        // POST: Posters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PosterEdicaoViewModel viewModel)
        {
            viewModel.NomeArquivo = GravarArquivo();
            if (viewModel.NomeArquivo != null)
            {
                if (ModelState.IsValid)
                {
                    Poster poster = Mapper.Map<PosterEdicaoViewModel, Poster>(viewModel);
                    _repositorio.Insert(poster);
                    return RedirectToAction("Index");
                }
                else
                {
                    CriarListaDeCursos();
                    CriarListaDeEventos();
                    return View(viewModel);
                }
            }
            ModelState.AddModelError("sem_arquivo", "Insira um arquivo.");
            CriarListaDeCursos();
            return View(viewModel);
        }

        // GET: Posters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poster poster = _repositorio.ById(id.Value);
            if (poster == null)
            {
                return HttpNotFound();
            }
            PosterEdicaoViewModel viewModel = Mapper.Map<Poster, PosterEdicaoViewModel>(poster);
            return View(viewModel);
        }

        // POST: Posters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PosterEdicaoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Poster poster = Mapper.Map<PosterEdicaoViewModel, Poster>(viewModel);
                _repositorio.Update(poster);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Posters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poster poster = _repositorio.ById(id.Value);
            if (poster == null)
            {
                return HttpNotFound();
            }
            PosterEdicaoViewModel viewModel = Mapper.Map<Poster, PosterEdicaoViewModel>(poster);
            return View(viewModel);
        }

        // POST: Posters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repositorio.DeleteById(id);
            return RedirectToAction("Index");
        }

        private string GravarArquivo()
        {
            var fileUpload = Request.Files["fileUpload"];
            if (fileUpload != null)
            {
                var fileName = Guid.NewGuid().ToString() +
                  System.IO.Path.GetExtension(fileUpload.FileName);
                var path = Server.MapPath("~/Upload");
                fileUpload.SaveAs(Path.Combine(path, fileName));
                return fileName;
            }
            else
                return null;
        }

        // GET: Posters/AtribuirPoster
        public ActionResult AtribuirPoster()
        {
            List<Poster> posteres = _repositorio.Select();
            List<PosterIndexViewModel> posteresViewModels = Mapper.Map<List<Poster>, List<PosterIndexViewModel>>(posteres);
            ViewBag.Posteres = new SelectList(posteresViewModels, "Id", "Titulo");
            UserStore<IdentityUser> userStore
                    = new UserStore<IdentityUser>(new ProjetoPosterIdentityDbContext());
            UserManager<IdentityUser> userManager
                = new UserManager<IdentityUser>(userStore);
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(new ProjetoPosterIdentityDbContext());
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);
            List<IdentityUser> usuarios = userManager.Users.ToList();
            IdentityRole avaliadorRole = roleManager.Roles.Where(r => r.Name == "AVALIADOR").First();
            usuarios = usuarios.Where(u => u.Roles.First().RoleId == avaliadorRole.Id).ToList();
            ViewBag.Avaliadores = new SelectList(usuarios, "Id", "UserName");
            return View();

        }

        // POST: Posters/AtribuirPoster
        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult AtribuirPoster(AtribuirPosterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                
                Avaliacao avaliacao = Mapper.Map<AtribuirPosterViewModel, Avaliacao>(viewModel);
                _repositorioAvaliacao.Insert(avaliacao);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
    }
}

