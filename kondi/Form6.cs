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
    public partial class Form6 : Form
    {
        public Form6()
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
        private void AddComboInfo()
        {
            BD.openSQL();
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Bid", BD.conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Id"]);
            }
            reader.Close();

            SqlCommand cmd1 = new SqlCommand("SELECT Users FROM Users", BD.conn);

            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                comboBox2.Items.Add(reader1["Users"]);
            }

            BD.closeSQL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
