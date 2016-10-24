using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace The_Alchemist
{
    public partial class frmHighscores : Form
    {
        private UserList highscores;                                                                                                       // User list to hold the highscores information

        public frmHighscores()
        {
            InitializeComponent();

            if (Globals.userSettings.UserTheme == Theme.Fire)                                                                              // Change the background image to fit theme if neccessary
            {
                this.BackgroundImage = Properties.Resources.mainMenu1;
            }

            if (Globals.loggedInUser == null)                                                                                              // If user is not logged in disable my scores report
            {
                btnMyScores.Enabled = false;
            }
        }

        private void frmHighscores_Load(object sender, EventArgs e)
        {
            /*
             * Create the binding list of users for the highscores datagridview, 
             * load all the user info and assign it. 
             */

            highscores = new UserList();                                                                                                   // Create new user list
            initialiseUserList(highscores);                                                                                                // Initialise the user list

            dgvHighscores.DataSource = highscores;                                                                                         // Assign the user list as the data source of datagridview
            dgvHighscores.Columns["UserHighestScore"].Visible = false;                                                                     // Hide the highscores struct - displays incorrectly
            dgvHighscores.Columns["UserPassword"].Visible = false;                                                                         // Hide the password from view
            dgvHighscores.Columns["UserName"].HeaderText = "Name";                                                                         // Change column heading for userName
            addHighestscoreColumns();                                                                                                      // Add the columns to display highscore info
            dgvHighscores.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;                                          // Make the name column take up most of the grid
            dgvHighscores.Columns["HighestLevel"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                  // Align hihest level column to the center of column
            dgvHighscores.Columns["HighestLevel"].Width = 140;                                                                             // Change the width of the highest level column
            dgvHighscores.Columns["HighestLevelDate"].Width = 140;                                                                         // Change the width of the date column
            dgvHighscores.Columns["HighestLevelDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;              // Align column contents to center
            dgvHighscores.Columns["HighestLevelDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;              // Align column header contents to center
            dgvHighscores.Columns["HighestLevel"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                  // Align column header contents to center
        }

        /*
         * Connects to the database, retrieves all the data related to the users,
         * creates a user object and adds it to the user list passed as a parameter.
         */
        private void initialiseUserList(UserList ul)
        {
            using (SqlConnection con = new SqlConnection(Globals.DBConn))                                                                  // Create a new connection to the database
            {
                try
                {
                    con.Open();                                                                                                            // Open the connection to the database

                    User user;
                    string query = "SELECT * FROM PLAYER";
                    SqlDataReader reader;

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        string userName;
                        string userPassword;

                        User.UserHighestScoreInfo highscoreInfo;                                                                           // Struct that holds all the user's highscore information
                        int userHighestLevel;
                        DateTime userHighestLevelDate;

                        reader = cmd.ExecuteReader();

                        while (reader.Read())                                                                                              // Loop through all player table entries
                        {
                            userName = reader.GetString(1);
                            userPassword = reader.GetString(2);
                            userHighestLevel = reader.GetInt32(3);
                            userHighestLevelDate = reader.GetDateTime(4);

                            highscoreInfo = new User.UserHighestScoreInfo();                                                                // Create highscore info struct to hold inofrmation to user's highscore
                            highscoreInfo.HighestLevel = userHighestLevel;
                            highscoreInfo.HighestLevelDate = userHighestLevelDate;

                            user = new User(userName, userPassword, highscoreInfo);                                                        // Create user object
                            ul.Add(user);                                                                                                  // Add the user to the user list
                        }

                        con.Close();                                                                                                       // Close the connection to the database
                    }
                }

                catch (Exception err)
                {
                    MessageBox.Show("Error: " + err.Message);
                }
            }
        }

        /*
         * Add the columns to the datagridview to display the highestscore info correctly.
         * Uses the highscore object from the form.
         */
        private void addHighestscoreColumns()
        {
            dgvHighscores.Columns.Add("HighestLevel", "Highest Level");
            for (int i = 0; i < dgvHighscores.RowCount; i++)
            {
                dgvHighscores.Rows[i].Cells["HighestLevel"].Value = highscores[i].UserHighestScore.HighestLevel;
            }

            dgvHighscores.Columns.Add("HighestLevelDate", "Date");
            for (int i = 0; i < dgvHighscores.RowCount; i++)
            {
                dgvHighscores.Rows[i].Cells["HighestLevelDate"].Value = highscores[i].UserHighestScore.HighestLevelDate.ToString("dd/MM/yyyy");
            }
        }

        /*
         * This function reinitialises the columns that were programatically added.
         */
        private void reAddHighestscoreColumns()
        {
            for (int i = 0; i < dgvHighscores.RowCount; i++)
            {
                dgvHighscores.Rows[i].Cells["HighestLevel"].Value = highscores[i].UserHighestScore.HighestLevel;
            }

            for (int i = 0; i < dgvHighscores.RowCount; i++)
            {
                dgvHighscores.Rows[i].Cells["HighestLevelDate"].Value = highscores[i].UserHighestScore.HighestLevelDate.ToString("dd/MM/yyyy");
            }
        }

        /*
         * This function is meant to reinitialise the datagridview after a sort has been peformed
         */
        private void reinitialiseHighscores()
        {
            dgvHighscores.DataSource = highscores;                                                                                         // Assign the user list as the data source of datagridview
            dgvHighscores.Columns["UserHighestScore"].Visible = false;                                                                     // Hide the highscores struct - displays incorrectly
            dgvHighscores.Columns["UserPassword"].Visible = false;                                                                         // Hide the password from view
            dgvHighscores.Columns["UserName"].HeaderText = "Name";                                                                         // Change column heading for userName
            reAddHighestscoreColumns();                                                                                                    // Add the columns to display highscore info
            dgvHighscores.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;                                          // Make the name column take up most of the grid
            dgvHighscores.Columns["UserName"].DisplayIndex = 0;                                                                            // Move the name column to the left of the datagridview
        }

        /*
         * Sort according to highest level.
         * Change the button text to indicate a reversal of order.
         */
        private void btnSortHighestLevel_Click(object sender, EventArgs e)
        {
            if (btnSortHighestLevel.Text == "Highest Level ▼")
            {
                dgvHighscores.DataSource = null;
                highscores.quickSort(UserList.SortBy.HighestLevelDesc);
                btnSortHighestLevel.Text = "Highest Level ▲";
            }

            else if (btnSortHighestLevel.Text == "Highest Level ▲")
            {
                dgvHighscores.DataSource = null;
                highscores.quickSort(UserList.SortBy.HighestLevelAsc);
                btnSortHighestLevel.Text = "Highest Level ▼";
            }

            reinitialiseHighscores();
        }

        /*
         * Sort according to highest level date.
         * Change the button text to indicate a reversal of order.
         */
        private void btnSortDate_Click(object sender, EventArgs e)
        {
            if (btnSortDate.Text == "Date ▼")
            {
                dgvHighscores.DataSource = null;
                highscores.quickSort(UserList.SortBy.HighestLevelDateDesc);
                btnSortDate.Text = "Date ▲";
            }

            else if (btnSortDate.Text == "Date ▲")
            {
                dgvHighscores.DataSource = null;
                highscores.quickSort(UserList.SortBy.HighestLevelDateAsc);
                btnSortDate.Text = "Date ▼";
            }

            reinitialiseHighscores();
        }

        /*
         * Sort according to name.
         * Change the button text to indicate a reversal of order.
         */
        private void btnSortName_Click(object sender, EventArgs e)
        {
            if (btnSortName.Text == "Name ▼")
            {
                dgvHighscores.DataSource = null;
                highscores.quickSort(UserList.SortBy.NameDesc);
                btnSortName.Text = "Name ▲";
            }

            else if (btnSortName.Text == "Name ▲")
            {
                dgvHighscores.DataSource = null;
                highscores.quickSort(UserList.SortBy.NameAsc);
                btnSortName.Text = "Name ▼";
            }

            reinitialiseHighscores();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReport f = new frmReport();
            f.ShowDialog();
        }

        private void btnMyScores_Click(object sender, EventArgs e)
        {
            frmReportUser frm = new frmReportUser();
            frm.ShowDialog();
        }
    }
}
