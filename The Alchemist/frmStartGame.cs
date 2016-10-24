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
        public frmStartGame(bool d)  // 0 = Start, 1 = Died
        {
            InitializeComponent();

            if (Globals.userSettings.UserTheme == Theme.Fire)
            {
                this.BackgroundImage = Properties.Resources.mainMenu1;
            }
            this.ded = d;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var game = new AlchemistGame())
                game.Run();
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
        }

        private void frmStartGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
