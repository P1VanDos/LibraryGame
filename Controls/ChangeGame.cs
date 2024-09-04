using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using БИ.Controls;

using System.IO;
using БИ.Page;
using БИ.Controls;
using БИ.Forms;

namespace БИ.Controls
{
    public partial class ChangeGame : UserControl
    {
       

        private SqlConnection sqlConnection;
        
        public byte[] imageconvert1;
        public byte[] imageconvert2;

        public ChangeGame()
        {
            
            InitializeComponent();
            InfoPlatformsGame.Hide();
        }
        

        private void ChangeGame_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["GameInfoDB"].ConnectionString);

            sqlConnection.Open();
            using (SqlCommand commandName = new SqlCommand("SELECT NameGame FROM GameInfo", sqlConnection))
            {
                using (SqlDataReader readerName = commandName.ExecuteReader())
                {
                    while (readerName.Read())
                    {
                        ComboBoxGame.Items.Add(readerName[0].ToString());
                    }
                }
            }
           
            using (SqlCommand commandGenre = new SqlCommand("SELECT GenreGame FROM GameInfo", sqlConnection))
            {
                using (SqlDataReader readerGenre = commandGenre.ExecuteReader())
                {
                    HashSet<string> uniqueGenres = new HashSet<string>();
                    while (readerGenre.Read())
                    {
                        string genre = readerGenre[0].ToString();
                        if (!uniqueGenres.Contains(genre))
                        {
                            uniqueGenres.Add(genre);
                            ComboBoxGenre.Items.Add(genre);
                        }
                    }
                }
            }
            sqlConnection.Close();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (ComboBoxGame.SelectedItem == "")
            {
                MessageBox.Show("Название игры");
            }
            else
            {
                List<string> updateFields = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(ComboBoxGenre.Text))
                {
                    updateFields.Add("GenreGame = @GenreGame");
                    parameters.Add(new SqlParameter("@GenreGame", ComboBoxGenre.Text));
                }

                if (!string.IsNullOrEmpty(DeveloperTextBox.Text))
                {
                    updateFields.Add("DeveloperGame = @DeveloperGame");
                    parameters.Add(new SqlParameter("@DeveloperGame", DeveloperTextBox.Text));
                }

                if (!string.IsNullOrEmpty(PublisherTextBox.Text))
                {
                    updateFields.Add("PublisherGame = @PublisherGame");
                    parameters.Add(new SqlParameter("@PublisherGame", PublisherTextBox.Text));
                }

                if (!string.IsNullOrEmpty(DateTextBox.Text))
                {
                    updateFields.Add("DataGame = @DataGame");
                    parameters.Add(new SqlParameter("@DataGame", DateTextBox.Text));
                }

                if (!string.IsNullOrEmpty(ReviewsTextBox.Text))
                {
                    updateFields.Add("ReviewsTextGame = @ReviewsTextGame");
                    parameters.Add(new SqlParameter("@ReviewsTextGame", ReviewsTextBox.Text));
                }

                if (imageconvert1 != null)
                {
                    updateFields.Add("AvatarPicturesGame = @AvatarPicturesGame");
                    parameters.Add(new SqlParameter("@AvatarPicturesGame", imageconvert1));
                }

                if (imageconvert2 != null)
                {
                    updateFields.Add("BigPicturesGame = @BigPicturesGame");
                    parameters.Add(new SqlParameter("@BigPicturesGame", imageconvert2));
                }

                
                if (updateFields.Count > 0)
                {
                    string updateQuery = $"UPDATE GameInfo SET {string.Join(", ", updateFields)} WHERE NameGame = @NameGame";
                    SqlCommand command = new SqlCommand(updateQuery, sqlConnection);
                    command.Parameters.Add(new SqlParameter("@NameGame", ComboBoxGame.Text));
                    command.Parameters.AddRange(parameters.ToArray());

                    sqlConnection.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        
                    }
                    sqlConnection.Close();
                }
                else
                {
                    MessageBox.Show("Нет данных для обновления");
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


        private void AvatarPicturesBox_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.png; *.jpeg; *.jpg)|*.png;*.jpeg;*.jpg";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    AvatarPicturesBox.Image = Image.FromFile(openFileDialog.FileName);
                    Image image = Image.FromFile(openFileDialog.FileName);
                    imageconvert1 = ImageToByteArray(image);
                }
            }
            
        }

        private void BigPicturesGame_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.png; *.jpeg; *.jpg)|*.png;*.jpeg;*.jpg";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    BigPicturesGame.Image = Image.FromFile(openFileDialog.FileName);
                    Image image = Image.FromFile(openFileDialog.FileName);
                    imageconvert2 = ImageToByteArray(image);
                }
            }
        }

        private void LabelPlatformsGame_MouseEnter(object sender, EventArgs e)
        {
            InfoPlatformsGame.Show();
        }

        private void LabelPlatformsGame_MouseLeave(object sender, EventArgs e)
        {
            InfoPlatformsGame.Hide();
        }
    }
}
