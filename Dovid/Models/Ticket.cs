using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dovid.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int? TrainId { get; set; }
        public Train Train { get; set; }
        public string Name { get; set; }
        public string Sname { get; set; }
        public string Adress { get; set; }
        public DateTime Date { get; set; }
    }
}