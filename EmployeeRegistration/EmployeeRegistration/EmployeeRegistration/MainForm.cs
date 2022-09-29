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

namespace EmployeeRegistration
{
    public partial class FrmMainForm : Form
    {
        public FrmMainForm()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-CQB2NGM\\MSSQLSERVER2019;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        void Cleaner()
        {
            txtID.Text = "";
            txtJob.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            msktxtSalary.Text = "";
            cbxCity.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtName.Focus();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet.Tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet.Tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@p1", txtName.Text);
            sqlCommand.Parameters.AddWithValue("@p2", txtSurname.Text);
            sqlCommand.Parameters.AddWithValue("@p3", cbxCity.Text);
            sqlCommand.Parameters.AddWithValue("@p4", msktxtSalary.Text);
            sqlCommand.Parameters.AddWithValue("@p5", txtJob.Text);
            sqlCommand.Parameters.AddWithValue("@p6", label8.Text);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            MessageBox.Show("Employee Added");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                label8.Text = "True";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            label8.Text = "False";
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Cleaner();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int choosen = dataGridView1.SelectedCells[0].RowIndex;

            txtID.Text = dataGridView1.Rows[choosen].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[choosen].Cells[1].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[choosen].Cells[2].Value.ToString();
            cbxCity.Text = dataGridView1.Rows[choosen].Cells[3].Value.ToString();
            msktxtSalary.Text = dataGridView1.Rows[choosen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[choosen].Cells[5].Value.ToString();
            txtJob.Text = dataGridView1.Rows[choosen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            
            if(label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("Delete From Tbl_Personel Where Perid=@k1", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@k1", txtID.Text);

            sqlCommand.ExecuteNonQuery();
            
            sqlConnection.Close();

            MessageBox.Show("Employee Deleted");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("Update Tbl_Personel Set PerAd=@a1, PerSoyad=@a2, PerSehir=@a3, PerMaas=@a4, PerDurum=@a5, PerMeslek=@a6 Where Perid=@a7", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@a1", txtName.Text);
            sqlCommand.Parameters.AddWithValue("@a2", txtSurname.Text);
            sqlCommand.Parameters.AddWithValue("@a3", cbxCity.Text);
            sqlCommand.Parameters.AddWithValue("@a4", msktxtSalary.Text);
            sqlCommand.Parameters.AddWithValue("@a5", label8.Text);
            sqlCommand.Parameters.AddWithValue("@a6", txtJob.Text);
            sqlCommand.Parameters.AddWithValue("@a7", txtID.Text);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Employee Informations Updated");
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            FrmStatistic frmStatistic = new FrmStatistic();
            frmStatistic.Show();
        }

        private void btnGraphics_Click(object sender, EventArgs e)
        {
            GraphicsFrm graphicsFrm = new GraphicsFrm();
            graphicsFrm.Show();
        }
    }
}
