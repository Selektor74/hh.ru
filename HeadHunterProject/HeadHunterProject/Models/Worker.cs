using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeadHunterProject.Models
{
    public class Worker
    {
        public int WorkerId { get; set; }

        [Display(Name ="Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Город")]
        public string City { get; set; }

        [Display(Name = "Страна")]
        public string Country { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public string UserId { get; set; }
        public virtual List<Resume> Resumes { get; set; }
    }
}