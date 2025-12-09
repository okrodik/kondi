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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kondi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("INSERT INTO [Bid] (Date, Type, Model, Description, FIO, Number, Status) " +
                "VALUES (@val2, @val3, @val4, @val5, @val6, @val7, @val8)", BD.conn);
            cmd.Parameters.Add(new SqlParameter("@val2", SqlDbType.Date)).Value = dateTimePicker1.Text;
            cmd.Parameters.Add(new SqlParameter("@val3", SqlDbType.NVarChar)).Value = textBox1.Text;
            cmd.Parameters.Add(new SqlParameter("@val4", SqlDbType.NVarChar)).Value = textBox2.Text;
            cmd.Parameters.Add(new SqlParameter("@val5", SqlDbType.NVarChar)).Value = richTextBox1.Text;
            cmd.Parameters.Add(new SqlParameter("@val6", SqlDbType.NVarChar)).Value = textBox3.Text;
            cmd.Parameters.Add(new SqlParameter("@val7", SqlDbType.NVarChar)).Value = textBox4.Text;
            cmd.Parameters.Add(new SqlParameter("@val8", SqlDbType.NVarChar)).Value = comboBox1.Text;

            BD.openSQL();
            cmd.ExecuteNonQuery();
            BD.closeSQL();
        }
    }
}
