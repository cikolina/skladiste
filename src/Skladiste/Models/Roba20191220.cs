using System;
using System.Collections.Generic;

namespace Skladiste.Models
{
    public partial class Roba20191220
    {
        public Roba20191220()
        {
            Robanapomene20191220 = new HashSet<Robanapomene20191220>();
        }

        public int IdRoba { get; set; }
        public string SifraProizvoda { get; set; }
        public string Status { get; set; }
        public int? Tezina { get; set; }
        public DateTime? DatumIsporuke { get; set; }

        public virtual ICollection<Robanapomene20191220> Robanapomene20191220 { get; set; }
    }
}
