using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public string setNumero {

            set { this.numero = validarNumero(value); }

            //get { return this.numero.ToString(); } 
        }

       private double validarNumero(string strNumero){

            double numero; 

            if(double.TryParse(strNumero, out numero)){ // out hace strnumero retorna el valor a numero.
                return numero;
            }
            else{
                return 0;
            }
       }

        public string binarioDecimal(string binario){
            int i;
            char[] aux = binario.Reverse().ToArray();
            double resultado = 0;

            for(i = 0; i < aux.Length; i++){
                

                if (aux[i] == '1')
                {
                    resultado += Math.Pow(2, i);
                }

                else if (aux[i] != '0' && aux[i] != '1'){

                    return "valor invalido";

                }
            }
            return resultado.ToString();
        }

        public string decimalBinario(double numero) {

            int auxNum = (int)numero;
            StringBuilder sb = new StringBuilder();

            for (;;){
                if (auxNum == 1){
                    sb.Append(auxNum);             // agregamos un uno, tomamos todos los restos pero falta el 1 del resultado.
                    break;
                }
                sb.Append(auxNum % 2);
                auxNum = auxNum / 2;
            }
            return  new string(sb.ToString().Reverse().ToArray()); // reverse nos da vuelta el resultado y luego casteamos nuevamente.

        }

        public string decimalBinario(string numero)
        {
            return decimalBinario(double.Parse(numero));
        }  
        
        // SOBRECARGA DE OPERADORES

        public static double operator - (Numero num1, Numero num2){

            return num1.numero - num2.numero;
        }

        public static double operator + (Numero num1, Numero num2)
        {

            return num1.numero + num2.numero;
        }

        public static double operator * (Numero num1, Numero num2)
        {

            return num1.numero * num2.numero;
        }

        public static double operator / (Numero num1, Numero num2)
        {
            if (num2.numero != 0){

                return num1.numero / num2.numero;
            }
            return 0;
        }


    }
}
