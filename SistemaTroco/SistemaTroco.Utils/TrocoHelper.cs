using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTroco.Utils
{
    public static class TrocoHelper
    {
        public static Resultado calculaTroco(double valor, double pago)
        {

            int Nota100Count = 0;
            int Nota50Count = 0;
            int Nota20Count = 0;
            int Nota10Count = 0;


            int Centavo50Count = 0;
            int Centavo10Count = 0;
            int Centavo5Count = 0;
            int Centavo1Count = 0;


            string result = "";
            double troco;

            int vlr;
            bool temNota = true;
            bool temCentavo = true;
            troco = (pago - valor);
         //   txtTroco.Text = troco.ToString();

            //  definindo as notas do troco (parte inteira)
            vlr = ((int)(troco));

            while ((vlr != 0) && (temNota))
            {
                temNota = false;
                while (vlr >= 100)
                {
                    vlr = vlr - 100;
                    Nota100Count++;
                    temNota = true;
                }
                while (vlr >= 50)
                {
                    vlr = vlr - 50;
                    Nota50Count++;
                    temNota = true;
                }
                while (vlr >= 20)
                {
                    vlr = vlr - 20;
                    Nota20Count++;
                    temNota = true;
                }
                while (vlr >= 10)
                {
                    vlr = vlr - 10;
                    Nota10Count++;
                    temNota = true;
                }

            }


            //  definindo os centavos do troco (parte fracion�ria)
            vlr = ((int)(Math.Round(((vlr + (troco - ((int)(troco))))
                              * 100))));

            while ((vlr != 0) && (temCentavo))
            {
                temCentavo = false;
                while (vlr >= 50)
                {
                    vlr = vlr - 50;
                    Centavo50Count++;
                    temCentavo = true;
                }

                while (vlr >= 10)
                {
                    vlr = vlr - 10;
                    Centavo10Count++;
                    temCentavo = true;
                }

                while (vlr >= 5)
                {
                    vlr = vlr - 5;
                    Centavo5Count++;
                    temCentavo = true;
                }

                while (vlr >= 1)
                {
                    vlr = vlr - 1;
                    Centavo1Count++;
                    temCentavo = true;
                }


            }

            //Notas
            if (Nota100Count > 0)
            {
                result = result + Nota100Count + " notas de R$ 100 \n";
            }


            if (Nota50Count > 0)
            {
                result = result + Nota50Count + " notas de R$ 50 \n";
            }


            if (Nota20Count > 0)
            {
                result = result + Nota20Count + " notas de R$ 20 \n";
            }


            if (Nota10Count > 0)
            {
                result = result + Nota10Count + " notas de R$ 10 \n";
            }

            if (Centavo50Count > 0)
            {
                result = result + Centavo50Count + " moeda(s) de R$ 50 centavos \n";
            }

            if (Centavo10Count > 0)
            {
                result = result + Centavo10Count + "  moeda(s) de  R$ 10 centavos\n";
            }


            if (Centavo5Count > 0)
            {
                result = result + Centavo5Count + "  moeda(s) de R$ 5 centavos\n";
            }


            if (Centavo1Count > 0)
            {
                result = result + Centavo1Count + "  moeda(s) de R$ 1 centavo\n";
            }


            Resultado listTroco = new Resultado()
            {
                Troco=troco.ToString(),
                Descricao = result

            };    

            return listTroco;
       //     lblResultado.Text = result
       
       }
    }
}
