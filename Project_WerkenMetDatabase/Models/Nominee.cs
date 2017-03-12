using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_WerkenMetDatabase.Models
{
    public class Nominee
    {
        //Properties
        public int Id { get; set; }
        public string OscarYear { get; set; }
        public int CategoryId { get; set; }
        public bool Winner { get; set; }
        public string NomineeName { get; set; }
        public string FromTheMovie { get; set; }

        //Nav Properties
        public Category Category { get; set; }

        //Constructors
        public Nominee()
        {

        }

        public Nominee(string[] vFields)
        {
            OscarYear = vFields[0];
            CategoryId = int.Parse(vFields[1]);
            //CategoryName = vFields[2];
            Winner = (vFields[3].ToUpper() == "W" ? true : false);
            NomineeName = vFields[4];
            FromTheMovie = vFields[5];
        }

    }
}