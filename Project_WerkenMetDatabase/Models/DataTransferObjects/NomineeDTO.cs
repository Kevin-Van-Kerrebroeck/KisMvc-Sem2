using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_WerkenMetDatabase.Models.DataTransferObjects
{
    public class NomineeDTO
    {

        public int Id { get; set; }
        public string OscarYear { get; set; }
        public int CategoryId { get; set; }
        public bool Winner { get; set; }
        public string NomineeName { get; set; }
        public string FromTheMovie { get; set; }

    }
}