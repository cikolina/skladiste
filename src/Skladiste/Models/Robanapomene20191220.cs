using System;
using System.Collections.Generic;

namespace Skladiste.Models
{
    public partial class Robanapomene20191220
    {
        public int Id { get; set; }
        public int IdRoba { get; set; }
        public string Napomena { get; set; }

        public virtual Roba20191220 IdRobaNavigation { get; set; }
    }
}
