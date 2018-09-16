using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public double Operar(Numero num1, Numero num2, string operador){

            operador = Calculadora.validarOperador(operador);
            if (operador == "+")
            {
                return num1 + num2;
            }
            else if (operador == "-")
            {
                return num1 - num2;
            }
            else if (operador == "*")
            {
                return num1 * num2;
            }
            else
            {
                return num1 / num2;
            }

        }

        private static string validarOperador(string operador){

            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }

            else {
                return "+";
            }

            /*if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                operador = "+";
            }
            return operador; */
        }
    }
}
