using System;
using System.Collections.Generic;

namespace Api_BlackJack.Models
{
    public partial class Detallepartidum
    {
        public int Id { get; set; }
        public int IdPartida { get; set; }
        public int IdCarta { get; set; }

        public virtual Carta IdCartaNavigation { get; set; } = null!;
        public virtual Juego IdPartidaNavigation { get; set; } = null!;
    }
}
