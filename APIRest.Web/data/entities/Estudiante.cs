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

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string NombreApellido => $"{Nombre} {Apellido}";

        [Column(TypeName ="Date")]
        public DateTime? FechaNacimiento { get; set; }

        public ICollection<Matricula> Matriculas { get; set; }
    }
}
