using Api_BlackJack.DataContext;
using Api_BlackJack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_BlackJack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly BlackJackContext context;
        public UsuarioController(BlackJackContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        [Route("usuarios/getUsuarios")]
        public async Task<ActionResult> getUsuarios()
        {
            var lista = await context.Usuarios.ToListAsync();
            return Ok(lista);
        }

    }
}
