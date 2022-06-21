using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TermPaperDb.Models
{
    public class RouteEditModel
    {
        public int Id { get; set; }

        [Display(Name = "Введіть назву маршуту, який бажаєте відредагувати:")]
        public string Name { get; set; }
    }
}