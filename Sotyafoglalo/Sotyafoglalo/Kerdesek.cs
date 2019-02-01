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
    public partial class Kerdesek : Form
    {
        private string[] kerdesTomb = new string[5];
        private string[] labelek = new string[] { "A", "B", "C", "D" };
        private List<Label> valaszHelyek = new List<Label>();
        public Boolean bezarhat = false;

        public Kerdesek()
        {
            InitializeComponent();
        }
        public string[] KerdesTomb { get => kerdesTomb; set => kerdesTomb = value; }

        private void Kerdesek_Load(object sender, EventArgs e)
        {
            bezarhat = false;

            valaszHelyek.Add(aValasz);
            valaszHelyek.Add(bValasz);
            valaszHelyek.Add(cValasz);
            valaszHelyek.Add(dValasz);
        }
        public void setKerdesek()
        {
            kerdesLabel.Text = kerdesTomb[0];
            for (int i = 0; i < 4; i++)
            {
                valaszHelyek[i].Text = labelek[i] + ": " + kerdesTomb[i+1];
            }
            
        }
        public void setBGColor(int rowNum)
        {
            valaszHelyek[rowNum].BackColor = Color.Green;
        }

        private void Kerdesek_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!bezarhat)
            {
                if (MessageBox.Show("Biztosan bezárod a kérdéseket?", "Bezárás", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    this.Activate();
                }
            }
        }
    }
}
