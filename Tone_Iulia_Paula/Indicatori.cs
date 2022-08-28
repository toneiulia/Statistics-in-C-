using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tone_Iulia_Paula
{
    [Serializable]
    public class Indicatori : IComparable<Indicatori>, ICloneable
    {
        // productivitate: cifra afaceri / angajat
        private double cifraAfaceri;
        private int nrAngajati;
        private double profit;
        public double CifraAfaceri
        {
            get { return cifraAfaceri; }
            set { if (cifraAfaceri != value) cifraAfaceri = value; }
        }
        public int NrAngajati
        {
            get { return nrAngajati; }
            set { if (nrAngajati != value) nrAngajati = value; }
        }
        public double Profit
        {
            get { return profit; }
            set { if (profit != value) profit = value; }
        }
        public Indicatori()
        {
            this.cifraAfaceri = 0;
            this.nrAngajati = 0;
            this.profit = 0;
        }

        public Indicatori(double cifraAfaceri, int nrAngajati, double profit)
        {
            this.cifraAfaceri = cifraAfaceri;
            this.nrAngajati = nrAngajati;
            this.profit = profit;
        }

        public string AfiseazaValori()
        {
            return string.Format("{0},{1},{2}",cifraAfaceri,nrAngajati,profit);
        }
        
        public override string ToString()
        {
            return string.Format("CA: {0} RON, nr. angajati: {1}, profit: {2}", cifraAfaceri, nrAngajati, profit);
        }

        public int CompareTo(Indicatori other)
        {
            double sumaIndicatoriCurenti = cifraAfaceri+ nrAngajati+ profit;
            double sumaAltiIndicatori = other.cifraAfaceri + other.nrAngajati + other.profit;

            return sumaIndicatoriCurenti < sumaAltiIndicatori ? -1 : 1;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public static Indicatori operator +(Indicatori indicatori1, Indicatori indicatori2)
        {
            Indicatori indNou = new Indicatori();
            indNou.cifraAfaceri = indicatori1.cifraAfaceri + indicatori2.cifraAfaceri;
            indNou.nrAngajati = indicatori1.nrAngajati + indicatori2.nrAngajati;
            indNou.profit = indicatori1.profit + indicatori2.profit;
            return indNou;
        }

        public static Indicatori operator -(Indicatori indicatori1, Indicatori indicatori2)
        {
            Indicatori indNou = new Indicatori();
            indNou.cifraAfaceri = indicatori1.cifraAfaceri - indicatori2.cifraAfaceri;
            indNou.nrAngajati = indicatori1.nrAngajati - indicatori2.nrAngajati;
            indNou.profit = indicatori1.profit - indicatori2.profit;
            return indNou;
        }
    }

}
