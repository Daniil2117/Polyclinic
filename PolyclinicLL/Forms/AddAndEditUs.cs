using PolyclinicLL.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PolyclinicLL.Forms
{
    public partial class AddAndEditUs : Form
    {
        string id_shed;
        public AddAndEditUs(string Id_shedule)
        {
            InitializeComponent();
            id_shed = Id_shedule;
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        void LoadTextBox()
        {
            SqlConnection connection = new SqlConnection(Connect.connection);
            try
            {
                connection.Open();
                string sqlExp = "SELECT [LoginUs],[PasswordUs],[dbo].[Employee].[LastName],[dbo].[Employee].[FirstName]," +
                       " [dbo].[Employee].[Patronymic],[Birthday],[Telephone],[NamePost],[Photo] FROM [dbo].[Employee] " +
                       " JOIN [dbo].[Users] ON [dbo].[Users].ID_employee = Employee.ID_employee " +
                       " JOIN [dbo].[PostEmployee] ON PostEmployee.ID_postEmpl = Employee.ID_postEmpl " +
                       " JOIN [dbo].[Department] ON Department.ID_dep = Employee.ID_dep WHERE [LoginUs] = @id_shedule";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                cmd.Parameters.AddWithValue("@id_shedule", id_shed);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        textBoxLogin.Text = reader[0].ToString();
                        textBoxPassword.Text = reader[1].ToString();
                        textBoxLastName.Text = reader[2].ToString();
                        textBoxName.Text = reader[3].ToString();
                        textBoxPatronymic.Text = reader[4].ToString();
                        dateBirthday.Text = reader[5].ToString();
                        textBoxPhone.Text = reader[6].ToString();
                        comboBoxPost.Text = reader[7].ToString();
                        textBoxPhotoLoad.Text = reader[8].ToString();
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

        void ComboPostEmployee()
        {
            SqlConnection connection = new SqlConnection(Connect.connection);
            try
            {
                connection.Open();
                string sqlExp = "SELECT DISTINCT [dbo].[PostEmployee].[NamePost] FROM [dbo].[PostEmployee]";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        comboBoxPost.Items.Add(reader[0].ToString());
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

        void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void AddAndEditUs_Load(object sender, EventArgs e)
        {
            dateBirthday.Value = new DateTime(2000, 1, 1);
            comboBoxPost.KeyPress += OnKeyPress;
            textBoxPhotoLoad.Enabled= false;
            if (ViewUsers.Flag == 0)
            {
                labelTitleP.Text = "Добавление пользователя в систему";
                buttonEdit.Visible= false; 
                buttonAdd.Visible= true;
            }
            if (ViewUsers.Flag == 1)
            {
                LoadTextBox();
                VivodPicture();
                labelTitleP.Text = "Изменение данных о пользователе";
                buttonEdit.Visible = true;
                buttonAdd.Visible = false;
                textBoxPasswordTwo.Visible= false;
                label4.Visible= false;
                comboBoxPost.Enabled= false;
            }
            ComboPostEmployee();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ViewUsers viewUsers = new ViewUsers();
            viewUsers.Show();
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            labelDate.Text = now.ToString("D");
            labelTime.Text = string.Format($"{DateTime.Now.ToLocalTime().ToShortTimeString()}");
        }

        public bool CheckPassword(string q, string w)
        {
            bool f, f1, f2;
            f = f1 = f2 = false;
            for (int i = 0; i < q.Length; i++)
            {
                if (Char.IsDigit(q[i])) f1 = true;
                if (Char.IsUpper(q[i])) f2 = true;
                if (f1 && f2) break;
            }
            if (!(f1 && f2))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну цифру и одну заглавную букву!");
                return f1 && f2;
            }
            else
            {
                string simbol = "!@#$%^";
                for (int i = 0; i < q.Length; i++)
                {
                    for (int j = 0; j < simbol.Length; j++)
                    {
                        if (q[i] == simbol[j])
                        {
                            f = true;
                            break;
                        }
                    }
                }
                if (!f) MessageBox.Show("Пароль должен содержать один из символов !@#$%^");
                if ((q == w) && f) return true; else { MessageBox.Show("Неверное подтвержден пароль"); return false; }
            }
        }
        bool UserCheck()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(Connect.connection))
                {
                    connect.Open();

                    string sqlExp = "SELECT [LoginUs] FROM Users WHERE LoginUs = @login";
                    SqlCommand cmd = new SqlCommand(sqlExp, connect);
                    cmd.Parameters.AddWithValue("@login", textBoxLogin.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Такой логин уже есть");
                        return false;
                    }
                    else
                    {
                        reader.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        void AddUsers()
        {
            DateTime dateTime2 = DateTime.Parse(dateBirthday.Value.ToShortDateString());
            SqlConnection connection = new SqlConnection(Connect.connection);
            try
            {
                connection.Open();
                string sqlExpression = "EXEC InsertUsers @lastname,@firstname," +
                    " @patronymic, @date_of_birth," +
                    " @phone,@namePost,@email,@password,@photo";
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@email", textBoxLogin.Text);
                cmd.Parameters.AddWithValue("@password", textBoxPassword.Text);
                cmd.Parameters.AddWithValue("@lastname", textBoxLastName.Text);
                cmd.Parameters.AddWithValue("@firstname", textBoxName.Text);
                cmd.Parameters.AddWithValue("@patronymic", textBoxPatronymic.Text);
                cmd.Parameters.AddWithValue("@date_of_birth", dateTime2);
                cmd.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                cmd.Parameters.AddWithValue("@namePost", comboBoxPost.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@photo", textBoxPhotoLoad.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Добавление пользователя прошло успешно");
            connection.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxLastName.Text == "" || textBoxLogin.Text == "" || textBoxPatronymic.Text == "" || textBoxPhone.Text == "" 
                   || textBoxPassword.Text == "" || dateBirthday.Value.ToString() == ""
                   || textBoxName.Text == "" || textBoxPasswordTwo.Text == "" || textBoxPhotoLoad.Text == "" || comboBoxPost.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните все поля!");
            }

            else
            {
                bool rez = CheckPassword(textBoxPassword.Text, textBoxPasswordTwo.Text);
                if (!rez) return;
                else
                    if (UserCheck()) AddUsers();
                else return;
                ViewUsers viewUsers = new ViewUsers();
                viewUsers.Show();
                this.Close();
            }
        }

        private void textBoxLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && !(e.KeyChar == (char)8))
            {
                e.Handled = true;
            }
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && !(e.KeyChar == (char)8))
            {
                e.Handled = true;
            }
        }

        private void textBoxPatronymic_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && !(e.KeyChar == (char)8))
            {
                e.Handled = true;
            }
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != (char)(Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    if (textBoxPhone.Text.Length > 10)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void dateBirthday_ValueChanged(object sender, EventArgs e)
        {
            int dateStart = DateTime.Now.Year;
            int dateEnd = dateBirthday.Value.Year;
            int itog = dateStart - dateEnd;
            if (itog < 18)
            {
                MessageBox.Show("Сотрудник не может быть моложе 18");
                dateBirthday.Value = new DateTime(2000, 1, 1);
            }
        }

        private void buttonLoadPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = @"Поликлиника\PolyclinicLL\PolyclinicLL\bin\Debug\Images";
            openFileDialog.Title = "Please select an image file.";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                    textBoxPhotoLoad.Text = openFileDialog.SafeFileName.ToString();
                }
                catch
                {
                    MessageBox.Show("Не удалось открыть фотографию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void VivodPicture()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(Connect.connection))
                {
                    connect.Open();
                    string sqlExp = "Select [Photo] from [dbo].[Users]" +
                                    $"where [LoginUs] = @login";
                    SqlCommand command = new SqlCommand(sqlExp, connect);
                    command.Parameters.AddWithValue("@login", id_shed);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    try
                    {
                        pictureBox1.Image = (Bitmap)Image.FromFile($@"Images/{reader[0]}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "Фотография отсутсвует");
                    }
                    reader.Close();
                }
            }
            catch (SqlException Exp)
            {
                MessageBox.Show(Exp.Message);
            }
        }

        void UpdateUsers()
        {
            DateTime dateTime2 = DateTime.Parse(dateBirthday.Value.ToShortDateString());
            SqlConnection connection = new SqlConnection(Connect.connection);
            try
            {
                connection.Open();
                string sqlExpression = "EXEC UpdateUsers @lastname,@firstname," +
                    " @patronymic,@date_of_birth," +
                    " @phone,@namePost,@email,@password,@photo";
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@email", textBoxLogin.Text);
                cmd.Parameters.AddWithValue("@password", textBoxPassword.Text);
                cmd.Parameters.AddWithValue("@lastname", textBoxLastName.Text);
                cmd.Parameters.AddWithValue("@firstname", textBoxName.Text);
                cmd.Parameters.AddWithValue("@patronymic", textBoxPatronymic.Text);
                cmd.Parameters.AddWithValue("@date_of_birth", dateTime2);
                cmd.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                cmd.Parameters.AddWithValue("@namePost", comboBoxPost.Text.ToString());
                cmd.Parameters.AddWithValue("@photo", textBoxPhotoLoad.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Обновление прошло успешно");
            connection.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (textBoxLastName.Text == "" || textBoxLogin.Text == "" || textBoxPatronymic.Text == "" || textBoxPhone.Text == "" 
                   || textBoxPassword.Text == "" || dateBirthday.Value.ToString() == ""
                   || textBoxName.Text == "" || textBoxPhotoLoad.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }

            else
            {
                UpdateUsers();
                ViewUsers viewUsers = new ViewUsers();
                viewUsers.Show();
                this.Close();
            }
        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
