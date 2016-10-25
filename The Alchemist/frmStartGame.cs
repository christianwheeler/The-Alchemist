using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace The_Alchemist
{
    public partial class frmStartGame : Form
    {
        private bool ded;
        private bool won;
        public frmStartGame(bool d, bool won)  // 0 = Start, 1 = Died
        {
            InitializeComponent();

            if (Globals.userSettings.UserTheme == Theme.Fire)
            {
                this.BackgroundImage = Properties.Resources.mainMenu1;
            }
            this.ded = d;
            this.won = won;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            using ( Globals.game = new AlchemistGame())
                Globals.game.Run();
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            frmHighscores f = new frmHighscores();
            f.ShowDialog();
        }

        private void frmStartGame_Load(object sender, EventArgs e)
        {
            if (ded)
            {
                lblDed.Visible = true;
                btnRegister.Text = "Play again";
            }
            else if (won)
            {
                lblDed.Visible = true;
                lblDed.Text = "You beat the game!!!";
            }
        }

        private void frmStartGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
