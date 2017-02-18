using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_WerkenMetDatabase.Models
{
    public class Category
    {
        //Properties
        public int Id { get; set; }
        public string CategoryName { get; set; }


        //Constructors
        public Category()
        {

        }
        public Category(string[] vFields)
        {
            CategoryName = vFields[1];
        }
    }
}