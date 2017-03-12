using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_WerkenMetDatabase.Models.ViewModels
{
    public class CategoryFilterViewModel
    {

        
        public List<Nominee> Nominees { get; set; }

        public Category Category { get; set; }

        public SelectList CategoryDropDownList { get; set; }
        public int SelectedId { get; set; }
     
    }
}