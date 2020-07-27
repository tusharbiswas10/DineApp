using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DineApp
{
    public partial class LogInForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-B9pUM9B;Initial Catalog=Dine1;Integrated Security=True;Pooling=False");
        public LogInForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerEntryForm mf = new ManagerEntryForm();

            SqlDataAdapter da = new SqlDataAdapter("select * from User_table where UserName='" + textBox1.Text.Trim() + "' and Password='" + textBox2.Text.Trim() + "' ",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
              mf.Show();
              this.Hide();

            }

            else
            {
                MessageBox.Show("Error !!! : wrong username or password");
            }
            
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }
    }
}
