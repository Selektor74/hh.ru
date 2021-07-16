using HeadHunterProject.Infrastructure;
using HeadHunterProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace HeadHunterProject.Controllers
{
    public class WorkerController : Controller
    {
        Context context = new Context();

        #region Добавление соискателя в систему
        [Authorize(Roles = "Worker")]
        public ActionResult AddWorker()
        {
            return View();
        }

        [Authorize(Roles = "Worker")]
        [HttpPost]
        [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        public ActionResult AddWorker(Worker model)
        {
            if (ModelState.IsValid)
            {
                var ActiveUserId = User.Identity.GetUserId();

                if (context.Workers.Where(x => x.UserId == ActiveUserId).Count() > 0)
                {
                    Worker EditWorker = context.Workers.
                 Where(i => i.UserId == ActiveUserId).FirstOrDefault();

                    EditWorker.FirstName = model.FirstName;
                    EditWorker.LastName = model.LastName;
                    EditWorker.City = model.City;
                    EditWorker.Country = model.Country;

                    context.SaveChanges();
                    return Json(new { success = true });

                }
                model.UserId = User.Identity.GetUserId();
                model.Email = User.Identity.Name;
                context.Workers.Add(model);
                context.SaveChanges();

                return Json(new { success = true });
            }

            return View();
        }
        #endregion

        #region Получение информации о соискателе
        [Authorize(Roles = "Worker")]
        public ActionResult WorkerInfo()
        {
            return View();
        }

        public JsonResult GetWorkerInfo()
        {
            var ActiveUserId = User.Identity.GetUserId();
            return Json(context.Workers.Where(u => u.UserId == ActiveUserId));
        }
        #endregion

        #region Добавление резюме в систему
        [Authorize(Roles = "Worker")]
        public ActionResult AddResume()
        {
            return View();
        }
        [Authorize(Roles = "Worker")]

        [HttpPost]
        [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        public ActionResult AddResume(Resume model)
        {
            if (ModelState.IsValid)
            {
                var ActiveUserId = User.Identity.GetUserId();
                if (context.Workers.Where(u => u.UserId == ActiveUserId).FirstOrDefault() != null)
                {
                    model.WorkerId = context.Workers.Where(w => w.UserId == ActiveUserId).FirstOrDefault().WorkerId;
                    context.Resumes.Add(model);
                    context.SaveChanges();
                    return Json(new { success = true });
                }

            }

            return Json(new { success = false });
        }
        #endregion

        #region Удаление резюме из базы
        [Authorize(Roles = "Worker")]
        public ActionResult DeleteResume(int id)
        {
            context.Resumes.Remove(context.Resumes.Where(v => v.ResumeId == id).FirstOrDefault());
            context.SaveChanges();
            return Json(new { success = true });
        }
        #endregion

        #region Получение данных о своих резюме
        [Authorize(Roles = "Worker")]
        public ActionResult ResumeInfo()
        {
            return View();
        }

        public JsonResult GetResumeInfo()
        {
            var ActiveUserId = User.Identity.GetUserId();
            var worker = context.Workers.Where(i => i.UserId == ActiveUserId).FirstOrDefault();
           
            if (worker == null )
            {
                return Json(new { success = false });
            }
            var resumesCount = context.Resumes.Where(i => i.WorkerId == worker.WorkerId).Count();
             if (resumesCount == 0)
            {
                return Json(new { success = false });
            }
            return Json(context.Resumes.Where(i => i.WorkerId == worker.WorkerId));
        }
        #endregion

        #region Просмотр вакансий выложенных компаниями

        [HttpPost]
        public JsonResult GetVacanciesList()
        {

            return Json(new { vacancies = context.Vacancies, companies = context.Companies });
        }
        [HttpPost]
        public JsonResult GetCompanyInfo(int Id)
        {
            return Json(context.Companies.Where(u => u.CompanyId == Id));
        }
        [HttpPost]
        public JsonResult GetVacancy(int id)
        {
            Vacancy model = context.Vacancies.Where(x => x.VacancyId == id).FirstOrDefault();
            return Json(model);
        }

        public ActionResult LookVacancies()
        {
            return View();
        }
        #endregion
        
    }
}