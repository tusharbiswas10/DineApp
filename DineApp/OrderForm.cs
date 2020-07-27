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
    public partial class OrderForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-B9pUM9B;Initial Catalog=Dine1;Integrated Security=True;Pooling=False");
        public OrderForm()
        {
            InitializeComponent();
        }

        private void Backbutton_Click(object sender, EventArgs e)
        {
            ManagerEntryForm mef = new ManagerEntryForm();
            mef.Show();
            this.Hide();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
           // data_manipulate();
            catch_value();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            double a = int.Parse(PricetextBox.Text);
            double b = double.Parse(QuantitytextBox.Text);
            double c = a * b;

            string ValueText = Convert.ToString(c);

            string userText = ItemtextBox.Text;
            string userText1 = QuantitytextBox.Text;
            string userText2 = TabletextBox.Text;
            string userText3 = OrderTypetextBox.Text;



            cmd.CommandText = "insert into Order_Table values('" + userText + "','" + ValueText + "','" + userText1 + "','" + userText2 + "','" + userText3 + "')";
            cmd.ExecuteNonQuery();
            con.Close();
           display_data2();
            MessageBox.Show("Order added successfully");
        }

        public void display_data1()
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

        public void display_data2()
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Order_Table";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            dataGridView2.DataSource = dt;

            con.Close();

        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            display_data1();
            display_data2();
            //  catch_value();



        }

        private void ItemtextBox_TextChanged(object sender, EventArgs e)
        {
            catch_value();
            //con.Open();
            //string userText = ItemtextBox.Text;
            //if (ItemtextBox.Text != "")
            //{
            //    SqlCommand cmd = new SqlCommand("select Price from Menu_table where Name='" + userText + "' ", con);
            //    SqlDataReader da = cmd.ExecuteReader();

            //    while (da.Read())
            //    {
            //        PricetextBox.Text = da.GetValue(0).ToString();
            //    }
            //}
            //con.Close();
        }

        public void catch_value()
        {
            con.Open();
            string userText = ItemtextBox.Text;
            if (ItemtextBox.Text != "")
            {
                SqlCommand cmd = new SqlCommand("select Price from Menu_table where Name='" + userText + "' ", con);
                SqlDataReader da = cmd.ExecuteReader();

                while (da.Read())
                {
                    PricetextBox.Text = da.GetValue(0).ToString();
                }
            }
            con.Close();

        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            dataGridView2[0, dataGridView2.Rows.Count - 1].Value = "Total =";
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[1].Style.BackColor = Color.Yellow;
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[1].Style.ForeColor = Color.Red;

            decimal tot = 0;

            for(int i=0;i<dataGridView2.RowCount - 1; i++)
            {
                var value = dataGridView2.Rows[i].Cells[1].Value;

                if(value != DBNull.Value)
                {
                    tot += Convert.ToDecimal(value);
                }
            }

            if (tot == 0)
            {

            }

            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[1].Value = tot.ToString();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmap = new Bitmap(this.dataGridView2.Width, this.dataGridView2.Height);
            dataGridView2.DrawToBitmap(bmap, new Rectangle(0, 0, this.dataGridView2.Width, this.dataGridView2.Height));


                e.Graphics.DrawImage(bmap, 250, 90);

        }

        private void BillButton_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from Order_Table";
            cmd.ExecuteNonQuery();
            con.Close();

            display_data2();
            MessageBox.Show("Order reseted");
        }

        //public void data_manipulate()
        //{
        //    int a =int.Parse(PricetextBox.Text);
        //    int b = int.Parse(QuantitytextBox.Text);
        //    int c = a + b;  

        //    string ValueText = Convert.ToString(c);

        //}
    }
}
