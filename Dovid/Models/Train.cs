using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dovid.Models
{
    public class Train
    {
        public int Id { get; set; }

        public string SPos { get; set; }

        public string FPos { get; set; }

        public DateTime STime { get; set; }

        public DateTime FTime { get; set; }
        public int VCount { get; set; }
        public int Price { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public Train()
        {
            Tickets = new List<Ticket>();
        }
        public virtual ICollection<Station> Stations{ get; set; }
    }
}