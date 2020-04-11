using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;



namespace Proiect
{
    class FormularAgenda : Form
    {
        IStocareData adminPersoane = StocareFactory.GetAdministratorStocare();

        private Grup textFlagsGrup = Grup.Familie;
        private Provenienta textFlagsProvenienta = Provenienta.Anglia;

        public Agenda[] AGENDA=new Agenda[20];
        public int Nr_Persoane=0;

        private const int LATIME_CONTROL = 220;
        private const int INALTIME_CONTROL = 30;
        private const int INALTIME_CONTROL1= 20;
        private const int TOP_CONTROL = 20;
        private const int LEFT_CONTROL = 20;
        private const int DIMENSIUNE_PAS_X = 350;

        private Label lblNume, lblPrenume, lblNumar_telefon, lblAdresa_email,lblData_nasterii,lblGrup,lblProvenienta,lblInfo;
        private TextBox txtNume, txtPrenume, txtNumar_telefon, txtAdresa_email, txtData_nasterii;
        private ComboBox cmbGrupa,cmbProvenienta;
        private Button btnAdauga;

        public FormularAgenda()
        {
            this.Size = new System.Drawing.Size(500, 200);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(100, 100);
            this.Font = new Font("Cooper black", 15, FontStyle.Italic);
            this.ForeColor = Color.Black;
            this.BackColor = Color.Gray;
            this.Text = "Agenda";

            //Obiecte de tip Label

            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Height = INALTIME_CONTROL;
            lblNume.Top = TOP_CONTROL;
            lblNume.Left = LEFT_CONTROL;
            lblNume.Text = "Nume:";
            lblNume.Font = new Font("Elephant", 14, FontStyle.Bold);
            lblNume.BackColor = Color.LightGray;
            this.Controls.Add(lblNume);

            lblPrenume = new Label();
            lblPrenume.Width = LATIME_CONTROL;
            lblPrenume.Height = INALTIME_CONTROL;
            lblPrenume.Text = "Prenume:";
            lblPrenume.Font= new Font("Elephant", 14, FontStyle.Bold);
            lblPrenume.Top = 3*TOP_CONTROL;
            lblPrenume.Left = LEFT_CONTROL;
            lblPrenume.BackColor = Color.LightGray;
            this.Controls.Add(lblPrenume);

            lblData_nasterii = new Label();
            lblData_nasterii.Width = LATIME_CONTROL;
            lblData_nasterii.Height = INALTIME_CONTROL;
            lblData_nasterii.Text = "Data nasterii:";
            lblData_nasterii.Font= new Font("Elephant", 14, FontStyle.Bold);
            lblData_nasterii.Top = 5 * TOP_CONTROL;
            lblData_nasterii.Left = LEFT_CONTROL;
            lblData_nasterii.BackColor = Color.LightGray;
            this.Controls.Add(lblData_nasterii);

            lblNumar_telefon = new Label();
            lblNumar_telefon.Width = LATIME_CONTROL;
            lblNumar_telefon.Height = INALTIME_CONTROL;
            lblNumar_telefon.Text = "Numar de telefon:";
            lblNumar_telefon.Font= new Font("Elephant", 14, FontStyle.Bold);
            lblNumar_telefon.Top = 7 * TOP_CONTROL;
            lblNumar_telefon.Left = LEFT_CONTROL;
            lblNumar_telefon.BackColor = Color.LightGray;
            this.Controls.Add(lblNumar_telefon);

            lblAdresa_email = new Label();
            lblAdresa_email.Width = LATIME_CONTROL;
            lblAdresa_email.Height = INALTIME_CONTROL;
            lblAdresa_email.Text = "Adresa de email:";
            lblAdresa_email.Font= new Font("Elephant", 14, FontStyle.Bold);
            lblAdresa_email.Top = 9 * TOP_CONTROL;
            lblAdresa_email.Left = LEFT_CONTROL;
            lblAdresa_email.BackColor = Color.LightGray;
            this.Controls.Add(lblAdresa_email);

            lblGrup = new Label();
            lblGrup.Width = LATIME_CONTROL;
            lblGrup.Height = INALTIME_CONTROL;
            lblGrup.Text = "Grupul:";
            lblGrup.Font= new Font("Elephant", 14, FontStyle.Bold);
            lblGrup.Top =11 * TOP_CONTROL;
            lblGrup.Left = LEFT_CONTROL;
            lblGrup.BackColor = Color.LightGray;
            this.Controls.Add(lblGrup);

            lblProvenienta = new Label();
            lblProvenienta.Width = LATIME_CONTROL;
            lblProvenienta.Height = INALTIME_CONTROL;
            lblProvenienta.Text = "Provenienta:";
            lblProvenienta.Font= new Font("Elephant", 14, FontStyle.Bold);
            lblProvenienta.Top = 13 * TOP_CONTROL;
            lblProvenienta.Left = LEFT_CONTROL;
            lblProvenienta.BackColor = Color.LightGray;
            this.Controls.Add(lblProvenienta);

            lblInfo = new Label();
            lblInfo.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X - 200, 18 * TOP_CONTROL);
            lblInfo.Height = INALTIME_CONTROL1;
            lblInfo.Width = (LATIME_CONTROL * 4) + 200;
            lblInfo.Font = new Font("Elephant", 13, FontStyle.Italic);
            lblInfo.BackColor = Color.DarkGray;
            this.Controls.Add(lblInfo);

