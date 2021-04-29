using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Personal_Details
{
    public partial class Form1 : Form
    {
        string phno;
        string firstName;
        string lastName;
        string gender;
        string Corcpp, cSharp, visualBasic, delphi;
        string hobbies;
        string searchName;
        string searchPhone;
        string MyConnection = "datasource=localhost;port=3306;username=root;password=root";

        public Form1()
        {
            InitializeComponent();
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Clear();
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Clear();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            phno = textBox1.Text;

           
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            firstName = textBox2.Text;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            lastName = textBox3.Text;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            searchName = textBox4.Text;
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            searchPhone = textBox5.Text;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

       

        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

       
        private void radioButton1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            gender = "Male";
        }

      

        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = true;
            gender = "female";
        }

      

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Corcpp = "yes";
            }
            else
            {
                Corcpp = "no";
            }


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            hobbies = richTextBox1.Text;
        }

       

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                cSharp = "yes";
            }
            else
            {
                cSharp = "no";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                visualBasic = "yes";
            }
            else
            {
                visualBasic = "no";
            }

        }

       

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                delphi = "yes";
            }
            else
            {
                delphi = "no";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                string Query = "insert into applicant_info.personal_info (FirstName, LastName, PhoneNo, Gender, C_or_Cpp, C_Sharp, Visual_Basic, Delphi, Hobbies) values('" + firstName + "','" + lastName + "','" + phno + "','" + gender + "','" + Corcpp + "','" + cSharp + "','" + visualBasic + "','" + delphi + "','" + hobbies + "');";

                MySqlConnection MyConn1 = new MySqlConnection(MyConnection);

                MySqlCommand MyCommand1 = new MySqlCommand(Query, MyConn1);
                MySqlDataReader MyReader1;
                MyConn1.Open();
                MyReader1 = MyCommand1.ExecuteReader();
                MessageBox.Show("Save Data");
                MyConn1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string Query = "select * from applicant_info.personal_info where FirstName = '" + searchName + "' OR LastName = '" + searchName + "'; ";
            MySqlConnection MyConn1 = new MySqlConnection(MyConnection);
            try
            {



                MySqlCommand MyCommand1 = new MySqlCommand(Query, MyConn1);
                MySqlDataReader MyReader1;
                MyConn1.Open();
                MyReader1 = MyCommand1.ExecuteReader();
                if (MyReader1.HasRows)

                {

                    DataTable dt = new DataTable();

                    dt.Load(MyReader1);

                    dataGridView1.DataSource = dt;

                }

            }



            finally

            {

                MyConn1.Close();

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string Query = "select * from applicant_info.personal_info where PhoneNo = '" + searchPhone + "'; ";
            MySqlConnection MyConn1 = new MySqlConnection(MyConnection);
            try
            {



                MySqlCommand MyCommand1 = new MySqlCommand(Query, MyConn1);
                MySqlDataReader MyReader1;
                MyConn1.Open();
                MyReader1 = MyCommand1.ExecuteReader();
                if (MyReader1.HasRows)

                {

                    DataTable dt = new DataTable();

                    dt.Load(MyReader1);

                    dataGridView1.DataSource = dt;

                }

            }



            finally

            {

                MyConn1.Close();

            }
        }

    }
}
