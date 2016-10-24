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
    public partial class frmReportUser : Form
    {
        public frmReportUser()
        {
            InitializeComponent();
        }

        private void frmReportUser_Load(object sender, EventArgs e)
        {
            // Initialise parametrised report for current user
            crystalReportViewer1.SelectionFormula = "{PLAYER.PLAYER_NAME} = '" + Globals.loggedInUser.UserName + "'";
        }
    }
}
