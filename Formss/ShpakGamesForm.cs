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
using БИ.Page;

namespace БИ
{
    
    public partial class ShpakGamesForm : Form
    {
        private readonly DataBank _user;
        public static string NameGameVitrine;

        private SqlConnection sqlConnection;
        static private string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

        private string WhiteRead = Path.Combine(appDirectory, "Pictures", "White", "WhiteRead.png");
        private string WhiteRec = Path.Combine(appDirectory, "Pictures", "White", "WhiteRec.png");
        private string BestWhite = Path.Combine(appDirectory, "Pictures", "White", "BestWhite.png");
        private string WhiteNew = Path.Combine(appDirectory, "Pictures", "White", "WhiteNew.png");
        private string NotBigPictures = Path.Combine(appDirectory, "Pictures", "GameAvatar", "NotBigPictures.jpg");
        private string NotPictures = Path.Combine(appDirectory, "Pictures", "GameAvatar", "NotPictures.png");
        private string RedRead = Path.Combine(appDirectory, "Pictures", "Red", "RedRead.png");
        private string RedRec = Path.Combine(appDirectory, "Pictures", "Red", "RedRec.png");
        private string RedNew = Path.Combine(appDirectory, "Pictures", "Red", "RedNew.png");
        private string TopRed = Path.Combine(appDirectory, "Pictures", "Red", "TopRed.png");
        private string InfWhite = Path.Combine(appDirectory, "Pictures", "White", "InfWhite.png");
        private string RedInfo = Path.Combine(appDirectory, "Pictures", "Red", "RedInfo.png");

        GameReviews gameReviews = new GameReviews();

        public int CountClick;
        public int CountClickd;

        public int CountClick1 = 1;
        public int CountClick2 = 1;
        public int CountClick3 = 1;
        public bool exp;


        public ShpakGamesForm(DataBank user)
        {
            
            
            _user = user;
            InitializeComponent();
            BG_AccounteClick.Hide();
            GenreInfo.Hide();
            BG_AvatarAdd.Hide();
            InfoPlatformsGame.Hide();

            comboBox1.Items.Add("Все жанры");
            
            PITSRead1.Image = Image.FromFile(WhiteRead);
            PITSRead2.Image = Image.FromFile(WhiteRead);
            PITSRead3.Image = Image.FromFile(WhiteRead);
            PITSRead4.Image = Image.FromFile(WhiteRead);
            PITSRead5.Image = Image.FromFile(WhiteRead);
            PITSRead6.Image = Image.FromFile(WhiteRead);

            PNewRead1.Image = Image.FromFile(WhiteRead);
            PNewRead2.Image = Image.FromFile(WhiteRead);
            PNewRead3.Image = Image.FromFile(WhiteRead);
            PNewRead4.Image = Image.FromFile(WhiteRead);
            PNewRead5.Image = Image.FromFile(WhiteRead);
            PNewRead6.Image = Image.FromFile(WhiteRead);

            InfoInTheSpotlight.Hide();
            InfoNew.Hide();
            InfoBest.Hide();

            PInTheSpotlight.Image = Image.FromFile(WhiteRec);
            PBest.Image = Image.FromFile(BestWhite);
            PNew.Image = Image.FromFile(WhiteNew);
        }
        
        private void EntranceToReviews()
        {
            sqlConnection.Open();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM GameInfo WHERE NameGame=@NG ",
               sqlConnection);
            command.Parameters.AddWithValue("@NG", NameVitrine3.Text);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                int CountEnterClick = Convert.ToInt32(table.Rows[0]["CountEnterGame"]);
                CountClickd++;

                SqlCommand command2 = new SqlCommand("UPDATE GameInfo SET CountEnterGame = @CountEnterGame WHERE NameGame=@NG ",
               sqlConnection);
                command2.Parameters.AddWithValue("@NG", NameVitrine3.Text);
                command2.Parameters.AddWithValue("CountEnterGame", CountEnterClick++);
                command2.ExecuteNonQuery();

                var gameinfo = new DataBank(table.Rows[0].ItemArray[1].ToString(),
                table.Rows[0].ItemArray[2].ToString(),
                table.Rows[0].ItemArray[3].ToString(),
                table.Rows[0].ItemArray[4].ToString(),
                Convert.ToDateTime(table.Rows[0].ItemArray[5]),
                table.Rows[0]["ReviewsTextGame"].ToString());

                gameReviews = new GameReviews(gameinfo);

