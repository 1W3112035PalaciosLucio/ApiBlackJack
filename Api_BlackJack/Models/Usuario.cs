using System;
using System.Collections.Generic;

namespace Api_BlackJack.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Juegos = new HashSet<Juego>();
            Partida = new HashSet<Partidum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] Clave { get; set; } = null!;

        public virtual ICollection<Juego> Juegos { get; set; }
        public virtual ICollection<Partidum> Partida { get; set; }
    }
}
