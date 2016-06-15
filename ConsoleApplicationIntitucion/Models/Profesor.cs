using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationIntitucion.Models
{
    //no se puede heredar de profesor
    public sealed class  Profesor:Persona
    {
        public static int indice = 1;
        public string Catedra { get; set; }



        public Profesor() {
            Id = indice;
            Catedra = "Programacion";
            indice++;


        }


        override
        public string ToString()
        {

            string cadena = "";
            cadena = "Id:" + this.Id + "\nNombre:" + this.NombreCompleto + "\n Catedra:" + this.Catedra ;

            return cadena;

        }

        public override string ConstruirResumen()
        {
            return $"{NombreCompleto},{Catedra}, {Edad}";
        }
    }
}
