using System;
using System.Collections.Generic;

namespace Api_BlackJack.Models
{
    public partial class Juego
    {
        public Juego()
        {
            Detallepartida = new HashSet<Detallepartidum>();
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public ulong Activo { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Detallepartidum> Detallepartida { get; set; }
    }
}
