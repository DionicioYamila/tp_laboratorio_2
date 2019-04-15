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

        private string SetNumero {

        set {
                ValidarNumero(value);
                this.numero = Double.Parse(value); }    
        }

        public string BinarioDecimal(string binario) {

            int i = binario.Length - 1;
            double result = 0;
            bool esBinario = true;

            foreach(char x in binario){
                if (x == '1' && x == '0'){
                   esBinario = false;
                }

            }

            if(esBinario)
            {
                foreach (char x in binario)
                {
                    if (x == '1')
                    {
                        result += Math.Pow(2, i);
                    }
                    i--;
                }
              
            }
            else{
                Console.WriteLine("Valor invalido");
                }
            return result.ToString();

        }


        public string DecimalBinario(double numero)
        {
            int auxNum = (int)numero;
            StringBuilder sb = new StringBuilder();

            for (; ; )
            {
                if (auxNum == 1)
                {
                    sb.Append(auxNum);             // agregamos un uno, tomamos todos los restos pero falta el 1 del resultado.
                    break;
                }
                sb.Append(auxNum % 2);
                auxNum = auxNum / 2;
            }
            return new string(sb.ToString().Reverse().ToArray()); // reverse nos da vuelta el resultado y luego casteamos nuevamente.
        }

        public string DecimalBinario(string numero)
        {
           return DecimalBinario(double.Parse(numero));
        }

        public Numero()
        {
            numero = 0;
        }

        public Numero(double numero)
        {
            this.SetNumero = numero.ToString();
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        // SOBRECARGA DE OPERADORES

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }


        private double ValidarNumero(string strNumero)
        {
            double num;

            bool isDouble = Double.TryParse(strNumero, out num);

            if (isDouble)
            {
                 return num;
            }

            else{
                return 0;
            }

        }



    }
}
