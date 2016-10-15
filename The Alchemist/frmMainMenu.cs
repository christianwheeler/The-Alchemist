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
                    using (var game = new AlchemistGame())
                        game.Run();
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
    }
}
