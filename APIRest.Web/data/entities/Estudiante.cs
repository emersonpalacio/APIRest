using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIRest.Web.data.entities
{
    public class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }

        [Required(ErrorMessage ="Campo obligatorio")]
        [MinLength(10, ErrorMessage ="Minimo 10 caracteres")]
        [MaxLength(10, ErrorMessage ="Maximo de 10 caracteres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [MinLength(3, ErrorMessage = "Nombre Minimo 10 caracteres")]
        [MaxLength(50, ErrorMessage = "Nombre Maximo de 10 caracteres")]

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string NombreApellido => $"{Nombre} {Apellido}";

        [Column(TypeName ="Date")]
        [Required(ErrorMessage ="Campo obligatorio")]
        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { get; set; }

        public ICollection<Matricula> Matriculas { get; set; }
    }
}
