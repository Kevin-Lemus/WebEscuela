using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebEscuela.Models
{
    public class Curso: EscuelaBase
    {
        //atributos
        [Required(ErrorMessage = "El nombre es requerido")]
        public override string Nombre { get; set; }
        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }
        [Required(ErrorMessage = "Seleccione una jornada")]
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public string Direccion { get; set; }
        


    }
}
