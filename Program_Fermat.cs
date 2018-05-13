using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Diagnostics;

namespace Primzahlen_Fermat_Forms
{
    public partial class Form1 : Form
    {

        async void Program_Fermat()
        {
            BigInteger anfang = 0;
            BigInteger ende = 0;
            int letzteBasis = 2;


            try
            {
                anfang = BigInteger.Parse(textBox1.Text);
                ende = BigInteger.Parse(textBox2.Text);
                letzteBasis = Convert.ToInt32(textBox4.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte richtige Eingaben machen! :O");
                return;
            }

            button1.Enabled = false;
            await Task.Run(() => SuchePrimzahlen(anfang, ende, letzteBasis));
            button1.Enabled = true;
        }


        void SuchePrimzahlen(BigInteger anfang, BigInteger ende, int letzteBasis)
        {
            Stopwatch s = new Stopwatch();
            int P_Nr = 0;
            string ausgString;


            // Schleife Ersetzt Hand Eingabe.
            for (; anfang <= ende; anfang++)
            {
                s.Start();

                // Primzahlen Engine nach Fermat! :)))
                if (!IstPrimzahlFermat(anfang, letzteBasis))
                    continue;

                s.Stop();
                TimeSpan timeSpan = s.Elapsed;


                // Ausgabe
                ++P_Nr;

                if (checkBox1.Checked)
                {
                    ausgString = String.Format("\nPrimzahl {0} :)  {1:#,#}\r\n", P_Nr, anfang);
                }
                else
                {
                    ausgString = String.Format("\nPrimzahl {0} :)  {1}\r\n", P_Nr, anfang);
                }
                ausgString += String.Format("Time: {0}h {1}m {2}s {3}ms\r\n\r\n", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);

                textBox1.Invoke(new Action(() => textBox3.Text += ausgString));
            }

            textBox3.Invoke(new Action(() => textBox3.Text += "Fertig! :)"));
            textBox3.Invoke(new Action(() => textBox3.Text += "\r\n\r\n\r\n\tCopyright © Nicolas Sauter\r\n\r\n\r\n"));
        }

        bool IstPrimzahlFermat(BigInteger bigZahl, int letzteBasis)
        {
            BigInteger bigErgebnis;

            #region Vorselektion nach Liste *************************************************
            if (bigZahl == 0 || bigZahl == 1)
                return false;
            // Die ersten Primzahlen nach Liste
            if (bigZahl == 2)
                return true;
            if (bigZahl == 3)
                return true;
            if (bigZahl == 5)
                return true;
            if (bigZahl == 7)
                return true;
            if (bigZahl == 11)
                return true;
            if (bigZahl == 13)
                return true;
            if (bigZahl == 17)
                return true;
            if (bigZahl == 19)
                return true;
            if (bigZahl == 23)
                return true;
            if (bigZahl == 29)
                return true;
            if (bigZahl == 31)
                return true;
            if (bigZahl == 37)
                return true;
            if (bigZahl == 41)
                return true;
            if (bigZahl == 43)
                return true;
            if (bigZahl == 47)
                return true;
            if (bigZahl == 53)
                return true;
            if (bigZahl == 59)
                return true;
            if (bigZahl == 61)
                return true;
            if (bigZahl == 67)
                return true;
            if (bigZahl == 71)
                return true;
            if (bigZahl == 73)
                return true;
            if (bigZahl == 79)
                return true;
            if (bigZahl == 83)
                return true;
            if (bigZahl == 89)
                return true;
            if (bigZahl == 97)
                return true;
            // Vorselektion mit Modulo, brutale Beschleunigung!!
            // Alles was vorher mit == muss nochmals mit % Ergänzt werden.
            if ((bigZahl % 2) == 0)
                return false;
            if ((bigZahl % 3) == 0)
                return false;
            if ((bigZahl % 5) == 0)
                return false;
            if ((bigZahl % 7) == 0)
                return false;
            if ((bigZahl % 11) == 0)
                return false;
            if ((bigZahl % 13) == 0)
                return false;
            if ((bigZahl % 17) == 0)
                return false;
            if ((bigZahl % 19) == 0)
                return false;
            if ((bigZahl % 23) == 0)
                return false;
            if ((bigZahl % 29) == 0)
                return false;
            if ((bigZahl % 31) == 0)
                return false;
            if ((bigZahl % 37) == 0)
                return false;
            if ((bigZahl % 41) == 0)
                return false;
            if ((bigZahl % 43) == 0)
                return false;
            if ((bigZahl % 47) == 0)
                return false;
            if ((bigZahl % 53) == 0)
                return false;
            if ((bigZahl % 59) == 0)
                return false;
            if ((bigZahl % 61) == 0)
                return false;
            if ((bigZahl % 67) == 0)
                return false;
            if ((bigZahl % 71) == 0)
                return false;
            if ((bigZahl % 73) == 0)
                return false;
            if ((bigZahl % 79) == 0)
                return false;
            if ((bigZahl % 83) == 0)
                return false;
            if ((bigZahl % 89) == 0)
                return false;
            if ((bigZahl % 97) == 0)
                return false;
            //Ende Liste****************************************************************
            #endregion
            
            //Beliebig viele Durchläufe Angefangen mit Basis 2 bis letzteBasis;
            for (int i = 2; i <= letzteBasis; i++)
            {
                //Test nach Fermat mit ModPow() Methode! :)))))
                bigErgebnis = BigInteger.ModPow(i, bigZahl - 1, bigZahl);

                // 7 Gibt bei Basis 7, 14, 21 usw.  eine Null obwohl Prim! 
                // 0 ist auch Prim
                // gibts z.B. bei prime 7 Basis 7 oder prime 11 Basis 11 usw.
                // (auch bei allen vielfachen der Basis)
                if (bigErgebnis > 1)
                    return false;
            }
            return true;
        }

        #region Info vom Konsolen Program übernommen:
        /*   
                

                "   Basis?\n\n" +
                "   Es werden alle bis zur letzten gerechnet.\n" +
                "   Ausser wenn ein Ergebnis > 1 wird sofort Abgebrochen\n\n" +
                "   Von Basis 2 bis Basis: ");
        
         
                Versuch mit Progressbar:

                //Vor for
                int Gesamt_Bereich = (int)(ende - anfang);
                
                //Nach for Hand Schleife
                int p1 = (int)((Gesamt_Bereich) - (ende - anfang));
                progressBar1.Invoke(new Action(() => progressBar1.Value = (p1 / Gesamt_Bereich) * 1000));
      
         */
        #endregion
    }
}
