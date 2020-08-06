using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        Correo c = new Correo();

        [TestMethod]
        public void TestMethod1()
        {

            Assert.IsNotNull(c.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))] /*TrackingIdRepetidoException*/
        public void TestMethod2()
        {
            Paquete p1 = new Paquete("","");
            Paquete p2 = new Paquete("","");

            c += p1; 
            c += p2; 
        }




    }
}
