using System;
using System.ComponentModel.DataAnnotations;

namespace RedSocial.Shared.Models
{
	public class SolicitudAmistad
	{
		public int Id { get; set; }
		[Required]
		public DateTime FechaSolicitud { get; set; }
        [Range(1, int.MaxValue)]
        public int PerfilSolictaId { get; set; }
		public Perfil? PerfilSolicita { get; set; }
        [Range(1, int.MaxValue)]
        public int PerfilSolicitadoId { get; set; }
		public Perfil? PerfilSolicitado { get; set; }
		public bool Aceptado { get; set; }
		public bool AceptarMensajes { get; set; }
	}
}

