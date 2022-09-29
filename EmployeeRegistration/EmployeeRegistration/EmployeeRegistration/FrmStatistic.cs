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
    public partial class FrmStatistic : Form
    {
        public FrmStatistic()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CQB2NGM\\MSSQLSERVER2019;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void FrmStatistic_Load(object sender, EventArgs e)
        {

            //Total Number of Employees
            connection.Open();
            SqlCommand command1 = new SqlCommand("Select Count(*) From Tbl_Personel", connection);
            SqlDataReader dr1 = command1.ExecuteReader();
            while (dr1.Read())
            {
                lblTotalEmployees.Text = dr1[0].ToString();
            }

            connection.Close();


            //Married Employees
            connection.Open();
            SqlCommand command2 = new SqlCommand("Select Count(*) From Tbl_Personel Where PerDurum=1", connection);
            SqlDataReader dr2 = command2.ExecuteReader();
            while (dr2.Read())
            {
                lblMarriedEmployees.Text = dr2[0].ToString();
            }

            connection.Close();


            //Single Employees
            connection.Open();
            SqlCommand command3 = new SqlCommand("Select Count(*) From Tbl_Personel Where PerDurum=0", connection);
            SqlDataReader dr3 = command3.ExecuteReader();

            while (dr3.Read())
            {
                lblSingleEmployees.Text = dr3[0].ToString();
            }

            connection.Close();


            //Number of Cities With Distinct
            connection.Open();
            SqlCommand command4 = new SqlCommand("Select Count(Distinct(PerSehir)) From Tbl_Personel", connection);
            SqlDataReader dr4 = command4.ExecuteReader();

            while (dr4.Read())
            {
                lblNumberofCities.Text = dr4[0].ToString();
            }

            connection.Close();


            //Total Salary
            connection.Open();
            SqlCommand command5 = new SqlCommand("Select Sum(PerMaas) From Tbl_Personel", connection);
            SqlDataReader dr5 = command5.ExecuteReader();
            while (dr5.Read())
            {
                lblTotalSalary.Text = dr5[0].ToString();
            }

            connection.Close();


            // Average Salary
            connection.Open();
            SqlCommand command6 = new SqlCommand("Select Avg(PerMaas) From Tbl_Personel", connection);
            SqlDataReader dr6 = command6.ExecuteReader();
            while (dr6.Read())
            {
                lblAverageSalary.Text = dr6[0].ToString();
            }

            connection.Close();

        }
    }
}
