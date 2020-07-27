using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DineApp
{
    public partial class ManagerEntryForm : Form
    {
        public ManagerEntryForm()
        {
            InitializeComponent();
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            LogInForm lf = new LogInForm();
            lf.Show();
            this.Hide();
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            OrderForm of = new OrderForm();
            of.Show();
            this.Hide();

        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            MenuForm mf = new MenuForm();
            mf.Show();
            this.Hide();
        }

        private void UserButton_Click(object sender, EventArgs e)
        {
            UserForm uf = new UserForm();
            uf.Show();
            this.Hide();

        }

        private void ManagerEntryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
