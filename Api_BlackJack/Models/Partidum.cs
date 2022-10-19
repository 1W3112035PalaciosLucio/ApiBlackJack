using System;
using System.Collections.Generic;

namespace Api_BlackJack.Models
{
    public partial class Partidum
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public ulong Activo { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
