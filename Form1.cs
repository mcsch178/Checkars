using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

namespace Checkers
{
    public partial class Board : Form
    {
        bool turn = true; 
        int turncount = 0;
        static String player1initial;
        static String player2initial;
        Player p1 = new Player();
        Player p2 = new Player();
        Grid[,] buttons = new Grid[8, 8];

        private Grid selectedbutton;
        private Grid MoveTobutton;

        private char PlayerMark = 'b';

        public Board()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            P1NameLabel.Text = player1initial;
            P2NameLabel.Text = player2initial;
            p1.GetPlayerName = player1initial;
            p2.GetPlayerName = player2initial;
            p1.GetPlayerWinCount = 0;
            p2.GetPlayerWinCount = 0;

        }

        public static void SetNames(String n1, String n2)
        {
            player1initial = n1;
            player2initial = n2;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            buttons[0, 0] = new Grid(A1, 'b', 1);
            buttons[0, 1] = new Grid(B1, ' ', 2);
            buttons[0, 2] = new Grid(C1, 'b', 3);
            buttons[0, 3] = new Grid(D1, ' ', 4);
            buttons[0, 4] = new Grid(E1, 'b', 5);
            buttons[0, 5] = new Grid(F1, ' ', 6);
            buttons[0, 6] = new Grid(G1, 'b', 7);
            buttons[0, 7] = new Grid(H1, ' ', 8);
            buttons[1, 0] = new Grid(A2, ' ', 9);
            buttons[1, 1] = new Grid(B2, 'b', 10);
            buttons[1, 2] = new Grid(C2, ' ', 11);
            buttons[1, 3] = new Grid(D2, 'b', 12);
            buttons[1, 4] = new Grid(E2, ' ', 13);
            buttons[1, 5] = new Grid(F2, 'b', 14);
            buttons[1, 6] = new Grid(G2, ' ', 15);
            buttons[1, 7] = new Grid(H2, 'b', 16);
            buttons[2, 0] = new Grid(A3, 'b', 17);
            buttons[2, 1] = new Grid(B3, ' ', 18);
            buttons[2, 2] = new Grid(C3, 'b', 19);
            buttons[2, 3] = new Grid(D3, ' ', 20);
            buttons[2, 4] = new Grid(E3, 'b', 21);
            buttons[2, 5] = new Grid(F3, ' ', 22);
            buttons[2, 6] = new Grid(G3, 'b', 23);
            buttons[2, 7] = new Grid(H3, ' ', 24);
            buttons[3, 0] = new Grid(A4, ' ', 25);
            buttons[3, 1] = new Grid(B4, ' ', 26);
            buttons[3, 2] = new Grid(C4, ' ', 27);
            buttons[3, 3] = new Grid(D4, ' ', 28);
            buttons[3, 4] = new Grid(E4, ' ', 29);
            buttons[3, 5] = new Grid(F4, ' ', 30);
            buttons[3, 6] = new Grid(G4, ' ', 31);
            buttons[3, 7] = new Grid(H4, ' ', 32);
            buttons[4, 0] = new Grid(A5, ' ', 33);
            buttons[4, 1] = new Grid(B5, ' ', 34);
            buttons[4, 2] = new Grid(C5, ' ', 35);
            buttons[4, 3] = new Grid(D5, ' ', 36);
            buttons[4, 4] = new Grid(E5, ' ', 37);
            buttons[4, 5] = new Grid(F5, ' ', 38);
            buttons[4, 6] = new Grid(G5, ' ', 39);
            buttons[4, 7] = new Grid(H5, ' ', 40);
            buttons[5, 0] = new Grid(A6, ' ', 41);
            buttons[5, 1] = new Grid(B6, 'r', 42);
            buttons[5, 2] = new Grid(C6, ' ', 43);
            buttons[5, 3] = new Grid(D6, 'r', 44);
            buttons[5, 4] = new Grid(E6, ' ', 45);
            buttons[5, 5] = new Grid(F6, 'r', 46);
            buttons[5, 6] = new Grid(G6, ' ', 47);
            buttons[5, 7] = new Grid(H6, 'r', 48);
            buttons[6, 0] = new Grid(A7, 'r', 49);
            buttons[6, 1] = new Grid(B7, ' ', 50);
            buttons[6, 2] = new Grid(C7, 'r', 51);
            buttons[6, 3] = new Grid(D7, ' ', 52);
            buttons[6, 4] = new Grid(E7, 'r', 53);
            buttons[6, 5] = new Grid(F7, ' ', 54);
            buttons[6, 6] = new Grid(G7, 'r', 55);
            buttons[6, 7] = new Grid(H7, ' ', 56);
            buttons[7, 0] = new Grid(A8, ' ', 57);
            buttons[7, 1] = new Grid(B8, 'r', 58);
            buttons[7, 2] = new Grid(C8, ' ', 59);
            buttons[7, 3] = new Grid(D8, 'r', 60);
            buttons[7, 4] = new Grid(E8, ' ', 61);
            buttons[7, 5] = new Grid(F8, 'r', 62);
            buttons[7, 6] = new Grid(G8, ' ', 63);
            buttons[7, 7] = new Grid(H8, 'r', 64);

            FillGrid();
            
            checkcurrentplayer();
        }

