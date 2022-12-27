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

namespace PolyclinicLL.Forms
{
    public partial class AddAndUpdatePatient : Form
    {
        int index;
        public AddAndUpdatePatient(int index)
        {
            InitializeComponent();
            this.index = index;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            labelDate.Text = now.ToString("D");
            labelTime.Text = string.Format($"{DateTime.Now.ToLocalTime().ToShortTimeString()}");
        }

        private void AddAndUpdatePatient_Load(object sender, EventArgs e)
        {
            if(ViewPatient.Flag == 0)
            {
                buttonUpdate.Visible= false;
                labelTitleP.Text = "Добавление нового пациента";
            }
            else
            {
                PatientLoad();
                buttonUpdate.Visible= true;
                buttonAddRecPat.Visible= false;
            }
            timer1.Enabled = true;
            timer1.Interval = 1000;
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

        private void textBoxNumPassport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != (char)(Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    if (textBoxNumPassport.Text.Length > 5)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void PatientLoad()
        {
            SqlConnection connect = new SqlConnection(Connect.connection);
            try
            {
                connect.Open();
                string sqlExp = "EXEC [dbo].[LoadPatient] @id";
                SqlCommand cmd = new SqlCommand(sqlExp, connect);
                cmd.Parameters.AddWithValue("@id", index);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        textBoxLastName.Text = reader[0].ToString();
                        textBoxName.Text = reader[1].ToString();    
                        textBoxPatronymic.Text = reader[2].ToString();
                        dateBirthday.Text = reader[3].ToString();
                        textBoxSeriaPassport.Text = reader[4].ToString();
                        textBoxNumPassport.Text = reader[5].ToString();
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
            ViewPatient viewPatient = new ViewPatient();
            viewPatient.Show();
            this.Close();
        }

        private void textBoxSeriaPassport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != (char)(Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    if (textBoxSeriaPassport.Text.Length > 3)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void AddPatient()
        {
            DateTime dateTime2 = DateTime.Parse(dateBirthday.Value.ToShortDateString());
            SqlConnection connect = new SqlConnection(Connect.connection);
            try
            {
                connect.Open();
                string sqlExp = "EXEC AddPatient @LastName,@FirstName,@Patronymic,@Birthday,@SeriaPas,@NumPas";
                SqlCommand cmd = new SqlCommand(sqlExp, connect);
                cmd.Parameters.AddWithValue("@LastName", textBoxLastName.Text);
                cmd.Parameters.AddWithValue("@FirstName", textBoxName.Text);
                cmd.Parameters.AddWithValue("@Patronymic", textBoxPatronymic.Text);
                cmd.Parameters.AddWithValue("@Birthday", dateTime2);
                cmd.Parameters.AddWithValue("@SeriaPas", int.Parse(textBoxSeriaPassport.Text));
                cmd.Parameters.AddWithValue("@NumPas", int.Parse(textBoxNumPassport.Text));

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            connect.Close();
        }

        private void UpdatePatient()
        {
            DateTime dateTime2 = DateTime.Parse(dateBirthday.Value.ToShortDateString());
            SqlConnection connect = new SqlConnection(Connect.connection);
            try
            {
                connect.Open();
                string sqlExp = "EXEC UpdatePatient @LastName,@FirstName,@Patronymic,@Birthday,@SeriaPas,@NumPas,@idpatient";
                SqlCommand cmd = new SqlCommand(sqlExp, connect);
                cmd.Parameters.AddWithValue("@LastName", textBoxLastName.Text);
                cmd.Parameters.AddWithValue("@FirstName", textBoxName.Text);
                cmd.Parameters.AddWithValue("@Patronymic", textBoxPatronymic.Text);
                cmd.Parameters.AddWithValue("@Birthday", dateTime2);
                cmd.Parameters.AddWithValue("@SeriaPas", int.Parse(textBoxSeriaPassport.Text));
                cmd.Parameters.AddWithValue("@NumPas", int.Parse(textBoxNumPassport.Text));
                cmd.Parameters.AddWithValue("@idpatient", index);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            connect.Close();
        }

        private void buttonAddRecPat_Click(object sender, EventArgs e)
        {
            if(textBoxLastName.Text == "" || textBoxName.Text == "" || textBoxPatronymic.Text == "" 
                || dateBirthday.Text == "" || textBoxNumPassport.Text == "" || textBoxSeriaPassport.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
                if(textBoxNumPassport.Text.Length != 6 && textBoxSeriaPassport.Text.Length != 4)
                {
                    MessageBox.Show("Проверьте номер и серию паспорт на корректность!");
                }
            }
            else
            {
                AddPatient();
                MessageBox.Show("Пациент успешно добавлен!");
                ViewPatient viewPatient = new ViewPatient();
                viewPatient.Show();
                this.Close();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxLastName.Text == "" || textBoxName.Text == "" || textBoxPatronymic.Text == ""
                || dateBirthday.Text == "" || textBoxNumPassport.Text == "" || textBoxSeriaPassport.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
                if (textBoxNumPassport.Text.Length != 6 && textBoxSeriaPassport.Text.Length != 4)
                {
                    MessageBox.Show("Проверьте номер и серию паспорт на корректность!");
                }
            }
            else
            {
                UpdatePatient();
                MessageBox.Show("Данные об пациенте успешно изменены!");
                ViewPatient viewPatient = new ViewPatient();
                viewPatient.Show();
                this.Close();
            }
        }
    }
}
