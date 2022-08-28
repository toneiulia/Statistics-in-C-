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
    public partial class AddIndicatoriForm : Form
    {
        public AddFirmaFormcs parinte;
        public Indicatori indic;
        public AddIndicatoriForm(AddFirmaFormcs parinte, Indicatori indic)
        {
            InitializeComponent();
            this.parinte = parinte;
            this.indic = indic;
        }

        public void ActualizeazaControale()
        {
            
            if (indic != null)
            {
                button1.Text = "Modifica";
                textBoxAng.Text = indic.NrAngajati.ToString();
                textBoxCA.Text = indic.CifraAfaceri.ToString();
                textBoxProf.Text = indic.Profit.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (indic != null)
            {
                indic.CifraAfaceri = Double.Parse(textBoxCA.Text);
                indic.Profit = Double.Parse(textBoxProf.Text);
                indic.NrAngajati = Int32.Parse(textBoxAng.Text);
            }
            parinte.firma.IndicatoriStatistici = indic;

            this.DialogResult = DialogResult.OK;
        }

        private void textBoxAng_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(textBoxAng.Text, out int rez) == false)
            {
                errorProvider1.SetError(textBoxAng, "Numar de angajati invalid");
                e.Cancel = true;
            }
            else
            {
                if (Convert.ToInt32(textBoxAng.Text) < 0)
                {
                    errorProvider1.SetError(textBoxAng, "Introduceti numar natural.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(textBoxAng, ""); // sau string.empty
                }
            }
        }

        private void textBoxProf_Validating(object sender, CancelEventArgs e)
        {
            if (double.TryParse(textBoxAng.Text, out double rez) == false)
            {
                errorProvider1.SetError(textBoxProf, "Profit invalid");
                e.Cancel = true;
            }
            else
            {
                if (Convert.ToDouble(textBoxProf.Text) < 0)
                {
                    errorProvider1.SetError(textBoxProf, "Introduceti numar natural.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(textBoxProf, ""); 
                }
            }
        }

        private void textBoxCA_Validating(object sender, CancelEventArgs e)
        {
            if (double.TryParse(textBoxCA.Text, out double rez) == false)
            {
                errorProvider1.SetError(textBoxCA, "Cifra de afaceri invalida!");
                e.Cancel = true;
            }
            else
            {
                if (Convert.ToDouble(textBoxCA.Text) < 0)
                {
                    errorProvider1.SetError(textBoxCA, "Introduceti numar natural.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(textBoxCA, ""); 
                }
            }
        }
    }
}
