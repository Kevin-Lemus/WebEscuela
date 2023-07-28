using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebEscuela.Models
{
    public class Escuela: EscuelaBase
    {
        //Atributos
        public int Fundacion { get; set; }

        public TiposEscuela AtributoTipoDeEscuela { get; set; }
        public List<Curso> ListaCursos { get; set; }
        public string Direccion { get; set; }

    }
}
