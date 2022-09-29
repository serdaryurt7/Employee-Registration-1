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
    public partial class GraphicsFrm : Form
    {
        public GraphicsFrm()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-CQB2NGM\\MSSQLSERVER2019;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void chart1_Click(object sender, EventArgs e)
        {
            //Graphic 1
            connection.Open();

            SqlCommand command = new SqlCommand("Select PerSehir, Count(*) From Tbl_Personel Group By PerSehir",connection);
            SqlDataReader dr1 = command.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Cities"].Points.AddXY(dr1[0], dr1[1]);
            }

            connection.Close();

            //Graphic 2

            connection.Open();
            SqlCommand command1 = new SqlCommand("Select PerMeslek,Avg(PerMaas) From Tbl_Personel Group By PerMeslek",connection);
            SqlDataReader dr2 = command1.ExecuteReader();

            while (dr2.Read())
            {
                chart2.Series["Jobs and Salaries"].Points.AddXY(dr2[0], dr2[1]);
            }

            connection.Close();
        }
    }
}
