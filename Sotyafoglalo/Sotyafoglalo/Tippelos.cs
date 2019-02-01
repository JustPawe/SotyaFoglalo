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
    public partial class Tippelos : Form
    {
        private int helyesValasz;
        public Boolean bezarhat = false;

        public Tippelos()
        {
            InitializeComponent();
        }

        public void setKerdes(string kerdes, int reqhelyesValasz)
        {
            label1.Text = kerdes;
            helyesValasz = reqhelyesValasz;
        }

        public void displayHelyesValasz()
        {
            label2.Text = helyesValasz + "";
            label2.BackColor = Color.Green;
        }

        private void Tippelos_FormClosing(object sender, FormClosingEventArgs e)
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
