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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            Vivod();
        }

        private void Vivod()
        {
            BD.openSQL();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Bid", BD.conn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
            BD.closeSQL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            BD.openSQL();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Bid WHERE Id =@ID", BD.conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
            BD.closeSQL();
        }
    }
}
