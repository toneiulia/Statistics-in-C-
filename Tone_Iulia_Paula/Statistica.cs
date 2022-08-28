using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tone_Iulia_Paula
{
    public class Statistica
    {
        private List<Firma> firme;
        private double[] productivitati; // productivitate: cifra afaceri / angajat

        public Statistica(List<Firma> f)
        {
            firme = f;
            productivitati = new double[f.Count];
            for (int i = 0; i < firme.Count; i++) {
                productivitati[i] = firme[i].IndicatoriStatistici.CifraAfaceri / firme[i].IndicatoriStatistici.NrAngajati;
            }
        }

        public List<Firma> Firme
            {
            get { return firme; }
            set { firme = value; }
            }
        public double[] Productivitati
        {
            get { return productivitati; }
        }
    }
}