                gameReviews.Show();
                Controls.Add(gameReviews);
                gameReviews.Location = new Point(235, 60);
                gameReviews.BringToFront();
                BG_AvatarAdd.BringToFront();
                BG_AccounteClick.BringToFront();


            }
            sqlConnection.Close();
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Autorization autorization = new Autorization();
            autorization.Show();
        }

        private void NameAccounte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(CountClick == 0)
            {
                BG_AccounteClick.Show();
                CountClick++;
            }
            else
            {
                BG_AccounteClick.Hide();
                CountClick--;
            }
            
        }

        private void ShpakGamesForm_Load(object sender, EventArgs e)
        {
            button1.Hide();
            if (_user.Admin == true)
            {
                
                button1.Show();
            }
            AddGames.AdminCheck  = _user.Admin;
            AddGames.Login = _user.Login;
            NameAccounte.Text = $"{_user.Name}🠋";
            
            _Login.Text = _user.Login;
            _Name.Text = _user.Name;
            Avatar.Image = ByteArrayToImage(_user.Avatar);
            MiniAvatar.Image = ByteArrayToImage(_user.Avatar);
            

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["GameInfoDB"].ConnectionString);

            sqlConnection.Open();
            
                    using (SqlCommand commandName = new SqlCommand("SELECT NameGame FROM GameInfo WHERE AdminCheckReviews =@AdminCheckReviews", sqlConnection))
                    {
                commandName.Parameters.AddWithValue("@AdminCheckReviews", true);
                using (SqlDataReader readerName = commandName.ExecuteReader())
                        {
                            while (readerName.Read())
                            {
                                listBox1.Items.Add(readerName[0].ToString());
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
                                    comboBox1.Items.Add(genre);
                                }
                            }
                        }
                    }

            DataTable tableBest = new DataTable();

            SqlDataAdapter adapterBest = new SqlDataAdapter();

            SqlCommand commandBest = new SqlCommand("SELECT * FROM GameInfo ORDER BY CountLikeGame DESC", sqlConnection);
            adapterBest.SelectCommand = commandBest;
            adapterBest.Fill(tableBest);
            if (tableBest.Rows.Count > 0)
            {

                LinkBestName1.Text = tableBest.Rows[0].ItemArray[1].ToString();

                if (tableBest.Rows[0]["BigPicturesGame"] == DBNull.Value)
                {
                    PBest1.Image = Image.FromFile(NotBigPictures);
                }
                else
                {
                    PBest1.Image = ByteArrayToImage((byte[])tableBest.Rows[0]["BigPicturesGame"]);
                }

                LinkBestName1.Parent = PBest1;
                LinkBestName1.BackColor = Color.Transparent;
                LinkBestName1.BringToFront();
                PBestRead1.Parent = PBest1;
                PBestRead1.BackColor = Color.Transparent;
                PBestRead1.Image = Image.FromFile(WhiteRead);


                LinkBestName2.Text = tableBest.Rows[1].ItemArray[1].ToString();

                LinkBestName2.Parent = PBest2;
                LinkBestName2.BackColor = Color.Transparent;
                LinkBestName2.BringToFront();
                PBestRead2.Parent = PBest2;
                PBestRead2.BackColor = Color.Transparent;
                PBestRead2.Image = Image.FromFile(WhiteRead);
                if (tableBest.Rows[1]["BigPicturesGame"] == DBNull.Value)
                {
                    PBest2.Image = Image.FromFile(NotBigPictures);
                }
                else
                {
                    PBest2.Image = ByteArrayToImage((byte[])tableBest.Rows[1]["BigPicturesGame"]);
                }


                LinkBestName3.Text = tableBest.Rows[2].ItemArray[1].ToString();

                LinkBestName3.Parent = PBest3;
                LinkBestName3.BackColor = Color.Transparent;
                LinkBestName3.BringToFront();
                PBestRead3.Parent = PBest3;
                PBestRead3.BackColor = Color.Transparent;
                PBestRead3.Image = Image.FromFile(WhiteRead);
                if (tableBest.Rows[2]["BigPicturesGame"] == DBNull.Value)
                {
                    PBest3.Image = Image.FromFile(NotBigPictures);
                }
                else
                {
                    PBest3.Image = ByteArrayToImage((byte[])tableBest.Rows[2]["BigPicturesGame"]);
                }
            }

            DataTable tableNew = new DataTable();

            SqlDataAdapter adapterNew = new SqlDataAdapter();

            SqlCommand commandNew = new SqlCommand("SELECT * FROM GameInfo ORDER BY DataAddGame DESC", sqlConnection);
            adapterNew.SelectCommand = commandNew;
            adapterNew.Fill(tableNew);
            if (tableNew.Rows.Count > 0)
            {
                NameNewVitrine1.Text = tableNew.Rows[0]["NameGame"].ToString();

                NameNewVitrine1.Parent = NewPicutureBox1;
                NameNewVitrine1.BackColor = Color.Transparent;
                NameNewVitrine1.BringToFront();
                PNewRead1.Parent = NewPicutureBox1;
                PNewRead1.BackColor = Color.Transparent;

                if (tableNew.Rows[0]["AvatarPicturesGame"] == DBNull.Value)
                {
                    NewPicutureBox1.Image = Image.FromFile(NotPictures);
                }
                else
                {
                    NewPicutureBox1.Image = ByteArrayToImage((byte[])tableNew.Rows[0]["AvatarPicturesGame"]);
                }
                NameNewVitrine2.Text = tableNew.Rows[1]["NameGame"].ToString();

                NameNewVitrine2.Parent = NewPicutureBox2;
                NameNewVitrine2.BackColor = Color.Transparent;
                NameNewVitrine2.BringToFront();
                PNewRead2.Parent = NewPicutureBox2;
                PNewRead2.BackColor = Color.Transparent;

                if (tableNew.Rows[1]["AvatarPicturesGame"] == DBNull.Value)
                {
                    NewPicutureBox2.Image = Image.FromFile(NotPictures);
                }
                else
                {
                    NewPicutureBox2.Image = ByteArrayToImage((byte[])tableNew.Rows[1]["AvatarPicturesGame"]);
                }
                NameNewVitrine3.Text = tableNew.Rows[2]["NameGame"].ToString();

                NameNewVitrine3.Parent = NewPicutureBox3;
                NameNewVitrine3.BackColor = Color.Transparent;
                NameNewVitrine3.BringToFront();
                PNewRead3.Parent = NewPicutureBox3;
                PNewRead3.BackColor = Color.Transparent;

                if (tableNew.Rows[2]["AvatarPicturesGame"] == DBNull.Value)
                {
                    NewPicutureBox3.Image = Image.FromFile(NotPictures);
                }
                else
                {
                    NewPicutureBox3.Image = ByteArrayToImage((byte[])tableNew.Rows[2]["AvatarPicturesGame"]);
                }
                NameNewVitrine4.Text = tableNew.Rows[3]["NameGame"].ToString();

                NameNewVitrine4.Parent = NewPicutureBox4;
                NameNewVitrine4.BackColor = Color.Transparent;
                NameNewVitrine4.BringToFront();
                PNewRead4.Parent = NewPicutureBox4;
                PNewRead4.BackColor = Color.Transparent;

                if (tableNew.Rows[3]["AvatarPicturesGame"] == DBNull.Value)
                {
                    NewPicutureBox4.Image = Image.FromFile(NotPictures);
                }
                else
                {
                    NewPicutureBox4.Image = ByteArrayToImage((byte[])tableNew.Rows[3]["AvatarPicturesGame"]);
                }
                NameNewVitrine5.Text = tableNew.Rows[4]["NameGame"].ToString();

                NameNewVitrine5.Parent = NewPicutureBox5;
                NameNewVitrine5.BackColor = Color.Transparent;
                NameNewVitrine5.BringToFront();
                PNewRead5.Parent = NewPicutureBox5;
                PNewRead5.BackColor = Color.Transparent;

                if (tableNew.Rows[4]["AvatarPicturesGame"] == DBNull.Value)
                {
                    NewPicutureBox5.Image = Image.FromFile(NotPictures);
                }
                else
                {
                    NewPicutureBox5.Image = ByteArrayToImage((byte[])tableNew.Rows[4]["AvatarPicturesGame"]);
                }
                NameNewVitrine6.Text = tableNew.Rows[5]["NameGame"].ToString();

                NameNewVitrine6.Parent = NewPicutureBox6;
                NameNewVitrine6.BackColor = Color.Transparent;
                NameNewVitrine6.BringToFront();
                PNewRead6.Parent = NewPicutureBox6;
                PNewRead6.BackColor = Color.Transparent;

                if (tableNew.Rows[5]["AvatarPicturesGame"] == DBNull.Value)
                {
                    NewPicutureBox6.Image = Image.FromFile(NotPictures);
                }
                else
                {
                    NewPicutureBox6.Image = ByteArrayToImage((byte[])tableNew.Rows[5]["AvatarPicturesGame"]);
                }
            }
            DataTable tableITS = new DataTable();

            SqlDataAdapter adapterITS = new SqlDataAdapter();

            SqlCommand commandITS = new SqlCommand("SELECT * FROM GameInfo ORDER BY CountEnterGame DESC", sqlConnection);
            adapterITS.SelectCommand = commandITS;
            adapterITS.Fill(tableITS);
            if (tableITS.Rows.Count > 0)
            {
                NameITSVitrine1.Text = tableITS.Rows[0]["NameGame"].ToString();

                NameITSVitrine1.Parent = ITSPicutureBox1;
                NameITSVitrine1.BackColor = Color.Transparent;
                NameITSVitrine1.BringToFront();
                PITSRead1.Parent = ITSPicutureBox1;
                PITSRead1.BackColor = Color.Transparent;

                if (tableITS.Rows[0]["AvatarPicturesGame"] == DBNull.Value)
                {
                    ITSPicutureBox1.Image = Image.FromFile(NotPictures);
                }
                else
                {
                    ITSPicutureBox1.Image = ByteArrayToImage((byte[])tableITS.Rows[0]["AvatarPicturesGame"]);
                }
                NameITSVitrine2.Text = tableITS.Rows[1]["NameGame"].ToString();

                NameITSVitrine2.Parent = ITSPicutureBox2;
                NameITSVitrine2.BackColor = Color.Transparent;
                NameITSVitrine2.BringToFront();
                PITSRead2.Parent = ITSPicutureBox2;
                PITSRead2.BackColor = Color.Transparent;

                if (tableITS.Rows[1]["AvatarPicturesGame"] == DBNull.Value)
                {
                    ITSPicutureBox2.Image = Image.FromFile(NotPictures);
                }
                else
                {
                    ITSPicutureBox2.Image = ByteArrayToImage((byte[])tableITS.Rows[1]["AvatarPicturesGame"]);
                }
                NameVitrine3.Text = tableITS.Rows[2]["NameGame"].ToString();

                NameVitrine3.Parent = ITSPicutureBox3;
                NameVitrine3.BackColor = Color.Transparent;
                NameVitrine3.BringToFront();
                PITSRead3.Parent = ITSPicutureBox3;
                PITSRead3.BackColor = Color.Transparent;

                if (tableITS.Rows[2]["AvatarPicturesGame"] == DBNull.Value)
                {
                    ITSPicutureBox3.Image = Image.FromFile(NotPictures);
                }
                else
                {
                    ITSPicutureBox3.Image = ByteArrayToImage((byte[])tableITS.Rows[2]["AvatarPicturesGame"]);
                }
                NameITSVitrine4.Text = tableITS.Rows[3]["NameGame"].ToString();

                NameITSVitrine4.Parent = ITSPicutureBox4;
                NameITSVitrine4.BackColor = Color.Transparent;
                NameITSVitrine4.BringToFront();
                PITSRead4.Parent = ITSPicutureBox4;
                PITSRead4.BackColor = Color.Transparent;

                if (tableITS.Rows[3]["AvatarPicturesGame"] == DBNull.Value)
                {
                    ITSPicutureBox4.Image = Image.FromFile(NotPictures);
                }
                else
                {
                    ITSPicutureBox4.Image = ByteArrayToImage((byte[])tableITS.Rows[3]["AvatarPicturesGame"]);
                }
                NameITSVitrine5.Text = tableITS.Rows[4]["NameGame"].ToString();

                NameITSVitrine5.Parent = ITSPicutureBox5;
                NameITSVitrine5.BackColor = Color.Transparent;
                NameITSVitrine5.BringToFront();
                PITSRead5.Parent = ITSPicutureBox5;
                PITSRead5.BackColor = Color.Transparent;

                if (tableITS.Rows[4]["AvatarPicturesGame"] == DBNull.Value)
                {
                    ITSPicutureBox5.Image = Image.FromFile(NotPictures);
                }
                else
                {
                    ITSPicutureBox5.Image = ByteArrayToImage((byte[])tableITS.Rows[4]["AvatarPicturesGame"]);
                }
                NameITSVitrine6.Text = tableITS.Rows[5]["NameGame"].ToString();

                NameITSVitrine6.Parent = ITSPicutureBox6;
                NameITSVitrine6.BackColor = Color.Transparent;
                NameITSVitrine6.BringToFront();
                PITSRead6.Parent = ITSPicutureBox6;
                PITSRead6.BackColor = Color.Transparent;

                if (tableITS.Rows[5]["AvatarPicturesGame"] == DBNull.Value)
                {
                    ITSPicutureBox6.Image = Image.FromFile(NotPictures);
                }
                else
                {
                    ITSPicutureBox6.Image = ByteArrayToImage((byte[])tableITS.Rows[5]["AvatarPicturesGame"]);
                }
            }
            sqlConnection.Close();

        }

        private void ShpakGamesForm_Deactivate(object sender, EventArgs e)
        {
            
        }

        private void SupportButton_Click(object sender, EventArgs e)
        {
         
            
        }
        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void AddAvatarButton_Click(object sender, EventArgs e)
        {
            BG_AvatarAdd.Show();
            BG_AccounteClick.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand commandName = new SqlCommand("SELECT NameGame FROM GameInfo", sqlConnection);
                SqlDataReader readerName = commandName.ExecuteReader();
                listBox1.Items.Clear();
                while (readerName.Read())
                {
                    if (readerName[0].ToString().ToLower().Contains(textBox1.Text.ToLower()))
                    {

                        listBox1.Items.Add(readerName[0].ToString());
                    }
                }
                readerName.Close();

            sqlConnection.Close();
        }

        private void PGenre_MouseEnter(object sender, EventArgs e)
        {
            PGenre.Image = Image.FromFile("C:\\Users\\-\\source\\repos\\БИ\\Pictures\\Red\\RedGenre.png");
            GenreInfo.Show();
        }

        private void PGenre_MouseLeave(object sender, EventArgs e)
        {
            PGenre.Image = Image.FromFile("C:\\Users\\-\\source\\repos\\БИ\\Pictures\\White\\WhiteGenre.png");
            GenreInfo.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnection.Open();

            DataTable table = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand command = new SqlCommand("SELECT * FROM GameInfo WHERE (GenreGame = @GG AND AdminCheckReviews= @AdminCheckReviews)", sqlConnection);
                command.Parameters.AddWithValue("@GG", comboBox1.SelectedItem);
            command.Parameters.AddWithValue("@AdminCheckReviews", true);
            adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    listBox1.Items.Clear();
                
                
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        listBox1.Items.Add(table.Rows[i].ItemArray[1].ToString());
                    }
                }
                else
                {
                    SqlCommand commandName = new SqlCommand("SELECT NameGame FROM GameInfo", sqlConnection);
                    SqlDataReader readerName = commandName.ExecuteReader();
                    while (readerName.Read())
                    {
                        listBox1.Items.Add(readerName[0].ToString());
                    }
                    readerName.Close();
                }
            
            sqlConnection.Close();
        }
        
        
       
        private void Refresh_Click(object sender, EventArgs e)
        {
           for(int i = 0;i == CountClickd; i--)
            {
                gameReviews.Hide();
            }
            ShpakGamesForm shpakGamesForm = new ShpakGamesForm(_user);
            shpakGamesForm.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (listBox1.SelectedItem.ToString() == null)
            {
                goto V;
            }
            sqlConnection.Open();
            
            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            
            SqlCommand command = new SqlCommand("SELECT * FROM GameInfo WHERE NameGame=@NG ",
               sqlConnection);
            command.Parameters.AddWithValue("@NG", listBox1.SelectedItem.ToString());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                int CountEnterClick = Convert.ToInt32(table.Rows[0]["CountEnterGame"]);
                CountClickd++;
                
                SqlCommand command2 = new SqlCommand("UPDATE GameInfo SET CountEnterGame = @CountEnterGame WHERE NameGame=@NG ",
               sqlConnection);
                command2.Parameters.AddWithValue("@NG", listBox1.SelectedItem.ToString());
                command2.Parameters.AddWithValue("CountEnterGame", CountEnterClick++);
                command2.ExecuteNonQuery();

                var gameinfo = new DataBank(table.Rows[0].ItemArray[1].ToString(),
                table.Rows[0].ItemArray[2].ToString(),
                table.Rows[0].ItemArray[3].ToString(),
                table.Rows[0].ItemArray[4].ToString(),
                Convert.ToDateTime(table.Rows[0].ItemArray[5]),
                table.Rows[0]["ReviewsTextGame"].ToString());
               
                   
                    gameReviews = new GameReviews(gameinfo);
                    
                
                    
               

                gameReviews.Show();
                Controls.Add(gameReviews);
                gameReviews.Location = new Point(235, 45);
                gameReviews.BringToFront();
                BG_AvatarAdd.BringToFront();
                BG_AccounteClick.BringToFront();




                
            }

        V:
            sqlConnection.Close();
        
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.png; *.jpeg; *.jpg)|*.png;*.jpeg;*.jpg";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    AvatarAcceptPicturesBox.Image = Image.FromFile(openFileDialog.FileName);
                    Avatar.Image = Image.FromFile(openFileDialog.FileName);
                    MiniAvatar.Image = Image.FromFile(openFileDialog.FileName);
                    Image image = Image.FromFile(openFileDialog.FileName);
                    byte[] imageconvert = ImageToByteArray(image);
                    SqlCommand command = new SqlCommand($"UPDATE People SET Avatar = @Avatar WHERE Login = @Login",
                        sqlConnection);
                    command.Parameters.AddWithValue("Login", _user.Login);
                    command.Parameters.AddWithValue("Avatar", imageconvert);

                    command.ExecuteNonQuery();
                    
                }
            }
            sqlConnection.Close();
        }

        private void InfoPictureBox_MouseEnter(object sender, EventArgs e)
        {
            InfoPlatformsGame.Show();
            InfoPictureBox.Image = Image.FromFile(RedInfo);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            BG_AvatarAdd.Hide();
        }

        private void AddGameAdmin_Click(object sender, EventArgs e)
        {
            AdminAddGame adminAddGame = new AdminAddGame();
            adminAddGame.Show();
        }

        private void CheckRequest_Click(object sender, EventArgs e)
        {
            
        }

        private void InfoPictureBox_MouseLeave(object sender, EventArgs e)
        {
            InfoPlatformsGame.Hide();
            InfoPictureBox.Image = Image.FromFile(InfWhite);
        }

        private void PITSRead1_MouseEnter(object sender, EventArgs e)
        {
            PITSRead1.Image = Image.FromFile(RedRead);
        }

        private void PITSRead1_MouseLeave(object sender, EventArgs e)
        {
            PITSRead1.Image = Image.FromFile(WhiteRead);
        }

        private void PITSRead2_MouseEnter(object sender, EventArgs e)
        {
            PITSRead2.Image = Image.FromFile(RedRead);
        }

        private void PITSRead2_MouseLeave(object sender, EventArgs e)
        {
            PITSRead2.Image = Image.FromFile(WhiteRead);
        }

        private void PITSRead3_MouseEnter(object sender, EventArgs e)
        {
            PITSRead3.Image = Image.FromFile(RedRead);
        }

        private void PITSRead3_MouseLeave(object sender, EventArgs e)
        {
            PITSRead3.Image = Image.FromFile(WhiteRead);
        }

        private void PITSRead4_MouseEnter(object sender, EventArgs e)
        {
            PITSRead4.Image = Image.FromFile(RedRead);
        }

        private void PITSRead4_MouseLeave(object sender, EventArgs e)
        {
            PITSRead4.Image = Image.FromFile(WhiteRead);
        }

        private void PITSRead5_MouseEnter(object sender, EventArgs e)
        {
            PITSRead5.Image = Image.FromFile(RedRead);
        }

        private void PITSRead5_MouseLeave(object sender, EventArgs e)
        {
            PITSRead5.Image = Image.FromFile(WhiteRead);
        }

        private void PITSRead6_MouseEnter(object sender, EventArgs e)
        {
            PITSRead6.Image = Image.FromFile(RedRead);
        }

        private void PITSRead6_MouseLeave(object sender, EventArgs e)
        {
            PITSRead6.Image = Image.FromFile(WhiteRead);
        }

        private void PBestRead1_MouseEnter(object sender, EventArgs e)
        {
            PBestRead1.Image = Image.FromFile(RedRead);
        }

        private void PBestRead1_MouseLeave(object sender, EventArgs e)
        {
            PBestRead1.Image = Image.FromFile(WhiteRead);
        }

        private void PBestRead2_MouseEnter(object sender, EventArgs e)
        {
            PBestRead2.Image = Image.FromFile(RedRead);
        }

        private void PBestRead2_MouseLeave(object sender, EventArgs e)
        {
            PBestRead2.Image = Image.FromFile(WhiteRead);
        }

        private void PBestRead3_MouseEnter(object sender, EventArgs e)
        {
            PBestRead3.Image = Image.FromFile(RedRead);
        }

        private void PBestRead3_MouseLeave(object sender, EventArgs e)
        {
            PBestRead3.Image = Image.FromFile(WhiteRead);
        }

        private void PNew_MouseEnter(object sender, EventArgs e)
        {
            PNew.Image = Image.FromFile(RedNew);
            InfoNew.Show();

        }

        private void PNew_MouseLeave(object sender, EventArgs e)
        {
            PNew.Image = Image.FromFile(WhiteNew);
            InfoNew.Hide();
        }

        private void PInTheSpotlight_MouseEnter(object sender, EventArgs e)
        {
            PInTheSpotlight.Image = Image.FromFile(RedRec);
            InfoInTheSpotlight.Show();
        }

        private void PInTheSpotlight_MouseLeave(object sender, EventArgs e)
        {
            PInTheSpotlight.Image = Image.FromFile(WhiteRec);
            InfoInTheSpotlight.Hide();
        }

        private void PBest_MouseEnter(object sender, EventArgs e)
        {
            PBest.Image = Image.FromFile(TopRed);
            InfoBest.Show();
        }

        private void PBest_MouseLeave(object sender, EventArgs e)
        {
            PBest.Image = Image.FromFile(BestWhite);
            InfoBest.Hide();
        }

        private void PNewRead1_MouseEnter(object sender, EventArgs e)
        {
            PNewRead1.Image = Image.FromFile(RedRead);
        }

        private void PNewRead1_MouseLeave(object sender, EventArgs e)
        {
            PNewRead1.Image = Image.FromFile(WhiteRead);
        }

        private void PNewRead2_MouseEnter(object sender, EventArgs e)
        {
            PNewRead2.Image = Image.FromFile(RedRead);
        }

        private void PNewRead2_MouseLeave(object sender, EventArgs e)
        {
            PNewRead2.Image = Image.FromFile(WhiteRead);
        }

        private void PNewRead3_MouseEnter(object sender, EventArgs e)
        {
            PNewRead3.Image = Image.FromFile(RedRead);
        }

        private void PNewRead3_MouseLeave(object sender, EventArgs e)
        {
            PNewRead3.Image = Image.FromFile(WhiteRead);
        }

        private void PNewRead4_MouseEnter(object sender, EventArgs e)
        {
            PNewRead4.Image = Image.FromFile(RedRead);
        }

        private void PNewRead4_MouseLeave(object sender, EventArgs e)
        {
            PNewRead4.Image = Image.FromFile(WhiteRead);
        }

        private void PNewRead5_MouseEnter(object sender, EventArgs e)
        {
            PNewRead5.Image = Image.FromFile(RedRead);
        }

        private void PNewRead5_MouseLeave(object sender, EventArgs e)
        {
            PNewRead5.Image = Image.FromFile(WhiteRead);
        }

        private void PNewRead6_MouseEnter(object sender, EventArgs e)
        {
            PNewRead6.Image = Image.FromFile(RedRead);
        }

        private void PNewRead6_MouseLeave(object sender, EventArgs e)
        {
            PNewRead6.Image = Image.FromFile(WhiteRead);
        }

        private async void BestGameButtonLeft_Click(object sender, EventArgs e)
        {
            if (CountClick1 == 1)
            {
                CountClick1++;
                while (!exp && PBest1.Location.X > -850)
                {
                   
                    await Task.Delay(1);
                    PBest1.Location = new Point(PBest1.Location.X - 50, PBest1.Location.Y);
                    PBest2.Location = new Point(PBest2.Location.X - 50, PBest2.Location.Y);
                    PBest3.Location = new Point(PBest3.Location.X - 50, PBest2.Location.Y);
                }
            }
            else if (CountClick1 == 2)
            {
                CountClick1++;
                while (!exp && PBest1.Location.X > -1950)
                {
                    exp = true;
                    await Task.Delay(1);
                    PBest1.Location = new Point(PBest1.Location.X - 50, PBest1.Location.Y);
                    PBest2.Location = new Point(PBest2.Location.X - 50, PBest2.Location.Y);
                    PBest3.Location = new Point(PBest3.Location.X - 50, PBest2.Location.Y);
                    exp = false;
                }
            }


        }

        private async void BestGameButtonRight_Click(object sender, EventArgs e)
        {
            if (CountClick1 == 2)
            {

                CountClick1--;
                while (!exp && PBest1.Location.X < 250)
                {
                    exp = true;
                    await Task.Delay(1);
                    PBest1.Location = new Point(PBest1.Location.X + 50, PBest1.Location.Y);
                    PBest2.Location = new Point(PBest2.Location.X + 50, PBest2.Location.Y);
                    PBest3.Location = new Point(PBest3.Location.X + 50, PBest2.Location.Y);
                    exp = false;
                }
            }
            else if (CountClick1 == 3)
            {
                CountClick1--;
                while (!exp && PBest1.Location.X < -900)
                {

                    await Task.Delay(1);
                    PBest1.Location = new Point(PBest1.Location.X + 50, PBest1.Location.Y);
                    PBest2.Location = new Point(PBest2.Location.X + 50, PBest2.Location.Y);
                    PBest3.Location = new Point(PBest3.Location.X + 50, PBest2.Location.Y);

                }
            }
        }

        private async void InTheSpotlightButtonLeft_Click(object sender, EventArgs e)
        {
            if (CountClick2 == 1)
            {

                CountClick2++;
                while (!exp && ITSPicutureBox1.Location.X > -850)
                {

                    await Task.Delay(1);
                    ITSPicutureBox1.Location = new Point(ITSPicutureBox1.Location.X - 50, ITSPicutureBox1.Location.Y);
                    ITSPicutureBox2.Location = new Point(ITSPicutureBox2.Location.X - 50, ITSPicutureBox2.Location.Y);
                    ITSPicutureBox3.Location = new Point(ITSPicutureBox3.Location.X - 50, ITSPicutureBox3.Location.Y);
                    ITSPicutureBox4.Location = new Point(ITSPicutureBox4.Location.X - 50, ITSPicutureBox4.Location.Y);
                    ITSPicutureBox5.Location = new Point(ITSPicutureBox5.Location.X - 50, ITSPicutureBox5.Location.Y);
                    ITSPicutureBox6.Location = new Point(ITSPicutureBox6.Location.X - 50, ITSPicutureBox6.Location.Y);
                }
            }
        }

        private async void InTheSpotlightButtonRight_Click(object sender, EventArgs e)
        {
            if (CountClick2 == 2)
            {

                CountClick2--;
                while (!exp && ITSPicutureBox1.Location.X < 250)
                {
                    exp = true;
                    await Task.Delay(1);
                    ITSPicutureBox1.Location = new Point(ITSPicutureBox1.Location.X + 50, ITSPicutureBox1.Location.Y);
                    ITSPicutureBox2.Location = new Point(ITSPicutureBox2.Location.X + 50, ITSPicutureBox2.Location.Y);
                    ITSPicutureBox3.Location = new Point(ITSPicutureBox3.Location.X + 50, ITSPicutureBox3.Location.Y);
                    ITSPicutureBox4.Location = new Point(ITSPicutureBox4.Location.X + 50, ITSPicutureBox4.Location.Y);
                    ITSPicutureBox5.Location = new Point(ITSPicutureBox5.Location.X + 50, ITSPicutureBox5.Location.Y);
                    ITSPicutureBox6.Location = new Point(ITSPicutureBox6.Location.X + 50, ITSPicutureBox6.Location.Y);
                    exp = false;
                }
            }
        }

        private async void NewButtonLeft_Click(object sender, EventArgs e)
        {
            if (CountClick3 == 1)
            {

                CountClick3++;
                while (!exp && NewPicutureBox1.Location.X > -850)
                {

                    await Task.Delay(1);
                    NewPicutureBox1.Location = new Point(NewPicutureBox1.Location.X - 50, NewPicutureBox1.Location.Y);
                    NewPicutureBox2.Location = new Point(NewPicutureBox2.Location.X - 50, NewPicutureBox2.Location.Y);
                    NewPicutureBox3.Location = new Point(NewPicutureBox3.Location.X - 50, NewPicutureBox3.Location.Y);
                    NewPicutureBox4.Location = new Point(NewPicutureBox4.Location.X - 50, NewPicutureBox4.Location.Y);
                    NewPicutureBox5.Location = new Point(NewPicutureBox5.Location.X - 50, NewPicutureBox5.Location.Y);
                    NewPicutureBox6.Location = new Point(NewPicutureBox6.Location.X - 50, NewPicutureBox6.Location.Y);

                }
            }
        }

        private async void NewButtonRight_Click(object sender, EventArgs e)
        {
            if (CountClick3 == 2)
            {

                CountClick3--;
                while (!exp && NewPicutureBox1.Location.X < 250)
                {
                    exp = true;
                    await Task.Delay(1);
                     NewPicutureBox1.Location = new Point(NewPicutureBox1.Location.X + 50, NewPicutureBox1.Location.Y);
                    NewPicutureBox2.Location = new Point(NewPicutureBox2.Location.X + 50, NewPicutureBox2.Location.Y);
                    NewPicutureBox3.Location = new Point(NewPicutureBox3.Location.X + 50, NewPicutureBox3.Location.Y);
                    NewPicutureBox4.Location = new Point(NewPicutureBox4.Location.X + 50, NewPicutureBox4.Location.Y);
                    NewPicutureBox5.Location = new Point(NewPicutureBox5.Location.X + 50, NewPicutureBox5.Location.Y);
                    NewPicutureBox6.Location = new Point(NewPicutureBox6.Location.X + 50, NewPicutureBox6.Location.Y);
                    exp = false;
                }
            }
        }

        private void LinkBestName1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EntranceToReviews();
        }

        private void LinkBestName2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EntranceToReviews();
        }

        private void LinkBestName3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EntranceToReviews();
        }

        private void PBestRead1_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void PBestRead2_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void PBestRead3_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void PBest1_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }
        private void PBest2_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void PBest3_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void NameITSVitrine1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EntranceToReviews();
        }

        private void NameITSVitrine2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EntranceToReviews();
        }

        private void NameVitrine3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EntranceToReviews();
        }

        private void NameITSVitrine4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EntranceToReviews();
        }

        private void NameITSVitrine5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EntranceToReviews();
        }

        private void NameITSVitrine6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EntranceToReviews();
        }

        private void NameNewVitrine1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EntranceToReviews();
        }

        private void NameNewVitrine2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EntranceToReviews();
        }

        private void NameNewVitrine3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EntranceToReviews();
        }

        private void NameNewVitrine4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EntranceToReviews();
        }

        private void NameNewVitrine5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EntranceToReviews();
        }

        private void NameNewVitrine6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EntranceToReviews();
        }

        private void PITSRead1_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void PITSRead2_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void PITSRead3_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void PITSRead4_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void PITSRead5_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void PITSRead6_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void PNewRead1_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void PNewRead2_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void PNewRead3_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void PNewRead4_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void PNewRead5_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void PNewRead6_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void ITSPicutureBox1_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void ITSPicutureBox2_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void ITSPicutureBox3_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void ITSPicutureBox4_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void ITSPicutureBox5_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void ITSPicutureBox6_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void NewPicutureBox1_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void NewPicutureBox2_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void NewPicutureBox3_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void NewPicutureBox4_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void NewPicutureBox5_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }

        private void NewPicutureBox6_Click(object sender, EventArgs e)
        {
            EntranceToReviews();
        }
    }
}
