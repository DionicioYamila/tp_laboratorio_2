using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        public static bool Insertar(Paquete p)
        {
            string s = string.Format("'{0}','{1}','Yamila Dionicio'", p.DireccionEntrega, p.TrackingID);
            string consulta = "INSERT INTO Paquetes(direccionEntrega, trackingID, alumno) VALUES(" + s + ")";

            try
            {
                conexion.Open();
                comando.CommandText = consulta;
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Error al Insertar", e);
            }
        }

        static PaqueteDAO()
        {
            comando = new SqlCommand();
            conexion = new SqlConnection("Data source = DESKTOP-SK3BO0C\\SQLEXPRESS; Database = correo-sp-2017; Trusted_Connection = True;");
        }
    }
}
