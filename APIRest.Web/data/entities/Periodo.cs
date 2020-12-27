using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Web.data.entities
{
    public class Periodo
    {
        [Key]
        public int IdPeriodo { get; set; }

        public int? Anio { get; set; }

        public bool?  Estado { get; set; }

        public ICollection<Matricula> Matriculas { get; set; }
    }    
}
