using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using Snake;


namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        private const int LATIME_CONTROL = 150;
        private const int ALINIERE_X = 50;
        private const int ALINIERE_Y = 15;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 170;

        private Label lblTitlu;
        private Label[] lblNickname = new Label[30];
        private Label[] lblPuncte = new Label[30];
        private Label[] lblData = new Label[30];

        public Form1()
        {
            string numeFisier;
            int nrPlayeri;

            numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            AdministrarePlayer_FisierText adminPlayer = new AdministrarePlayer_FisierText(caleCompletaFisier);
            Players[] Player = adminPlayer.GetPlayeri(out nrPlayeri);

            //Declarari si initializari
            //initializare forma
            this.Size = new Size(600,580); 
            this.Text = "Snake";
            this.ForeColor = Color.Blue;
            this.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Aqua;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.WindowState = FormWindowState.Normal;

            lblTitlu = new Label();
            lblTitlu.Width = 400;
            lblTitlu.Left = 100;
            lblTitlu.Top = ALINIERE_Y;
            lblTitlu.Text = "Playeri";
            lblTitlu.BackColor = Color.LightGreen;
            lblTitlu.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add( lblTitlu );

            for(int i = 0; i < nrPlayeri; i++)
            {
                lblNickname[i] = new Label();
                lblNickname[i].Text = Player[i].Nickname;
                lblNickname[i].Font = new Font("Arial", 9, FontStyle.Bold);
                lblNickname[i].Width = LATIME_CONTROL;
                lblNickname[i].Top = (i + 1) * DIMENSIUNE_PAS_Y + ALINIERE_Y;
                lblNickname[i].Left = ALINIERE_X;
                lblNickname[i].BackColor = Color.LightGreen;
                lblNickname[i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add( lblNickname[i] );

                lblPuncte[i] = new Label();
                lblPuncte[i].Text = Player[i].Punctaj.ToString();
                lblPuncte[i].Font = new Font("Cambria", 9, FontStyle.Bold);
                lblPuncte[i].Width = LATIME_CONTROL;
                lblPuncte[i].Top = (i + 1) * DIMENSIUNE_PAS_Y + ALINIERE_Y;
                lblPuncte[i].Left = DIMENSIUNE_PAS_X + ALINIERE_X;
                lblPuncte[i].BackColor = Color.LightGreen;
                lblPuncte[i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add( lblPuncte[i] );

                lblData[i] = new Label();
                lblData[i].Text = Player[i].Data;
                lblData[i].Font = new Font("Cambria", 9, FontStyle.Bold);
                lblData[i].Width = LATIME_CONTROL;
                lblData[i].Top = (i + 1) * DIMENSIUNE_PAS_Y + ALINIERE_Y;
                lblData[i].Left = 2 * DIMENSIUNE_PAS_X + ALINIERE_X;
                lblData[i].BackColor = Color.LightGreen;
                lblData[i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add( lblData[i] );
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
