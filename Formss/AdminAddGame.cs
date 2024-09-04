using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using БИ.Controls;

namespace БИ.Forms
{
    
    public partial class AdminAddGame : Form
    {
        public AddGames addGames = new AddGames();
        public ChangeGame changeGame = new ChangeGame();
        public int CountClickLink;
        public AdminAddGame()
        {
            InitializeComponent();
        }

        private void AdminAddGame_Load(object sender, EventArgs e)
        {
           
            Controls.Add(addGames);
            addGames.Location = new Point(45, 30);
            addGames.BringToFront();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(CountClickLink== 0)
            {
                CountClickLink++;
                linkLabel1.Text = "Добавить обзор";
                addGames.Hide();
                Controls.Add(changeGame);
                changeGame.Location = new Point(45, 30);
                changeGame.BringToFront();
                changeGame.Show();
            }
            else
            {
                CountClickLink--;
                changeGame.Hide();
                addGames.Show();
                linkLabel1.Text = "Изменить обзор";
            }
            

        }
    }
}