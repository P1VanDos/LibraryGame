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
using System.Xml.Linq;
using БИ.Controls;
using БИ.Page;


namespace БИ.Page
{
    public partial class GameReviews : UserControl
    {
      

        private readonly DataBank _gameinfo;

        private SqlConnection sqlConnection;
        public int CountClickLike;
        public int CountClickDisLike;

        public GameReviews(DataBank gameinfo)
        {
           _gameinfo = gameinfo;
            InitializeComponent();
            
        }

        public GameReviews()
        {
            InitializeComponent();
        }
        private void GameReviews_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["GameInfoDB"].ConnectionString);
            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM GameInfo WHERE NameGame=@NG ",
               sqlConnection);
            command.Parameters.AddWithValue("@NG", _gameinfo.NameGame);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            CountClickLike = Convert.ToInt32(table.Rows[0]["CountLikeGame"]);
            CountClickDisLike = Convert.ToInt32(table.Rows[0]["CountDislikeGame"]);
            _NameGame.Text = _gameinfo.NameGame;
            _Genre.Text = _gameinfo.GenreGame;
            _DeveloperGame.Text = _gameinfo.DeveloperGame;
            _PublisherGame.Text = _gameinfo.PublisherGame;

            
            
            if (table.Rows[0]["AvatarPicturesGame"] == DBNull.Value)
            {
                _AvatarGame.Image = Image.FromFile("C:\\Users\\-\\source\\repos\\БИ\\Pictures\\GameAvatar\\NotPictures.png");
            }
            else
            {
                _AvatarGame.Image = ByteArrayToImage((byte[])table.Rows[0]["AvatarPicturesGame"]);
            }




            if (_gameinfo.ReviewsText == "")
            {
                _ReviewsGame.Text = "Обзор еще не готов";
            }
            else
            {
                _ReviewsGame.Text = _gameinfo.ReviewsText.ToString();
            }
            
            _DateGame.Text = _gameinfo.DataGame.ToString();
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void Like_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            CountClickLike++;
                SqlCommand command = new SqlCommand("UPDATE GameInfo SET CountLikeGame = @CountLikeGame WHERE NameGAme = @NameGame", sqlConnection);
                command.Parameters.AddWithValue("CountLikeGame", CountClickLike);
                command.Parameters.AddWithValue("NameGame", _gameinfo.NameGame);
               if (command.ExecuteNonQuery() == 1)
               {
               
               }

            sqlConnection.Close();
        }

        private void DisLike_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            CountClickDisLike++;
            SqlCommand command = new SqlCommand("UPDATE GameInfo SET CountDisLikeGame = @CountDisLikeGame WHERE NameGAme = @NameGame", sqlConnection);
            command.Parameters.AddWithValue("CountDisLikeGame", CountClickDisLike);
            command.Parameters.AddWithValue("NameGame", _gameinfo.NameGame);
            if (command.ExecuteNonQuery() == 1)
            {
               
            }

            sqlConnection.Close();
        }
    }
}
