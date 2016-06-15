/*
 
 Autor: Ricardo Aijon Martin
 Version : 1.0
 Curso: c# Basico en PLATZI
 Licencia: GPL.
 
 
 */


using ConsoleApplicationIntitucion.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationIntitucion
{
    class Program
    {
        public static List<Alumno> ListaAlumnos;
        public static List<Profesor> ListaProfesores;
        public static string folder_test="c:\\Test";

        static void Main(string[] args)
        {

            if (ReadLista() > -1)
            {
                Console.WriteLine("Leido fichero de texto correctamente");

                Console.WriteLine("Existen un total de " + Persona.ContadordePersonas + " personas");

            }
            else {
                Persona[] lista = new Persona[3];
                lista[0] = new Alumno("Ricardo", "Aijon Martin", "C# Basico PLATZI", 40, 5, "yasha_i@hotmail.com", "936384824");
                lista[1] = new Alumno("makitodev", "Desconocido", "C# Basico PLATZI", 0, 5, "makitodev@gmail.com", "0");


                lista[2] = new Profesor()
                {

                    Nombre = "Juan Carlos",
                    Apellido = "Ruiz Pacheco",
                    Email = "",
                    Edad = 38,
                    Catedra="Programación",
                    Telefono=""

                };



                ListaAlumnos = new List<Alumno>();
                ListaProfesores = new List<Profesor>();



                ListaAlumnos.Add((Alumno) lista[0]);
                ListaAlumnos.Add((Alumno )lista[1]);

                Persona.ListaPersonas.Add((Alumno)lista[0]);
                Persona.ListaPersonas.Add((Alumno)lista[1]);
                Persona.ListaPersonas.Add((Profesor)lista[2]);

                ListaProfesores.Add((Profesor)lista[2]);

                //Grabo los ficheros JSON 
                SaveLista();

                Console.WriteLine("El profesor del curso es :" +lista[2].ToString());

                Console.WriteLine("Existen un total de "+ Persona.getTotalPersonas()+" personas");


                Console.WriteLine("Resumenes\n");

                /* version clasica
                for (int i = 0; i < lista.Length; i++) {

                    Console.WriteLine(lista[i].ConstruirResumen());

                }*/

                foreach (Persona p in lista) {
                    Console.WriteLine($"Tipo {p.GetType()}");
                    Console.WriteLine(p.ConstruirResumen());
                }
               

            }


          

            Console.WriteLine("\nGestion de institucion\n------------------------------------------");
            //Console.WriteLine("\nMi alumno1 es :\n" + alumno1.ToString());
            //Console.WriteLine("\nMi alumno2 es :\n" + alumno2.ToString());
            PrintAlumnos(ListaAlumnos);
            //SaveLista();
            Console.ReadLine();
        }


        public static void PrintAlumnos(List<Alumno> lista) {


      
            Console.WriteLine("\nAlumnos Inscritos al curso:");
            foreach (Alumno x in lista) {

                Console.WriteLine(x.ToString());
            }

        }

        //Graba lista en formato texto JSON
        //Test OK
        public static void SaveLista() {

            string path = @"c:\Test";


            string[] lines = new string[100];
            
            int i = 0;
            int ultimo_index = ListaAlumnos.Count - 1;
            foreach (Alumno x in ListaAlumnos)
            {
                
                if (i == 0)
                {
                    lines[0] = "["+x.ToJSON() + ",";
                    //Console.WriteLine("Primera linea :" + lines[0]);

                }
                else if(i>0 && i<ultimo_index){
                    lines[i] = x.ToJSON() + ",";
                   

                }
               

                else if (i == ultimo_index) {
                    lines[ListaAlumnos.Count-1] = x.ToJSON()+"]";
                    //Console.WriteLine("Ultima linea :" + lines[ListaAlumnos.Count - 1]);
                }
               


                i++;
            }
            try
            {
                if (Directory.Exists(@"C:\Test"))
                {

                    System.IO.File.WriteAllLines(@"C:\Test\Alumnos.txt", lines);
                    Console.WriteLine(" Grabado fichero ok ");
                }
                else {
                    //creo el directorio
                    DirectoryInfo di = Directory.CreateDirectory(path);


                    //grabo en el
                    System.IO.File.WriteAllLines(@"C:\Test\Alumnos.txt", lines);

                    Console.WriteLine("Creado directorio y Grabado fichero ok ");

                }
                

            }
            catch (IOException es) {
                Console.WriteLine("Error en la escritura del archivo " + es.Message);

            }
          
        }

        /*Descripcion:
         * Recoge la lista grabada en archivo de texto e introduce en la lista si esta vacia
         * Test realizado: ok
        */
       
        public static int ReadLista() {

            //leo de fichero de texto 
            try
            {
                string file = @"c:\Test\Alumnos.txt";
                if (File.Exists(file)) {
                    string json = @System.IO.File.ReadAllText(file);
                    Console.WriteLine("Recogida lista :" + json);
                    ListaAlumnos = JsonConvert.DeserializeObject<List<Alumno>>(json);
                    if (ListaAlumnos.Count > 0) return 1;

                }
              
            


            }
            catch (System.IO.FileNotFoundException es) {
                Console.WriteLine("Error. El archivo no existe" + es.Message);

            }

            catch (Exception ex)
            {

                Console.WriteLine("Error." + ex.Message);
            }
           


            return -1; //no se pudo leer la lista

        }

    }
}
