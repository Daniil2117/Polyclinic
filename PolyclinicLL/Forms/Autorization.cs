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
    public partial class Autorization : Form
    {
        public static string Fio { get; set; }
        public static string UserId { get; set; }
        public static string Role { get; set; }

        public Autorization()
        {
            InitializeComponent();
            Fio = "";
            UserId = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            labelDate.Text = now.ToString("D");
            labelTime.Text = string.Format($"{DateTime.Now.ToLocalTime().ToShortTimeString()}");
        }

        private void Autorization_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        void CheckAutorize()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(Connect.connection))
                {
                    connect.Open();

                    if (!(textBoxLogin.Text != "" && textBoxPassword.Text != ""))
                    {
                        MessageBox.Show("Введите данные"); return;
                    }
                    string sqlExp = "SELECT [LastName],[PasswordUs],[FirstName],[Patronymic],[dbo].[Employee].[ID_employee],[ID_role]," +
                        " [LoginUs] FROM [dbo].[Employee] JOIN [dbo].[Users] ON [dbo].[Users].ID_employee = [dbo].[Employee].ID_employee " +
                        " WHERE [LoginUs] = @login";
                    SqlCommand cmd = new SqlCommand(sqlExp, connect);
                    cmd.Parameters.AddWithValue("@login", textBoxLogin.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Fio = reader["LastName"].ToString() + " " + reader["FirstName"].ToString() + " " + reader["Patronymic"].ToString();
                        UserId = reader["LoginUs"].ToString();
                        Role = reader["ID_role"].ToString();

                        if (reader[1].ToString() == textBoxPassword.Text)
                            switch (reader["ID_role"])
                            {
                                case "А":
                                    MenuAdmin menuAdmin = new MenuAdmin();
                                    menuAdmin.Show();
                                    Close();
                                    break;
                                case "В":
                                    MenuVrach menuVrach = new MenuVrach();
                                    menuVrach.Show();
                                    Close();
                                    break;
                               case "Р":
                                    MenuRecept menuRecept = new MenuRecept();
                                    menuRecept.Show();
                                    Close();
                                    break;
                                default:
                                    MessageBox.Show("Ошибка роли");
                                    break;
                            }
                        else
                        {
                            MessageBox.Show("Неверный пароль");
                            textBoxPassword.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нет такого пользователя");
                        textBoxLogin.Text = "";
                        textBoxPassword.Text = "";
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void buttonAutorization_Click(object sender, EventArgs e)
        {
            CheckAutorize();
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            textBoxLogin.Text = "regist1@";
            textBoxPassword.Text = "Registr123!";
        }

        private void buttonVrach_Click(object sender, EventArgs e)
        {
            textBoxLogin.Text = "vrach3@";
            textBoxPassword.Text = "VrachSys3!";
        }

        private void buttonAdm_Click(object sender, EventArgs e)
        {
            textBoxLogin.Text = "admin1@";
            textBoxPassword.Text = "Admin123!";
        }
    }
}
