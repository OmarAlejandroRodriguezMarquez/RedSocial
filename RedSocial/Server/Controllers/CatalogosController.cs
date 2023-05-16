using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedSocial.Server.Data;
using RedSocial.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedSocial.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PerfilController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet("generos")]
        public async Task<ActionResult<List<Generos>>> ObtenerGeneros()
        {
            List<Generos> generos = new List<Generos>();
            generos = await context.Generos.ToListAsync();
            return generos;
        }

        [HttpPost("agregargenero")]
        public async Task<ActionResult<int>> GuardarGenero(Generos genero)
        {
            context.Generos.Add(genero);
            await context.SaveChangesAsync();
            return genero.Id;
        }
    }
}

