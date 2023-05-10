using System;
using System.ComponentModel.DataAnnotations;

namespace RedSocial.Shared.Models
{
	public class Generos
	{
		public int Id { get; set; }
		[Required]
		public string Genero { get; set; }

		ICollection<Perfil> Perfil { get; set; }
	}
}

