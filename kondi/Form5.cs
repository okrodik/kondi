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
            Uvedomlenie();
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

        private void Uvedomlenie()
        {
            int x = Convert.ToInt32(Access.access);

            BD.openSQL();
            SqlCommand cmd = new SqlCommand("SELECT Status FROM Bid WHERE Id =@ID", BD.conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = x;

            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                string status = result.ToString();
                label1.Text = $"Уведомление. Заказ под номером {x} изменён на статус: {status}";
            }
            else
            {
                label1.Text = "Уведомление. Ничего не менялось";
            }
            BD.closeSQL();

        }
    }
}
