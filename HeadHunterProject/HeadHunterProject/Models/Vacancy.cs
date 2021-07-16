using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeadHunterProject.Models
{
    public class Vacancy
    {
        public int VacancyId { get; set; }

        [Display(Name = "Должность")]
        public string NameOfPosition { get; set; }

        [Display(Name = "Зарплата")]
        public int Salary { get; set; }

        [Display(Name = "Требования")]
        public string Requirements { get; set; }

        [Display(Name = "О нас")]
        public string AboutUs { get; set; }

        public int CompanyId { get; set; }
    }
}