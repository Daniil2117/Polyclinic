using PolyclinicLL.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PolyclinicLL.Forms
{
    public partial class ViewUsers : Form
    {
        public static int Flag { get; set; }

        public ViewUsers()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MenuAdmin menu = new MenuAdmin();
            menu.Show();
            this.Close();
        }

        private void ViewUsers_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            UsersLoad();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            labelDate.Text = now.ToString("D");
            labelTime.Text = string.Format($"{DateTime.Now.ToLocalTime().ToShortTimeString()}");
        }

        private void UsersLoad()
        {
            SqlConnection connect = new SqlConnection(Connect.connection);
                try
                {
                    connect.Open();
                    string sqlExp = "SELECT [LoginUs],[PasswordUs],[dbo].[Employee].[LastName],[dbo].[Employee].[FirstName]," +
                        " [dbo].[Employee].[Patronymic],[NameOtd],[Birthday],[Telephone],[NamePost] FROM [dbo].[Employee] " +
                        " JOIN [dbo].[Users] ON [dbo].[Users].ID_employee = Employee.ID_employee " +
                        " JOIN [dbo].[PostEmployee] ON PostEmployee.ID_postEmpl = Employee.ID_postEmpl " +
                        " JOIN [dbo].[Department] ON Department.ID_dep = Employee.ID_dep";
                    SqlCommand cmd = new SqlCommand(sqlExp, connect);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8]);
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
                Flag = 0;
                AddAndEditUs addAndEditUs = new AddAndEditUs((string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
                addAndEditUs.Show();
                Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if ((string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value == null)
            {
                MessageBox.Show("Выберите строку для изменений данных о пользователе");
            }
            else
            {
                Flag = 1;
                AddAndEditUs addAndEditUs = new AddAndEditUs((string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
                addAndEditUs.Show();
                Close();
            }
        }

        void DelUsers()
        {
            SqlConnection connection = new SqlConnection(Connect.connection);
            try
            {
                connection.Open();
                string sqlExpression = "EXEC DelUsers @email";
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@email", (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);

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

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if ((string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value == null)
            {
                MessageBox.Show("Выберите строку для удаления данных о пользователе");
            }
            else
            {
                int emp = dataGridView1.CurrentRow.Index;
                if (emp != -1)
                {
                    DialogResult dialogResult = MessageBox.Show($"Вы действительно хотите удалить: {dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value} " +
                        $"{dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value} {dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value}", "Предупреждение", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DelUsers();
                        dataGridView1.Rows.Clear();
                        UsersLoad();

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
    }
}
