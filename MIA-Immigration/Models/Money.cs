using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIA_Immigration.Models
{
    public class Money
    {
        public int MoneyID { get; set; }

        public string Price { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}