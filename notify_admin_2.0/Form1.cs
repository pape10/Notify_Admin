using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace notify_admin_2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string event1 = textBox1.Text;
            /*sw.WriteLine(event1);
            sw.Flush();
            sw.Close();
            fs.Close();*/
            SqlConnection sqlConnection1;
            try
            {
               sqlConnection1 =
                  new SqlConnection(@"Data Source=mssql5.gear.host;Initial Catalog=events3;User ID=events3;Password=Ev067I!~zyZy");
                DateTime today = DateTime.Now;

                string query = "INSERT Events2 (EventName,Upload_Time) VALUES ('" + event1 + "','" + today + "')";
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO EVENTS2 (EventName,Upload_Time) VALUES (@Name,@Time) ", sqlConnection1);
                cmd.Parameters.AddWithValue("@Name", event1);
                cmd.Parameters.AddWithValue("@Time", today);
                int output = cmd.ExecuteNonQuery();
                if (output > 0)
                {
                    label2.Text = "your event has been registered";
                    textBox1.Text = "";
                }
                else
                {
                    label2.Text = "something went wrong try again in some time";
                }
                sqlConnection1.Close();
            }
            catch(Exception ex)
            {
                label2.Text = "the connection could not be established";
                MessageBox.Show(""+ex);
            }
            
        }
    }
}
