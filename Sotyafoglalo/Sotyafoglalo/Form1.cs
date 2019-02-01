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
    public partial class mainLayout : Form
    {
        private int csapatSzam;
        private string[] csapatNevek = new string[4];
        private bool isItTurn = false;
        private ControlForm controlForm = new ControlForm();
        private ControlForm cForm = null;
        
        public mainLayout()
        {
            InitializeComponent();
        }

        public mainLayout(Form callingForm)
        {
            cForm = callingForm as ControlForm;
            InitializeComponent();
        }

        public int CsapatSzam { get => csapatSzam; set => csapatSzam = value; }
        public string[] CsapatNevek { get => csapatNevek; set => csapatNevek = value; }
        
        
        private List<GroupBox> groups = new List<GroupBox>();
        private Cell[,] cells = new Cell[6, 6];
        private int attackingTeamNumber;
        private List<Label> pontok = new List<Label>();

        
        private void Form1_Load(object sender, EventArgs e)
        {
            pontok.Add(pointDisplay1);
            pontok.Add(pointDisplay2);
            pontok.Add(pointDisplay3);
            pontok.Add(pointDisplay4);
            groups.Add(team1Box);
            groups.Add(team2Box);
            groups.Add(team3Box);
            groups.Add(team4Box);
            for (int i = 0; i < csapatSzam; i++)
            {
                groups[i].Text = csapatNevek[i];
            }
            for (int i = csapatSzam; i < 4; i++)
            {
                groups[i].Visible = false;
            }

            if (csapatSzam == 4)
            {
                //TEAM 1
                cells[0, 0] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox1, Cell.OUTER_FIELD_VALUE);
                cells[0, 1] = new Cell(Cell.FORTRESS_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox2, Cell.FORTRESS_FIELD_VALUE);
                cells[0, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox3, Cell.OUTER_FIELD_VALUE);
                cells[1, 0] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox7, Cell.OUTER_FIELD_VALUE);
                cells[1, 1] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox8, Cell.INNER_FIELD_VALUE);
                cells[1, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox9, Cell.INNER_FIELD_VALUE);
                cells[2, 0] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox13, Cell.OUTER_FIELD_VALUE);
                cells[2, 1] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox14, Cell.INNER_FIELD_VALUE);
                cells[2, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox15, Cell.INNER_FIELD_VALUE);

                //TEAM 2
                cells[3, 0] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox19, Cell.OUTER_FIELD_VALUE);
                cells[3, 1] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox20, Cell.INNER_FIELD_VALUE);
                cells[3, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox21, Cell.INNER_FIELD_VALUE);
                cells[4, 0] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox25, Cell.OUTER_FIELD_VALUE);
                cells[4, 1] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox26, Cell.INNER_FIELD_VALUE);
                cells[4, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox27, Cell.INNER_FIELD_VALUE);
                cells[5, 0] = new Cell(Cell.FORTRESS_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox31, Cell.FORTRESS_FIELD_VALUE);
                cells[5, 1] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox32, Cell.OUTER_FIELD_VALUE);
                cells[5, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox33, Cell.OUTER_FIELD_VALUE);


                //TEAM 3
                cells[3, 3] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox22, Cell.INNER_FIELD_VALUE);
                cells[3, 4] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox23, Cell.INNER_FIELD_VALUE);
                cells[3, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox24, Cell.OUTER_FIELD_VALUE);
                cells[4, 3] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox28, Cell.INNER_FIELD_VALUE);
                cells[4, 4] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox29, Cell.INNER_FIELD_VALUE);
                cells[4, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox30, Cell.OUTER_FIELD_VALUE);
                cells[5, 3] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox34, Cell.OUTER_FIELD_VALUE);
                cells[5, 4] = new Cell(Cell.FORTRESS_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox35, Cell.FORTRESS_FIELD_VALUE);
                cells[5, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox36, Cell.OUTER_FIELD_VALUE);

                //TEAM 4
                cells[0, 3] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_4, pictureBox4, Cell.OUTER_FIELD_VALUE);
                cells[0, 4] = new Cell(Cell.FORTRESS_FIELD, Cell.OCCUPIED_BY_TEAM_4, pictureBox5, Cell.FORTRESS_FIELD_VALUE);
                cells[0, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_4, pictureBox6, Cell.OUTER_FIELD_VALUE);
                cells[1, 3] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_4, pictureBox10, Cell.INNER_FIELD_VALUE);
                cells[1, 4] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_4, pictureBox11, Cell.INNER_FIELD_VALUE);
                cells[1, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_4, pictureBox12, Cell.OUTER_FIELD_VALUE);
                cells[2, 3] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_4, pictureBox16, Cell.INNER_FIELD_VALUE);
                cells[2, 4] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_4, pictureBox17, Cell.INNER_FIELD_VALUE);
                cells[2, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_4, pictureBox18, Cell.OUTER_FIELD_VALUE);
                for (int i = 0; i < 4; i++)
                {
                    setTeamPoints(i, 2800);
                }

            }
            else if(csapatSzam==3)
            {
                //TEAM 1
                cells[0, 0] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox1, Cell.OUTER_FIELD_VALUE);
                cells[0, 1] = new Cell(Cell.FORTRESS_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox2, Cell.FORTRESS_FIELD_VALUE);
                cells[0, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox3, Cell.OUTER_FIELD_VALUE);
                cells[0, 3] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox4, Cell.OUTER_FIELD_VALUE);
                cells[0, 3].getPBox().Image = Properties.Resources.kek400;
                cells[1, 0] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox7, Cell.OUTER_FIELD_VALUE);
                cells[1, 1] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox8, Cell.INNER_FIELD_VALUE);
                cells[1, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox9, Cell.INNER_FIELD_VALUE);
                cells[1, 3] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox10, Cell.OUTER_FIELD_VALUE);
                cells[1, 3].getPBox().Image = Properties.Resources.kek400;
                cells[2, 0] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox13, Cell.OUTER_FIELD_VALUE);
                cells[2, 1] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox14, Cell.INNER_FIELD_VALUE);
                cells[2, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox15, Cell.INNER_FIELD_VALUE);
                cells[2, 3] = new Cell(Cell.OUTER_FIELD_VALUE, Cell.OCCUPIED_BY_TEAM_1, pictureBox16, Cell.INNER_FIELD_VALUE);
                cells[2, 3].getPBox().Image = Properties.Resources.kek400;

                //TEAM 2
                cells[3, 0] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox19, Cell.OUTER_FIELD_VALUE);
                cells[3, 1] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox20, Cell.INNER_FIELD_VALUE);
                cells[3, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox21, Cell.INNER_FIELD_VALUE);
                cells[3, 3] = new Cell(Cell.OUTER_FIELD_VALUE, Cell.OCCUPIED_BY_TEAM_2, pictureBox22, Cell.INNER_FIELD_VALUE);
                cells[3, 3].getPBox().Image = Properties.Resources.piros400;
                cells[4, 0] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox25, Cell.OUTER_FIELD_VALUE);
                cells[4, 1] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox26, Cell.INNER_FIELD_VALUE);
                cells[4, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox27, Cell.INNER_FIELD_VALUE);
                cells[4, 3] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox28, Cell.OUTER_FIELD_VALUE);
                cells[4, 3].getPBox().Image = Properties.Resources.piros400;
                cells[5, 0] = new Cell(Cell.FORTRESS_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox31, Cell.FORTRESS_FIELD_VALUE);
                cells[5, 1] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox32, Cell.OUTER_FIELD_VALUE);
                cells[5, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox33, Cell.OUTER_FIELD_VALUE);
                cells[5, 3] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox34, Cell.OUTER_FIELD_VALUE);
                cells[5, 3].getPBox().Image = Properties.Resources.piros400;

                //TEAM 3
                cells[0, 4] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox5, Cell.OUTER_FIELD_VALUE);
                cells[0, 4].getPBox().Image = Properties.Resources.rozsa400;
                cells[0, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox6, Cell.OUTER_FIELD_VALUE);
                cells[0, 5].getPBox().Image = Properties.Resources.rozsa400;
                cells[1, 4] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox11, Cell.INNER_FIELD_VALUE);
                cells[1, 4].getPBox().Image = Properties.Resources.rozsa300;
                cells[1, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox12, Cell.OUTER_FIELD_VALUE);
                cells[1, 5].getPBox().Image = Properties.Resources.rozsa400;
                cells[2, 4] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox17, Cell.INNER_FIELD_VALUE);
                cells[2, 4].getPBox().Image = Properties.Resources.rozsa300;
                cells[2, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox18, Cell.OUTER_FIELD_VALUE);
                cells[2, 5].getPBox().Image = Properties.Resources.rozsa400;

                cells[3, 4] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox23, Cell.INNER_FIELD_VALUE);
                cells[3, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox24, Cell.OUTER_FIELD_VALUE);
                cells[4, 4] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox29, Cell.INNER_FIELD_VALUE);
                cells[4, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox30, Cell.OUTER_FIELD_VALUE); 
                cells[5, 4] = new Cell(Cell.FORTRESS_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox35, Cell.FORTRESS_FIELD_VALUE);
                cells[5, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_3, pictureBox36, Cell.OUTER_FIELD_VALUE);

                for (int i = 0; i < 3; i++)
                {
                    setTeamPoints(i, 4000);
                }


            }
            else if(csapatSzam==2)
            {
                //TEAM 1
                cells[0, 0] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox1, Cell.OUTER_FIELD_VALUE);
                cells[0, 1] = new Cell(Cell.FORTRESS_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox2, Cell.FORTRESS_FIELD_VALUE);
                cells[0, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox3, Cell.OUTER_FIELD_VALUE);

                cells[0, 3] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox4, Cell.OUTER_FIELD_VALUE);
                cells[0, 3].getPBox().Image = Properties.Resources.kek400;
                cells[0, 4] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox5, Cell.OUTER_FIELD_VALUE);
                cells[0, 4].getPBox().Image = Properties.Resources.kek400;
                cells[0, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox6, Cell.OUTER_FIELD_VALUE);
                cells[0, 5].getPBox().Image = Properties.Resources.kek400;

                cells[1, 0] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox7, Cell.OUTER_FIELD_VALUE);
                cells[1, 1] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox8, Cell.INNER_FIELD_VALUE);
                cells[1, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox9, Cell.INNER_FIELD_VALUE);

                cells[1, 3] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox10, Cell.INNER_FIELD_VALUE);
                cells[1, 3].getPBox().Image = Properties.Resources.kek300;
                cells[1, 4] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox11, Cell.INNER_FIELD_VALUE);
                cells[1, 4].getPBox().Image = Properties.Resources.kek300;
                cells[1, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox12, Cell.OUTER_FIELD_VALUE);
                cells[1, 5].getPBox().Image = Properties.Resources.kek400;

                cells[2, 0] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox13, Cell.OUTER_FIELD_VALUE);
                cells[2, 1] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox14, Cell.INNER_FIELD_VALUE);
                cells[2, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox15, Cell.INNER_FIELD_VALUE);

                cells[2, 3] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox16, Cell.INNER_FIELD_VALUE);
                cells[2, 3].getPBox().Image = Properties.Resources.kek300;
                cells[2, 4] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox17, Cell.INNER_FIELD_VALUE);
                cells[2, 4].getPBox().Image = Properties.Resources.kek300;
                cells[2, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_1, pictureBox18, Cell.OUTER_FIELD_VALUE);
                cells[2, 5].getPBox().Image = Properties.Resources.kek400;

                //TEAM 2
                cells[3, 0] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox19, Cell.OUTER_FIELD_VALUE);
                cells[3, 1] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox20, Cell.INNER_FIELD_VALUE);
                cells[3, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox21, Cell.INNER_FIELD_VALUE);

                cells[3, 3] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox22, Cell.INNER_FIELD_VALUE);
                cells[3, 3].getPBox().Image = Properties.Resources.piros300;
                cells[3, 4] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox23, Cell.INNER_FIELD_VALUE);
                cells[3, 4].getPBox().Image = Properties.Resources.piros300;
                cells[3, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox24, Cell.OUTER_FIELD_VALUE);
                cells[3, 5].getPBox().Image = Properties.Resources.piros400;

                cells[4, 0] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox25, Cell.OUTER_FIELD_VALUE);
                cells[4, 1] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox26, Cell.INNER_FIELD_VALUE);
                cells[4, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox27, Cell.INNER_FIELD_VALUE);

                cells[4, 3] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox28, Cell.INNER_FIELD_VALUE);
                cells[4, 3].getPBox().Image = Properties.Resources.piros300;
                cells[4, 4] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox29, Cell.INNER_FIELD_VALUE);
                cells[4, 4].getPBox().Image = Properties.Resources.piros300;
                cells[4, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox30, Cell.OUTER_FIELD_VALUE);
                cells[4, 5].getPBox().Image = Properties.Resources.piros400;

                cells[5, 0] = new Cell(Cell.FORTRESS_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox31, Cell.FORTRESS_FIELD_VALUE);
                cells[5, 1] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox32, Cell.OUTER_FIELD_VALUE);
                cells[5, 2] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox33, Cell.OUTER_FIELD_VALUE);

                cells[5, 3] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox34, Cell.OUTER_FIELD_VALUE);
                cells[5, 3].getPBox().Image = Properties.Resources.piros400;
                cells[5, 4] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox35, Cell.OUTER_FIELD_VALUE);
                cells[5, 4].getPBox().Image = Properties.Resources.piros400;
                cells[5, 5] = new Cell(Cell.REGULAR_FIELD, Cell.OCCUPIED_BY_TEAM_2, pictureBox36, Cell.OUTER_FIELD_VALUE);
                cells[5, 5].getPBox().Image = Properties.Resources.piros400;


                for (int i = 0; i < 2; i++)
                {
                    setTeamPoints(i, 5600);
                }
            }
        }

        private void mainLayout_FormClosed(object sender, FormClosedEventArgs e)
        {
            Bevitel obj = (Bevitel)Application.OpenForms["Bevitel"];
            obj.Close();
        }

        public void setNextTeamName (string nev)
        {
            nextTeamLabel.Text = nev;
        }

        void AttackField(int xCoordinate, int yCoordinate, int fieldOwner, int fieldValue)
        {
            if (attackingTeamNumber!=fieldOwner && isItTurn)
            {
                if(fieldValue!= Cell.FORTRESS_FIELD_VALUE)
                {
                    if (xCoordinate == 0 && yCoordinate == 0)
                    {
                        if (cells[1, 0].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                        }
                        else if (cells[0, 1].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                        }
                    }

                    else if (xCoordinate == 5 && yCoordinate == 0)
                    {
                        if (cells[4, 0].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                        }
                        else if (cells[5, 1].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                        }
                    }

                    else if (xCoordinate == 0 && yCoordinate == 5)
                    {
                        if (cells[0, 4].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                        }
                        else if (cells[1, 5].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                        }
                    }

                    else if (xCoordinate == 5 && yCoordinate == 5)
                    {
                        if (cells[4, 5].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                        }
                        else if (cells[5, 4].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                        }
                    }
                    else if (xCoordinate == 0)
                    {
                        if (cells[xCoordinate + 1, yCoordinate].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                            //ask question here
                        }
                        else if (cells[xCoordinate, yCoordinate - 1].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                            //ask question here
                        }
                        else if (cells[xCoordinate, yCoordinate + 1].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                            //ask question here
                        }

                    }

                    else if (xCoordinate == 5)
                    {
                        if (cells[xCoordinate - 1, yCoordinate].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                            //ask question here
                        }
                        else if (cells[xCoordinate, yCoordinate - 1].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                            //ask question here
                        }
                        else if (cells[xCoordinate, yCoordinate + 1].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                            //ask question here
                        }

                    }

                    else if (yCoordinate == 0)
                    {
                        if (cells[xCoordinate + 1, yCoordinate].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                            //ask question here
                        }
                        else if (cells[xCoordinate - 1, yCoordinate].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                            //ask question here
                        }
                        else if (cells[xCoordinate, yCoordinate + 1].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                            //ask question here
                        }

                    }

                    else if (yCoordinate == 5)
                    {
                        if (cells[xCoordinate + 1, yCoordinate].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                            //ask question here
                        }
                        else if (cells[xCoordinate - 1, yCoordinate].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                            //ask question here
                        }
                        else if (cells[xCoordinate, yCoordinate - 1].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                            //ask question here
                        }


                    }

                    else if (xCoordinate > 0 && xCoordinate < 5 && yCoordinate > 0 && yCoordinate < 5)
                    {
                        if (cells[xCoordinate - 1, yCoordinate].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                            //ask questin here
                        }
                        else if (cells[xCoordinate + 1, yCoordinate].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                            //ask question here
                        }
                        else if (cells[xCoordinate, yCoordinate - 1].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                            //ask question here
                        }
                        else if (cells[xCoordinate, yCoordinate + 1].getFieldOwner() == attackingTeamNumber)
                        {
                            cForm.setSecondTeamLabel(fieldOwner);
                            isItTurn = false;
                            cForm.getAttackedField(xCoordinate, yCoordinate, fieldValue);
                            //ask question here
                        }
                        else
                        {
                            cForm.setSecondTeamLabel(4);
                        }
                    }
                    else
                    {
                        cForm.setSecondTeamLabel(4);
                    }
                }
            }
        }

        public void Attack(int attackingNumber)
        {
            attackingTeamNumber = attackingNumber;
            isItTurn = true;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    int fOwner = cells[i, j].getFieldOwner();
                    int x = i;
                    int y = j;
                    int val = cells[i, j].getValue();
                    cells[i, j].getPBox().Click += delegate { AttackField(x, y, fOwner, val); };
                }
            }

        }
        private int[] csapatPontok = new int[4];
        public void setTeamPoints(int teamNumber, int pointsToIncrease)
        {
            csapatPontok[teamNumber] += pointsToIncrease;
            pontok[teamNumber].Text = csapatPontok[teamNumber]+"";
        }

        public void changeTerulet(int x, int y, int ujTulaj, int ertek)
        {
            cells[x, y].changeFieldOwner(ujTulaj);
            string firstHalfOfPicutre = "";
            string secondHalfOfPicture = "";
            switch (ujTulaj)
            {
                case 0:
                    firstHalfOfPicutre = "kek";
                    break;
                case 1:
                    firstHalfOfPicutre = "piros";
                    break;
                case 2:
                    firstHalfOfPicutre = "rozsa";
                    break;
                case 3:
                    firstHalfOfPicutre = "sarga";
                    break;
                default:
                    firstHalfOfPicutre = "";
                    break;
            }
            switch (ertek)
            {
                case 0:
                    secondHalfOfPicture = "Var";
                    break;
                case 300:
                    secondHalfOfPicture = "300";
                    break;
                case 400:
                    secondHalfOfPicture = "400";
                    break;
                default:
                    secondHalfOfPicture = "";
                    break;
            }
            string kepID = firstHalfOfPicutre + secondHalfOfPicture;
            cells[x,y].getPBox().Image = (Image)Properties.Resources.ResourceManager.GetObject(kepID);
            cells[x, y].getPBox().Refresh();

        }

    }

    public class Cell
    {
        
        public static readonly int OCCUPIED_BY_TEAM_1 = 0;
        public static readonly int OCCUPIED_BY_TEAM_2 = 1;
        public static readonly int OCCUPIED_BY_TEAM_3 = 2;
        public static readonly int OCCUPIED_BY_TEAM_4 = 3;
        public static readonly int FORTRESS_FIELD = 5;
        public static readonly int REGULAR_FIELD = 6;
        public static readonly int FORTRESS_FIELD_VALUE = 0;
        public static readonly int INNER_FIELD_VALUE = 300;
        public static readonly int OUTER_FIELD_VALUE = 400;
        private PictureBox picBoxRef;
        private readonly int type;
        private int fieldOwner;
        private int valueOfField;
        public Cell(int requiredType, int requiredfieldOwner, PictureBox picBox, int valueOfField)
        {
            this.type = requiredType;
            this.fieldOwner = requiredfieldOwner;
            this.picBoxRef = picBox;
            this.valueOfField = valueOfField;
        }

        public int getType()
        {
            return type;
        }

        public int getFieldOwner()
        {
            return fieldOwner;
        }

        public void changeFieldOwner(int requiredFieldOwner)
        {
            fieldOwner = requiredFieldOwner;
        }
        public int getValue()
        {
            return valueOfField;
        }

        public PictureBox getPBox()
        {
            return picBoxRef;
        }

    }//cell
}
