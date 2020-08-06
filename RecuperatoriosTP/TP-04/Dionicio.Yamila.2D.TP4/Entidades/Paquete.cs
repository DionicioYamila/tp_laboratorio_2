using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Win32;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado { Ingresado, EnViaje, Entregado }

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformarEstado;
        public event DelegadoEstado InformarError;

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }


        public void MockCicloDeVida()
        {
            Thread.Sleep(4000);
            estado = EEstado.EnViaje;

            if (this.InformarEstado != null)
            {
                InformarEstado.Invoke(this, null);
            }

            Thread.Sleep(4000);
            estado = EEstado.Entregado;
            if (this.InformarEstado != null)
            {
                InformarEstado.Invoke(this, null);
            }

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch(Exception ex)
            {
                if(this.InformarError != null)
                {
                    InformarError.Invoke(ex.Message + " paquete con TrakingId = " + this.trackingID, null);
                }
            }
        }

        /// <summary>
        /// MostrarDatos retorna un string con todos los datos del paquete.
        /// </summary>
        /// <param name="elementos">Elementos la lista de paquetes</param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} para {1}", this.trackingID, this.direccionEntrega));

            return sb.ToString();
        }


        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Un paquete sera distinto a otro paquete, solo si, un paquete no es igual al otro.
        /// </summary>
        /// <param name="p1">Paquete a comparar</param>
        /// <param name="p2">Paquete a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Un Paquete es igual a un paquete si, y solo si, los trackingID de cada uno son iguales-
        /// </summary>
        /// <param name="p1">Paquete a comparar</param>
        /// <param name="p2">Paquete a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.trackingID == p2.trackingID);
        }
    }
}
