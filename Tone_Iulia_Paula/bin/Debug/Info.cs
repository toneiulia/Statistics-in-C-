using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlProject
{
    public partial class Info : UserControl
    {
        public Info()
        {
            InitializeComponent();
        }
        public void update(DateTime data, int nrFirme, double profitMaxim, double profitMinim)
        {
            if (nrFirme != 0 && profitMaxim != 0 && profitMinim != 0)
            {
                label1.Text = "Data de azi " + data.ToString("dd MMMM yyyy");
                label2.Text = "Sunt " + nrFirme + " firme";
                label3.Text = "Cel mai mare profit: " + profitMaxim;
                label4.Text = "Cel mai mic profit: " + profitMinim;
            }
            else
            {
                label1.Text = "Data de azi " + data.ToString("dd MMMM yyyy");
                label2.Text = "Nu exista date.";
                label3.Text = "";
                label4.Text = "";
            }
        }

        private void Info_Load(object sender, EventArgs e)
        {

        }
    }
}
