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
            int i;
            
            int num = binario.Length;

            for (i = 0; i < num; i++) 
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    return "Valor invalido";                
                }
            }
            return Convert.ToInt32(binario, 2).ToString();
        }

        public string DecimalBinario(double numero)
        {
            int num = Convert.ToInt32(Math.Abs(Math.Truncate(numero)));

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
            this.SetNumero = numero;
            return this.DecimalBinario(this.numero);
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
            this.SetNumero =  strNumero;
        }

        private double ValidarNumero(string strNumero) 
        {
            double num;

            bool isDouble = Double.TryParse(strNumero, out num);

            if (isDouble)
            {
                return num;
            }

            else
            {
                return 0;
            }
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
