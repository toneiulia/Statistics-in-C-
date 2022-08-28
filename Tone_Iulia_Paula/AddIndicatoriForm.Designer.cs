
namespace Tone_Iulia_Paula
{
    partial class AddIndicatoriForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAng = new System.Windows.Forms.TextBox();
            this.textBoxProf = new System.Windows.Forms.TextBox();
            this.textBoxCA = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelDenumireFirma = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Angajati";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Profit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cifra afaceri";
            // 
            // textBoxAng
            // 
            this.textBoxAng.Location = new System.Drawing.Point(169, 71);
            this.textBoxAng.Name = "textBoxAng";
            this.textBoxAng.Size = new System.Drawing.Size(100, 26);
            this.textBoxAng.TabIndex = 3;
            this.textBoxAng.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxAng_Validating);
            // 
            // textBoxProf
            // 
            this.textBoxProf.Location = new System.Drawing.Point(169, 110);
            this.textBoxProf.Name = "textBoxProf";
            this.textBoxProf.Size = new System.Drawing.Size(100, 26);
            this.textBoxProf.TabIndex = 4;
            this.textBoxProf.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxProf_Validating);
            // 
            // textBoxCA
            // 
            this.textBoxCA.Location = new System.Drawing.Point(169, 151);
            this.textBoxCA.Name = "textBoxCA";
            this.textBoxCA.Size = new System.Drawing.Size(100, 26);
            this.textBoxCA.TabIndex = 5;
            this.textBoxCA.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCA_Validating);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "Adauga indicatori";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelDenumireFirma
            // 
            this.labelDenumireFirma.AutoSize = true;
            this.labelDenumireFirma.Location = new System.Drawing.Point(97, 26);
            this.labelDenumireFirma.Name = "labelDenumireFirma";
            this.labelDenumireFirma.Size = new System.Drawing.Size(53, 20);
            this.labelDenumireFirma.TabIndex = 7;
            this.labelDenumireFirma.Text = "Firma ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddIndicatoriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 336);
            this.Controls.Add(this.labelDenumireFirma);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxCA);
            this.Controls.Add(this.textBoxProf);
            this.Controls.Add(this.textBoxAng);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddIndicatoriForm";
            this.Text = "AddIndicatoriForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAng;
        private System.Windows.Forms.TextBox textBoxProf;
        private System.Windows.Forms.TextBox textBoxCA;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelDenumireFirma;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}