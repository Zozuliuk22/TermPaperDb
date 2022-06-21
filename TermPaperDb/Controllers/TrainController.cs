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
    public class TrainController : Controller
    {
        private Repository<vTrain> _repositoryTrain;
        private Repository<cRoute> _repositoryRoute;

        public TrainController()
        {
            _repositoryTrain = new Repository<vTrain>();
            _repositoryRoute = new Repository<cRoute>();
        }

        public ActionResult Index()
        {
            var model = new TrainsViewModel();
            var trains = _repositoryTrain.GetAll().OrderBy(t => t.Id).ThenBy(t => t.DepartureDate);
            var routes = _repositoryRoute.GetAll().OrderBy(r => r.Id);

            var result = trains.Join(routes, t => t.RouteId, r => r.Id, (t, r) => new { t = t, r = r })
                               .Select(o => new TrainViewModel()
                                            {
                                                Train = o.t,
                                                Route = o.r
                                            });

            model.Trains = result;

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new TrainCreateViewModel();
            var routes = _repositoryRoute.GetAll();
            model.Routes = new SelectList(routes, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(TrainCreateViewModel model)
        {
            var train = new vTrain()
            {
                Name = model.Name,
                DepartureDate = model.DepartureDate,
                RouteId = model.RouteId,
            };

            _repositoryTrain.Add(train);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = _repositoryTrain.GetAll().FirstOrDefault(i => i.Id == id);

            var model = new TrainEditViewModel()
            {
                Id = id,
                Name = item.Name,
                DepartureDate= item.DepartureDate,
                RouteId= item.RouteId,
            };

            var routes = _repositoryRoute.GetAll();
            model.Routes = new SelectList(routes, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TrainEditViewModel model)
        {
            var train = new vTrain()
            {
                Id = model.Id,
                Name = model.Name,
                DepartureDate = model.DepartureDate,
                RouteId = model.RouteId,
            };

            _repositoryTrain.Update(train);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var item = _repositoryTrain.GetAll().FirstOrDefault(i => i.Id == id);
            if (item != null)
                _repositoryTrain.Delete(item);
            return RedirectToAction("Index");
        }
    }
}