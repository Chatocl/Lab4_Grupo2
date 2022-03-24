using System;
using System.ComponentModel.DataAnnotations;
using Lab4_Grupo2.Models.Datos;
namespace Lab4_Grupo2.Models
{
    public class Paciente
    {
        public delegate int Prioridad(string Sexo, int edad, string Especializacion, string Ingreso);

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

        public Prioridad Delegado = new Prioridad(Singleton.Instance.Pacientes.Prioraty);
        

    }
}