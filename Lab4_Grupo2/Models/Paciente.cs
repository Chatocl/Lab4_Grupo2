using System;
using System.ComponentModel.DataAnnotations;

namespace Lab4_Grupo2.Models
{
    public class Paciente
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Apellidos { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime? FDNacimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Especializacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string MIngreso { get; set; }

    }
}