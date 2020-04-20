using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string Operador)
        {
            Operador = Calculadora.ValidarOperador(Operador);

            if (Operador == "+")
            {
                return num1 + num2;
            }
            else if (Operador == "-")
            {
                return num1 - num2;
            }
            else if (Operador == "*")
            {
                return num1 * num2;
            }
            else 
            {
                return num1 / num2;
            }
        }

        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            else 
            {
                return "+";
            }
        }



    }
}
