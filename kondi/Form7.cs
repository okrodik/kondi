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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            Vivod();
            Statistika();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void Vivod()
        {
            BD.openSQL();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Bid WhERE Status=@sts", BD.conn);
            cmd.Parameters.Add("@sts", SqlDbType.NVarChar).Value = "Закрыт";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
            BD.closeSQL();
        }

        private void Statistika()
        {
            BD.openSQL();
            SqlCommand cmd = new SqlCommand("SELECT Id, Status FROM Bid", BD.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView2.DataSource = dt;
            BD.closeSQL();
        }
    }
}
