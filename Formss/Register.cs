using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Xml.Linq;
using System.IO;


namespace БИ
{
    public partial class Register : Form
    {
        private SqlConnection sqlConnection = null;
        public Register()
        {
            InitializeComponent();
            SecretTextBox.Hide();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Image image = Image.FromFile("C:\\Users\\-\\source\\repos\\БИ\\Resources\\profilbild.jpg");
            byte[] imageconvert = ImageToByteArray(image);
           SqlCommand command = new SqlCommand($"INSERT INTO [People] (Name, Login, Password,Admin,Avatar) Values (@Name, @Login, @Password,@Admin,@Avatar)",
               sqlConnection);
           command.Parameters.AddWithValue("Name",NameTextBox.Text);
           command.Parameters.AddWithValue("Login", LoginTextBox.Text);
           command.Parameters.AddWithValue("Password", PasswordTextBox.Text);
           command.Parameters.AddWithValue("Avatar", imageconvert);
           
            #region LoginTextBoxError 1
            if ( LoginTextBox.Text == "")
            {
                errorProvider1.SetError(LoginTextBox, "Отсутвует логин");
                if ( NameTextBox.Text == "")
                {
                    errorProvider2.SetError(NameTextBox, "Отсутвует имя");
                }
                else
                {
                    errorProvider2.Clear();
                }
                if (PasswordTextBox.Text == "")
                {
                    errorProvider4.SetError(PasswordTextBox, "Пароль отсутсвует");
                }
                else
                {
                    errorProvider4.Clear();
                }
            }
            else
            {
                errorProvider1.Clear();
                #endregion
                #region NameTextBoxError 2
                if (NameTextBox.Text == "")
                {
                    errorProvider1.SetError(NameTextBox, "Отсутвует имя");
                    if (LoginTextBox.Text == "")
                    {
                        errorProvider1.SetError(LoginTextBox, "Отсутвует логин");
                    }
                    else
                    {
                        errorProvider1.Clear();
                    }


                    if (PasswordTextBox.Text == "")
                    {
                        errorProvider4.SetError(PasswordTextBox, "Пароли отсутсвует");

                    }
                    else
                    {
                        errorProvider4.Clear();
                    }
                }
                else
                {
                    errorProvider2.Clear();
                    #endregion
                    #region PasswordTextBoxError 3
                    if ( PasswordTextBox.Text == "")
                    {
                        errorProvider4.SetError(PasswordTextBox, "Пароль отсутсвует");
                        if ( LoginTextBox.Text == "")
                        {
                            errorProvider1.SetError(LoginTextBox, "Отсутвует логин");
                        }
                        else
                        {
                            errorProvider1.Clear();
                        }


                    }
                    else
                    {
                        errorProvider4.Clear();
                        #endregion
                        #region RepeatPasswordTextBoxError 4
                        if (PasswordTextBox.Text != RepeatPasswordTextBox.Text)
                        {
                            errorProvider5.SetError(RepeatPasswordTextBox, "Пароли не совпадают");

                        }
                        else
                        {
                            errorProvider5.Clear();
                            #endregion
                            #region AdminCheck
                            if (SecretTextBox.Text == "Егор")
                            {
                                command.Parameters.AddWithValue("Admin", 1);
                                if (command.ExecuteNonQuery() == 1)
                                {
                                    this.Hide();
                                    Autorization authorization = new Autorization();
                                    authorization.Show();
                                }
                            }
                            else if (SecretTextBox.Text == "")
                            {
                                command.Parameters.AddWithValue("Admin", 0);
                                if (command.ExecuteNonQuery() == 1)
                                {
                                    this.Hide();
                                    Autorization authorization = new Autorization();
                                    authorization.Show();
                                }
                            }
                            else
                            {
                                SecretTextBox.Hide();
                                SecretPictureClick.Hide();
                                Application.Exit();
                            }
                            #endregion
                        }
                        
                    }
                }

            }
                         





        }
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["GameInfoDB"].ConnectionString);
            sqlConnection.Open();
        }

        private void SecretPictureClick_Click(object sender, EventArgs e)
        {
            SecretTextBox.Show();
        }

        private void Authorization_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Autorization autorization = new Autorization();
            this.Hide();
            autorization.Show();
        }
    }
}
