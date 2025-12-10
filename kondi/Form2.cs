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
    public partial class Form2 : Form
    {
        public Form2()
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

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void отследитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void назначитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void расчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f7 = new Form7();
            f7.Show();
        }
    }
}
