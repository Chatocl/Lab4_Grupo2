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

        [Display(Name = "Tipo de especialidad")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Especializacion { get; set; }

        [Display(Name = "Tipo de ingreso")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string MIngreso { get; set; }

        public Prioridad Delegado = new Prioridad(Prioraty);
        public static int Prioraty(string Sexo, int edad, string Especializacion, string Ingreso)
        {
            int Prioridad = 0;
            if (Sexo == "FEMENINO")
            {
                Prioridad += 3;
            }
            else
            {
                Prioridad += 5;
            }

            if (edad >= 0 && edad <= 5)
            {
                Prioridad += 8;
            }
            else if (edad >= 6 && edad <= 17)
            {
                Prioridad += 5;
            }
            else if (edad >= 18 && edad <= 49)
            {
                Prioridad += 3;
            }
            else if (edad >= 50 && edad <= 69)
            {
                Prioridad += 8;
            }
            else if (edad >= 70)
            {
                Prioridad += 10;
            }

            if (Especializacion == "INTERNA")
            {
                Prioridad += 3;
            }
            else if (Especializacion == "EXPUESTA")
            {
                Prioridad += 8;
            }
            else if (Especializacion == "GINECOLOGIA")
            {
                Prioridad += 5;
            }
            else if (Especializacion == "CARDIOLOGIA")
            {
                Prioridad += 10;
            }
            else if (Especializacion == "NEUMOLOGIA")
            {
                Prioridad += 8;
            }

            if (Ingreso == "AMBULANCIA")
            {
                Prioridad += 5;
            }
            else
            {
                Prioridad += 3;
            }

            return Prioridad;
        }
    }
}