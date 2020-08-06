using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ConsolePrueba
{
    class Program
    {
        static void Main(string[] args)
        {

            Paquete p = new Paquete("bsas 123", "kfc3312");

            p.MockCicloDeVida();

            Console.ReadKey();   

        }
    }
}
