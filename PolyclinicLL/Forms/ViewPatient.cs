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
    public partial class ViewPatient : Form
    {
        public static int Flag { get; set; }

        public ViewPatient()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            labelDate.Text = now.ToString("D");
            labelTime.Text = string.Format($"{DateTime.Now.ToLocalTime().ToShortTimeString()}");
        }

        private void ViewPatient_Load(object sender, EventArgs e)
        {
            PatientLoad();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if ((string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value == null)
            {
                MessageBox.Show("Выберите строку для добавления пользователя");
            }
            else
            {
                Flag = 0;
                AddAndUpdatePatient addAndEditUs = new AddAndUpdatePatient((int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
                addAndEditUs.Show();
                Close();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if ((string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value == null)
            {
                MessageBox.Show("Выберите строку для добавления пользователя");
            }
            else
            {
                Flag = 1;
                AddAndUpdatePatient addAndEditUs = new AddAndUpdatePatient((int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
                addAndEditUs.Show();
                Close();
            }
        }
        private void PatientLoad()
        {
            SqlConnection connect = new SqlConnection(Connect.connection);
            try
            {
                connect.Open();
                string sqlExp = "SELECT [ID_patient],([dbo].[Patient].[LastName] + ' ' + [dbo].[Patient].[FirstName] + ' ' + [dbo].[Patient].[Patronymic]) as FIO, " +
                    " [Adress], DATEDIFF(hour,[dbo].[Patient].Birthday, GETDATE())/ 8766 AS Age, cast([SeriaPas] as varchar) +' ' + cast([NumPas] as varchar) as Passport" +
                    " FROM[dbo].[Patient] JOIn[dbo].[Passport] ON[dbo].[Passport].ID_passport = [dbo].[Patient].ID_passport";
                SqlCommand cmd = new SqlCommand(sqlExp, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
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
            MenuRecept menuRecept = new MenuRecept();
            menuRecept.Show();
            this.Close();
        }


        void DelPatient()
        {
            SqlConnection connection = new SqlConnection(Connect.connection);
            try
            {
                connection.Open();
                string sqlExpression = "EXEC [DelPatient] @id";
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@id", (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Удаление пользователя прошло успешно");
            connection.Close();
        }

        private void buttonDelPat_Click(object sender, EventArgs e)
        {
            if ((string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value == null)
            {
                MessageBox.Show("Выберите строку для удаления данных о пользователе");
            }
            else
            {
                int emp = dataGridView1.CurrentRow.Index;
                if (emp != -1)
                {
                    DialogResult dialogResult = MessageBox.Show($"Вы действительно хотите удалить: {dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value}", 
                        " Предупреждение", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DelPatient();
                        dataGridView1.Rows.Clear();
                        PatientLoad();

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show("Произошла отмена удаления");
                    }
                }
                else
                {
                    MessageBox.Show("Выберите строку для удаления");
                }
            }
        }

        void SearchOnText()
        {
            SqlConnection connection = new SqlConnection(Connect.connection);
            try
            {
                connection.Open();
                string sqlExpression = "SELECT [ID_patient],([dbo].[Patient].[LastName] + ' ' + [dbo].[Patient].[FirstName] + ' ' + [dbo].[Patient].[Patronymic]) as FIO, " +
                    " [Adress], DATEDIFF(hour,[dbo].[Patient].Birthday, GETDATE())/ 8766 AS Age, cast([SeriaPas] as varchar) +' ' + cast([NumPas] as varchar) as Passport" +
                    " FROM[dbo].[Patient] JOIn[dbo].[Passport] ON[dbo].[Passport].ID_passport = [dbo].[Patient].ID_passport WHERE " +
                    " ([dbo].[Patient].[LastName] + ' ' + [dbo].[Patient].[FirstName] + ' ' + [dbo].[Patient].[Patronymic]) LIKE @textSearch";
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@textSearch", "%" + textBoxSearch.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
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

        private void buttonAddRecPat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная функция в разработке");
        }
    }
}
