﻿using System;
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

namespace FATEA.ProjetoPoster.Web.Controllers
{
    public class PostersController : Controller
    {
        private ICrudRepositorio<Poster, int> _repositorio = new PosterRepository(new ProjetoPosterDbContext());

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

            return View();
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

                    return View(viewModel);
                }
            }
            ModelState.AddModelError("sem_arquivo", "Insira um arquivo.");
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
            var fileUpload =  Request.Files["fileUpload"];
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
    }
}
