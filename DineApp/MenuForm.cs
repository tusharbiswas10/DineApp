using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DineApp
{
    public partial class MenuForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-B9pUM9B;Initial Catalog=Dine1;Integrated Security=True;Pooling=False");
        public MenuForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerEntryForm mef = new ManagerEntryForm();
            mef.Show();
            this.Hide();
        }

        

        public void display_data()
        {
           
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Menu_table";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();

        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            display_data();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string userText = NametextBox.Text;
            string userText1 = CategorytextBox.Text;
            string userText2 = PricetextBox.Text;
            //string userText3 = RoleTextBox.Text;
            //string userText4 = PhoneTextBox.Text;
            //string userText5 = AddressTextBox.Text;


            cmd.CommandText = "insert into Menu_table values('" + userText + "','" + userText1 + "','" + userText2 + "')";
            //cmd.CommandText = "insert into Menu_table values('"+NameTextBox+"','"+UserNameTextBox+"','"+PassTextBox+"','"+RoleTextBox+"','"+PhoneTextBox+"','"+AddressTextBox+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            display_data();
            MessageBox.Show("info added successfully");
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string userText = NametextBox.Text;
            

            cmd.CommandText = "delete from Menu_table where Name='" + userText + "'";

            cmd.ExecuteNonQuery();
            con.Close();
            display_data();
            MessageBox.Show("info deleted successfully");
        }
    }
}
