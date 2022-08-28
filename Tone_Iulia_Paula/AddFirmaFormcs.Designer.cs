
namespace Tone_Iulia_Paula
{
    partial class AddFirmaFormcs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDenumire = new System.Windows.Forms.TextBox();
            this.textBoxAdresa = new System.Windows.Forms.TextBox();
            this.textBoxIS = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCUI = new System.Windows.Forms.TextBox();
            this.buttonAddFirma = new System.Windows.Forms.Button();
            this.buttonAddIndic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Denumire";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Adresa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(470, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Indicatori statistici";
            // 
            // textBoxDenumire
            // 
            this.textBoxDenumire.Location = new System.Drawing.Point(159, 43);
            this.textBoxDenumire.Name = "textBoxDenumire";
            this.textBoxDenumire.Size = new System.Drawing.Size(100, 26);
            this.textBoxDenumire.TabIndex = 4;
            // 
            // textBoxAdresa
            // 
            this.textBoxAdresa.Location = new System.Drawing.Point(159, 95);
            this.textBoxAdresa.Name = "textBoxAdresa";
            this.textBoxAdresa.Size = new System.Drawing.Size(100, 26);
            this.textBoxAdresa.TabIndex = 5;
            // 
            // textBoxIS
            // 
            this.textBoxIS.Location = new System.Drawing.Point(474, 95);
            this.textBoxIS.Multiline = true;
            this.textBoxIS.Name = "textBoxIS";
            this.textBoxIS.Size = new System.Drawing.Size(246, 230);
            this.textBoxIS.TabIndex = 8;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(67, 235);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(159, 24);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Platitoare de TVA";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "CUI";
            // 
            // textBoxCUI
            // 
            this.textBoxCUI.Location = new System.Drawing.Point(159, 166);
            this.textBoxCUI.Name = "textBoxCUI";
            this.textBoxCUI.Size = new System.Drawing.Size(100, 26);
            this.textBoxCUI.TabIndex = 6;
            // 
            // buttonAddFirma
            // 
            this.buttonAddFirma.Location = new System.Drawing.Point(63, 328);
            this.buttonAddFirma.Name = "buttonAddFirma";
            this.buttonAddFirma.Size = new System.Drawing.Size(138, 39);
            this.buttonAddFirma.TabIndex = 10;
            this.buttonAddFirma.Text = "Adauga firma";
            this.buttonAddFirma.UseVisualStyleBackColor = true;
            this.buttonAddFirma.Click += new System.EventHandler(this.buttonAddFirma_Click);
            // 
            // buttonAddIndic
            // 
            this.buttonAddIndic.Location = new System.Drawing.Point(474, 348);
            this.buttonAddIndic.Name = "buttonAddIndic";
            this.buttonAddIndic.Size = new System.Drawing.Size(170, 39);
            this.buttonAddIndic.TabIndex = 11;
            this.buttonAddIndic.Text = "Adauga indicatori";
            this.buttonAddIndic.UseVisualStyleBackColor = true;
            this.buttonAddIndic.Click += new System.EventHandler(this.buttonAddIndic_Click);
            // 
            // AddFirmaFormcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAddIndic);
            this.Controls.Add(this.buttonAddFirma);
            this.Controls.Add(this.textBoxCUI);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBoxIS);
            this.Controls.Add(this.textBoxAdresa);
            this.Controls.Add(this.textBoxDenumire);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddFirmaFormcs";
            this.Text = "AddFirmaFormcs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDenumire;
        private System.Windows.Forms.TextBox textBoxAdresa;
        private System.Windows.Forms.TextBox textBoxIS;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCUI;
        private System.Windows.Forms.Button buttonAddFirma;
        private System.Windows.Forms.Button buttonAddIndic;
    }
}