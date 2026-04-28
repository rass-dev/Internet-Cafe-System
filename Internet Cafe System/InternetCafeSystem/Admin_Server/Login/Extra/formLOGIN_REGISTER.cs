using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetCafe.Login
{
    public partial class formLOGIN_REGISTER : Form
    {
        public formLOGIN_REGISTER()
        {
            InitializeComponent();
        }

        private void formLOGIN_REGISTER_Load(object sender, EventArgs e)
        {
            ControlBox = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        formManagePC ManagePC;

        private void submenu1_Click(object sender, EventArgs e)
        {
            if (ManagePC == null)
            {
                ManagePC = new formManagePC();
                ManagePC.FormClosed += ManagePC_FormClosed;
                ManagePC.MdiParent = this;
                ManagePC.Dock = DockStyle.Fill;
                ManagePC.Show();
            }
            else
            {
                ManagePC.Activate();



            }

        }

        private void ManagePC_FormClosed(object sender, FormClosedEventArgs e)
        {
            ManagePC = null;
        }


    }
}
