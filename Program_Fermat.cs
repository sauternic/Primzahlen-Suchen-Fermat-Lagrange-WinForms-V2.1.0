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

            //Vorselektion nach Liste:
            if (bigZahl == 0 || bigZahl == 1)
                return false;

            if (bigZahl == 2)
                return true;

            if (bigZahl == 5)
                return true;

            //Vorselektion mit Modulo, gerade Zahlen und 5 am Schluss Raus:
            if ((bigZahl % 2) == 0 || bigZahl % 5 == 0)
                return false;

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
        /*   
                Info vom Konsolen Program übernommen:

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
    }
}
