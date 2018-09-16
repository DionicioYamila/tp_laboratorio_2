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


namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
       public static Calculadora calculadora = new Calculadora();

        public LaCalculadora()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNum1.Text, txtNum2.Text, cmbOperador.Text).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            
            if(!lblResultado.Text.Equals(""))
            {
                lblResultado.Text = numero.decimalBinario(lblResultado.Text);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();

            if (!lblResultado.Text.Equals(""))
            {
                lblResultado.Text = numero.binarioDecimal(lblResultado.Text);
            }
        }

        private void limpiar() {

            this.txtNum1.Clear();
            this.txtNum2.Clear();
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }

        private static double Operar(string num1, string num2, string operador){

            Numero numUno = new Numero();
            Numero numDos = new Numero();

            numUno.setNumero = num1;
            numDos.setNumero = num2;

           return calculadora.Operar(numUno, numDos, operador);
           
        }
    }
}
