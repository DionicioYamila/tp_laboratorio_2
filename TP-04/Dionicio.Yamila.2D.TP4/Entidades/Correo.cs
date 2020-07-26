using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }

            set
            {
                this.paquetes = value;
            }
        }

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// FinEntregas cerrará todos los hilos activos.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread aux in this.mockPaquetes)
            {
                if (aux.IsAlive)
                {
                    aux.Abort();
                }
            }
        }

        /// <summary>
        /// MostrarDatos retorna un string con todos los datos del paquete.
        /// </summary>
        /// <param name="elementos">Elementos la lista de paquetes</param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Paquete p in ((Correo)elementos).paquetes)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Agrega un Paquete al Porreo si, y solo si, el Paquete no se encuentra en la lista de Paquetes de esta.
        /// </summary>
        /// <param name="c">Correo al que se agrega el paquete</param>
        /// <param name="p">Paquete que se agrega al correo</param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete aux in c.paquetes)
            {
                if (aux == p)
                {
                    throw new TrackingIdRepetidoException("El paquete se encuentra en el Correo");
                }
            }

            c.paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();

            return c;
        }

    }
}
