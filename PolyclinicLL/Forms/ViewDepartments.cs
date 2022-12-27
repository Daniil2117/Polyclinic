using PolyclinicLL.Connection;
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

namespace PolyclinicLL.Forms
{
    public partial class ViewDepartments : Form
    {
        public ViewDepartments()
        {

            InitializeComponent();
            OtdelLoad();
        }
        private void OtdelLoad()
        {
            SqlConnection connect = new SqlConnection(Connect.connection);
            try
            {
                connect.Open();
                string sqlExp = "SElect [NameOtd],([LastName]+' '+[FirstName]+' '+[Patronymic]) as Vrach ,COUNT(Reception.ID_patient) as KolPatient FROM [dbo].[Department]" +
                    " JOIN[dbo].[Employee] ON[dbo].[Employee].ID_dep = Department.ID_dep" +
                    " JOIN Reception ON Reception.ID_employee = Employee.ID_employee" +
                    " GROUP BY NameOtd,[LastName],[FirstName],[Patronymic] ";
                SqlCommand cmd = new SqlCommand(sqlExp, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader[0], reader[1], reader[2]);
                    }
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            connect.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if(Autorization.Role == "А")
            {
                MenuAdmin menuAdmin = new MenuAdmin();  
                menuAdmin.Show();
                Close();
            }
            else
            {
                MenuRecept menuRecept = new MenuRecept();
                menuRecept.Show();
                Close();
            }
        }
        void SearchOnText()
        {
            SqlConnection connection = new SqlConnection(Connect.connection);
            try
            {
                connection.Open();
                string sqlExpression;
                if (comboBoxSelect.SelectedIndex == 0)
                {
                        sqlExpression = "SElect [NameOtd],([LastName]+' '+[FirstName]+' '+[Patronymic]) as Vrach ,COUNT(Reception.ID_patient) " +
                        " as KolPatient FROM [dbo].[Department] JOIN [dbo].[Employee] ON [dbo].[Employee].ID_dep = Department.ID_dep JOIN " +
                        " Reception ON Reception.ID_employee = Employee.ID_employee WHERE [NameOtd] LIKE @textsearch GROUP BY NameOtd,[LastName]," +
                        " [FirstName],[Patronymic]";
                }
                else
                {
                        sqlExpression = "SElect [NameOtd],([LastName]+' '+[FirstName]+' '+[Patronymic]) as Vrach," +
                        " COUNT(Reception.ID_patient) as KolPatient FROM [dbo].[Department]" +
                        " JOIN[dbo].[Employee] ON[dbo].[Employee].ID_dep = Department.ID_dep" +
                        " JOIN Reception ON Reception.ID_employee = Employee.ID_employee" +
                        " WHERE([LastName] + ' ' +[FirstName] + ' ' +[Patronymic]) LIKE @textsearch" +
                        " GROUP BY NameOtd,[LastName],[FirstName],[Patronymic]";
                }
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@textSearch", "%" + textBoxSearch.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader[0], reader[1], reader[2]);
                    }
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SearchOnText();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            labelDate.Text = now.ToString("D");
            labelTime.Text = string.Format($"{DateTime.Now.ToLocalTime().ToShortTimeString()}");
        }

        private void ViewDepartments_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }
    }
}
