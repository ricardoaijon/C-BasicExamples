
/*
 
 Autor: Ricardo Aijon Martin
 Version : 1.0
 Curso: c# Basico en PLATZI
 Licencia: GPL.
 
 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationIntitucion.Models
{
    public abstract class Persona
    {
        public static List<Persona> ListaPersonas = new List<Persona>();
        public static int ContadordePersonas = 0;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public short Edad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        protected string Inasistencias { get; set; } //acessible desde profesor y alumnos

        //permite poder sobreescribir este metodo en las clases que hereden de la misma
        public virtual string NombreCompleto
        {
            get
            {
                return $"{Nombre} {Apellido}";

            }


        }

        public Persona()
        {
            ContadordePersonas++;
        }

        public static int getTotalPersonas() {

            return ListaPersonas.Count;



        }



        override
        public string ToString() {

            return Nombre + " " + Apellido+"Total personas actuales:"+ContadordePersonas;

        }


        public abstract string ConstruirResumen();



    }
}
