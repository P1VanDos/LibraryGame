using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using БИ;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace БИ.Controls
{
    public partial class AddGames : UserControl
    {
        public byte[] imageconvert1;
        public byte[] imageconvert2;
        public static bool AdminCheck;
        public static string Login;

        private readonly DataBank _user;

        private SqlConnection sqlConnection;
        public AddGames(DataBank user)
        {
            _user = user;
            InitializeComponent();
            InfoPlatformsGame.Hide();
           
        }
        public AddGames()
        {
            InitializeComponent();
            InfoPlatformsGame.Hide();

        }

        private void LabelPlatformsGame_MouseEnter(object sender, EventArgs e)
        {
            InfoPlatformsGame.Show();
        }

        private void LabelPlatformsGame_MouseLeave(object sender, EventArgs e)
        {
            InfoPlatformsGame.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AdminCheck == true)
            {
                sqlConnection.Open();

              
                SqlCommand command = new SqlCommand($"INSERT INTO [GameInfo] (NameGame, GenreGame, DeveloperGame, PublisherGame, DataGame, BigPicturesGame, AvatarPicturesGame, ReviewsTextGame, AdminCheckReviews) " +
                    $"VALUES (@NameGame, @GenreGame, @DeveloperGame, @PublisherGame, @DataGame, @BigPicturesGame, @AvatarPicturesGame, @ReviewsTextGame, @AdminCheckReviews)",
                    sqlConnection);

               
                command.Parameters.AddWithValue("@NameGame", NameTextBox.Text);
                command.Parameters.AddWithValue("@GenreGame", ComboBoxGenre.Text);
                command.Parameters.AddWithValue("@DeveloperGame", DeveloperTextBox.Text);
                command.Parameters.AddWithValue("@PublisherGame", PublisherTextBox.Text);
                DateTime gameDate;
                if (DateTime.TryParse(DateTextBox.Text, out gameDate))
                {
                    command.Parameters.AddWithValue("@DataGame", gameDate);
                }
                else
                {
                    MessageBox.Show("Неправильный формат даты. Введите дату в формате 'ГГГГ-MM-ДД'.");
                    sqlConnection.Close();
                    return;
                }
                command.Parameters.AddWithValue("@ReviewsTextGame", ReviewsTextBox.Text);
                command.Parameters.AddWithValue("@AvatarPicturesGame", imageconvert1);
                command.Parameters.AddWithValue("@BigPicturesGame", imageconvert2);
                command.Parameters.AddWithValue("@AdminCheckReviews", 1);
                
                
                if (string.IsNullOrEmpty(NameTextBox.Text))
                {
                    errorProvider1.SetError(NameTextBox, "Заполните поле");
                }
                else if (string.IsNullOrEmpty(ComboBoxGenre.Text))
                {
                    errorProvider2.SetError(ComboBoxGenre, "Заполните поле");
                }
                else if (string.IsNullOrEmpty(DeveloperTextBox.Text))
                {
                    errorProvider3.SetError(DeveloperTextBox, "Заполните поле");
                }
                else if (string.IsNullOrEmpty(PublisherTextBox.Text))
                {
                    errorProvider4.SetError(PublisherTextBox, "Заполните поле");
                }
                else if (string.IsNullOrEmpty(DateTextBox.Text))
                {
                    errorProvider5.SetError(DateTextBox, "Заполните поле");
                }
                else if (string.IsNullOrEmpty(ReviewsTextBox.Text))
                {
                    errorProvider6.SetError(ReviewsTextBox, "Заполните поле");
                }
                else if (imageconvert1 == null)
                {
                    errorProvider7.SetError(AvatarPicturesBox, "Заполните поле");
                }
                else if (imageconvert2 == null)
                {
                    errorProvider8.SetError(BigPicturesGame, "Заполните поле");
                }
                else
                {
               
                    errorProvider1.Clear();
                    errorProvider2.Clear();
                    errorProvider3.Clear();
                    errorProvider4.Clear();
                    errorProvider5.Clear();
                    errorProvider6.Clear();
                    errorProvider7.Clear();
                    errorProvider8.Clear();

                    if (command.ExecuteNonQuery() == 1)
                    {
                       
                        MessageBox.Show("Игра успешно добавлена");
                    }
                }

                sqlConnection.Close();
            }
        
            else
            {
                sqlConnection.Open();


                SqlCommand command = new SqlCommand($"INSERT INTO [GameInfo] (NameGame, GenreGame, DeveloperGame, PublisherGame, DataGame, BigPicturesGame, AvatarPicturesGame, ReviewsTextGame, AdminCheckReviews) " +
                    $"VALUES (@NameGame, @GenreGame, @DeveloperGame, @PublisherGame, @DataGame, @BigPicturesGame, @AvatarPicturesGame, @ReviewsTextGame, @AdminCheckReviews)",
                    sqlConnection);


                command.Parameters.AddWithValue("@NameGame", NameTextBox.Text);
                command.Parameters.AddWithValue("@GenreGame", ComboBoxGenre.Text);
                command.Parameters.AddWithValue("@DeveloperGame", DeveloperTextBox.Text);
                command.Parameters.AddWithValue("@PublisherGame", PublisherTextBox.Text);
                DateTime gameDate;
                if (DateTime.TryParse(DateTextBox.Text, out gameDate))
                {
                    command.Parameters.AddWithValue("@DataGame", gameDate);
                }
                else
                {
                    MessageBox.Show("Неправильный формат даты. Введите дату в формате 'yyyy-MM-dd'.");
                    sqlConnection.Close();
                    return;
                }
                command.Parameters.AddWithValue("@ReviewsTextGame", ReviewsTextBox.Text);
                command.Parameters.AddWithValue("@AvatarPicturesGame", imageconvert1);
                command.Parameters.AddWithValue("@BigPicturesGame", imageconvert2);
                command.Parameters.AddWithValue("@AdminCheckReviews", 0);
               


                if (string.IsNullOrEmpty(NameTextBox.Text))
                {
                    errorProvider1.SetError(NameTextBox, "Заполните поле");
                }
                else if (string.IsNullOrEmpty(ComboBoxGenre.Text))
                {
                    errorProvider2.SetError(ComboBoxGenre, "Заполните поле");
                }
                else if (string.IsNullOrEmpty(DeveloperTextBox.Text))
                {
                    errorProvider3.SetError(DeveloperTextBox, "Заполните поле");
                }
                else if (string.IsNullOrEmpty(PublisherTextBox.Text))
                {
                    errorProvider4.SetError(PublisherTextBox, "Заполните поле");
                }
                else if (string.IsNullOrEmpty(DateTextBox.Text))
                {
                    errorProvider5.SetError(DateTextBox, "Заполните поле");
                }
                else if (string.IsNullOrEmpty(ReviewsTextBox.Text))
                {
                    errorProvider6.SetError(ReviewsTextBox, "Заполните поле");
                }
                else if (imageconvert1 == null)
                {
                    errorProvider7.SetError(AvatarPicturesBox, "Заполните поле");
                }
                else if (imageconvert2 == null)
                {
                    errorProvider8.SetError(BigPicturesGame, "Заполните поле");
                }
                else
                {
                   
                    errorProvider1.Clear();
                    errorProvider2.Clear();
                    errorProvider3.Clear();
                    errorProvider4.Clear();
                    errorProvider5.Clear();
                    errorProvider6.Clear();
                    errorProvider7.Clear();
                    errorProvider8.Clear();

                    if (command.ExecuteNonQuery() == 1)
                    {
                       
                        MessageBox.Show("Игра успешно добавлена");
                    }
                }

                sqlConnection.Close();
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

        private void AddGames_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["GameInfoDB"].ConnectionString);
            sqlConnection.Open();
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

       

        private void pictureBox1_Click(object sender, EventArgs e)
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
    }
}
