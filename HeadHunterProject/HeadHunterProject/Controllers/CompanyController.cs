using HeadHunterProject.Infrastructure;
using HeadHunterProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace HeadHunterProject.Controllers
{
    public class CompanyController : Controller
    {
        Context context = new Context();
        #region Добавление компании в систему
        [Authorize(Roles = "Company")]
        public ActionResult AddCompany()
        {
            return View();
        }
        [Authorize(Roles = "Company")]

        [HttpPost]
        [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        public ActionResult AddCompany(Company model)
        {
            if (ModelState.IsValid)
            {
                var ActiveUserId = User.Identity.GetUserId();
                if (context.Companies.Where(x => x.UserId == ActiveUserId).Count() > 0)
                {
                    Company EditCompany = context.Companies.
                 Where(i => i.UserId == ActiveUserId).FirstOrDefault();

                    EditCompany.CompanyName = model.CompanyName;
                    EditCompany.City = model.City;
                    EditCompany.Country = model.Country;
                    EditCompany.AboutCompany = model.AboutCompany;

                    context.SaveChanges();
                    return Json(new { success = true });

                }
                model.UserId = User.Identity.GetUserId();
                model.Email = User.Identity.Name;
                context.Companies.Add(model);
                context.SaveChanges();



                return Json(new { success = true });

            }

            return View(model);
        }
        #endregion

        #region Получение информации о компании
        [Authorize(Roles = "Company")]
        public ActionResult CompanyInfo()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Company")]
        public JsonResult GetCompanyInfo()
        {
            var ActiveUserId = User.Identity.GetUserId();

            return Json(context.Companies.Where(u => u.UserId == ActiveUserId));
        }

        public JsonResult GetCompanyInfo(int CompanyId)
        {
            return Json(context.Companies.Where(u => u.CompanyId == CompanyId));
        }
        #endregion

        #region Просмотр резюме 
        public ActionResult LookResumes()
        {
            return View();
        }
        public JsonResult GetResumesList()
        {
            return Json(context.Resumes);
        }
        public JsonResult GetResume(int id)
        {
            Resume model = context.Resumes.Where(x => x.ResumeId == id).FirstOrDefault();
            return Json(model);
        }

        public ActionResult LookResume()
        {
            return View();
        }
        public JsonResult GetWorkerInfo(int Id)
        {
            return Json(context.Workers.Where(u => u.WorkerId == Id));
        }
        #endregion

        #region Добавление и удаление вакансий

        [Authorize(Roles = "Company")]
        public ActionResult AddVacancy()
        {
            return View();
        }

        [Authorize(Roles = "Company")]
        [HttpPost]
        [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        public ActionResult AddVacancy(Vacancy model)
        {
            var ActiveUserId = User.Identity.GetUserId();

            if (context.Companies.Where(u => u.UserId == ActiveUserId).FirstOrDefault() != null)
            {
                model.CompanyId = context.Companies.Where(i => i.UserId == ActiveUserId).FirstOrDefault().CompanyId;

                if (ModelState.IsValid)
                {

                    context.Vacancies.Add(model);
                    context.SaveChanges();

                    return Json(new { success = true });
                }
            }

            return Json(new { success = false });
        }

        [Authorize(Roles = "Company")]
        public ActionResult DeleteVacancy(int id)
        {
            context.Vacancies.Remove(context.Vacancies.Where(v => v.VacancyId == id).FirstOrDefault());
            context.SaveChanges();
            return Json(new { success = true });
        }
        #endregion

        #region Получение информации о вакансиях
        [Authorize(Roles = "Company")]
        public JsonResult GetVacancyInfo()
        {

            var ActiveUserId = User.Identity.GetUserId();
            var company = context.Companies.Where(i => i.UserId == ActiveUserId).FirstOrDefault();
            if (company == null || context.Vacancies.Where(i => i.CompanyId == company.CompanyId).FirstOrDefault() == null)
            {
                return Json(new { success = false });
            }
            return Json(context.Vacancies.Where(i => i.CompanyId == company.CompanyId));
        }



        [Authorize(Roles = "Company")]
        public ActionResult VacancyInfo()
        {
            return View();
        }
        #endregion











    }
}