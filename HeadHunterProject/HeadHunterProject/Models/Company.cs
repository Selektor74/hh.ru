using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeadHunterProject.Models
{
    public class Company
    {
        
        public int CompanyId { get; set; }

        [Display(Name = "Название вашей компании")]
        public string CompanyName { get; set; }

        [Display(Name = "Город")]
        public string City { get; set; }

        [Display(Name = "Страна")]
        public string Country { get; set; }

        [Display(Name = "Ваша электронная почта для связи")]
        public string Email { get; set; }

        [Display(Name = "О компании")]
        public string AboutCompany { get; set; }

        public string UserId { get; set; }

        public virtual List<Vacancy> Vacancies { get; set; }
    }
}