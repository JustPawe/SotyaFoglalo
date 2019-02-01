using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sotyafoglalo
{
    public partial class Kerdes : Form
    {
        private string[] kerdesTomb = new string[5];
        private List<Label> valaszHelyek = new List<Label>();
        public Kerdes()
        {
            InitializeComponent();
        }

        public string[] KerdesTomb { get => kerdesTomb; set => kerdesTomb = value; }

        private void Kerdes_Load(object sender, EventArgs e)
        {
            valaszHelyek.Add(aValasz);
            valaszHelyek.Add(bValasz);
            valaszHelyek.Add(cValasz);
            valaszHelyek.Add(dValasz);

            Random random = new Random();
            kerdesLabel.Text = kerdesTomb[0];
            int joHelye = random.Next(0,4);
            int rossz1Helye = (joHelye + 1) % 4;
            int rossz2Helye;
            if(rossz1Helye==3)
            {
                rossz2Helye = 0;
            }
            else
            {
                rossz2Helye = rossz1Helye + 1;
            }
            int rossz3Helye = (joHelye + 3) % 4;

            valaszHelyek[joHelye].Text = kerdesTomb[1];
            valaszHelyek[rossz1Helye].Text = kerdesTomb[2];
            valaszHelyek[rossz2Helye].Text = kerdesTomb[3];
            valaszHelyek[rossz3Helye].Text = kerdesTomb[4];

        }
    }
}
