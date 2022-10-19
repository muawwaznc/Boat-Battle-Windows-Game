using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boatbattle
{
    public partial class MainMenu_form : Form
    {
        public MainMenu_form()
        {
            InitializeComponent();
        }

        private void btn_newGame_Click(object sender, EventArgs e)
        {
            Level1_forrm newForm = new Level1_forrm();
            this.Hide();
            newForm.Show();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainMenu_form_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
        }
    }
}
