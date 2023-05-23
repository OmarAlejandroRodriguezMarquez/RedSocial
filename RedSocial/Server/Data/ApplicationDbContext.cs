using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedSocial.Shared.Models;

namespace RedSocial.Server.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //add-migration Amigos
        //update-database

        //dotnet ef migrations add Amigos
        //dotnet ef database update

        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<Historia> Historias { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<SolicitudAmistad> SolicitudesAmistad { get; set; }
    }
}


