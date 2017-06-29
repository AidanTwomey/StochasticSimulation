using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using StochasticSimulation.ChemicalKinetics.Web.Models;

namespace StochasticSimulation.ChemicalKinetics.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly SsaCaller _ssaCaller = new SsaCaller();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CallSSA(SimulationModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _ssaCaller.Run(model).Result;
                var simulationPoints = JsonConvert.DeserializeObject<IEnumerable<SimulationPoint>>(result);
                var display = String.Join(Environment.NewLine, simulationPoints.Select(p => p.ToString()));

                model.Results = display;
                
            }

            return View("Index", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}