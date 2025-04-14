using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGjatek
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {

        }

        private void ContinueBtn_Click(object sender, EventArgs e)
        {

        }

        private void NewgameBtn_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
