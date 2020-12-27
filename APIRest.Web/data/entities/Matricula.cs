using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Web.data.entities
{
    public class Matricula
    {
        [Key]
        public int IdMatricula { get; set; }

        public DateTime Fecha { get; set; }

        public Estudiante Estudiante { get; set; }
        public Periodo Periodo { get; set; }

        public ICollection<InscripcionCurso> InscripcionCursos { get; set; }
    }
}
