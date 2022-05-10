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
        private const int LUNGIME_NICKNAME = 15;

        private Label lblTitlu;
        private Label[,] lblTablou;

        private Label LNickname;
        private Label LPuncte;
        private Label LData;

        private Label NickError;
        private Label DateError;
        private Label PctError;

        /* declarare TextBox-uri pentru citire prin cod
        private TextBox TNickname;
        private TextBox TPuncte;
        private TextBox TData;
        */

        /* declarare butoane adauga si refresh prin cod
        private Button btnAdauga;
        private Button btnRefresh;
        */
        private Button btnNext;

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
            this.Size = new Size(480,110); 
            this.Text = "Snake";
            this.ForeColor = Color.Blue;
            this.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Aqua;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.WindowState = FormWindowState.Normal;

            LNickname = new Label();
            LNickname.Width = LATIME_CONTROL;
            LNickname.Text = "Nickname";
            LNickname.Top = ALINIERE_Y;
            LNickname.Left = ALINIERE_X;
            LNickname.BackColor = Color.LawnGreen;
            LNickname.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add( LNickname );

            /* TextBoxNick pentru citire definit prin cod
            TNickname = new TextBox();
            TNickname.Width = LATIME_CONTROL;
            TNickname.Top = ALINIERE_Y + DIMENSIUNE_PAS_Y;
            TNickname.Left = ALINIERE_X;
            this.Controls.Add( TNickname );
            */

            LPuncte = new Label();
            LPuncte.Width = LATIME_CONTROL;
            LPuncte.Text = "Puncte";
            LPuncte.Top = ALINIERE_Y;
            LPuncte.Left = ALINIERE_X + DIMENSIUNE_PAS_X;
            LPuncte.BackColor = Color.LawnGreen;
            LPuncte.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add( LPuncte );

            /* TextBoxPct pentru citire definit prin cod
            TPuncte = new TextBox();
            TPuncte.Width = LATIME_CONTROL;
            TPuncte.Top = ALINIERE_Y + DIMENSIUNE_PAS_Y;
            TPuncte.Left = ALINIERE_X + DIMENSIUNE_PAS_X;
            this.Controls.Add(TPuncte);
            */

            LData = new Label();
            LData.Width = LATIME_CONTROL;
            LData.Text = "Data";
            LData.Top = ALINIERE_Y;
            LData.Left = ALINIERE_X + 2 * DIMENSIUNE_PAS_X;
            LData.BackColor = Color.LawnGreen;
            LData.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add( LData );

            /* TextBoxData pentru citire definit prin cod
            TData = new TextBox();
            TData.Width = LATIME_CONTROL;
            TData.Top = ALINIERE_Y + DIMENSIUNE_PAS_Y;
            TData.Left = ALINIERE_X + 2 * DIMENSIUNE_PAS_X;
            this.Controls.Add(TData);
            */

            /* Butoane adauga si refresh declarate prin cod
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
            */

            NickError = new Label();
            DateError = new Label();
            PctError = new Label();
            btnNext = new Button();
        }

        private void Form1_Load(Object sender, EventArgs e)
        {
            
        }

        private void OnButtonAdaugaClick(Object sender, EventArgs e)
        {
            Players[] Playeri = adminPlayer.GetPlayeri(out int nrPlayeri);
            nrPlayeri += 1;
            int idPlayeri = nrPlayeri;
            string errorMessage;
            if (ValidareInput(out errorMessage))
            {
                Players player = new Players(textBoxNick.Text, textBoxData.Text, Convert.ToInt32(textBoxPct.Text));
                player.idPlayer = idPlayeri;
                adminPlayer.AddPlayer(player);
                //stergere erori si continut introdus
                DateError.Text = String.Empty;
                PctError.Text = String.Empty;
                NickError.Text = String.Empty;
                LData.ForeColor = Color.Blue;
                LNickname.ForeColor = Color.Blue;
                LPuncte.ForeColor = Color.Blue;
                textBoxNick.Text = String.Empty;
                textBoxData.Text = String.Empty;
                textBoxPct.Text = String.Empty;
            }
            else
            {
                if (errorMessage == "11" || errorMessage == "21")
                {
                    if(errorMessage == "11")
                        NickError.Text = "Obligatoriu";
                    else
                        NickError.Text = "Prea lung";
                    NickError.Top = ALINIERE_Y + 2 * DIMENSIUNE_PAS_Y;
                    NickError.Left = ALINIERE_X;
                    NickError.Width = LATIME_CONTROL;
                    NickError.ForeColor = Color.Red;
                    NickError.TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(NickError);

                    LNickname.ForeColor = Color.Red;
                    PctError.Text = String.Empty;
                    DateError.Text = String.Empty;
                    textBoxNick.Text = String.Empty;
                }
                if (errorMessage == "13" || errorMessage == "23")
                {
                    if (errorMessage == "13")
                        PctError.Text = "Obligatoriu";
                    else
                        PctError.Text = "Trebuie numar";
                    PctError.Top = ALINIERE_Y + 2 * DIMENSIUNE_PAS_Y;
                    PctError.Left = ALINIERE_X + DIMENSIUNE_PAS_X;
                    PctError.Width = LATIME_CONTROL;
                    PctError.ForeColor = Color.Red;
                    PctError.TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(PctError);

                    LPuncte.ForeColor = Color.Red;
                    LData.ForeColor = Color.Blue;
                    LNickname.ForeColor = Color.Blue;
                    NickError.Text = String.Empty;
                    DateError.Text = String.Empty;
                    textBoxPct.Text = String.Empty;
                }
                if (errorMessage == "12" || errorMessage == "22")
                {
                    if (errorMessage == "12")
                        DateError.Text = "Obligatoriu";
                    else
                        DateError.Text = "Format diferit";
                    DateError.Top = ALINIERE_Y + 2 * DIMENSIUNE_PAS_Y;
                    DateError.Left = ALINIERE_X + 2 * DIMENSIUNE_PAS_X;
                    DateError.Width = LATIME_CONTROL;
                    DateError.ForeColor = Color.Red;
                    DateError.TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(DateError);

                    LData.ForeColor = Color.Red;
                    LNickname.ForeColor = Color.Blue;
                    LPuncte.ForeColor = Color.Blue;
                    NickError.Text = String.Empty;
                    PctError.Text = String.Empty;
                    textBoxData.Text = String.Empty;
                }
            }
        }
        /*private void OnButtonRefreshClick(Object sender, EventArgs e)
        {
            AfisarePlayeri();
            textBoxNick.Text = String.Empty;
            textBoxPct.Text = String.Empty;
            textBoxData.Text = String.Empty;
        }*/
        private void OnButtonAfiseazaClick(Object sender, EventArgs e)
        {
            Players[] Player = adminPlayer.GetPlayeri(out int nrPlayeri);
            this.Size = new Size( 1300 , 200 );
            this.AutoSize = true;
            AfisarePlayeri();
            if (Screen.PrimaryScreen.Bounds.Height <= (nrPlayeri + 1) * DIMENSIUNE_PAS_Y + ALINIERE_Y)
            {
                btnNext.Text = "&Next";
                btnNext.Width = 85;
                btnNext.Height = 23;
                btnNext.Location = new Point(ALINIERE_X + 3 * DIMENSIUNE_PAS_X, ALINIERE_Y + 2 * DIMENSIUNE_PAS_Y);
                btnNext.Font = new Font("Arial", 9, FontStyle.Bold);
                btnNext.BackColor = Color.Aquamarine;
                btnNext.Click += OnButtonNextClick;
                this.Controls.Add(btnNext);
            }
                this.CenterToScreen();
        }
        private void OnFormClick(Object sender, EventArgs e)
        {
            this.AutoSize = false;
            this.Size = new Size(730, 155);
            this.CenterToScreen();
            // stergerea Label-urilor
            this.Controls.Remove(lblTitlu);
            Players[] Player = adminPlayer.GetPlayeri(out int nrPlayeri);
            for (int i = 0; i < nrPlayeri; i++)
            {
                this.Controls.Remove(lblTablou[0, i]);
                this.Controls.Remove(lblTablou[1, i]);
                this.Controls.Remove(lblTablou[2, i]);
            }
            this.Controls.Remove(btnNext);
        }
        private void OnButtonNextClick(Object sender, EventArgs e)
        {
            Players[] Player = adminPlayer.GetPlayeri(out int nrPlayeri);
            int afisStop = (Screen.PrimaryScreen.Bounds.Height - ALINIERE_Y) / DIMENSIUNE_PAS_Y - 3;
            this.Controls.Remove(lblTitlu);
            for (int i = 0; i < afisStop; i++)
            {
                this.Controls.Remove(lblTablou[0, i]);
                this.Controls.Remove(lblTablou[1, i]);
                this.Controls.Remove(lblTablou[2, i]);
            }
            for (int i = afisStop; i < nrPlayeri; i++)
            {
                lblTablou[0, i] = new Label();
                lblTablou[0, i].Text = Player[i].Nickname;
                lblTablou[0, i].Font = new Font("Arial", 9, FontStyle.Bold);
                lblTablou[0, i].Width = LATIME_CONTROL;
                lblTablou[0, i].Top = (i - afisStop ) * DIMENSIUNE_PAS_Y + ALINIERE_Y;
                lblTablou[0, i].Left = 4 * DIMENSIUNE_PAS_X + ALINIERE_X;
                lblTablou[0, i].BackColor = Color.LightGreen;
                lblTablou[0, i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(lblTablou[0, i]);

                lblTablou[1, i] = new Label();
                lblTablou[1, i].Text = Player[i].Punctaj.ToString();
                lblTablou[1, i].Font = new Font("Cambria", 9, FontStyle.Bold);
                lblTablou[1, i].Width = LATIME_CONTROL;
                lblTablou[1, i].Top = (i - afisStop ) * DIMENSIUNE_PAS_Y + ALINIERE_Y;
                lblTablou[1, i].Left = 5 * DIMENSIUNE_PAS_X + ALINIERE_X;
                lblTablou[1, i].BackColor = Color.LightGreen;
                lblTablou[1, i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(lblTablou[1, i]);

                lblTablou[2, i] = new Label();
                lblTablou[2, i].Text = Player[i].Data;
                lblTablou[2, i].Font = new Font("Cambria", 9, FontStyle.Bold);
                lblTablou[2, i].Width = LATIME_CONTROL;
                lblTablou[2, i].Top = (i - afisStop ) * DIMENSIUNE_PAS_Y + ALINIERE_Y;
                lblTablou[2, i].Left = 6 * DIMENSIUNE_PAS_X + ALINIERE_X;
                lblTablou[2, i].BackColor = Color.LightGreen;
                lblTablou[2, i].TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(lblTablou[2, i]);
            }
        }
        public bool ValidareInput(out string errorMessage)
        {
            if (textBoxNick.Text.Length == 0)
            {
                errorMessage = "11";
                return false;
            }
            if (textBoxNick.Text.Length > LUNGIME_NICKNAME)
            {
                errorMessage = "21";
                return false;
            }
            if (textBoxPct.Text.Length == 0)
            {
                errorMessage = "13";
                return false;
            }
            if (!Int32.TryParse(textBoxPct.Text, out int result))
            {
                errorMessage = "23";
                return false;
            }
            if (textBoxData.Text.Length == 0)
            {
                errorMessage = "12";
                return false;
            }
            bool nr = true;
            for (int i = 0; i < textBoxData.Text.Length && i != 2 && i != 5; i++)
                if (textBoxData.Text[i] - '0' < 0 || textBoxData.Text[i] - '0' > 9)
                    nr = false;
            if (textBoxData.Text.Length != 10 || textBoxData.Text[2] != '.' || textBoxData.Text[5] != '.' || !nr)
            {
                errorMessage = "22";
                return false;
            }
            errorMessage = "";
            return true;
        }
        private void AfisarePlayeri()
        {
            Players[] Player = adminPlayer.GetPlayeri(out int nrPlayeri);

            lblTablou = new Label[3,nrPlayeri];

            lblTitlu = new Label();
            lblTitlu.Width = 400;
            lblTitlu.Left = 4 * DIMENSIUNE_PAS_X + 100;
            lblTitlu.Top = ALINIERE_Y;
            lblTitlu.Text = "Playeri";
            lblTitlu.BackColor = Color.LightGreen;
            lblTitlu.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitlu);

            for (int i = 0; i < nrPlayeri; i++)
            {
                    lblTablou[0, i] = new Label();
                    lblTablou[0, i].Text = Player[i].Nickname;
                    lblTablou[0, i].Font = new Font("Arial", 9, FontStyle.Bold);
                    lblTablou[0, i].Width = LATIME_CONTROL;
                    lblTablou[0, i].Top = (i + 1) * DIMENSIUNE_PAS_Y + ALINIERE_Y;
                    lblTablou[0, i].Left = 4 * DIMENSIUNE_PAS_X + ALINIERE_X;
                    lblTablou[0, i].BackColor = Color.LightGreen;
                    lblTablou[0, i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblTablou[0, i]);

                    lblTablou[1, i] = new Label();
                    lblTablou[1, i].Text = Player[i].Punctaj.ToString();
                    lblTablou[1, i].Font = new Font("Cambria", 9, FontStyle.Bold);
                    lblTablou[1, i].Width = LATIME_CONTROL;
                    lblTablou[1, i].Top = (i + 1) * DIMENSIUNE_PAS_Y + ALINIERE_Y;
                    lblTablou[1, i].Left = 5 * DIMENSIUNE_PAS_X + ALINIERE_X;
                    lblTablou[1, i].BackColor = Color.LightGreen;
                    lblTablou[1, i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblTablou[1, i]);

                    lblTablou[2, i] = new Label();
                    lblTablou[2, i].Text = Player[i].Data;
                    lblTablou[2, i].Font = new Font("Cambria", 9, FontStyle.Bold);
                    lblTablou[2, i].Width = LATIME_CONTROL;
                    lblTablou[2, i].Top = (i + 1) * DIMENSIUNE_PAS_Y + ALINIERE_Y;
                    lblTablou[2, i].Left = 6 * DIMENSIUNE_PAS_X + ALINIERE_X;
                    lblTablou[2, i].BackColor = Color.LightGreen;
                    lblTablou[2, i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblTablou[2, i]);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void GotFocusNick(Object sender, EventArgs e)
        {
            textBoxNick.BackColor = Color.BlueViolet;
        }
        private void LostFocusNick(Object sender, EventArgs e)
        {
            textBoxNick.BackColor = Color.White;
        }
        private void GotFocusPct(Object sender, EventArgs e)
        {
            textBoxPct.BackColor = Color.BlueViolet;
        }
        private void LostFocusPct(Object sender, EventArgs e)
        {
            textBoxPct.BackColor = Color.White;
        }
        private void GotFocusDate(Object sender, EventArgs e)
        {
            textBoxData.BackColor = Color.BlueViolet;
        }
        private void LostFocusDate(Object sender, EventArgs e)
        {
            textBoxData.BackColor = Color.White;
        }
    }
}
