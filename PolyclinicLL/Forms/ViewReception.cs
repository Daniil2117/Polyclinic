using PolyclinicLL.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyclinicLL.Forms
{
    public partial class ViewReception : Form
    {
        public ViewReception()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            labelDate.Text = now.ToString("D");
            labelTime.Text = string.Format($"{DateTime.Now.ToLocalTime().ToShortTimeString()}");
        }

        private void ViewReception_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            if(Autorization.Role == "Р")
            {
                ReceptionLoadReg();
                buttonСardPatient.Visible = false;
            }
            else
            {
                ReceptionLoad();
            }
        }

        private void ReceptionLoadReg()
        {
            SqlConnection connect = new SqlConnection(Connect.connection);
            try
            {
                connect.Open();
                string sqlExp = " SELECT [ID_reception],([dbo].[Patient].[LastName] + ' ' +[dbo].[Patient].FirstName +' '+ [dbo].[Patient].Patronymic)" +
                    " as Patient, [NameProc],[DateRecep],[TimeRecep] FROM[dbo].[Reception]" +
                    " JOIN[dbo].[Procedures] ON[dbo].[Procedures].ID_proc = [dbo].[Reception].ID_proc" +
                    " JOIN[dbo].[Patient] ON[dbo].[Patient].ID_patient = [dbo].[Reception].ID_patient" +
                    " JOIN[dbo].[Employee] ON[dbo].[Employee].ID_employee = [dbo].[Reception].ID_employee" +
                    " JOIN[dbo].[Users] ON[dbo].[Users].ID_employee = [dbo].[Employee].ID_employee";
                SqlCommand cmd = new SqlCommand(sqlExp, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3].ToString().Substring(0, 10), reader[4]);
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

        private void ReceptionLoad()
        {
            SqlConnection connect = new SqlConnection(Connect.connection);
            try
            {
                connect.Open();
                string sqlExp = "SELECT [ID_reception],([dbo].[Patient].[LastName] + ' ' +[dbo].[Patient].FirstName +' '+ [dbo].[Patient].Patronymic)" +
                    " as Patient, [NameProc],[DateRecep],[TimeRecep] FROM[dbo].[Reception]" +
                    " JOIN[dbo].[Procedures] ON[dbo].[Procedures].ID_proc = [dbo].[Reception].ID_proc" +
                    " JOIN[dbo].[Patient] ON[dbo].[Patient].ID_patient = [dbo].[Reception].ID_patient" +
                    " JOIN[dbo].[Employee] ON[dbo].[Employee].ID_employee = [dbo].[Reception].ID_employee" +
                    " JOIN[dbo].[Users] ON[dbo].[Users].ID_employee = [dbo].[Employee].ID_employee" +
                    " WHERE[LoginUs] = @idlogin";
                SqlCommand cmd = new SqlCommand(sqlExp, connect);
                cmd.Parameters.AddWithValue("@idlogin", Autorization.UserId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3].ToString().Substring(0, 10),reader[4]);
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
            if(Autorization.Role == "В")
            {
                MenuVrach menuVrach = new MenuVrach();
                menuVrach.Show();
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
                string sqlExpression = " EXEC SearchPatient @idlogin, @patient";
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@idlogin", Autorization.UserId);
                cmd.Parameters.AddWithValue("@patient", "%" + textBoxSearch.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3].ToString().Substring(0, 10), reader[4]);
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


        void SearchOnTextReg()
        {
            SqlConnection connection = new SqlConnection(Connect.connection);
            try
            {
                connection.Open();
                string sqlExpression = "EXEC SearchPatientReg @patient";
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@patient", "%" + textBoxSearch.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3].ToString().Substring(0, 10), reader[4]);
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

        void SearchOnData()
        {
            SqlConnection connection = new SqlConnection(Connect.connection);
            try
            {
                connection.Open();
                string sqlExpression = " SELECT [ID_reception],([dbo].[Patient].[LastName] + ' ' +[dbo].[Patient].FirstName +' '+ [dbo].[Patient].Patronymic)" +
                    " as Patient, [NameProc],[DateRecep],[TimeRecep] FROM[dbo].[Reception]" +
                    " JOIN[dbo].[Procedures] ON[dbo].[Procedures].ID_proc = [dbo].[Reception].ID_proc" +
                    " JOIN[dbo].[Patient] ON[dbo].[Patient].ID_patient = [dbo].[Reception].ID_patient" +
                    " JOIN[dbo].[Employee] ON[dbo].[Employee].ID_employee = [dbo].[Reception].ID_employee" +
                    " JOIN[dbo].[Users] ON[dbo].[Users].ID_employee = [dbo].[Employee].ID_employee" +
                    " WHERE[LoginUs] = @idlogin AND [DateRecep] = @date";
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@idlogin", Autorization.UserId);
                cmd.Parameters.AddWithValue("@date", dateSearch.Value.ToString());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3].ToString().Substring(0, 10), reader[4]);
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

        void SearchOnDataR()
        {
            SqlConnection connection = new SqlConnection(Connect.connection);
            try
            {
                connection.Open();
                string sqlExpression = " SELECT [ID_reception],([dbo].[Patient].[LastName] + ' ' +[dbo].[Patient].FirstName +' '+ [dbo].[Patient].Patronymic)" +
                    " as Patient, [NameProc],[DateRecep],[TimeRecep] FROM[dbo].[Reception]" +
                    " JOIN[dbo].[Procedures] ON[dbo].[Procedures].ID_proc = [dbo].[Reception].ID_proc" +
                    " JOIN[dbo].[Patient] ON[dbo].[Patient].ID_patient = [dbo].[Reception].ID_patient" +
                    " JOIN[dbo].[Employee] ON[dbo].[Employee].ID_employee = [dbo].[Reception].ID_employee" +
                    " JOIN[dbo].[Users] ON[dbo].[Users].ID_employee = [dbo].[Employee].ID_employee" +
                    " WHERE [DateRecep] = @date";
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@date", dateSearch.Value.ToString());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3].ToString().Substring(0, 10), reader[4]);
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


        void SearchOnTextAndData()
        {
            SqlConnection connection = new SqlConnection(Connect.connection);
            try
            {
                connection.Open();
                string sqlExpression = " SELECT [ID_reception],([dbo].[Patient].[LastName] + ' ' +[dbo].[Patient].FirstName +' '+ [dbo].[Patient].Patronymic)" +
                    " as Patient, [NameProc],[DateRecep],[TimeRecep] FROM[dbo].[Reception]" +
                    " JOIN[dbo].[Procedures] ON[dbo].[Procedures].ID_proc = [dbo].[Reception].ID_proc" +
                    " JOIN[dbo].[Patient] ON[dbo].[Patient].ID_patient = [dbo].[Reception].ID_patient" +
                    " JOIN[dbo].[Employee] ON[dbo].[Employee].ID_employee = [dbo].[Reception].ID_employee" +
                    " JOIN[dbo].[Users] ON[dbo].[Users].ID_employee = [dbo].[Employee].ID_employee" +
                    " WHERE[LoginUs] = @idlogin AND([dbo].[Patient].[LastName] + ' ' +[dbo].[Patient].FirstName + ' ' + [dbo].[Patient].Patronymic) LIKE @patient" +
                    " AND [DateRecep] = @date";
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@idlogin", Autorization.UserId);
                cmd.Parameters.AddWithValue("@patient", "%" + textBoxSearch.Text + "%");
                cmd.Parameters.AddWithValue("@date", dateSearch.Value.ToString());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3].ToString().Substring(0, 10), reader[4]);
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

        void SearchOnTextAndDataReg()
        {
            SqlConnection connection = new SqlConnection(Connect.connection);
            try
            {
                connection.Open();
                string sqlExpression = " SELECT [ID_reception],([dbo].[Patient].[LastName] + ' ' +[dbo].[Patient].FirstName +' '+ [dbo].[Patient].Patronymic)" +
                    " as Patient, [NameProc],[DateRecep],[TimeRecep] FROM[dbo].[Reception]" +
                    " JOIN[dbo].[Procedures] ON[dbo].[Procedures].ID_proc = [dbo].[Reception].ID_proc" +
                    " JOIN[dbo].[Patient] ON[dbo].[Patient].ID_patient = [dbo].[Reception].ID_patient" +
                    " JOIN[dbo].[Employee] ON[dbo].[Employee].ID_employee = [dbo].[Reception].ID_employee" +
                    " JOIN[dbo].[Users] ON[dbo].[Users].ID_employee = [dbo].[Employee].ID_employee" +
                    " WHERE ([dbo].[Patient].[LastName] + ' ' +[dbo].[Patient].FirstName + ' ' + [dbo].[Patient].Patronymic) LIKE @patient" +
                    " AND [DateRecep] = @date";
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@patient", "%" + textBoxSearch.Text + "%");
                cmd.Parameters.AddWithValue("@date", dateSearch.Value.ToString());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3].ToString().Substring(0, 10), reader[4]);
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
            if (Autorization.UserId == "В")
            {

                dataGridView1.Rows.Clear();
                SearchOnText();
            }
            else
            {
                dataGridView1.Rows.Clear();
                SearchOnTextReg();
            }
        }

        private void dateSearch_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBoxSearch.Text = "";
            dateSearch.Value = DateTime.Today;
            if (Autorization.UserId == "В")
            {
                ReceptionLoad();
            }
            else
            {
                ReceptionLoadReg();

            }
        }

        private void buttonСardPatient_Click(object sender, EventArgs e)
        {
            if((string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value == null)
            {
                MessageBox.Show("Выберите строку для открытия карты");
            }
            else
            {
                CardPatient cardPatient = new CardPatient((string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value, (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
                cardPatient.Show();
                this.Close();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if(Autorization.UserId == "В")
            {
                if (textBoxSearch.Text != "" || dateSearch.Text != "")
                {
                    dataGridView1.Rows.Clear();
                    SearchOnTextAndData();
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    SearchOnData();
                }
            }
            else
            {
                if (textBoxSearch.Text != "" || dateSearch.Text != "")
                {
                    dataGridView1.Rows.Clear();
                    SearchOnTextAndDataReg();
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    SearchOnDataR();
                }
            }
        }
    }
}
