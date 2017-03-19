using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_WerkenMetDatabase.Models.DataTransferObjects
{
    public class CategoryDTO
    {

        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<NomineeDTO> NomineeDTOs { get; set; }

    }
}