using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_WerkenMetDatabase.Models
{
    public class President
    {
        //props
        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        public string Opmerking { get; set; }

        //constructors
        public President()
        {

        }

        public President(string[] fields)
        {
            Name = fields[1];
            StartDate = DateTime.Parse(fields[2]);
            EndDate = DateTime.Parse(fields[3]);
            Opmerking = fields[4];

        }
        //public methods
        public string GetRegeerPeriode()
        {
            return this.StartDate.Year + " - " + this.EndDate.Year;
        }
        //private methods

    }
}