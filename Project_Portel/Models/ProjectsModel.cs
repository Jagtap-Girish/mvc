using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Portel.Models
{
    public class ProjectsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }

    }
}