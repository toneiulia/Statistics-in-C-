using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlProject;


namespace Tone_Iulia_Paula
{
    public partial class Form1 : Form
    {
        string stringConexiune = "Data Source = database1.db";
        public Form1()
        {
            InitializeComponent();
            Indicatori f1 = new Indicatori(88893f, 3000, 78002f);
            Indicatori f2 = new Indicatori(1893f, 200, 3422f);

            Firma m1 = new Firma("SC BistroFox SRL", "Calea Victoriei nr. 34", true, f1, "RO63246432563");
            Firma m2 = new Firma("SC Avramex SA", "Strada Soarelui nr. 9", false, f2, "531001263");

            ListViewItem lvi1 = new ListViewItem(m1.Denumire);
            lvi1.SubItems.Add(m1.Adresa);
            lvi1.SubItems.Add(m1.PlatitoareTVA.ToString());
            lvi1.SubItems.Add(m1.CUI);
            lvi1.UseItemStyleForSubItems = false;
            lvi1.Tag = m1;
            listView1.Items.Add(lvi1);

            ListViewItem lvi2 = new ListViewItem(m2.Denumire);
            lvi2.SubItems.Add(m2.Adresa);
            lvi2.SubItems.Add(m2.PlatitoareTVA.ToString());
            lvi2.SubItems.Add(m2.CUI);
            lvi2.UseItemStyleForSubItems = false;
            lvi2.Tag = m2;
            listView1.Items.Add(lvi2);
            double max = f1.Profit;
            if (f2.Profit > max) max = f2.Profit;
            double min = f1.Profit;
            if (f2.Profit < min) min = f2.Profit;
            info1.update(DateTime.Now, 2, max, min);
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
        }
        public void update()
        {
            double max = 0; int count = 0; double min = 9999999;
            foreach (ListViewItem lvi in listView1.Items)
            {
                Firma m = (Firma)lvi.Tag;
                if (m.IndicatoriStatistici.Profit > max) max = m.IndicatoriStatistici.Profit;
                if (m.IndicatoriStatistici.Profit < min) min = m.IndicatoriStatistici.Profit;
                count++;
            }
            info1.update(DateTime.Now, count, max, min);
        }
        public void UpdateItems()
        {
            foreach (ListViewItem lvi in listView1.Items)
            {
                Firma m = (Firma)lvi.Tag;
                lvi.Text = m.Denumire.ToString();
                lvi.SubItems[1].Text = m.Adresa;
                if (m.PlatitoareTVA) lvi.SubItems[2].Text = "Da";
                else lvi.SubItems[2].Text = "Nu";
                lvi.SubItems[3].Text = m.CUI;
            }
        }
        private void arataIndicatoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Firma m = (Firma)listView1.SelectedItems[0].Tag;
                IndicatoriForm ifm = new IndicatoriForm(m);
                ifm.Text = "Indicatorii firmei " + m.Denumire;
                ifm.Show();
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                arataIndicatoriToolStripMenuItem.Enabled = true;
                stergeToolStripMenuItem.Enabled = true;
                modificaToolStripMenuItem.Enabled = true;
            }
            else
            {
                arataIndicatoriToolStripMenuItem.Enabled = false;
                stergeToolStripMenuItem.Enabled = false;
                modificaToolStripMenuItem.Enabled = false;
            }
        }

        private void adaugaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new
               ListViewItem(new string[] { "", "", "", "" });
            listView1.Items.Add(lvi);
            Firma m = new Firma("", "", false, null, "");
            lvi.Tag = m;

            AddFirmaFormcs fm = new AddFirmaFormcs(this, m);

            fm.Text = "Adaugare firma";

            fm.ShowDialog();

            if (fm.DialogResult != DialogResult.OK)
            {
                lvi.Remove();
            }
            update();
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                listView1.DoDragDrop(listView1.SelectedItems[0], DragDropEffects.Copy);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Calibri", 8);
            Brush brush = Brushes.Black;
            Pen pen = new Pen(brush);

            PageSettings pageSettings = printDocument1.DefaultPageSettings;
            int latime = pageSettings.PaperSize.Width - pageSettings.Margins.Left - pageSettings.Margins.Right;
            int lungime = pageSettings.PaperSize.Height - pageSettings.Margins.Top - pageSettings.Margins.Bottom;

            if (pageSettings.Landscape)
            {
                int temp = lungime;
                lungime = latime;
                latime = temp;
            }

            int latRand = latime / 7;
            int inalRand = 40;

            int x = pageSettings.Margins.Left;
            int y = 100;

            graphics.DrawString("Lista firme", new Font("Times New Roman", 8), brush, latime / 2 - (13 / 2), y);
            y += 100;

            graphics.DrawString("Denumire", font, brush, x, y);
            graphics.DrawString("Adresa", font, brush, x + latRand, y);
            graphics.DrawString("TVA", font, brush, x + 2 * latRand, y);
            graphics.DrawString("CUI", font, brush, x + 3 * latRand, y);
            graphics.DrawString("Indicatori", font, brush, x + 6 * latRand, y);

            y += inalRand;

            List<Firma> lista = listView1.Items.Cast<ListViewItem>().Select(item => (Firma)item.Tag).ToList();
            Rectangle rec = new Rectangle(x - 2, y, e.PageBounds.Width - 2 * (x - 2), e.PageBounds.Height - 2 * y);
            Pen pen2 = new Pen(Color.Black, 3);
            e.Graphics.DrawRectangle(pen2, rec);

            foreach (Firma m in lista)
            {
                graphics.DrawString(m.Denumire, font, brush, x, y);
                graphics.DrawString(m.Adresa, font, brush, x + latRand, y);
                graphics.DrawString(m.PlatitoareTVA.ToString(), font, brush, x + 2 * latRand, y);
                graphics.DrawString(m.CUI, font, brush, x + 3 * latRand, y);
                graphics.DrawString(m.IndicatoriStatistici.ToString(), font, brush, x + 4 * latRand, y);

                y += inalRand;
            }

        }

        private void toolStripButtPRint_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.Document = printDocument1; 

            if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
        }

        private void statusStrip1_MouseHover(object sender, EventArgs e)
        {

            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void binarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog(); 
            fd.CheckPathExists = true; 
            fd.Filter = "Fisiere firme (*firme)|*.firme";  

            if (fd.ShowDialog() == DialogResult.OK)
            {
                Stream fb = File.Create(fd.FileName);  
                BinaryFormatter serializator = new BinaryFormatter();  

                List<Firma> lista = listView1.Items.Cast<ListViewItem>().Select(item => (Firma)item.Tag).ToList();

                serializator.Serialize(fb, lista);
                fb.Close();

            }
        }

        private void binarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog(); 
            fd.CheckPathExists = true; 
            fd.CheckFileExists = true; 
            fd.Filter = "Fisiere firme (*firme)|*.firme";  

            if (fd.ShowDialog() == DialogResult.OK)
            {
                Stream fb = File.OpenRead(fd.FileName); 
                BinaryFormatter des = new BinaryFormatter();
                List<Firma> lista = (List<Firma>)des.Deserialize(fb); 

                listView1.Items.Clear(); 
                foreach (Firma m in lista) 
                {
                    ListViewItem lvi = new ListViewItem(new string[] { "", "", "", "" });  
                    lvi.Tag = m;   
                    listView1.Items.Add(lvi);  
                }
                UpdateItems();  
                fb.Close();  
            }
            update();
        }

        private void textToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<Firma> list = listView1.Items.Cast<ListViewItem>().Select(item => (Firma)item.Tag).ToList();
            StreamWriter sw = new StreamWriter("Firme.txt");
            foreach (Firma m in list)
            {
                sw.WriteLine(m.Denumire);
                sw.WriteLine(m.Adresa);
                sw.WriteLine(m.PlatitoareTVA);
                sw.WriteLine(m.CUI);
                sw.WriteLine(m.IndicatoriStatistici.CifraAfaceri);
                sw.WriteLine(m.IndicatoriStatistici.NrAngajati);
                sw.WriteLine(m.IndicatoriStatistici.Profit);
            }
            sw.Close();
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Firma> lista = null;
            StreamReader sr = new StreamReader("Firme.txt");
            string[] lines = System.IO.File.ReadAllLines("Firme.txt");
            lista = new List<Firma>();
            for (int i = 0; i < lines.Length - 6; i += 7)
            {
                Indicatori inds = new Indicatori(Double.Parse(lines[i + 4]), Int32.Parse(lines[i + 5]), Double.Parse(lines[i + 6]));
                Firma m = new Firma(lines[i], lines[i + 1], lines[i + 2], inds, lines[i + 3]);
                lista.Add(m);
            }

            sr.Close();
            listView1.Items.Clear();

            foreach (Firma m1 in lista)
            {
                ListViewItem lvi1 = new ListViewItem(m1.Denumire);
                lvi1.SubItems.Add(m1.Adresa);
                lvi1.SubItems.Add(m1.PlatitoareTVA.ToString());
                lvi1.SubItems.Add(m1.CUI);
                lvi1.UseItemStyleForSubItems = false;
                lvi1.Tag = m1;
                listView1.Items.Add(lvi1);
            }
            update();
        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                AddFirmaFormcs fm = new AddFirmaFormcs(this, null);

                fm.Text = "Modificare firma";

                listView1.SelectedIndexChanged += new EventHandler(fm.ActualizeazaControale);

                fm.ActualizeazaControale(listView1, e);
                fm.parinte = this;
                fm.ShowDialog();
            }
            update();
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Firma m = (Firma)listView1.SelectedItems[0].Tag;
                DialogResult rezultat = MessageBox.Show("Sunteti sigur ca doriti sa stergeti firma " + m.Denumire + " ?",
                    "Confirmare stergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rezultat == DialogResult.Yes) listView1.SelectedItems[0].Remove();

            }
            update();
        }

  
        private void button1_Click(object sender, EventArgs e)
        {
            Firma m = new Firma("", "", false, null, "");

            AddFirmaFormcs fm = new AddFirmaFormcs(this, m);

            fm.Text = "Adaugare firma in baza de date";

            fm.ShowDialog();

            if (fm.DialogResult != DialogResult.OK)
            {
                m = null;
            }
            else m = fm.firma;
            if (m != null)
            {
                string query = "INSERT INTO Firme(Denumire, Adresa, CUI,TVA) VALUES(@denumire, @adresa, @CUI, @TVA); SELECT last_insert_rowid()";

                using (SqliteConnection connection = new SqliteConnection(stringConexiune))
                {
                    SqliteCommand command = new SqliteCommand(query, connection);
                    command.Parameters.AddWithValue("@denumire", m.Denumire);
                    command.Parameters.AddWithValue("@adresa", m.Adresa);
                    command.Parameters.AddWithValue("@CUI", m.CUI);
                    if (m.PlatitoareTVA == true)
                        command.Parameters.AddWithValue("@TVA", 1);
                    else command.Parameters.AddWithValue("@TVA", 0);

                    connection.Open(); 

                    long id = (long)command.ExecuteScalar();

                }
                string query2 = "INSERT INTO Indicatori(Angajati, CifraAfaceri, Profit) VALUES(@ang, @ca, @pr); SELECT last_insert_rowid()";

                using (SqliteConnection connection = new SqliteConnection(stringConexiune))
                {
                    SqliteCommand command = new SqliteCommand(query2, connection);
                    command.Parameters.AddWithValue("@ang", m.IndicatoriStatistici.NrAngajati);
                    command.Parameters.AddWithValue("@ca", m.IndicatoriStatistici.CifraAfaceri);
                    command.Parameters.AddWithValue("@pr", m.IndicatoriStatistici.Profit);

                    connection.Open(); 

                    long id = (long)command.ExecuteScalar();

                }

                listView1.Items.Clear();
                button2_Click(sender, e);
            }
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Firma> lista = new List<Firma>();
            string query = "SELECT * FROM Firme"; 

            using (SqliteConnection connection = new SqliteConnection(stringConexiune)) 
            {
                SqliteCommand command = new SqliteCommand(query, connection); 

                connection.Open();
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        string den = (string)reader["Denumire"];
                        string adresa = (string)reader["Adresa"];
                        string cui = (string)reader["CUI"];
                        long tva = (long)reader["TVA"];
                        bool TVA = false;
                        if (tva == 1) TVA = true;
                        ListViewItem lvi = new
                        ListViewItem(new string[] { "", "", "", "" });
                        listView1.Items.Add(lvi);
                        Firma m = new Firma(den, adresa, TVA, null, cui);
                        lvi.Tag = m;
                        lista.Add(m);
                    }
                }
            }
            query = "SELECT * FROM Indicatori"; 

            using (SqliteConnection connection = new SqliteConnection(stringConexiune)) 
            {
                SqliteCommand command = new SqliteCommand(query, connection); 

                connection.Open();
                int i = 0;
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        long ang = (long)reader["Angajati"];
                        double profit = (double)reader["Profit"];
                        double ca = (double)reader["CifraAfaceri"];
                        Indicatori inds = new Indicatori(ca, (int)ang, profit);
                        if(i<lista.Count)
                        lista[i].IndicatoriStatistici = inds;
                        i++;
                    }
                }
            }
            buttonDelete.Enabled = true;
            buttonUpdate.Enabled = true;
            buttonDelete.Text = "delete";
            buttonUpdate.Text = "update";
            UpdateItems();
            update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear(); 
            update();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Firma m = (Firma)listView1.SelectedItems[0].Tag;
                DialogResult rezultat = MessageBox.Show("Sunteti sigur ca doriti sa stergeti firma " + m.Denumire + " din baza de date?",
                    "Confirmare stergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rezultat == DialogResult.Yes) 
                {
                    listView1.SelectedItems[0].Remove();
                

                    string query = "DELETE FROM Firme WHERE Denumire=@denumire";

                    using (SqliteConnection connection = new SqliteConnection(stringConexiune))
                    {

                        SqliteCommand command = new SqliteCommand(query, connection);
                        command.Parameters.AddWithValue("@denumire", m.Denumire);

                        connection.Open();

                        command.ExecuteNonQuery();
                    }
                    query = "DELETE FROM Indicatori WHERE Angajati=@ang and Profit=@profit and CifraAfaceri = @ca";

                    using (SqliteConnection connection = new SqliteConnection(stringConexiune))
                    {

                        SqliteCommand command = new SqliteCommand(query, connection);
                        command.Parameters.AddWithValue("@ang", m.IndicatoriStatistici.NrAngajati);
                        command.Parameters.AddWithValue("@profit", m.IndicatoriStatistici.Profit);
                        command.Parameters.AddWithValue("@ca", m.IndicatoriStatistici.CifraAfaceri);
                        connection.Open();

                        command.ExecuteNonQuery();
                    }
                    update();
                }
            }
            
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string vechi = listView1.SelectedItems[0].Text;
                Firma v = (Firma)listView1.SelectedItems[0].Tag;
                int angv = v.IndicatoriStatistici.NrAngajati;
                double prv = v.IndicatoriStatistici.Profit;
                double ca = v.IndicatoriStatistici.CifraAfaceri;
                AddFirmaFormcs fm = new AddFirmaFormcs(this, null);

                fm.Text = "Modificare firma baza de date";

                listView1.SelectedIndexChanged += new EventHandler(fm.ActualizeazaControale);

                fm.ActualizeazaControale(listView1, e);
                fm.parinte = this;
                fm.ShowDialog();
              
                Firma m = fm.firma;
                string query = "UPDATE Firme SET Denumire = @denumire, Adresa = @adresa, CUI = @CUI, TVA = @TVA WHERE Denumire = @vechi";

                using (SqliteConnection connection = new SqliteConnection(stringConexiune))
                {
                    SqliteCommand command = new SqliteCommand(query, connection);
                    command.Parameters.AddWithValue("@denumire", m.Denumire);
                    command.Parameters.AddWithValue("@adresa", m.Adresa);
                    command.Parameters.AddWithValue("@CUI", m.CUI);
                    command.Parameters.AddWithValue("@vechi", vechi);
                    if (m.PlatitoareTVA == true)
                        command.Parameters.AddWithValue("@TVA", 1);
                    else command.Parameters.AddWithValue("@TVA", 0);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
                query = "UPDATE Indicatori SET Angajati = @ang, Profit = @profit, CifraAfaceri = @ca WHERE Angajati = @angv and Profit = @profitv and CifraAfaceri = @cav";

                using (SqliteConnection connection = new SqliteConnection(stringConexiune))
                {
                    SqliteCommand command = new SqliteCommand(query, connection);
                    command.Parameters.AddWithValue("@ang", m.IndicatoriStatistici.NrAngajati);
                    command.Parameters.AddWithValue("@profit", m.IndicatoriStatistici.Profit);
                    command.Parameters.AddWithValue("@ca", m.IndicatoriStatistici.CifraAfaceri);
                    command.Parameters.AddWithValue("@angv", angv);
                    command.Parameters.AddWithValue("@profitv",prv);
                    command.Parameters.AddWithValue("@cav", ca);


                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
            update();
        }
    } 
    
}
