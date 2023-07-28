using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebEscuela.Models
{
    public abstract class EscuelaBase
    {
        //Atributos
        public string Id { get; set; }
        
        public virtual string Nombre { get; set; }

        //Métodos
        public EscuelaBase()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nombre}, {Id}";
        }
    }
}
