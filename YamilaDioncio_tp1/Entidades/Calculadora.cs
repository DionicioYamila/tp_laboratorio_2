using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado;

            switch (ValidarOperador(operador))
            {

                case "-":
                    Console.WriteLine("El resultado de la resta es: ");
                    resultado = num1 - num2;
                    break;

                case "*":
                    Console.WriteLine("El resultado de la multiplicacion es: ");
                    resultado = num1 * num2;
                    break;

                case "/":
                    Console.WriteLine("El resultado de la division es: ");
                    resultado =  num1 / num2;
                    break;

                default:
                    Console.WriteLine("El resultado de la suma es: ");
                    resultado = num1 + num2;
                    break;
            }

            return resultado;
        }

        private static string ValidarOperador(string operador)
        {
            if (operador == "*" || operador == "+" || operador == "-" || operador == "/")
            {
                return operador; 
            }
            else{
                return "+" ;
            }
        }


    }
}
