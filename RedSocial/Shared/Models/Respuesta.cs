using System;
using System.ComponentModel.DataAnnotations;

namespace RedSocial.Shared.Models
{
	public class Respuesta
	{
		public int Id { get; set; }
		[Required]
		public DateTime FechaRespuesta { get; set; }
		[Range(1,int.MaxValue)]
		public int HistoriaId { get; set; }
		public Historia? Historia { get; set; }
        [Required]
        [MinLength(20)]
        [MaxLength(100)]
        public string TextoRespuesta { get; set; }
        [Range(1, int.MaxValue)]
        public int PerfilRespuestaId { get; set; }
		public Perfil? PerfilRespuesta { get; set; }
	}
}

