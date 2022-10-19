using Api_BlackJack.Comands;
using Api_BlackJack.DataContext;
using Api_BlackJack.Models;
using Api_BlackJack.Results;
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

        [HttpPost]
        [Route("loginUsuario")]
        public async Task<ActionResult<ResultadoBase>> postLogin([FromBody]ComandoLogin comando)
        {
            ResultadoBase resultado = new ResultadoBase();
            var usuario = await context.Usuarios.Where(c => c.Email.Equals(comando.email) && c.Clave.Equals(comando.clave)).FirstOrDefaultAsync();
            if(usuario != null)
            {
                resultado.setOk();
                return Ok(resultado);
            }
            else
            {
                resultado.setError("Usuario no encontrado");
                return BadRequest(resultado);
            }
        }

        [HttpGet]
        [Route("getUsuarios")]
        public async Task<ActionResult> getUsuarios()
        {
            var lista = await context.Usuarios.ToListAsync();
            return Ok(lista);
        }
    }
}
