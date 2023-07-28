using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebEscuela.Models
{
    public class Asignatura: EscuelaBase
    {
        [Required(ErrorMessage ="El nombre es requerido")]
        public override string Nombre { get; set; } 
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluacion> Evaluaciones { get; set; }

    }
}
