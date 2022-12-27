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
    public partial class MenuVrach : Form
    {
        public MenuVrach()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            labelDate.Text = now.ToString("D");
            labelTime.Text = string.Format($"{DateTime.Now.ToLocalTime().ToShortTimeString()}");
        }

        private void MenuVrach_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            labelFIO.Text = Autorization.Fio;
            VivodPicture();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.Show();
            Close();
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
                    command.Parameters.AddWithValue("@login", Autorization.UserId);
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

        private void buttonViewReception_Click(object sender, EventArgs e)
        {
            ViewReception viewReception = new ViewReception();
            viewReception.Show();
            Close();
        }
    }
}