        private void FillGrid()
        {
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        buttons[i, j].GetButton.Click += new System.EventHandler(Button_Click);

                        if (buttons[i, j].getmark == 'r')
                        {
                            buttons[i, j].GetButton.Image = Checkers.Properties.Resources.Red;
                        }

                        else if (buttons[i, j].getmark == 'b')
                        {
                            buttons[i, j].GetButton.Image = Checkers.Properties.Resources.Black;
                        }
                        else if (buttons[i, j].GetButton.BackColor == Color.Black)
                        {
                            buttons[i, j].GetButton.Enabled = false;
                        }
                        else
                        {
                            buttons[i, j].GetButton.Image = null;

                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Error: please click 'X' in Program Window and exit.");
            }
        }

        private void CheckForWinner()
        {
            bool winner = false;
            String winnertext = "";

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (buttons[i, j].GetButton.Image == Checkers.Properties.Resources.Black)
                    {
                        if (turn == true)
                        {
                            disablebuttons();
                            winnertext = (p1.GetPlayerName);
                            p1.GetPlayerWinCount += 1;
                            winner = true;
                        }
                    }
                    else if (buttons[i, j].GetButton.Image == Checkers.Properties.Resources.Red)
                    {
                        if (turn == false)
                        {
                            disablebuttons();
                            winnertext = (p2.GetPlayerName);
                            p2.GetPlayerWinCount += 1;
                            winner = true;
                        }
                    }
                    MessageBox.Show(winnertext + " Wins!");
                }
            }
        }

        private void disablebuttons()
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }

            }// end foreach
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Image = null;
                    FillGrid();
                }
                catch { }

            }// end foreach
        }

        private void checkcurrentplayer()
        {
            if (turn == true)
            {
                currentplayerlabel.Text = ("Current Player: " + p1.GetPlayerName);
            }
            else
            {
                currentplayerlabel.Text = ("Current Player: " + p2.GetPlayerName);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button currentbtn = (Button)sender;
            checkcurrentplayer();

            if (selectedbutton != null)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (currentbtn.Image == buttons[i, j].GetButton.Image)
                        {
                            if (buttons[i, j].GetButton.Image == null)
                            {
                                MoveTobutton = buttons[i, j];
                                MoveTobutton.GetButton.Image = selectedbutton.GetButton.Image;
                                selectedbutton.GetButton.Image = null;
                                selectedbutton = null;
                                turn = !turn;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (currentbtn.Image == buttons[i, j].GetButton.Image)
                        {
                            if (turn == true)
                            {
                                if (buttons[i, j].GetButton.Image == Checkers.Properties.Resources.Black)
                                {
                                    selectedbutton = buttons[i, j];
                                }
                            }
                            else if (turn == false)
                            {
                                if (buttons[i, j].GetButton.Image == Checkers.Properties.Resources.Red)
                                {
                                    selectedbutton = buttons[i, j];
                                }
                            }
                        }
                    }
                }
            }
        }
        
        
    }
    
}



