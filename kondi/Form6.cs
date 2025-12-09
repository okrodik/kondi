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
            AddComboInfo();
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

            SqlCommand cmd1 = new SqlCommand("SELECT Id, Users FROM Users", BD.conn);

            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                var user = new UserInfo
                {
                    Id = Convert.ToInt32(reader1["Id"]),
                    Name = reader1["Users"].ToString()
                };
                comboBox2.Items.Add(user);

            }
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";

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

            string sql;

            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                sql = "UPDATE Bid SET UserID = @val3 WHERE Id = @ID";
            }
            else
            {
                sql = "UPDATE Bid SET Description = @val2, UserID = @val3 WHERE Id = @ID";
            }

            SqlCommand cmd = new SqlCommand(sql, BD.conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(comboBox1.Text);
            cmd.Parameters.Add("@val3", SqlDbType.Int).Value = ((UserInfo)comboBox2.SelectedItem).Id;

            if (!string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                cmd.Parameters.Add("@val2", SqlDbType.NVarChar).Value = richTextBox1.Text;
            }

            cmd.ExecuteNonQuery();
            BD.closeSQL();

            Vivod();
        }
    }
}
