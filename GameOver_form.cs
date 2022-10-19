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
    public partial class GameOver_form : Form
    {
        public GameOver_form()
        {
            InitializeComponent();
        }

        private void GameOver_form_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
        }

        private void btn_mainMenu_Click(object sender, EventArgs e)
        {
            MainMenu_form newForm = new MainMenu_form();
            this.Hide();
            newForm.Show();
        }
    }
}
