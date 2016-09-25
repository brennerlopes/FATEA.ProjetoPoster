using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FATEA.ProjetoPoster.DataAccess.Entity.Context;
using FATEA.ProjetoPoster.Domain;
using FATEA.ProjetoPoster.Web.ViewModels.Evento;
using FATEA.ProjetoPoster.Repository.Common;
using FATEA.ProjetoPoster.Repository;
using FATEA.ProjetoPoster.Web.ViewModels.Curso;
using AutoMapper;

namespace FATEA.ProjetoPoster.Web.Controllers
{
    public class CursosController : Controller
    {
        private ProjetoPosterDbContext db = new ProjetoPosterDbContext();

        private ICrudRepositorio<Curso, long> _repositorio = new CursoRepository(new ProjetoPosterDbContext());
        // GET: Cursos
        public ActionResult Index()
        {
           

            List<CursoIndexViewModel> viewModels = new List<CursoIndexViewModel>();
            List<Curso> cursos = _repositorio.Select();
            viewModels = Mapper.Map<List<Curso>, List<CursoIndexViewModel>>(cursos);
            return View(viewModels);
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = _repositorio.ById(id.Value);
            if (curso == null)
            {
                return HttpNotFound();
            }

            CursoIndexViewModel viewModel = Mapper.Map<Curso, CursoIndexViewModel>(curso);
            return View(viewModel);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CursoEdicaoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Curso curso = Mapper.Map<CursoEdicaoViewModel, Curso>(viewModel);
                _repositorio.Insert(curso);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = _repositorio.ById(id.Value);
            if (curso == null)
            {
                return HttpNotFound();
            }
            CursoEdicaoViewModel viewModel = Mapper.Map<Curso, CursoEdicaoViewModel>(curso);
            return View(viewModel);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CursoEdicaoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Curso curso = Mapper.Map<CursoEdicaoViewModel, Curso>(viewModel);
                _repositorio.Update(curso);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = _repositorio.ById(id.Value);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = _repositorio.ById(id);
            return RedirectToAction("Index");
        }

        
    }
}
