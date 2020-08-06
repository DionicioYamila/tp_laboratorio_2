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
using System.IO;

namespace FrmPpal
{
    public partial class FrmPpal : Form
    {
        Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
            mtxtTrackingID.Mask = "aaa-aaa-aaa";
            mtxtTrackingID.ValidatingType = typeof(System.String);
        }

        public void ManejadorError(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(ManejadorError);

                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                MessageBox.Show(sender.ToString());
            }
        }

        public void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);

                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtDireccion.Text != null && txtDireccion.Text != string.Empty && mtxtTrackingID.Text != null && mtxtTrackingID.MaskFull)
            {
                Paquete p = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);

                p.InformarEstado += paq_InformaEstado;
                p.InformarError += ManejadorError;
                try
                {
                    correo += p;
                }
                catch (TrackingIdRepetidoException ex)
                {
                    MessageBox.Show("El paquete ya se encuentra en el correo", ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.ActualizarEstados();
            }
            else
            {
                MessageBox.Show("Faltan ingresar datos.");
            }
            
        }

        private void ActualizarEstados()
        {   
            lstEstadoIngresando.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete aux in correo.Paquetes)
            {
                if (aux.Estado == Paquete.EEstado.Ingresado)
                {
                    lstEstadoIngresando.Items.Add(aux);
                }
                else if(aux.Estado == Paquete.EEstado.EnViaje)
                {
                    lstEstadoEnViaje.Items.Add(aux);
                }
                else
                {
                    lstEstadoEntregado.Items.Add(aux);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        private void btnAgregarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);

            try
            {
                rtbMostrar.Text.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"/Archivo.txt"); 

                //rtbMostrar.Text.Guardar(Path.GetFullPath("Desktop")+"Archivo.txt"); /*@"C:\Users\Administrator\Desktop\archivito.txt"*/
                //Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el archivo", ex.Message);
            }
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
            }
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

    }
}
