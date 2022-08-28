using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tone_Iulia_Paula
{
    [Serializable]
    public class Firma : IComparable<Firma>, ICloneable
    {
        private string denumire;
        private string adresa;
        private bool platitoareTVA;
        private Indicatori indicatoriStatistici;
        private string cui;
        public string Denumire
        {
            get { return this.denumire; }
            set { if (value != this.denumire && value.Length > 0) denumire = value; }
        }

        public string Adresa
        {
            get { return this.adresa; }
            set { if (value != this.adresa && value.Length > 0) adresa = value; }
        }
        public bool PlatitoareTVA
        {
            get { return platitoareTVA; }
            set { if (value != this.platitoareTVA) platitoareTVA = value; }
        }
        public Indicatori IndicatoriStatistici
        {
            get { return indicatoriStatistici; }
            set { if (value != indicatoriStatistici) indicatoriStatistici = value; }
        }
        public string CUI
        {
            get { return cui; }
            set { if (cui != value && value.Length > 0) cui = value; }
        }

        public Firma()
        {
            denumire = "Firma fantoma";
            adresa = "Nicaieri";
            platitoareTVA = false;
            indicatoriStatistici = null;
            cui = "000";
        }

        public Firma(string denumire, string adresa, bool platitoareTVA, Indicatori indicatoriStatistici, string cui)
        {
            this.denumire = denumire;
            this.adresa = adresa;
            this.platitoareTVA = platitoareTVA;
            this.indicatoriStatistici = indicatoriStatistici;
            this.cui = cui;
        }
        public Firma(string denumire, string adresa, string platitoareTVA, Indicatori indicatoriStatistici, string cui)
        {
            this.denumire = denumire;
            this.adresa = adresa;
            if (platitoareTVA.Equals("False")|| platitoareTVA.Equals("false"))
                this.platitoareTVA = false; 
            else this.platitoareTVA = true;
            this.indicatoriStatistici = indicatoriStatistici;
            this.cui = cui;
        }

        public override string ToString()
        {
            string txt;
            txt = "Firma cu numele: " + denumire +", CUI: "+cui+ ", adresa: " + adresa;
            txt +=( platitoareTVA ==true) ?  " este " :  " nu este ";
            txt += "platitoare de TVA si are ca date: " + indicatoriStatistici.ToString();
            return txt;
        }

        public int CompareTo(Firma other)
        {
            return indicatoriStatistici.CompareTo(other.indicatoriStatistici);
        }

        public object Clone()
        {
            Firma clona = (Firma)this.MemberwiseClone();

            Indicatori indicatori = new Indicatori();
            indicatori = (Indicatori)indicatoriStatistici.Clone();

            clona.indicatoriStatistici = indicatori;

            return clona;
        }

      
    }
   
}
