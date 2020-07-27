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
    public partial class UserForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-B9pUM9B;Initial Catalog=Dine1;Integrated Security=True;Pooling=False");
        public UserForm()
        {
            InitializeComponent();
        }

        private void Backbutton_Click(object sender, EventArgs e)
        {
           ManagerEntryForm mf = new ManagerEntryForm();
            mf.Show();
            this.Hide();

        }

       

        private void DoneButton_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string userText = NameTextBox.Text;
            string userText1 = UserNameTextBox.Text;
            string userText2 = PassTextBox.Text;
            string userText3 = RoleTextBox.Text;
            string userText4 = PhoneTextBox.Text;
            string userText5 = AddressTextBox.Text;
           

            cmd.CommandText = "insert into User_table values('" + userText + "','" + userText1 + "','" + userText2 + "','" + userText3 + "','" + userText4 + "','" + userText5 + "')";
            //cmd.CommandText = "insert into User_table values('"+NameTextBox+"','"+UserNameTextBox+"','"+PassTextBox+"','"+RoleTextBox+"','"+PhoneTextBox+"','"+AddressTextBox+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            display_data();
            MessageBox.Show("info added successfully");
        }

        public void display_data()
        {
          //  DataGridView dataGridView1 = new DataGridView();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from User_table";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          //  SqlDataAdapter da = new SqlDataAdapter("select * from User_table",con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();

        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            display_data();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
           string userText = NameTextBox.Text;
           /* string userText1 = UserNameTextBox.Text;
            string userText2 = PassTextBox.Text;
            string userText3 = RoleTextBox.Text;
            string userText4 = PhoneTextBox.Text;
            string userText5 = AddressTextBox.Text;
            string userText6 = NameTextBox.Text;*/

            cmd.CommandText = "delete from User_table where Name='"+userText+"'";
         
            cmd.ExecuteNonQuery();
            con.Close();
            display_data();
            MessageBox.Show("info deleted successfully");
        }

        /* private void panel3_Paint(object sender, PaintEventArgs e)
         {
             display_data();
         }*/
    }
}
