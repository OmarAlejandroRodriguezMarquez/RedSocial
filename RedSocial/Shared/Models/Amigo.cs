using System;
using System.ComponentModel.DataAnnotations;

namespace RedSocial.Shared.Models
{
	public class Amigo
	{
		public int Id { get; set; }
		[Required]
		public DateTime FechaAmigos { get; set; }
		[Range(1,int.MaxValue)]
		public int MiPerfilId { get; set; }
		public Perfil? MiPerfil { get; set; }
        [Range(1, int.MaxValue)]
        public int PerfilAmigoId { get; set; }
		public Perfil? PerfilAmigo { get; set; }
	}
}

