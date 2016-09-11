using AutoMapper;
using FATEA.ProjetoPoster.DataAccess.Entity.Context;
using FATEA.ProjetoPoster.Domain;
using FATEA.ProjetoPoster.Web.ViewModels.Evento;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FATEA.ProjetoPoster.Web.Controllers
{
    public class EventosController : Controller
    {
        private ProjetoPosterDbContext db = new ProjetoPosterDbContext();

        // GET: Eventos
        public ActionResult Index()
        {
            List<EventoIndexViewModel> viewModels = new List<EventoIndexViewModel>();
            List<Evento> eventos = db.Eventos.ToList();
            viewModels = Mapper.Map<List<Evento>, List<EventoIndexViewModel>>(eventos);
            return View(viewModels);
                        
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }

            EventoIndexViewModel viewModel = Mapper.Map<Evento, EventoIndexViewModel>(evento);
            return View(viewModel);
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventoEdicaoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.DataInicio > viewModel.DataFim)
                {
                    ModelState.AddModelError("intervalo_datas_incorreto", "A data inicial não pode ser maior que a data final");
                    return View(viewModel);
                }
                Evento evento = Mapper.Map<EventoEdicaoViewModel, Evento>(viewModel);
                db.Eventos.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            EventoEdicaoViewModel viewModel = Mapper.Map<Evento, EventoEdicaoViewModel>(evento);
            return View(viewModel);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventoEdicaoViewModel viewModel )
        {
            if (viewModel.DataInicio > viewModel.DataFim)
            {
                ModelState.AddModelError("intervalo_datas_incorreto", "A data inicial não pode ser maior que a data final");
                return View(viewModel);
            }
            if (ModelState.IsValid)
            {
                Evento evento = Mapper.Map<EventoEdicaoViewModel, Evento>(viewModel);
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            EventoEdicaoViewModel viewModel = Mapper.Map<Evento, EventoEdicaoViewModel>(evento);
            return View(viewModel);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evento evento = db.Eventos.Find(id);
            db.Eventos.Remove(evento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
