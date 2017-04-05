using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaTroco.Classe
{
     public static class Util
    {
        public static string CasasDecimais(this decimal valor, int casas)
        {
            return Math.Round(valor, casas).ToString("F" + casas).Replace(',', '.');
        }

        public static string CasasDecimais(this decimal? valor, int casas)
        {
            if (valor == null || valor == 0)
                return "";

            return CasasDecimais(valor.Value, casas);
        }

        public static void SomenteNumero(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || //Letras
               char.IsSymbol(e.KeyChar) || //Símbolos
               char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
