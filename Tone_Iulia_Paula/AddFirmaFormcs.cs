using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tone_Iulia_Paula
{
    public partial class AddFirmaFormcs : Form
    {
        public Form1 parinte;
        public Firma firma;
        public AddFirmaFormcs(Form1 par,Firma firma)
        {
            InitializeComponent();
            this.parinte = par;
            this.firma = firma;
        }
        public void ActualizeazaControale(object sender, EventArgs e)
        {
            buttonAddFirma.Text = "Modifica firma";
            buttonAddIndic.Text = "Modifica indicatori";
            ListView listaMea = (ListView)sender;
            firma = null;
            if (listaMea.SelectedItems.Count > 0)
                firma = (Firma)listaMea.SelectedItems[0].Tag;

            if (firma != null)
            {
                textBoxDenumire.Text = firma.Denumire;
                textBoxAdresa.Text = firma.Adresa;
                textBoxCUI.Text = firma.CUI;
                if (firma.PlatitoareTVA == true) checkBox1.Checked = true;
                else checkBox1.Checked = false;
                if(firma.IndicatoriStatistici!=null)
                textBoxIS.Text = firma.IndicatoriStatistici.ToString();
            }
        }
        private void buttonAddFirma_Click(object sender, EventArgs e)
        {
            if (firma != null)
            {
                firma.Denumire = textBoxDenumire.Text;
                firma.CUI = textBoxCUI.Text;
                firma.Adresa = textBoxAdresa.Text;
                if (checkBox1.Checked) firma.PlatitoareTVA = true;
                else firma.PlatitoareTVA = false;
            }
            parinte.UpdateItems();
            this.DialogResult = DialogResult.OK;
        }

        private void buttonAddIndic_Click(object sender, EventArgs e)
        {
            
            if(this.Text == "Modificare firma"||this.Text== "Modificare firma baza de date")
            {
                
                Indicatori m = firma.IndicatoriStatistici;
                AddIndicatoriForm fm = new AddIndicatoriForm(this, m);

                fm.Text = "Modificare indicatori";
               fm.ActualizeazaControale();
                fm.ShowDialog();

                textBoxIS.Text = m.ToString();
            }
            else
            {
                Indicatori m = new Indicatori(0, 0, 0);

                AddIndicatoriForm fm = new AddIndicatoriForm(this, m);

                fm.Text = "Adaugare indicatori";

                fm.ShowDialog();

                if (fm.DialogResult != DialogResult.OK)
                {
                    m = null;
                    this.DialogResult = DialogResult.Cancel;
                }
                textBoxIS.Text = m.ToString();
            }
        }
    }
}
