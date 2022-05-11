
namespace InterfataUtilizator_WindowsForms
{
    partial class Form1
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
            this.textBoxNick = new System.Windows.Forms.TextBox();
            this.textBoxPct = new System.Windows.Forms.TextBox();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNick
            // 
            this.textBoxNick.Location = new System.Drawing.Point(45, 38);
            this.textBoxNick.Name = "textBoxNick";
            this.textBoxNick.Size = new System.Drawing.Size(132, 22);
            this.textBoxNick.TabIndex = 0;
            this.textBoxNick.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNick.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBoxNick.Enter += new System.EventHandler(this.GotFocusNick);
            this.textBoxNick.Leave += new System.EventHandler(this.LostFocusNick);
            // 
            // textBoxPct
            // 
            this.textBoxPct.Location = new System.Drawing.Point(196, 38);
            this.textBoxPct.Name = "textBoxPct";
            this.textBoxPct.Size = new System.Drawing.Size(133, 22);
            this.textBoxPct.TabIndex = 1;
            this.textBoxPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPct.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBoxPct.Enter += new System.EventHandler(this.GotFocusPct);
            this.textBoxPct.Leave += new System.EventHandler(this.LostFocusPct);
            // 
            // textBoxData
            // 
            this.textBoxData.AccessibleName = "";
            this.textBoxData.Location = new System.Drawing.Point(347, 38);
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.Size = new System.Drawing.Size(133, 22);
            this.textBoxData.TabIndex = 2;
            this.textBoxData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxData.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.textBoxData.Enter += new System.EventHandler(this.GotFocusDate);
            this.textBoxData.Leave += new System.EventHandler(this.LostFocusDate);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Aquamarine;
            this.button1.Location = new System.Drawing.Point(499, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 3;
            this.button1.Text = "&Adauga";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.OnButtonAdaugaClick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Aquamarine;
            this.button2.Location = new System.Drawing.Point(499, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 22);
            this.button2.TabIndex = 4;
            this.button2.Text = "Afisea&za";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.OnButtonAfiseazaClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxData);
            this.Controls.Add(this.textBoxPct);
            this.Controls.Add(this.textBoxNick);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.OnFormClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNick;
        private System.Windows.Forms.TextBox textBoxPct;
        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

