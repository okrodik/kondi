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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            AddComboInfo();
            UpdateDannuy();
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
                comboBox3.Items.Add(user);

            }

            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Id";
            BD.closeSQL();
        }

        private void IzmenitDannue(int id)
        {
            BD.openSQL();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Bid WHERE Id=@ID", BD.conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Ничего не найдено!");
            }

            BD.closeSQL();
        }

        private void IzmenitOpisanie(int id)
        {

            BD.openSQL();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand("UPDATE Bid SET Status=@val1, Description=@val2, UserID=@val3 WHERE Id=@ID", BD.conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@val1", SqlDbType.NVarChar).Value = comboBox2.Text;
            cmd.Parameters.Add("@val2", SqlDbType.NVarChar).Value = richTextBox1.Text;

            cmd.Parameters.Add("@val3", SqlDbType.Int).Value = ((UserInfo)comboBox3.SelectedItem).Id;

            cmd.ExecuteNonQuery();
            BD.closeSQL();

            UpdateDannuy();

        }

        private void UpdateDannuy()
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
            SqlCommand cmd = new SqlCommand("DELETE FROM Bid", BD.conn);

            BD.openSQL();
            cmd.ExecuteNonQuery();
            BD.closeSQL();

            UpdateDannuy();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IzmenitDannue(Convert.ToInt32(comboBox1.SelectedItem));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IzmenitOpisanie(Convert.ToInt32(comboBox1.SelectedItem));
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox3.ValueMember);
        }
    }
}
