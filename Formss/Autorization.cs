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
using System.Configuration;
using System.IO;
using БИ.Controls;
using БИ.Page;

namespace БИ
{
    public partial class Autorization : Form
    {
        DataBank databank;
        public Autorization()
        {
            databank = new DataBank();
            InitializeComponent();
            
        }

        private void Autorization_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command1 = new SqlCommand("SELECT * FROM People WHERE Login=@Login AND Password=@Password "
                , databank.SqlConnection());
            command1.Parameters.AddWithValue("@Login", LoginTextBox.Text);
            command1.Parameters.AddWithValue("@Password", PasswordTextBox.Text);
           
            adapter.SelectCommand = command1;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                
                
                var user = new DataBank(table.Rows[0].ItemArray[1].ToString(),
                    table.Rows[0].ItemArray[3].ToString(),
                    Convert.ToBoolean(table.Rows[0].ItemArray[4]), 
                    (byte[])table.Rows[0]["Avatar"]);
                
                    
                errorProvider1.Clear();
                errorProvider2.Clear();

                this.Hide();
                ShpakGamesForm shpakGamesForm = new ShpakGamesForm(user);
                AddGames addGames = new AddGames(user);
                shpakGamesForm.Show();
               
            }
            else
            {
                errorProvider1.SetError(LoginTextBox, "Неправильный логин или пароль");
                errorProvider2.SetError(PasswordTextBox, "Неправильный логин или пароль");
            }

           

        }

        private void SecretPictureClick_Click(object sender, EventArgs e)
        {
           
        }
        
    }
}
