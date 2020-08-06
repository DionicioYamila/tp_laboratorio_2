using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {

        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                using (StreamWriter w = File.AppendText(archivo))
                {
                    w.WriteLine(texto);
                }
                return true;
            }
            catch(Exception e)
            {
                throw new Exception("Error en generar archivo", e);
            }

        }
    }
}
