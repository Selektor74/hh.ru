using HeadHunterProject.Infrastructure;
using HeadHunterProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeadHunterProject.Controllers
{
    public class HomeController : Controller
    {

        Context context = new Context();
        private Counters counters = new Counters();
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public JsonResult GetCounters()
        {
            var countVacancies = context.Vacancies.Count();
            var countResumes = context.Resumes.Count();
            var countCompanies = context.Companies.Count();
            var countWorkers = context.Workers.Count();

            counters.CountVacancies = countVacancies;
            counters.CountResumes = countResumes;
            counters.CountCompanies = countCompanies;
            counters.CountWorkers = countWorkers;

            return Json(counters);
        }

        #region Вложенный класс для удобства использования переменных в ангуляре
        public class Counters
        {
            public  int CountVacancies { get; set; }
            public  int CountResumes { get; set; }
            public  int CountCompanies { get; set; }
            public int CountWorkers { get; set; }
        }
        #endregion


        public ActionResult About()
        {
            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}