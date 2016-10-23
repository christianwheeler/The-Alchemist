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
            Globals.userSettings.writeSettings();
            this.Hide();

            frmStartGame f = new frmStartGame(false);
            f.ShowDialog();
        }

        //Fire
        private void button2_Click(object sender, EventArgs e)
        {
            Globals.userSettings.UserCharacterType = CharacterType.Fire;
            Globals.userSettings.writeSettings();
            this.Hide();
            frmStartGame f = new frmStartGame(false);
            f.ShowDialog();
        }

        //Water
        private void button3_Click(object sender, EventArgs e)
        {
            Globals.userSettings.UserCharacterType = CharacterType.Water;
            Globals.userSettings.writeSettings();
            this.Hide();
            frmStartGame f = new frmStartGame(false);
            f.ShowDialog();
        }

        //Wind
        private void button4_Click(object sender, EventArgs e)
        {
            Globals.userSettings.UserCharacterType = CharacterType.Wind;
            Globals.userSettings.writeSettings();
            this.Hide();
            frmStartGame f = new frmStartGame(false);
            f.ShowDialog();
        }

        private void characterSelection_Load(object sender, EventArgs e)
        {

        }
    }
}
