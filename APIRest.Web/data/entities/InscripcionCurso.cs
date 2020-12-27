using System;
using System.ComponentModel.DataAnnotations;

namespace APIRest.Web.data.entities
{
    public class InscripcionCurso
    {
        [Key]
        public int IdInscripcionCurso { get; set; }

        public DateTime Fecha { get; set; }

        public Estudiante Estudiante { get; set; }
        public Periodo Periodo { get; set; }

        public Curso Curso { get; set; }
    }
}
