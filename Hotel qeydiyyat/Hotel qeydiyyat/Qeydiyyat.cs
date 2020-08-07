using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hotel_qeydiyyat
{
    public partial class Qeydiyyat : Form
    {
        SqlConnection elaqe = new SqlConnection("Data Source=DESKTOP-3V0EO5N;Initial Catalog=otel;Integrated Security=True");

        private void goster() {
            listView1.Items.Clear();
            elaqe.Open();
            SqlCommand emr = new SqlCommand("Select * from musteriler", elaqe);
            SqlDataReader oxu = emr.ExecuteReader();

            while (oxu.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = oxu["Id"].ToString();
                list.SubItems.Add(oxu["Ad"].ToString());
                list.SubItems.Add(oxu["Soyad"].ToString());
                list.SubItems.Add(oxu["OtaqNom"].ToString());
                list.SubItems.Add(oxu["GirisTar"].ToString());
                list.SubItems.Add(oxu["CixisTar"].ToString());

                listView1.Items.Add(list);

            }
            elaqe.Close();


        }

        public Qeydiyyat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            goster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            elaqe.Open();
            SqlCommand emr = new SqlCommand("insert into musteriler values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "','"+dateTimePicker1.Text.ToString()+"','"+dateTimePicker2.Text.ToString()+"') ", elaqe);
            emr.ExecuteNonQuery();



            emr.CommandText ="insert into doluotaqlar values('" + comboBox1.Text + "')";
            emr.ExecuteNonQuery();
            emr.CommandText = "Delete from  bosotaqlar where bosotaqlar='"+comboBox1.Text+"' ";
            emr.ExecuteNonQuery();

            elaqe.Close();
            goster();
        }

        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            elaqe.Open();
            SqlCommand emr = new SqlCommand("Delete from musteriler where Id='"+id+"' ", elaqe);
            emr.ExecuteNonQuery();


            emr.CommandText = "insert into bosotaqlar values('" + comboBox1.Text + "')";
            emr.ExecuteNonQuery();
            emr.CommandText = "Delete from  doluotaqlar where bosotaqlar='" + comboBox1.Text + "' ";
            emr.ExecuteNonQuery();

            elaqe.Close();
            goster();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            dateTimePicker2.Text = listView1.SelectedItems[0].SubItems[5].Text;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            elaqe.Open();
            SqlCommand emr = new SqlCommand("update musteriler set Id='"+textBox1.Text+ "',Ad='" + textBox2.Text + "',Soyad='" + textBox3.Text + "',OtaqNom='" + comboBox1.Text + "',GirisTar='"+dateTimePicker1.Text+"',CixisTar='"+dateTimePicker2.Text+"' where Id='"+id+"' ", elaqe);
            emr.ExecuteNonQuery();
            elaqe.Close();
            goster();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            elaqe.Open();
            SqlCommand emr = new SqlCommand("Select * from musteriler where Ad like '%"+textBox4.Text.ToString()+"%'", elaqe);
            SqlDataReader oxu = emr.ExecuteReader();

            while (oxu.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = oxu["Id"].ToString();
                list.SubItems.Add(oxu["Ad"].ToString());
                list.SubItems.Add(oxu["Soyad"].ToString());
                list.SubItems.Add(oxu["OtaqNom"].ToString());
                list.SubItems.Add(oxu["GirisTar"].ToString());
                list.SubItems.Add(oxu["CixisTar"].ToString());

                listView1.Items.Add(list);

            }
            elaqe.Close();
        }

        private void Qeydiyyat_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            elaqe.Open();
            SqlCommand emr = new SqlCommand("Select * from bosotaqlar", elaqe);
            SqlDataReader oxu = emr.ExecuteReader();

            while (oxu.Read())
            {
                comboBox1.Items.Add(oxu["bosotaqlar"].ToString());

            }
            elaqe.Close();
        }
    }
}
