using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplicationIntitucion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationIntitucion.Models.Tests
{
    [TestClass()]
    public class AlumnoTests
    {
        [TestMethod()]
        //Pruebo que se crea un alumno correctamente dados unos valores
        public void AlumnoTest()
        {
            // arrange  o valores previos
            string nombre = "Ricardo";
            string apellidos = "Aijon Martin";
            string curso = "C# Basico PLATZI";
            // act  accion a probar
            var alumno1 = new Alumno(nombre, apellidos, curso, 40, 5, "yasha_i@hotmail.com", "936384824");
            // assert  
            Assert.IsNotNull(alumno1);
       
        }

        [TestMethod()]
        //Pruebo que funciona el pasar a JSON
        public void AlumnoTest1()
        {
            //ARRANGE
            var alumno = new Alumno();
            //act
            string json=alumno.ToJSON();

            //ASSERT
            Assert.IsTrue(ToJSONTest(json));
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public Boolean ToJSONTest(string json)
        {
           
            if (json.Length > 0) return true;

            return false;

        }
    }
}