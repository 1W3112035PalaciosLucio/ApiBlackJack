using System;
using System.Collections.Generic;

namespace Api_BlackJack.Models
{
    public partial class Carta
    {
        public Carta()
        {
            Detallepartida = new HashSet<Detallepartidum>();
        }

        public int Id { get; set; }
        public int Numero { get; set; }
        public string Palo { get; set; } = null!;
        public ulong? Disponible { get; set; }

        public virtual ICollection<Detallepartidum> Detallepartida { get; set; }
    }
}
