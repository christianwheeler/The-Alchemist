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
    public partial class characterSelection : Form
    {
        frmStartGame frm = new frmStartGame(false, false);  // Preload the form so long

        public characterSelection()
        {
            InitializeComponent();

            this.BackgroundImage = Properties.Resources.mainMenu1;

            if (Globals.userSettings.UserTheme == Theme.Fire)
            {
                this.BackgroundImage = Properties.Resources.mainMenu1;
             
            }

            else if (Globals.userSettings.UserTheme == Theme.Ice)
            {
                this.BackgroundImage = Properties.Resources.mainMenu;
             
            }
        }
        //Earth
        private void button1_Click(object sender, EventArgs e)
        {
            Globals.userSettings.UserCharacterType = CharacterType.Earth;
            this.Hide();
            frm.ShowDialog();
        }

        //Fire
        private void button2_Click(object sender, EventArgs e)
        {
            Globals.userSettings.UserCharacterType = CharacterType.Fire;
            this.Hide();
            frm.ShowDialog();
        }

        //Water
        private void button3_Click(object sender, EventArgs e)
        {
            Globals.userSettings.UserCharacterType = CharacterType.Water;
            this.Hide();
            frm.ShowDialog();
        }

        //Wind
        private void button4_Click(object sender, EventArgs e)
        {
            Globals.userSettings.UserCharacterType = CharacterType.Wind;
            this.Hide();
            frm.ShowDialog();
        }

        private void characterSelection_Load(object sender, EventArgs e)
        {
            // Highlight the button that representst the current selection in user settings
            if (Globals.userSettings.UserCharacterType == CharacterType.Earth)
            {
                button1.FlatAppearance.BorderColor = Color.Green;
                button1.FlatAppearance.BorderSize = 2;
            }

            else if (Globals.userSettings.UserCharacterType == CharacterType.Fire)
            {
                button2.FlatAppearance.BorderColor = Color.Green;
                button2.FlatAppearance.BorderSize = 2;
            }

            else if (Globals.userSettings.UserCharacterType == CharacterType.Water)
            {
                button3.FlatAppearance.BorderColor = Color.Green;
                button3.FlatAppearance.BorderSize = 2;
            }

            else if (Globals.userSettings.UserCharacterType == CharacterType.Wind)
            {
                button4.FlatAppearance.BorderColor = Color.Green;
                button4.FlatAppearance.BorderSize = 2;
            }
        }

        private void characterSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
