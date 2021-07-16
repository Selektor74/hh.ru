using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeadHunterProject.Models
{
    public class Resume
    {
        public int ResumeId { get; set; }
        [Display(Name = "Должность")]
        public string NameOfPosition { get; set; }
        [Display(Name = "Опыт")]
        public string Experience { get; set; }
        [Display(Name = "Личные качества")]
        public string PersonalQuality { get; set; }
        [Display(Name = "О мне")]
        public string AboutMe { get; set; }
        public int WorkerId { get; set; }
    }
}