using System;
using System.ComponentModel.DataAnnotations;

namespace RedSocial.Shared.Models
{
	public class Historia
	{
		public int Id { get; set; }
		[Required]
		public DateTime FechaCreacion { get; set; }
		[Required]
		[MinLength(20)]
		[MaxLength(100)]
		public string TextoHistoria { get; set; }
		[Range(1,int.MaxValue)]
		public int PerfilCreacionId { get; set; }
		public Perfil? PerfilCreacion { get; set; }
	}
}

