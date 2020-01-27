using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIA_Immigration.Models
{
    public class Country
    {
        public int CountryID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Request> Requests { get; set; }


    }
}