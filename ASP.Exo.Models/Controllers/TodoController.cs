using ASP.Exo.Models.Models.Views;
using Model.Client.Services;
using Model.Common.Models;
using Model.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Exo.Models.Controllers
{
    public class TodoController : Controller
    {
        private ITacheRepository _service;
        public TodoController()
        {
            _service = new TacheService();
        }
        // GET: Todo
        public ActionResult Index()
        {
            IEnumerable<Tache> datas = _service.Get();
            return View(datas);
        }

        // GET: Todo/Details/5
        public ActionResult Details(int id)
        {
            Tache data = _service.Get(id);
            return View(data);
        }

        // GET: Todo/Create
        public ActionResult Create()
        {
            TacheFormCreate data = new TacheFormCreate();
            return View(data);
        }

        // POST: Todo/Create
        [HttpPost]
        public ActionResult Create(TacheFormCreate form)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Formulaire non valide");
                if (form.Intitule == null) throw new Exception();
                    Tache data = new Tache()
                {
                    Intitule = form.Intitule,
                    Description = form.Description,
                    AttributeTo = form.AttributeTo,
                    CreationDate = DateTime.Now,
                    IsDone = false
                };
                int id = _service.Insert(data);
                return RedirectToAction("Details",new { id = id});
            }
            catch(Exception ex)
            {
                ViewBag.Notification = ex.Message;
                if (form.Intitule == null)
                {
                    ModelState.AddModelError("Intitule", "Intitulé obligatoire");
                }
                TacheFormCreate data = new TacheFormCreate();
                return View(data);
            }
        }

        // GET: Todo/Edit/5
        public ActionResult Edit(int id)
        {
            Tache data = _service.Get(id);
            if (data == null) return RedirectToAction("index");
            return View(data);
        }

        // POST: Todo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Edition impossible");
                Tache data = _service.Get(id);
                if (data == null) throw new Exception("Données manquantes");
                data.Intitule = collection["Intitule"];
                data.Description = collection["Description"];
                data.IsDone = (collection["IsDone"] == "false") ? false : true;
                if(!_service.Update(id,data)) throw new Exception("Erreur dans la base de donnée.");
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Notification = ex.Message;
                Tache data = _service.Get(id);
                if (data == null) return RedirectToAction("index");
                return View(data);
            }
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(int id)
        {
            Tache data = _service.Get(id);
            if (data == null) return RedirectToAction("index");
            return View(data);
        }

        // POST: Todo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (!ModelState.IsValid) throw new Exception("Bravo, tu as su faire planter un formulaire sans infos...");
                if (!_service.Delete(id)) throw new Exception("Votre tache ne peut être supprimée");
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Notification = ex.Message;
                Tache data = _service.Get(id);
                if (data == null) return RedirectToAction("index");
                return View(data);
            }
        }
    }
}
