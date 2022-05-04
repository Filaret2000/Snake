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
        AdministrarePlayer_FisierText adminPlayer;

        private const int LATIME_CONTROL = 150;
        private const int ALINIERE_X = 50;
        private const int ALINIERE_Y = 15;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 170;

        private Label lblTitlu;
        private Label[] lblNickname;
        private Label[] lblPuncte;
        private Label[] lblData;
        private Label LNickname;
        private Label LPuncte;
        private Label LData;
        private TextBox TNickname;
        private TextBox TPuncte;
        private TextBox TData;

        private Button btnAdauga;
        private Button btnRefresh;

        public Form1()
        {
            string numeFisier;
            int nrPlayeri;

            numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            adminPlayer = new AdministrarePlayer_FisierText(caleCompletaFisier);
            Players[] Player = adminPlayer.GetPlayeri(out nrPlayeri);

            InitializeComponent();

            //Declarari si initializari
            //initializare forma
            this.Size = new Size(520,450); 
            this.Text = "Snake";
            this.ForeColor = Color.Blue;
            this.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Aqua;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.WindowState = FormWindowState.Normal;
            this.AutoScroll = true;

            LNickname = new Label();
            LNickname.Width = LATIME_CONTROL;
            LNickname.Text = "Nickname";
            LNickname.Top = ALINIERE_Y;
            LNickname.Left = ALINIERE_X;
            LNickname.BackColor = Color.LawnGreen;
            LNickname.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add( LNickname );

            TNickname = new TextBox();
            TNickname.Width = LATIME_CONTROL;
            TNickname.Top = ALINIERE_Y + DIMENSIUNE_PAS_Y;
            TNickname.Left = ALINIERE_X;
            this.Controls.Add( TNickname );

            LPuncte = new Label();
            LPuncte.Width = LATIME_CONTROL;
            LPuncte.Text = "Puncte";
            LPuncte.Top = ALINIERE_Y;
            LPuncte.Left = ALINIERE_X + DIMENSIUNE_PAS_X;
            LPuncte.BackColor = Color.LawnGreen;
            LPuncte.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add( LPuncte );

            TPuncte = new TextBox();
            TPuncte.Width = LATIME_CONTROL;
            TPuncte.Top = ALINIERE_Y + DIMENSIUNE_PAS_Y;
            TPuncte.Left = ALINIERE_X + DIMENSIUNE_PAS_X;
            this.Controls.Add(TPuncte);

            LData = new Label();
            LData.Width = LATIME_CONTROL;
            LData.Text = "Data";
            LData.Top = ALINIERE_Y;
            LData.Left = ALINIERE_X + 2 * DIMENSIUNE_PAS_X;
            LData.BackColor = Color.LawnGreen;
            LData.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add( LData );

            TData = new TextBox();
            TData.Width = LATIME_CONTROL;
            TData.Top = ALINIERE_Y + DIMENSIUNE_PAS_Y;
            TData.Left = ALINIERE_X + 2 * DIMENSIUNE_PAS_X;
            this.Controls.Add(TData);

            btnAdauga = new Button();
            btnAdauga.Width = LATIME_CONTROL;
            btnAdauga.Location = new Point(ALINIERE_X + 3 * DIMENSIUNE_PAS_X, ALINIERE_Y);
            btnAdauga.Text = "Adauga";
            btnAdauga.Font = new Font("Arial", 9, FontStyle.Bold);
            btnAdauga.BackColor = Color.Aquamarine;
            btnAdauga.Click += OnButtonAdaugaClick;
            this.Controls.Add( btnAdauga );

            btnRefresh = new Button();
            btnRefresh.Width = LATIME_CONTROL;
            btnRefresh.Location = new Point(ALINIERE_X + 3 * DIMENSIUNE_PAS_X, ALINIERE_Y + DIMENSIUNE_PAS_Y);
            btnRefresh.Text = "Refresh";
            btnRefresh.Font = new Font("Arial", 9, FontStyle.Bold);
            btnRefresh.BackColor = Color.Aquamarine;
            btnRefresh.Click += OnButtonRefreshClick;
            this.Controls.Add( btnRefresh );
        }

        private void Form1_Load(Object sender, EventArgs e)
        {
            AfisarePlayeri();
        }

        private void OnButtonAdaugaClick(Object sender, EventArgs e)
        {
            Players[] Playeri = adminPlayer.GetPlayeri(out int nrPlayeri);
            nrPlayeri += 1;
            int idPlayeri = nrPlayeri;
            Players player = new Players(TNickname.Text, TData.Text, Convert.ToInt32(TPuncte.Text));
            player.idPlayer = idPlayeri;
            adminPlayer.AddPlayer(player);
        }
        private void OnButtonRefreshClick(Object sender, EventArgs e)
        {
            AfisarePlayeri();
            TNickname.Text = String.Empty;
            TPuncte.Text = String.Empty;
            TData.Text = String.Empty;
        }
        private void AfisarePlayeri()
        {
            Players[] Player = adminPlayer.GetPlayeri(out int nrPlayeri);

            lblNickname = new Label[30];
            lblPuncte = new Label[30];
            lblData = new Label[30];

            lblTitlu = new Label();
            lblTitlu.Width = 400;
            lblTitlu.Left = 100;
            lblTitlu.Top = 3 * DIMENSIUNE_PAS_Y + ALINIERE_Y;
            lblTitlu.Text = "Playeri";
            lblTitlu.BackColor = Color.LightGreen;
            lblTitlu.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitlu);

            for (int i = 0; i < nrPlayeri; i++)
            {
                lblNickname[i] = new Label();
                lblNickname[i].Text = Player[i].Nickname;
                lblNickname[i].Font = new Font("Arial", 9, FontStyle.Bold);
                lblNickname[i].Width = LATIME_CONTROL;
                lblNickname[i].Top = (i + 4) * DIMENSIUNE_PAS_Y + ALINIERE_Y;
                lblNickname[i].Left = ALINIERE_X;
                lblNickname[i].BackColor = Color.LightGreen;
                lblNickname[i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(lblNickname[i]);

                lblPuncte[i] = new Label();
                lblPuncte[i].Text = Player[i].Punctaj.ToString();
                lblPuncte[i].Font = new Font("Cambria", 9, FontStyle.Bold);
                lblPuncte[i].Width = LATIME_CONTROL;
                lblPuncte[i].Top = (i + 4) * DIMENSIUNE_PAS_Y + ALINIERE_Y;
                lblPuncte[i].Left = DIMENSIUNE_PAS_X + ALINIERE_X;
                lblPuncte[i].BackColor = Color.LightGreen;
                lblPuncte[i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(lblPuncte[i]);

                lblData[i] = new Label();
                lblData[i].Text = Player[i].Data;
                lblData[i].Font = new Font("Cambria", 9, FontStyle.Bold);
                lblData[i].Width = LATIME_CONTROL;
                lblData[i].Top = (i + 4) * DIMENSIUNE_PAS_Y + ALINIERE_Y;
                lblData[i].Left = 2 * DIMENSIUNE_PAS_X + ALINIERE_X;
                lblData[i].BackColor = Color.LightGreen;
                lblData[i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(lblData[i]);
            }
        }
    }
}
