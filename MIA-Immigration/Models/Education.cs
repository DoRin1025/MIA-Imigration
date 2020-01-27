using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIA_Immigration.Models
{
    public class Education
    {

        public int EducationID { get; set; }

        public string EducationName { get; set; }

        public virtual ICollection<Request> Requests { get; set; }

    }
}