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
    public sealed class Alumno : Persona
    {

        public string Curso { get; set; }
        public int Nota { get; set; }
        public string NickName { get;  set; }

        public static int index=1;

        public Alumno() {
            Edad = 18;
            Apellido ="Ninguno";
            Curso ="Nada";
            Nota = 0;
            Nombre = "Desconocido";
            Telefono = "111111111";
            Email = "email@dominio.com";
            Id = index;
            index++;



        }
        //PARAMS: nombre,apellido,curso,edad,nota,email,telefono
        public Alumno(string nombre, string apellido, string curso, short edad, int nota,string email,string telefn) {
           

            Edad = edad;
            Apellido = apellido;
            Curso = curso;
            Nombre = nombre;
            Telefono = "";
            NickName = "Sin Alias";
            Email = email;
            Telefono = telefn;
            Nota = nota;
            Id = index;
            index++;



        }

        public override string NombreCompleto
        {
            get
            {
                return base.NombreCompleto.ToUpper();
            }
        }


        override
        public string ToString() {

            string cadena = "";
            cadena="Id:"+this.Id+"\nNombre:"+this.NombreCompleto+"\n Curso:"+this.Curso+"\n Nota:"+this.Nota;

            return cadena;

        }


        public string ToJSON() {
            string json = "";

            json="{'Id':'"+Id+"','Nombre':'"+ NombreCompleto + "','Curso':'"+Curso+"','Nota':'"+Nota+"','Email':'"+Email+"','Edad':'"+Edad+"','Telefono':'"+Telefono+"'}";

            return json;


        }

        public override string ConstruirResumen()
        {
            return $"{NombreCompleto}, {NickName}, {Telefono}";
        }
    }
}
