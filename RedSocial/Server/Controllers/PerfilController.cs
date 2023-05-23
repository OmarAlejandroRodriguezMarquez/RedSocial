using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedSocial.Server.Data;
using RedSocial.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedSocial.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerfilController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PerfilController(ApplicationDbContext context)
        {
            this.context = context;
        }

        
        [HttpPost("crear")]
        public async Task<ActionResult<int>> Registrar(Perfil perfil)
        {
            context.Add(perfil);
            await context.SaveChangesAsync();
            return perfil.Id;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{Identificador:int}")]
        public async Task<ActionResult<Perfil>> ObtenerPerfil(int Identificador)
        {
            Perfil perfil = new Perfil();
            perfil = await context.Perfiles.Where(p => p.Id == Identificador).Include(g => g.Genero).FirstOrDefaultAsync();
            return perfil;
        }
    }
}

