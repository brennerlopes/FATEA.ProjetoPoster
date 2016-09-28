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
using FATEA.ProjetoPoster.Repository.Common;
using FATEA.ProjetoPoster.Repository;
using FATEA.ProjetoPoster.Web.ViewModels.Avaliacao;
using AutoMapper;
using FATEA.ProjetoPoster.Web.ViewModels.Poster;

namespace FATEA.ProjetoPoster.Web.Controllers
{
    public class AvaliacoesController : Controller
    {
        private ICrudRepositorio<Avaliacao, long> _repositorio = new AvaliacaoRepository(new ProjetoPosterDbContext());
        private ICrudRepositorio<Poster, long> _repositorioPoster = new PosterRepository(new ProjetoPosterDbContext());

        // GET: Avaliacoes
        public ActionResult Index()
        {
            List<Avaliacao> avaliacoes = _repositorio.Select();
            List<AvaliacaoIndexViewModel> viewModels = Mapper.Map<List<Avaliacao>, List<AvaliacaoIndexViewModel>>(avaliacoes);
            return View(viewModels);
        }

        // GET: Avaliacoes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = _repositorio.ById(id.Value);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            AvaliacaoDetalhesViewModel viewModel = Mapper.Map<Avaliacao, AvaliacaoDetalhesViewModel>(avaliacao);
            return View(viewModel);
        }

        // GET: Avaliacoes/Create
        public ActionResult Create()
        {
            List<Poster> posteres = _repositorioPoster.Select();
            List<PosterIndexViewModel> posteresViewModels = Mapper.Map<List<Poster>, List<PosterIndexViewModel>>(posteres);
            ViewBag.PosterId = new SelectList(posteresViewModels, "Id", "Titulo");
            return View();
        }

        // POST: Avaliacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AvaliacaoCriacaoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Avaliacao avaliacao = Mapper.Map<AvaliacaoCriacaoViewModel, Avaliacao>(viewModel);
                avaliacao.NotaFinal = (avaliacao.NotaIntroducao + avaliacao.NotaTema + avaliacao.NotaDesenvolvimento + avaliacao.NotaResultados + avaliacao.NotaConclusao) / 5;
                _repositorio.Insert(avaliacao);
                return RedirectToAction("Index");
            }
            List<Poster> posteres = _repositorioPoster.Select();
            List<PosterIndexViewModel> posteresViewModels = Mapper.Map<List<Poster>, List<PosterIndexViewModel>>(posteres);
            ViewBag.PosterId = new SelectList(posteresViewModels, "Id", "Titulo", viewModel.PosterId);
            return View(viewModel);
        }
    }
}
