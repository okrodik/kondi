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

namespace kondi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Введите логин и/или пароль");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                string a = textBox1.Text;
                string b = textBox2.Text;
                connectBD(a, b);
            }
        }

        public string connectBD(string text1, string text2)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Users] WHERE Users = @lg AND Pass = @ps", BD.conn);
            cmd.Parameters.Add("@lg", SqlDbType.NVarChar).Value = text1;
            cmd.Parameters.Add("@ps", SqlDbType.NVarChar).Value = text2;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                BD.openSQL();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                BD.closeSQL();

                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();

                return "connect";
            }
            else
            {
                MessageBox.Show("Пользователь не существует");
                textBox1.Text = "";
                textBox2.Text = "";

                return "disconnect";
            }
        }       
    }
}
