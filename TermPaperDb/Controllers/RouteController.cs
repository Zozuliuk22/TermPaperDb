using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TermPaperDb.Models;
using TermPaperDb.Repositories;
using TermPaperDb.ViewModels;

namespace TermPaperDb.Controllers
{
    public class RouteController : Controller
    {
        private Repository<cRoute> _repository;

        public RouteController()
        {
            _repository = new Repository<cRoute>();
        }

        public ActionResult Index()
        {
            var model = new RouteViewModel();
            var result = _repository.GetAll();
            model.Routes = result.OrderBy(i => i.Id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RouteModel model)
        {
            var item = new cRoute()
            {
                Name = model.Name,
            };

            _repository.Add(item);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = _repository.GetAll().FirstOrDefault(i => i.Id == id);

            if (item == null) return View();

            var model = new RouteEditModel()
            {
                Id = item.Id,
                Name = item.Name,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RouteEditModel model)
        {
            var item = new cRoute()
            {
                Id = model.Id,
                Name = model.Name,
            };

            _repository.Update(item);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var item = _repository.GetAll().FirstOrDefault(i => i.Id == id);
            if(item != null)
                _repository.Delete(item);
            return RedirectToAction("Index");
        }
    }
}