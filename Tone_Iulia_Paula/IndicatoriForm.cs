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
    public partial class IndicatoriForm : Form
    {
        int nrObs;
        string[] x;
        double[] y; 
        Firma firma;

        public IndicatoriForm(Firma firma)
        {
            InitializeComponent();
            this.firma = firma;
            this.ResizeRedraw = true;
            
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            panel2.Invalidate(); 
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {  
            nrObs = 3;
            x = new string[] { "cifraAfaceri", "nrAngajati", "profit" }; 
            y = new double[] { firma.IndicatoriStatistici.CifraAfaceri, firma.IndicatoriStatistici.NrAngajati, firma.IndicatoriStatistici.Profit };  

            Graphics g = e.Graphics; 

            Rectangle zonaClient = e.ClipRectangle;  
            SolidBrush fundal = new SolidBrush(Color.White);  
            g.FillRectangle(fundal, zonaClient);
            
            zonaClient.X += 20; zonaClient.Y += 20;
            zonaClient.Width -= 40; zonaClient.Height -= 40;

            Pen creionRosu = new Pen(Color.Red, 3);
            g.DrawRectangle(creionRosu, zonaClient);

            int vl = zonaClient.Left, vb = zonaClient.Bottom, vr = zonaClient.Right, vt = zonaClient.Top;

            float rap_dist_lat = 0.2f, max;
            int  dist;    
            float lat;

            SolidBrush[] pensule = new SolidBrush[]
            {
                new SolidBrush(Color.RoyalBlue),
                new SolidBrush(Color.YellowGreen),
                new SolidBrush(Color.Red),
                new SolidBrush(Color.RosyBrown),
                new SolidBrush(Color.DarkCyan),
                new SolidBrush(Color.Moccasin)
            };

            SolidBrush pensulaCurenta;
            Pen creionCurent;

            lat = (vr - vl) / (int)((nrObs + 1) * rap_dist_lat + nrObs)*0.8f;

            dist = (int)(rap_dist_lat * lat);
            max = (float)y[0];
            int i;
            for (i = 1; i < nrObs; i++)
                if (max < y[i])
                    max = (float)y[i];

            creionCurent = new Pen(Color.Magenta);
            g.DrawLine(creionCurent, vl, vt, vl, vb);  
            g.DrawLine(creionCurent, vl, vb, vr, vb);

            for (i = 0; i < nrObs; i++)
            {
                pensulaCurenta = pensule[i % 6];
                PointF pnt = new PointF(vl + dist + i * (lat + dist),(float)( vb - y[i] * (vb - vt) / max));
                SizeF sz;
                if(i==1)    sz = new SizeF(lat, ((float)y[i] * (vb - vt) / max));
                else
                sz = new SizeF(lat, (float)y[i] * (vb - vt) / max);

                g.FillRectangle(pensulaCurenta, new RectangleF(pnt, sz));

                textBox1.Text = firma.IndicatoriStatistici.ToString();
                string denx = x[i].ToString();
                g.DrawString(denx, Font, pensulaCurenta, vl + dist + i * (lat + dist) + lat / 3, vb + 5);
                
                
            }
            Pen crNou = new Pen(Color.DarkRed, 7);
            for (i = 0; i < nrObs-1; i++)
                g.DrawLine(crNou,
                    new PointF(vl + dist + i * (lat + dist), (float)(vb - y[i] * (vb - vt) / max)), 
                    new PointF(vl + dist + (i+1) * (lat + dist), (float)(vb - y[i+1] * (vb - vt) / max)));

        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            Firma p = (Firma)((ListViewItem)e.Data.GetData(typeof(ListViewItem))).Tag;
            this.firma = p;
            panel2.Invalidate();
            labelProd.Text += (" " + p.Denumire);
            List<Firma> firme = new List<Firma>();
            firme.Add(p);
            Statistica s = new Statistica(firme);
            textBox2.Text = s.Productivitati[0].ToString();
            
        }

        private void textBox2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            
        }
    }
}
