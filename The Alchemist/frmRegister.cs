﻿using System;
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
    public partial class frmRegister : Form
    {
        // Form variables
        SqlConnection conn = new SqlConnection(Globals.DBConn);

        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO PLAYER VALUES('" + txtUsername.Text + "', '" + txtPassword.Text + "', '0')");
                cmd.Connection = conn;
                conn.Open();    // Open connection
                int rows = cmd.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Account Successfully Created");
                this.Hide();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
