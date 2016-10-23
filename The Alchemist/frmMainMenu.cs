using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace The_Alchemist
{
    public partial class frmMainMenu : Form
    {
        // Form variables
        SqlConnection conn = new SqlConnection(Globals.DBConn);
        SqlDataReader reader;

        public frmMainMenu()
        {
            InitializeComponent();
            
            if (Globals.userSettings.UserTheme == Theme.Fire)
            {
                this.BackgroundImage = Properties.Resources.mainMenu1;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM PLAYER WHERE PLAYER_NAME = '" + txtUsername.Text + "' AND PLAYER_PASSWORD = '" + txtPassword.Text + "'");
                cmd.Connection = conn;
                conn.Open();    // Open connection
                reader = cmd.ExecuteReader();   // Read all data into the reader

                if (reader.Read())
                {
                    // Set user as logged in
                    User.UserHighestScoreInfo hs = new User.UserHighestScoreInfo();
                    hs.HighestLevel = Convert.ToInt32(reader["HIGHEST_LEVEL"]);
                    hs.HighestLevelDate = Convert.ToDateTime(reader["HIGHEST_LEVEL_DATE"]);

                    User loggedInUser = new User(reader["PLAYER_NAME"].ToString(), reader["PLAYER_PASSWORD"].ToString(), hs);
                    Globals.loggedInUser = loggedInUser;

                    this.Hide();
                    //Jump to character selection screen
                    characterSelection cs = new characterSelection();
                    cs.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("User does not exist");
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister f = new frmRegister();
            f.ShowDialog();
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            frmHighscores f = new frmHighscores();
            f.ShowDialog();
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.mainMenu1;

            if (Globals.userSettings.UserTheme == Theme.Fire)
            {
                this.BackgroundImage = Properties.Resources.mainMenu;
                Globals.userSettings.UserTheme = Theme.Ice;
            }

            else if (Globals.userSettings.UserTheme == Theme.Ice)
            {
                this.BackgroundImage = Properties.Resources.mainMenu1;
                Globals.userSettings.UserTheme = Theme.Fire;
            }
        }
    }
}
