using AutoMapper;
using FATEA.ProjetoPoster.DataAccess.Entity.Context;
using FATEA.ProjetoPoster.Domain;
using FATEA.ProjetoPoster.Repository;
using FATEA.ProjetoPoster.Repository.Common;
using FATEA.ProjetoPoster.Web.ViewModels.Curso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FATEA.ProjetoPoster.Web.Controllers
{
    public class CursosController : Controller 
    {
        private ICrudRepositorio<Curso, long> _repositorio = new CursoRepository(new ProjetoPosterDbContext());

        public ActionResult Index()
        {
            List<CursoIndexViewModel> viewModels = new List<CursoIndexViewModel>();
            List<Curso> curso = _repositorio.Select();
            viewModels = Mapper.Map<List<Curso>, List<CursoIndexViewModel>>(curso);
            return View(viewModels);

        }
    }
}