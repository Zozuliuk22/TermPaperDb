using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TermPaperDb.Models
{
    public class RouteModel
    {
        [Display(Name = "Введіть назву маршуту, який бажаєте створити:")]
        public string Name { get; set; }
    }
}