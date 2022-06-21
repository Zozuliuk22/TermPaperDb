using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TermPaperDb.ViewModels
{
    public class TrainEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Введіть назву потяга, який бажаєте створити:")]
        public string Name { get; set; }

        [Display(Name = "Введіть дату його відправлення по маршуту:")]
        public DateTime? DepartureDate { get; set; }

        [Display(Name = "Виберіть маршрут:")]
        public int RouteId { get; set; }

        public SelectList Routes { get; set; }
    }
}