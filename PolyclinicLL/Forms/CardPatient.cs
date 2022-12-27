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
    public partial class CardPatient : Form
    {
        string namepatient;
        int index;
        public CardPatient(string namepat, int index)
        {
            InitializeComponent();
            namepatient = namepat;
            this.index = index;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            ViewReception viewReception = new ViewReception();
            viewReception.Show();
            this.Close();
        }

        void LoadCard()
        {
            SqlConnection connection = new SqlConnection(Connect.connection);
            try
            {
                connection.Open();
                string sqlExp = "SELECT [LastName],[FirstName],[Patronymic],DATEDIFF(hour,[dbo].[Patient].Birthday,GETDATE())/8766 AS Age, [NameDiag] FROM [dbo].[Patient]" +
                    " JOIN[dbo].[Reception] ON[dbo].[Reception].ID_patient = Patient.ID_patient" +
                    " JOIN Recep_Diagnosis ON Reception.ID_reception = Recep_Diagnosis.ID_reception" +
                    " JOIN Diagnosis ON Diagnosis.ID_diagnos = Recep_Diagnosis.ID_diagnos" +
                    " WHERE([dbo].[Patient].[LastName] + ' ' +[dbo].[Patient].FirstName + ' ' + [dbo].[Patient].Patronymic) = @namepatient";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                cmd.Parameters.AddWithValue("@namepatient",namepatient);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        labelLasName.Text = reader[0].ToString();
                        labelName.Text = reader[1].ToString();
                        labelPatronomyc.Text = reader[2].ToString();
                        labelAge.Text = reader[3].ToString();
                        comboBoxDiagn.Text = reader[4].ToString();
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

        void ComboBoxDiagnosis()
        {
            SqlConnection connection = new SqlConnection(Connect.connection);
            try
            {
                connection.Open();
                string sqlExp = "SELECT DISTINCT [dbo].[Diagnosis].[NameDiag] FROM [dbo].[Diagnosis] " +
                    " JOIN [dbo].[Recep_Diagnosis] ON [dbo].[Diagnosis].ID_diagnos = Recep_Diagnosis.ID_diagnos " +
                    " JOIN [dbo].[Reception] ON Reception.ID_reception = Recep_Diagnosis.ID_reception" +
                    " JOIN [dbo].[Employee] ON Employee.ID_employee = Reception.ID_employee " +
                    " JOIN [dbo].[Users] ON Users.ID_employee = Employee.ID_employee" +
                    " WHERE [LoginUs] = @login";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                cmd.Parameters.AddWithValue("@login", Autorization.UserId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        comboBoxDiagn.Items.Add(reader[0].ToString());
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

        private void CardPatient_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            ComboBoxDiagnosis();
            LoadCard();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxDiagn.Text.ToString() != "")
            {
                UpdateDiagnosis();
            }
            else
            {
                MessageBox.Show("Выберите диагноз");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            labelDate.Text = now.ToString("D");
            labelTime.Text = string.Format($"{DateTime.Now.ToLocalTime().ToShortTimeString()}");
        }

        void UpdateDiagnosis()
        {
            SqlConnection connection = new SqlConnection(Connect.connection);
            try
            {
                connection.Open();
                string sqlExpression = "EXEC [dbo].[UpdateDiagnosis] @name,@id";
                SqlCommand cmd = new SqlCommand(sqlExpression, connection);
                cmd.Parameters.AddWithValue("@name", comboBoxDiagn.Text);
                cmd.Parameters.AddWithValue("@id", index);
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

    }
}
