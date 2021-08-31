using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Portel.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public long Contact { get; set; }
        public int RoleId { get; set; }
    }
}