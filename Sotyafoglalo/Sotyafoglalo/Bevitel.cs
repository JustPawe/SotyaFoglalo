using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sotyafoglalo
{
    public partial class Bevitel : Form
    {
        ControlForm cForm = new ControlForm();

        private Boolean elsoFutas = true;

        private string KerdesekPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Paveszka Márk Rekenei Zolta\Sotyafoglaló\kerdesek.txt";
        private string TippkerdesekPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Paveszka Márk Rekenei Zolta\Sotyafoglaló\tippkerdesek.txt";

        private int szamlalo = 1;
        private int iskolaNevIndex;
        private string[] iskolaNev = { "Arany", "Benedek", "Dr. Mező alsó", "Dr. Mező felső", "Dr. Török Béla", "Heltai", "Herman alsó", "Herman felső	", "Hunyadi", "Jókai", "Jókai", "Kaffka", "Liszt", "Móra", "Munkácsy alsó", "Munkácsy felső", "Németh Imre", "Széchenyi", "Vakok" };

        private static int csapatSzam = 0;
        private static string csapatNev1 = null;
        private static string csapatNev2 = null;
        private static string csapatNev3 = null;
        private static string csapatNev4 = null;

        public static int CsapatSzam { get => csapatSzam;}
        public static string CsapatNev1 { get => csapatNev1;}
        public static string CsapatNev2 { get => csapatNev2;}
        public static string CsapatNev3 { get => csapatNev3;}
        public static string CsapatNev4 { get => csapatNev4;}
        
        //public string KerdesekPath1 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Paveszka Márk Rekenei Zolta\Sotyafoglaló\kerdesek.txt";
        public string KerdesekPath1 { get => KerdesekPath; }
        public string TippkerdesekPath1 { get => TippkerdesekPath; }

        public Bevitel()
        {
            InitializeComponent();

        }

        private void Bevitel_Load(object sender, EventArgs e)
        {
            if (elsoFutas)
            {

                #region mapparendszer és fájlok létrehozása
                try
                {
                    string MappaPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Paveszka Márk Rekenei Zolta\Sotyafoglaló\";

                    bool mappa = Directory.Exists(MappaPath);
                    if (!mappa)
                    {
                        Directory.CreateDirectory(MappaPath);
                        MessageBox.Show("Eltüntek a frappáns kérdéseid!\nBajban vagy!");
                    }

                    if (!File.Exists(KerdesekPath))
                    {
                        MessageBox.Show("Eltünt de csináltam neked másik 'kerdesek.txt'\n" + KerdesekPath);
                        File.Open(KerdesekPath, FileMode.Create).Close();
                    }
                    StreamReader streamReader = new StreamReader(KerdesekPath);
                    if (streamReader.ReadToEnd() == "")
                    {
                        MessageBox.Show("Hoppá nincsenek kérdéseid...\nÜres a 'kerdesek.txt'");
                    }

                    if (!File.Exists(TippkerdesekPath))
                    {
                        MessageBox.Show("Eltünt de csináltam neked másik 'Tippkerdesek.txt'\n" + TippkerdesekPath);
                        File.Open(TippkerdesekPath, FileMode.Create).Close();
                    }
                    streamReader = new StreamReader(TippkerdesekPath);
                    if (streamReader.ReadToEnd() == "")
                    {
                        MessageBox.Show("Hoppá nincsenek tippkérdéseid...\nÜres a 'tippkerdesek.txt'");
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Futtas rendszergazda ként mert igy nincs jogom!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Liba van a mátrixban!!!\n" + ex);
                }
                #endregion

                elsoFutas = false;
            }

            szamlalo = 1;

            csapatSzam = 0;
            csapatNev1 = null;
            csapatNev2 = null;
            csapatNev3 = null;
            csapatNev4 = null;
            csapatNevLabel.Text = szamlalo + ". Csapat neve:";
            csapatNevButton.Enabled = false;
            CsapatNevTextBox.Enabled = false;

            csapatSzamLabel.Enabled = true;
            csapatSzamNumericUpDown.Enabled = true;
            csapatSzamButton.Enabled = true;
        }

        private void alapButton_Click(object sender, EventArgs e)
        {
            Bevitel_Load(sender,e);
        }

        private void csapatSzamButton_Click(object sender, EventArgs e)
        {
            cForm.CsapatSzam = Convert.ToInt32(csapatSzamNumericUpDown.Value);
            csapatSzamLabel.Enabled = false;
            csapatSzamNumericUpDown.Enabled = false;
            csapatSzamButton.Enabled = false;

            CsapatNevTextBox.Enabled = true;
            csapatNevButton.Enabled = true;
        }

        private void csapatNevButton_Click(object sender, EventArgs e)
        {
            iskolaNevIndex = 0;
            if (CsapatNevTextBox.Text!="" && CsapatNevTextBox.Text != cForm.CsapatNevek[0] && CsapatNevTextBox.Text != cForm.CsapatNevek[1] && CsapatNevTextBox.Text != cForm.CsapatNevek[2])
            {
                csapatNevLabel.Text = (szamlalo + 1) + ". Csapat neve:";

                if (szamlalo == 1)
                {
                    cForm.CsapatNevek[0] = CsapatNevTextBox.Text;
                    CsapatNevTextBox.Clear();
                }
                else if (szamlalo == 2)
                {
                    cForm.CsapatNevek[1] = CsapatNevTextBox.Text;
                    CsapatNevTextBox.Clear();
                }
                else if (szamlalo == 3)
                {
                    cForm.CsapatNevek[2] = CsapatNevTextBox.Text;
                    CsapatNevTextBox.Clear();
                }
                else if (szamlalo == 4)
                {
                    cForm.CsapatNevek[3] = CsapatNevTextBox.Text;
                    CsapatNevTextBox.Clear();
                }

                if (szamlalo == cForm.CsapatSzam)
                {
                    this.Hide();
                    cForm.Show();
                }

                szamlalo++;
            }
            else if(CsapatNevTextBox.Text == "")
            {
                MessageBox.Show("Üresen hagytad a mezöt!");
            }
            else
            {
                MessageBox.Show("Ez a név már foglalt!");
            }
        }

        private void CsapatNevTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (csapatSzamButton.Enabled == true)
                {
                    csapatSzamButton_Click(this, new EventArgs());
                }
                else if (csapatNevButton.Enabled == true)
                {
                    csapatNevButton_Click(this, new EventArgs());
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (csapatSzamButton.Enabled == false && csapatNevButton.Enabled == true && iskolaNevIndex < iskolaNev.Length)
                {
                    CsapatNevTextBox.Text = iskolaNev[iskolaNevIndex];
                    iskolaNevIndex++;
                }
                else
                {
                    iskolaNevIndex = 0;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (csapatSzamButton.Enabled == false && csapatNevButton.Enabled == true && iskolaNevIndex > 0)
                {
                    CsapatNevTextBox.Text = iskolaNev[iskolaNevIndex];
                    iskolaNevIndex--;
                }
                else
                {
                    iskolaNevIndex = 0;
                }
            }
        }
    }
}