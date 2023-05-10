using System;
using System.ComponentModel.DataAnnotations;

namespace RedSocial.Shared.Models
{
	public class Perfil
	{
		public int Id { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		[Required(ErrorMessage ="El nickname es requerido")]
		[MinLength(5, ErrorMessage ="El nickname no debe de tener menos de 5 caracteres")]
        [MaxLength(15, ErrorMessage = "El nickname no debe de tener más de 15 caracteres")]
        public string Nickname { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [MinLength(2, ErrorMessage = "El nombre no debe de tener menos de 2 caracteres")]
        [MaxLength(50, ErrorMessage = "El nombre no debe de tener más de 50 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El primer apellido es requerido")]
        [MinLength(2, ErrorMessage = "El primer apellido no debe de tener menos de 2 caracteres")]
        [MaxLength(20, ErrorMessage = "El primer apellido no debe de tener más de 20 caracteres")]
        public string PrimerApellido { get; set; }
		public string? SegundoApellido { get; set; }
		[DataType(DataType.Date)]
		public DateTime FechaNacimiento { get; set; }
		[Range(1,int.MaxValue)]
		public int GeneroId { get; set; }
		public Generos? Genero { get; set; }
		[Required]
		[DataType(DataType.ImageUrl)]
		public string FotoPerfil { get; set; }
		[Required]
        [MinLength(15)]
        [MaxLength(500)]
        public string Biografia { get; set; }

		ICollection<Amigo> Amigos { get; set; }
	}

}