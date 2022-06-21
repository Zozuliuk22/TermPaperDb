using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TermPaperDb.ViewModels
{
    public class TrainsViewModel
    {
        public IEnumerable<TrainViewModel> Trains { get; set; }
    }
}