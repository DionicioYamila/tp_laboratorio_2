﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archivos;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace TestsUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Testea la excepcion DniInvalidoException en caso de que el dni ingresado sea menor a 1 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DNI_Bajo()
        {
            Alumno p = new Alumno(4, "Miguel", "Hernandez", "0",
           EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion,
           Alumno.EEstadoCuenta.AlDia);
        }

        /// <summary>
        /// Testea la excepcion DniInvalidoException en caso de que el dni ingresado contenga letras 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DNI_Letras()
        {
            Alumno p = new Alumno(4, "Miguel", "Hernandez", "12asd12",
           EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion,
           Alumno.EEstadoCuenta.AlDia);
        }

        /// <summary>
        /// Testea la excepcion DniInvalidoException en caso de que el dni ingresado sea mayor a 89999999 y nacionalidad
        /// sea 'Argentino'
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void DNI_Alto()
        {
            Alumno p = new Alumno(4, "Miguel", "Hernandez", "92264456",
           EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion,
           Alumno.EEstadoCuenta.AlDia);
        }

        /// <summary>
        /// Testea la excepcion NacionalidadInvalidaException en caso de que el dni ingresado sea menor a 90000000
        /// y nacionalidad sea 'Extrangero'
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void Nacionalidad_Incorrecta()
        {
            Alumno p = new Alumno(4, "Miguel", "Hernandez", "22264456",
           EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion,
           Alumno.EEstadoCuenta.AlDia);
        }

        /// <summary>
        /// Testea la excepcion SinProfesorException en caso de que no se encuentre un Profesor disponible para la Jornada
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void Sin_Profesor()
        {
            Universidad g = new Universidad();
            g += Universidad.EClases.Laboratorio;
        }

        /// <summary>
        /// Testea la excepcion AlumnoRepetidoException en caso de que se repita un Alumno
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void Alumno_Repetido()
        {
            Universidad g = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(1, "Juan", "Lopez", "12234456",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);

            g += a1;
            g += a2;
        }

        /// <summary>
        /// Testea que las propiedades de una Universidad no sean null.
        /// </summary>
        [TestMethod]
        public void Universidad_Propiedades_NotNull()
        {
            Universidad g = new Universidad();
            //g.Profesores = null; //Ejemplo en el que la test fallaria

            if ((g.Alumnos == null) || (g.Jornadas == null) || (g.Profesores == null))
                Assert.Fail();
        }
                
    }
}
