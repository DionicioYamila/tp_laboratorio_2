using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double numero;


        private string SetNumero
        {
            set 
            {
                this.numero = ValidarNumero(value);
            }
        }

        public string BinarioDecimal(string binario)
        {
            int num = Convert.ToInt32(binario);
            if (num > 0) 
            {
                return (Convert.ToInt32(binario, 2)).ToString();
            }
            else
            {
                return "Valor invalido";
            }
        }

        public string DecimalBinario(double numero)
        {
            int num = Math.Abs(Convert.ToInt32(numero));

            if (num > 0)
            {
                return Convert.ToString(num, 2);
            }
            else 
            {
                return "Valor invalido";
            }         
        }

        public string DecimalBinario(string numero)
        {
            return this.DecimalBinario(double.Parse(numero));
        }

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.numero =  double.Parse(strNumero);
        }

        private double ValidarNumero(string strNumero) 
        {
            int i;
            //1A2
            for(i=0; i < strNumero.Length; i++)
            {
                if (strNumero[i] <  0 || strNumero[i] > 9)
                {
                    return 0;                 
                }              
            }
            return double.Parse(strNumero);
        }

        public static double operator - (Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator + (Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator * (Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        { 
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else 
            {
                return n1.numero / n2.numero;
            }         
        }
    }
}
