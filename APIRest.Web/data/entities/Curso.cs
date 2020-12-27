using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Web.data.entities
{
    public class Curso
    {
        [Key]
        public int IdCurso { get; set; }

      
        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public bool? Estado { get; set; }

        public ICollection<InscripcionCurso>  InscripcionCursos { get; set; }

    }
}
