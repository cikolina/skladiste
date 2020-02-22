using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skladiste.Models
{
    public class Test
    {
        public int RobaId { get; set; }
        public int NapomenaId { get; set; }
        public Roba20191220 Roba { get; set; }

        public Robanapomene20191220 Napomena { get; set; }
    }
}
