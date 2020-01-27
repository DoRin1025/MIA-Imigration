using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIA_Immigration.Models
{
    public class CountryResidence
    {
        [Key]
        public int CountryRID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Request> Requests { get; set; }


    }
}