            //Obiecte de tip TextBox

            txtNume = new TextBox();
            txtNume.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, TOP_CONTROL);
            txtNume.Width = 30+LATIME_CONTROL;
            txtNume.Height = INALTIME_CONTROL;
            txtNume.Left = DIMENSIUNE_PAS_X;
            txtNume.BackColor=Color.DarkGray;
            txtNume.ForeColor = Color.Maroon;
            txtNume.Font = new Font("Elephant", 14, FontStyle.Regular);
            this.Controls.Add(txtNume);

            txtPrenume = new TextBox();
            txtPrenume.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 3*TOP_CONTROL);
            txtPrenume.Width = 30+LATIME_CONTROL;
            txtPrenume.Height = INALTIME_CONTROL;
            txtPrenume.Left = DIMENSIUNE_PAS_X;
            txtPrenume.BackColor = Color.DarkGray;
            txtPrenume.ForeColor = Color.Maroon;
            txtPrenume.Font = new Font("Elephant", 14, FontStyle.Regular);
            this.Controls.Add(txtPrenume);

            txtData_nasterii = new TextBox();
            txtData_nasterii.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 5 * TOP_CONTROL);
            txtData_nasterii.Width =30+ LATIME_CONTROL;
            txtData_nasterii.Height = INALTIME_CONTROL;
            txtData_nasterii.Left = DIMENSIUNE_PAS_X;
            txtData_nasterii.BackColor = Color.DarkGray;
            txtData_nasterii.ForeColor = Color.Maroon;
            txtData_nasterii.Font = new Font("Elephant", 14, FontStyle.Regular);
            this.Controls.Add(txtData_nasterii);

            txtNumar_telefon = new TextBox();
            txtNumar_telefon.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 7 * TOP_CONTROL);
            txtNumar_telefon.Width = 30+LATIME_CONTROL;
            txtNumar_telefon.Height = INALTIME_CONTROL;
            txtNumar_telefon.Left = DIMENSIUNE_PAS_X;
            txtNumar_telefon.BackColor = Color.DarkGray;
            txtNumar_telefon.ForeColor = Color.Maroon;
            txtNumar_telefon.Font = new Font("Elephant", 14, FontStyle.Regular);
            this.Controls.Add(txtNumar_telefon);

            txtAdresa_email = new TextBox();
            txtAdresa_email.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 9 * TOP_CONTROL);
            txtAdresa_email.Width = 30+LATIME_CONTROL;
            txtAdresa_email.Height = INALTIME_CONTROL;
            txtAdresa_email.Left = DIMENSIUNE_PAS_X;
            txtAdresa_email.BackColor = Color.DarkGray;
            txtAdresa_email.ForeColor = Color.Maroon;
            txtAdresa_email.Font = new Font("Elephant", 14, FontStyle.Regular);
            this.Controls.Add(txtAdresa_email);

             //Obiecte de tip ComboBox

            cmbGrupa = new ComboBox();
            cmbGrupa.Location = new Point(DIMENSIUNE_PAS_X, 11 * TOP_CONTROL);
            cmbGrupa.Left = DIMENSIUNE_PAS_X;
            cmbGrupa.BackColor = Color.DarkGray;
            cmbGrupa.ForeColor = Color.Maroon;
            cmbGrupa.Width = LATIME_CONTROL + 30;
            cmbGrupa.Font = new Font("Elephant", 14, FontStyle.Regular);
            foreach (string name in Enum.GetNames(typeof(Grup)))
            {
                cmbGrupa.Items.Add(name);
            }
            cmbGrupa.SelectedIndex = 0;
            cmbGrupa.SelectedIndexChanged += new EventHandler(cmbGrupa_SelectedIndexChanged_Grup);
            this.Controls.Add(cmbGrupa);

            cmbProvenienta = new ComboBox();
            cmbProvenienta.Location = new Point(DIMENSIUNE_PAS_X, 13 * TOP_CONTROL);
            cmbProvenienta.Left = DIMENSIUNE_PAS_X;
            cmbProvenienta.BackColor = Color.DarkGray;
            cmbProvenienta.Width = LATIME_CONTROL + 30;
            cmbProvenienta.ForeColor = Color.Maroon;
            cmbProvenienta.Font = new Font("Elephant", 14, FontStyle.Regular);
            foreach (string name in Enum.GetNames(typeof(Provenienta)))
            {
                cmbProvenienta.Items.Add(name);
            }
            cmbProvenienta.SelectedIndex = 0;
            cmbProvenienta.SelectedIndexChanged += new EventHandler(cmbProvenienta_SelectedIndexChanged_Provenienta);
            this.Controls.Add(cmbProvenienta);

            //Obiecte de tip Button

            btnAdauga = new Button();
            btnAdauga.Location = new System.Drawing.Point((DIMENSIUNE_PAS_X * 2)+80, 7*TOP_CONTROL);
            btnAdauga.Width = 130+LATIME_CONTROL;
            btnAdauga.Height = 10+INALTIME_CONTROL;
            btnAdauga.Text = "Adauga Persoana in Agenda";
            btnAdauga.BackColor = Color.LightGray;
            btnAdauga.Font = new Font("Elephant", 16, FontStyle.Italic);
            btnAdauga.Click += OnBtnAdaugaClick;
            this.Controls.Add(btnAdauga);
          
        }
        private void OnBtnAdaugaClick(object sender, EventArgs e)
        {
          
            if (txtNume.Text == "" || txtPrenume.Text == "" || txtData_nasterii.Text == "" || txtNumar_telefon.Text == "" || txtAdresa_email.Text == "")
            {
                if (txtNume.Text == "")
                    lblNume.ForeColor = Color.Red;
                else
                    lblNume.ForeColor = Color.Black;
                if (txtPrenume.Text == "")
                    lblPrenume.ForeColor = Color.Red;
                else
                    lblPrenume.ForeColor = Color.Black;
                if (txtNumar_telefon.Text == "")
                    lblNumar_telefon.ForeColor = Color.Red;
                else
                    lblNumar_telefon.ForeColor = Color.Black;
                if (txtData_nasterii.Text == "")
                    lblData_nasterii.ForeColor = Color.Red;
                else
                    lblData_nasterii.ForeColor = Color.Black;
                if (txtAdresa_email.Text == "")
                    lblAdresa_email.ForeColor = Color.Red;
                else
                    lblAdresa_email.ForeColor = Color.Black;
            }
            else
            {

                Agenda persoana = new Agenda(txtNume.Text, txtPrenume.Text, txtData_nasterii.Text, txtNumar_telefon.Text, txtAdresa_email.Text, textFlagsGrup,textFlagsProvenienta);
                var header = string.Format("{0,-12}{1,8}{2,20}{3,21}{4,29}{5,15}{6,26}"
                                      , "Nume", "Prenume", "Data de nastere", "Numar de telefon", "Adresa de email", "Grup", "Tara de provenienta");
                AGENDA[Nr_Persoane++] = persoana;
                adminPersoane.AddSPersoana_InFisier(persoana);
                lblInfo.Text = header;
                lblInfo.Height = lblInfo.Height + INALTIME_CONTROL;
                int i;
                for (i = 0; i < Nr_Persoane; i++)
                {

                    lblInfo.Text = lblInfo.Text + Environment.NewLine + AGENDA[i].ConversieLaSir();
                    lblInfo.Height = lblInfo.Height;

                }
                lblNumar_telefon.ForeColor = Color.Black;
                lblData_nasterii.ForeColor = Color.Black;
                lblNume.ForeColor = Color.Black;
                lblPrenume.ForeColor = Color.Black;
                lblAdresa_email.ForeColor = Color.Black;
            }
        }
      
        void cmbGrupa_SelectedIndexChanged_Grup(object sender, EventArgs e)
        {
            this.textFlagsGrup = (Grup)Enum.Parse(typeof(Grup),(string)cmbGrupa.Items[cmbGrupa.SelectedIndex]);
            Invalidate();
        }

        void cmbProvenienta_SelectedIndexChanged_Provenienta(object sender, EventArgs e)
        {
            this.textFlagsProvenienta = (Provenienta)Enum.Parse(typeof(Provenienta),(string)cmbProvenienta.Items[cmbProvenienta.SelectedIndex]);
            Invalidate();
        }
    }
}
