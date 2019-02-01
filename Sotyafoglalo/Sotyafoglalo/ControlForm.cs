using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sotyafoglalo
{
    public partial class ControlForm : Form
    {
        private string[] csapatNevek = new string[4];
        private int csapatSzam;
        public Stopwatch Stopwatch = new Stopwatch();
        public string[] CsapatNevek { get => csapatNevek; set => csapatNevek = value; }
        public int CsapatSzam { get => csapatSzam; set => csapatSzam = value; }

        private List<Kerdes> kerdesek = new List<Kerdes>();
        private List<TippKerdes> tippek = new List<TippKerdes>();
        private mainLayout form1;
        private int[] lepesek;
        private int kerdesSzam = 0;
        private int hatralevoKerdesekSzama;
        private int lepesekIndex = 0;
        private int tippkerdesSzam = 0;
        private Kerdesek kForm;
        private Tippelos tForm;
        private Bevitel bevitel;
        private int vedoNum;
        private int attackedX;
        private int attackedY;
        private int attackedValue;
        private string joValasz;
        private int joHelye;
        private bool isItValasztos = true;
        private int joTipp;

        public void stopperStarter()
        {
            this.Stopwatch.Reset();
            this.Stopwatch.Start();
        }

        public void stopperStop()
        {
            this.Stopwatch.Stop();
        }

        public ControlForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //mainLayout mainLayout = new mainLayout();
            label1.Text = Stopwatch.Elapsed.ToString("hh\\:mm\\:ss\\.ff");
            //mainLayout.stopperLable.Text = Stopwatch.Elapsed.ToString("hh\\:mm\\:ss\\.ff");
            kerdesID.Text = "Hátralévő körök száma: " + hatralevoKerdesekSzama.ToString();

            if (isItValasztos)
            {
                if (Stopwatch.ElapsedMilliseconds == 120000)
                {
                    stopperStop();
                    kForm.setBGColor(joHelye);
                    checkAnswers();
                }
            }
            else
            {
                if (Stopwatch.ElapsedMilliseconds == 60000)
                {
                    stopperStop();
                    tForm.displayHelyesValasz();
                    checkTippek();
                }
            }
        }

        public Screen GetSecondaryScreen()
        {
            if (Screen.AllScreens.Length == 1)
            {
                return null;
            }

            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Primary == false)
                {
                    return screen;
                }
            }

            return null;
        }

        private void startGameBtn_Click(object sender, EventArgs e)
        {
            form1 = new mainLayout(this);
            form1.CsapatNevek = csapatNevek;
            form1.CsapatSzam = csapatSzam;
            if (Screen.AllScreens.Length > 1)
            {
                // Important !
                form1.StartPosition = FormStartPosition.Manual;

                // Get the second monitor screen
                Screen screen = GetSecondaryScreen();

                // set the location to the top left of the second screen
                form1.Location = screen.WorkingArea.Location;

                // set it fullscreen
                form1.Size = new Size(screen.WorkingArea.Width, screen.WorkingArea.Height);

                // Show the form
                form1.Show();
            }
            else if (Screen.AllScreens.Length == 1)
            {
                form1.Show();
            }

            startGameBtn.Enabled = false;
            startTurnBtn.Enabled = true;
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
            OkButton1.Enabled = false;
            okButton2.Enabled = false;
            AktualisCsapat1DomainUpDown.Enabled = false;
            AktualisCsapat2DomainUpDown.Enabled = false;
            bevitel = new Bevitel();
            StreamReader kerdesInput = new StreamReader(bevitel.KerdesekPath1);
            while(!kerdesInput.EndOfStream)
            {
                string[] beolvasott = kerdesInput.ReadLine().Split(';');
                kerdesek.Add(new Kerdes(beolvasott[1], beolvasott[2], beolvasott[3], beolvasott[4], beolvasott[5], Convert.ToInt32(beolvasott[0]) ));
                kerdesSzam++;
            }

            hatralevoKerdesekSzama = kerdesSzam;

            if (csapatSzam == 2)
            {
                lepesek = new int[] { 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0 };
            }

            else if (csapatSzam == 3)
            {
                lepesek = new int[] { 0, 1, 2, 0, 2, 1, 1, 0, 2, 1, 2, 0, 2, 0, 1, 2, 1, 0 };
            }

            else if (csapatSzam == 4)
            {
                lepesek = new int[] { 0, 1, 2, 3, 1, 3, 0, 2, 2, 0, 3, 1, 3, 2, 0, 1, 1, 2, 3, 0, 0, 3, 2, 1 };
            }

            else
            {
                label1.Text = "Valami baj van a rendszerben!";
            }

            bevitel = new Bevitel();
            StreamReader tippelosek = new StreamReader(bevitel.TippkerdesekPath1);
            
            while(!tippelosek.EndOfStream)
            {
                string[] beolv = tippelosek.ReadLine().Split(';');
                tippek.Add(new TippKerdes(beolv[1], Convert.ToInt32(beolv[0]), Convert.ToInt32(beolv[2])));
                tippkerdesSzam++;
            }

            korNyerteseLabel.Text = "";
        }

        private void startTurnBtn_Click(object sender, EventArgs e)
        {
            if (hatralevoKerdesekSzama > 0)
            {
                korNyerteseLabel.Text = "Aktuális csapat válaszon mezőt!";
                if (kForm != null)
                {
                    kForm.bezarhat = true;
                    kForm.Close();
                }
                if (tForm != null)
                {
                    tForm.bezarhat = true;
                    tForm.Close();
                }
                if (!isItValasztos)
                {
                    isItValasztos = true;
                }

                AktualisCsapat1GroupBox.Text = csapatNevek[lepesek[lepesekIndex]];
                form1.setNextTeamName(csapatNevek[lepesek[lepesekIndex]]);
                form1.Attack(lepesek[lepesekIndex]);
                hanyanValaszoltak = 0;
                hanytipp = 0;
                tippCsapat1.Visible = false;
                tippCsapat2.Visible = false;
                gyorsabb1CheckBox.Visible = false;
                gyorsabb2CheckBox.Visible = false;
                OKButton3.Visible = false;
                OKButton4.Visible = false;
                startTurnBtn.Enabled = false;
            }
            else
            {
                MessageBox.Show("Elfogytak a kérdések!");
            }
            
 
        }

        public void setSecondTeamLabel(int secNum)
        {
            if(secNum==4)
            {
                AktualisCsapat2GroupBox.Text = "Ezt a területet nem lehet választani";
            }
            else
            {
                vedoNum = secNum;
                AktualisCsapat2GroupBox.Text = csapatNevek[secNum];
                kForm = new Kerdesek();
                kForm.Show();
                stopperBtn.Enabled = true;
            }
        }

        public void getAttackedField(int x, int y, int value)
        {
            attackedX = x;
            attackedY = y;
            attackedValue = value;
        }

        private void stopperBtn_Click(object sender, EventArgs e)
        {
            korNyerteseLabel.Text = "Csapat adjon választ a kérdésre!";

            if (isItValasztos)
            {
                OkButton1.Enabled = true;
                okButton2.Enabled = true;
                AktualisCsapat1DomainUpDown.ResetText();
                AktualisCsapat2DomainUpDown.ResetText();
                AktualisCsapat1DomainUpDown.Enabled = true;
                AktualisCsapat2DomainUpDown.Enabled = true;
                stopperBtn.Enabled = false;
                Random kerdesRandom = new Random();
                int aktualisSzam = kerdesRandom.Next(0, kerdesSzam);
                Kerdes aktualisKerdes = kerdesek[aktualisSzam];
                kerdesek.RemoveAt(aktualisSzam);
                kerdesSzam--;
                String[] kerdesPasszolni = new string[5];
                kerdesPasszolni[0] = aktualisKerdes.getKerdes();

                Random random = new Random();
                joHelye = random.Next(0, 4);
                int rossz1Helye = (joHelye + 1) % 4;
                int rossz2Helye;
                if (rossz1Helye == 3)
                {
                    rossz2Helye = 0;
                }
                else
                {
                    rossz2Helye = rossz1Helye + 1;
                }
                int rossz3Helye = (joHelye + 3) % 4;

                kerdesPasszolni[joHelye + 1] = aktualisKerdes.getJoValasz();
                kerdesPasszolni[rossz1Helye + 1] = aktualisKerdes.getRossz1();
                kerdesPasszolni[rossz2Helye + 1] = aktualisKerdes.getRossz2();
                kerdesPasszolni[rossz3Helye + 1] = aktualisKerdes.getRossz3();

                switch (joHelye)
                {
                    case 0:
                        joValasz = "A";
                        break;
                    case 1:
                        joValasz = "B";
                        break;
                    case 2:
                        joValasz = "C";
                        break;
                    case 3:
                        joValasz = "D";
                        break;
                    default:
                        joValasz = "";
                        break;
                }

                kForm.KerdesTomb = kerdesPasszolni;
                kForm.setKerdesek();
                kerdesID.Text = aktualisKerdes.getID()+"";
                stopperStarter();
            }

            else
            {
                tippCsapat1.ResetText();
                tippCsapat2.ResetText();

                stopperBtn.Enabled = false;
                Random tippRandom = new Random();
                int aktualisTippSzam = tippRandom.Next(0, tippkerdesSzam);
                TippKerdes aktualisTippKerdes = tippek[aktualisTippSzam];
                tippek.RemoveAt(aktualisTippSzam);
                tippkerdesSzam--;
                kerdesID.Text = aktualisTippKerdes.getID() + "";
                tForm.setKerdes(aktualisTippKerdes.getKerdes(), aktualisTippKerdes.getValasz());
                joTipp = aktualisTippKerdes.getValasz();
                stopperStarter();
            }
        }

        private string tamadoValasz="";
        private string vedoValasz="";
        private int hanyanValaszoltak = 0;
        private void OkButton1_Click(object sender, EventArgs e)
        {
            if (AktualisCsapat1DomainUpDown.Text != "")
            {
                tamadoValasz = AktualisCsapat1DomainUpDown.SelectedItem.ToString();
                hanyanValaszoltak++;
                OkButton1.Enabled = false;
                AktualisCsapat1DomainUpDown.Enabled = false;
                if (hanyanValaszoltak == 2)
                {
                    checkAnswers();
                }
            }
            else
            {
                MessageBox.Show("üres");
            }
        }

        private void okButton2_Click(object sender, EventArgs e)
        {
            if (AktualisCsapat2DomainUpDown.Text != "")
            {
                vedoValasz = AktualisCsapat2DomainUpDown.SelectedItem.ToString();
                hanyanValaszoltak++;
                okButton2.Enabled = false;
                if (hanyanValaszoltak == 2)
                {
                    //ide az összehasonlítás függvény
                    checkAnswers();
                }
            }
            else
            {
                MessageBox.Show("üres");
            }
        }

        private void checkAnswers()
        {
            stopperStop();
            hatralevoKerdesekSzama--;

            OkButton1.Enabled = false;
            okButton2.Enabled = false;
            AktualisCsapat1DomainUpDown.Enabled = false;
            AktualisCsapat2DomainUpDown.Enabled = false;

            if (vedoValasz==tamadoValasz)
            {
                if (vedoValasz==joValasz)
                {
                    //indítson egy tippelőset
                    startTippelosKerdes();
                }
                else
                {
                    //ne adjon pontot 
                    kForm.setBGColor(joHelye);
                    korNyerteseLabel.Text = "Senki";
                    lepesekIndex++;

                    startTurnBtn.Enabled = true;
                    stopperBtn.Enabled = false;
                }
            }
            else if(vedoValasz==joValasz)
            {
                form1.setTeamPoints(vedoNum, 100);
                kForm.setBGColor(joHelye);
                korNyerteseLabel.Text = csapatNevek[vedoNum];
                lepesekIndex++;
                startTurnBtn.Enabled = true;
                stopperBtn.Enabled = false;
            }
            else if(tamadoValasz==joValasz)
            {
                form1.setTeamPoints(lepesek[lepesekIndex], attackedValue);
                form1.setTeamPoints(vedoNum, -attackedValue);
                form1.changeTerulet(attackedX, attackedY, lepesek[lepesekIndex], attackedValue);
                kForm.setBGColor(joHelye);
                korNyerteseLabel.Text = csapatNevek[lepesek[lepesekIndex]];
                lepesekIndex++;
                
                startTurnBtn.Enabled = true;
                stopperBtn.Enabled = false;
                //a támadó kapja meg a területet
                //a támadó kapja meg a pontot
                //a védő veszítse el a pontot
            }
            else
            {
                //senki nem kap semmit
                kForm.setBGColor(joHelye);
                korNyerteseLabel.Text = "Senki";
                lepesekIndex++;

                startTurnBtn.Enabled = true;
                stopperBtn.Enabled = false;
            }

        }
        
        private void startTippelosKerdes()
        {
            kForm.bezarhat = true;
            kForm.Close();

            stopperStop();
            
            OKButton4.Enabled = true;
            OKButton3.Enabled = true;
            OkButton1.Enabled = false;
            okButton2.Enabled = false;
            
            AktualisCsapat1DomainUpDown.Enabled = false;
            AktualisCsapat2DomainUpDown.Enabled = false;

            tForm = new Tippelos();
            tForm.Show();
            isItValasztos = false;
            tippCsapat1.Visible = true;
            tippCsapat2.Visible = true;
            gyorsabb1CheckBox.Visible = true;
            gyorsabb2CheckBox.Visible = true;
            OKButton3.Visible = true;
            OKButton4.Visible = true;
            stopperBtn.Enabled = true;
            
        }
        private int attackerTipp;
        private int defenderTipp;
        private int hanytipp = 0;
        private void OKButton3_Click(object sender, EventArgs e)
        {
            if (tippCsapat1.Text != "")
            {
                attackerTipp = Convert.ToInt32(tippCsapat1.Text);
                OKButton3.Enabled = false;
                hanytipp++;
                if (hanytipp == 2)
                {
                    checkTippek();
                }
            }
            else
            {
                MessageBox.Show("üres");
            }
        }

        private void OKButton4_Click(object sender, EventArgs e)
        {
            if (tippCsapat2.Text != "")
            {
                defenderTipp = Convert.ToInt32(tippCsapat2.Text);
                OKButton4.Enabled = false;
                hanytipp++;
                if (hanytipp == 2)
                {
                    checkTippek();
                }
            }
            else
            {
                MessageBox.Show("üres");
            }
        }

        private void checkTippek()
        {
            stopperStop();

            int abs1 = (int)Math.Abs(joTipp - attackerTipp);
            int abs2 = (int)Math.Abs(joTipp - defenderTipp);
            if (abs1==abs2)
            {
                if (gyorsabb1CheckBox.Checked)
                {
                    form1.setTeamPoints(lepesek[lepesekIndex], attackedValue);
                    form1.setTeamPoints(vedoNum, -attackedValue);
                    form1.changeTerulet(attackedX, attackedY, lepesek[lepesekIndex], attackedValue);
                    tForm.displayHelyesValasz();
                    korNyerteseLabel.Text = csapatNevek[lepesek[lepesekIndex]];
                    lepesekIndex++;
                    startTurnBtn.Enabled = true;
                    stopperBtn.Enabled = false;
                }
                else if(gyorsabb2CheckBox.Checked)
                {
                    form1.setTeamPoints(vedoNum, 100);
                    tForm.displayHelyesValasz();
                    korNyerteseLabel.Text = csapatNevek[vedoNum];
                    lepesekIndex++;
                    startTurnBtn.Enabled = true;
                    stopperBtn.Enabled = false;
                }
            }
            else
            {
                if(abs1<abs2)
                {
                    form1.setTeamPoints(lepesek[lepesekIndex], attackedValue);
                    form1.setTeamPoints(vedoNum, -attackedValue);
                    form1.changeTerulet(attackedX, attackedY, lepesek[lepesekIndex], attackedValue);
                    tForm.displayHelyesValasz();
                    korNyerteseLabel.Text = csapatNevek[lepesek[lepesekIndex]];
                    lepesekIndex++;
                    startTurnBtn.Enabled = true;
                    stopperBtn.Enabled = false;
                }
                else
                {
                    form1.setTeamPoints(vedoNum, 100);
                    tForm.displayHelyesValasz();
                    korNyerteseLabel.Text = csapatNevek[vedoNum];
                    lepesekIndex++;
                    startTurnBtn.Enabled = true;
                    stopperBtn.Enabled = false;
                }
            }
        }

        private void ControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stopwatch.Stop();
            MessageBox.Show("Amig fut a játék addig ne csukj be!");
            Stopwatch.Start();
            e.Cancel = true;
        }
    }

    public class Kerdes
    {
        private string kerdes;
        private string joValasz;
        private string rosszValasz1;
        private string rosszValasz2;
        private string rosszValasz3;
        private int kerdesID;

        public Kerdes(string kerdes, string jovalasz, string rossz1, string rossz2, string rossz3, int id)
        {
            this.kerdes = kerdes;
            this.joValasz = jovalasz;
            this.rosszValasz1 = rossz1;
            this.rosszValasz2 = rossz2;
            this.rosszValasz3 = rossz3;
            this.kerdesID = id;
        }

        public string getKerdes()
        {
            return this.kerdes;
        }

        public string getJoValasz()
        {
            return this.joValasz;
        }

        public string getRossz1()
        {
            return this.rosszValasz1;
        }

        public string getRossz2()
        {
            return this.rosszValasz2;
        }

        public string getRossz3()
        {
            return this.rosszValasz3;
        }

        public int getID()
        {
            return this.kerdesID;
        }

    }

    public class TippKerdes
    {
        private string kerdes;
        private int kerdesID;
        private int valasz;

        public TippKerdes(string reqkerdes, int id, int reqvalasz)
        {
            kerdes = reqkerdes;
            kerdesID = id;
            valasz = reqvalasz;
        }
        public int getID()
        {
            return this.kerdesID;
        }
        public int getValasz()
        {
            return this.valasz;
        }

        public string getKerdes()
        {
            return this.kerdes;
        }
    }
 }