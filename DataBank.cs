using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace БИ
{
   
    public class DataBank
    {
        private SqlConnection sqlConnection;

        public string Login { get; set; }
        public string Name { get; set; }
        public bool Admin { get; }
        public byte[] Avatar { get; set; }
        public string Status => Admin ? "Admin" : "User";


        public string NameGame { get; set; }
        public string GenreGame { get; set; }
        public string DeveloperGame { get; set; }
        public string PublisherGame { get; set; }
        public string ReviewsText { get; set; }
        public DateTime DataGame { get; set; }
        public byte[]  AvatarGame { get; set; }
        public int CountEnterGame { get; set; }
        public int CountLikeGame { get; set; }
        public int CountDislikeGame { get; set; }
        public Image BigPicturesGame { get; set; }



       

        public DataBank(string login, string name, bool admin, byte[] avatar)
        {
            Login = login.Trim();
            Name = name.Trim();
            Admin = admin;
            Avatar = avatar;
        }
        public DataBank(string namegame, string genrename, string developergame,string publishergame, DateTime datatime, string reviewstext)
        {
            NameGame = namegame.Trim();
            GenreGame = genrename.Trim();
            DeveloperGame = developergame.Trim();
            PublisherGame = publishergame.Trim();
            ReviewsText = reviewstext.Trim();
            DataGame = datatime;
           
            

        }
        public DataBank()
        {

        }

        public void SqlConnectionOpen()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["GameInfoDB"].ConnectionString);
            sqlConnection.Open();
        }
        public SqlConnection SqlConnection()
        {
           return sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["GameInfoDB"].ConnectionString);
        }
        public void SqlConnectionClose()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["GameInfoDB"].ConnectionString);
            sqlConnection.Open();
        }
    }
   
}
