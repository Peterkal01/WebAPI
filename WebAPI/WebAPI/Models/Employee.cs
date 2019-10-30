using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Employee
    {
        public int  StaffId { get; set; }
        public string GivenName { get; set; }
        public string SurName { get; set; }

        public Employee()
        {

        }
        
        public Employee(int sid, string gname, string sname)
        {
            StaffId = sid;
            GivenName = gname;
            SurName = sname;
        }

    }
}