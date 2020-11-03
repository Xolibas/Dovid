using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dovid.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Oblast { get; set; }
        public virtual ICollection<Train> Trains { get; set; }

    }
}