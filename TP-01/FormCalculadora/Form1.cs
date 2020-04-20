using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FormCalculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static double Operar(string numero1, string numero2, string operador) 
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            
             return Calculadora.Operar(num1, num2, operador);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
           lblResultado.Text = Form1.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = String.Empty;
            txtNumero2.Text = String.Empty;
            lblResultado.Text = String.Empty;
            cmbOperador.Text = String.Empty;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();
            lblResultado.Text = num.DecimalBinario(lblResultado.Text);
        }

        private void btnconvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();
            lblResultado.Text = num.BinarioDecimal(lblResultado.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {       
            this.cmbOperador.Items.AddRange(new object[] {"+","-", "*","/"});
        }
    }
}
