namespace БИ.Controls
{
    partial class ChangeGame
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SendButton = new System.Windows.Forms.Button();
            this.InfoPlatformsGame = new System.Windows.Forms.ListBox();
            this.LabelPlatformsGame = new System.Windows.Forms.Label();
            this.PlatformsTextBox = new System.Windows.Forms.TextBox();
            this.LabelPublisherGame = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LabelDataGame = new System.Windows.Forms.Label();
            this.LabelGenreGame = new System.Windows.Forms.Label();
            this.LabelGameName = new System.Windows.Forms.Label();
            this.DateTextBox = new System.Windows.Forms.TextBox();
            this.DeveloperTextBox = new System.Windows.Forms.TextBox();
            this.ComboBoxGenre = new System.Windows.Forms.ComboBox();
            this.ReviewsTextBox = new System.Windows.Forms.RichTextBox();
            this.PublisherTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBoxGame = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AddPicturesLabel = new System.Windows.Forms.Label();
            this.AvatarPicturesBox = new System.Windows.Forms.PictureBox();
            this.BigPicturesGame = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarPicturesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BigPicturesGame)).BeginInit();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.SendButton.Location = new System.Drawing.Point(466, 468);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(130, 40);
            this.SendButton.TabIndex = 43;
            this.SendButton.Text = "Отправить";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // InfoPlatformsGame
            // 
            this.InfoPlatformsGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.InfoPlatformsGame.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InfoPlatformsGame.ForeColor = System.Drawing.Color.White;
            this.InfoPlatformsGame.FormattingEnabled = true;
            this.InfoPlatformsGame.Items.AddRange(new object[] {
            "Если платформа не 1, то ",
            "записывайте через запятую",
            "                     \" , \""});
            this.InfoPlatformsGame.Location = new System.Drawing.Point(193, 236);
            this.InfoPlatformsGame.Name = "InfoPlatformsGame";
            this.InfoPlatformsGame.Size = new System.Drawing.Size(149, 52);
            this.InfoPlatformsGame.TabIndex = 42;
            // 
            // LabelPlatformsGame
            // 
            this.LabelPlatformsGame.AutoSize = true;
            this.LabelPlatformsGame.ForeColor = System.Drawing.Color.White;
            this.LabelPlatformsGame.Location = new System.Drawing.Point(127, 236);
            this.LabelPlatformsGame.Name = "LabelPlatformsGame";
            this.LabelPlatformsGame.Size = new System.Drawing.Size(72, 13);
            this.LabelPlatformsGame.TabIndex = 41;
            this.LabelPlatformsGame.Text = "Платформы*";
            this.LabelPlatformsGame.MouseEnter += new System.EventHandler(this.LabelPlatformsGame_MouseEnter);
            this.LabelPlatformsGame.MouseLeave += new System.EventHandler(this.LabelPlatformsGame_MouseLeave);
            // 
            // PlatformsTextBox
            // 
            this.PlatformsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PlatformsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PlatformsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlatformsTextBox.ForeColor = System.Drawing.Color.White;
            this.PlatformsTextBox.Location = new System.Drawing.Point(53, 252);
            this.PlatformsTextBox.Name = "PlatformsTextBox";
            this.PlatformsTextBox.Size = new System.Drawing.Size(224, 19);
            this.PlatformsTextBox.TabIndex = 40;
            // 
            // LabelPublisherGame
            // 
            this.LabelPublisherGame.AutoSize = true;
            this.LabelPublisherGame.ForeColor = System.Drawing.Color.White;
            this.LabelPublisherGame.Location = new System.Drawing.Point(133, 193);
            this.LabelPublisherGame.Name = "LabelPublisherGame";
            this.LabelPublisherGame.Size = new System.Drawing.Size(56, 13);
            this.LabelPublisherGame.TabIndex = 39;
            this.LabelPublisherGame.Text = "Издатель";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(127, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Разработчик";
            // 
            // LabelDataGame
            // 
            this.LabelDataGame.AutoSize = true;
            this.LabelDataGame.ForeColor = System.Drawing.Color.White;
            this.LabelDataGame.Location = new System.Drawing.Point(127, 106);
            this.LabelDataGame.Name = "LabelDataGame";
            this.LabelDataGame.Size = new System.Drawing.Size(79, 13);
            this.LabelDataGame.TabIndex = 37;
            this.LabelDataGame.Text = "Дата выпуска";
            // 
            // LabelGenreGame
            // 
            this.LabelGenreGame.AutoSize = true;
            this.LabelGenreGame.ForeColor = System.Drawing.Color.White;
            this.LabelGenreGame.Location = new System.Drawing.Point(133, 54);
            this.LabelGenreGame.Name = "LabelGenreGame";
            this.LabelGenreGame.Size = new System.Drawing.Size(36, 13);
            this.LabelGenreGame.TabIndex = 36;
            this.LabelGenreGame.Text = "Жанр";
            // 
            // LabelGameName
            // 
            this.LabelGameName.AutoSize = true;
            this.LabelGameName.ForeColor = System.Drawing.Color.White;
            this.LabelGameName.Location = new System.Drawing.Point(122, 10);
            this.LabelGameName.Name = "LabelGameName";
            this.LabelGameName.Size = new System.Drawing.Size(77, 13);
            this.LabelGameName.TabIndex = 35;
            this.LabelGameName.Text = "Названия игр";
            // 
            // DateTextBox
            // 
            this.DateTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateTextBox.ForeColor = System.Drawing.Color.White;
            this.DateTextBox.Location = new System.Drawing.Point(53, 122);
            this.DateTextBox.Name = "DateTextBox";
            this.DateTextBox.Size = new System.Drawing.Size(224, 19);
            this.DateTextBox.TabIndex = 34;
            // 
            // DeveloperTextBox
            // 
            this.DeveloperTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DeveloperTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DeveloperTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeveloperTextBox.ForeColor = System.Drawing.Color.White;
            this.DeveloperTextBox.Location = new System.Drawing.Point(53, 164);
            this.DeveloperTextBox.Name = "DeveloperTextBox";
            this.DeveloperTextBox.Size = new System.Drawing.Size(224, 19);
            this.DeveloperTextBox.TabIndex = 33;
            // 
            // ComboBoxGenre
            // 
            this.ComboBoxGenre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ComboBoxGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxGenre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ComboBoxGenre.ForeColor = System.Drawing.Color.White;
            this.ComboBoxGenre.FormattingEnabled = true;
            this.ComboBoxGenre.Location = new System.Drawing.Point(50, 70);
            this.ComboBoxGenre.Name = "ComboBoxGenre";
            this.ComboBoxGenre.Size = new System.Drawing.Size(224, 28);
            this.ComboBoxGenre.Sorted = true;
            this.ComboBoxGenre.TabIndex = 32;
            // 
            // ReviewsTextBox
            // 
            this.ReviewsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ReviewsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ReviewsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReviewsTextBox.ForeColor = System.Drawing.Color.White;
            this.ReviewsTextBox.Location = new System.Drawing.Point(22, 294);
            this.ReviewsTextBox.Name = "ReviewsTextBox";
            this.ReviewsTextBox.Size = new System.Drawing.Size(1002, 168);
            this.ReviewsTextBox.TabIndex = 31;
            this.ReviewsTextBox.Text = "";
            // 
            // PublisherTextBox
            // 
            this.PublisherTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PublisherTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PublisherTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PublisherTextBox.ForeColor = System.Drawing.Color.White;
            this.PublisherTextBox.Location = new System.Drawing.Point(53, 209);
            this.PublisherTextBox.Name = "PublisherTextBox";
            this.PublisherTextBox.Size = new System.Drawing.Size(224, 19);
            this.PublisherTextBox.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(210, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Обзор";
            // 
            // ComboBoxGame
            // 
            this.ComboBoxGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ComboBoxGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ComboBoxGame.ForeColor = System.Drawing.Color.White;
            this.ComboBoxGame.FormattingEnabled = true;
            this.ComboBoxGame.Location = new System.Drawing.Point(50, 26);
            this.ComboBoxGame.Name = "ComboBoxGame";
            this.ComboBoxGame.Size = new System.Drawing.Size(224, 28);
            this.ComboBoxGame.Sorted = true;
            this.ComboBoxGame.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(692, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Добавить большую фотографию ";
            // 
            // AddPicturesLabel
            // 
            this.AddPicturesLabel.AutoSize = true;
            this.AddPicturesLabel.ForeColor = System.Drawing.Color.White;
            this.AddPicturesLabel.Location = new System.Drawing.Point(320, 137);
            this.AddPicturesLabel.Name = "AddPicturesLabel";
            this.AddPicturesLabel.Size = new System.Drawing.Size(127, 13);
            this.AddPicturesLabel.TabIndex = 49;
            this.AddPicturesLabel.Text = "Добавить фотографию ";
            // 
            // AvatarPicturesBox
            // 
            this.AvatarPicturesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.AvatarPicturesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AvatarPicturesBox.Location = new System.Drawing.Point(283, 56);
            this.AvatarPicturesBox.Name = "AvatarPicturesBox";
            this.AvatarPicturesBox.Size = new System.Drawing.Size(201, 174);
            this.AvatarPicturesBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AvatarPicturesBox.TabIndex = 48;
            this.AvatarPicturesBox.TabStop = false;
            this.AvatarPicturesBox.Click += new System.EventHandler(this.AvatarPicturesBox_Click);
            // 
            // BigPicturesGame
            // 
            this.BigPicturesGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.BigPicturesGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BigPicturesGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BigPicturesGame.Location = new System.Drawing.Point(502, 54);
            this.BigPicturesGame.Name = "BigPicturesGame";
            this.BigPicturesGame.Size = new System.Drawing.Size(522, 174);
            this.BigPicturesGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BigPicturesGame.TabIndex = 47;
            this.BigPicturesGame.TabStop = false;
            this.BigPicturesGame.Click += new System.EventHandler(this.BigPicturesGame_Click);
            // 
            // ChangeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddPicturesLabel);
            this.Controls.Add(this.AvatarPicturesBox);
            this.Controls.Add(this.BigPicturesGame);
            this.Controls.Add(this.ComboBoxGame);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.InfoPlatformsGame);
            this.Controls.Add(this.LabelPlatformsGame);
            this.Controls.Add(this.PlatformsTextBox);
            this.Controls.Add(this.LabelPublisherGame);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LabelDataGame);
            this.Controls.Add(this.LabelGenreGame);
            this.Controls.Add(this.LabelGameName);
            this.Controls.Add(this.DateTextBox);
            this.Controls.Add(this.DeveloperTextBox);
            this.Controls.Add(this.ComboBoxGenre);
            this.Controls.Add(this.ReviewsTextBox);
            this.Controls.Add(this.PublisherTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ChangeGame";
            this.Size = new System.Drawing.Size(1312, 522);
            this.Load += new System.EventHandler(this.ChangeGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AvatarPicturesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BigPicturesGame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.ListBox InfoPlatformsGame;
        private System.Windows.Forms.Label LabelPlatformsGame;
        private System.Windows.Forms.TextBox PlatformsTextBox;
        private System.Windows.Forms.Label LabelPublisherGame;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LabelDataGame;
        private System.Windows.Forms.Label LabelGenreGame;
        private System.Windows.Forms.Label LabelGameName;
        private System.Windows.Forms.TextBox DateTextBox;
        private System.Windows.Forms.TextBox DeveloperTextBox;
        private System.Windows.Forms.ComboBox ComboBoxGenre;
        private System.Windows.Forms.RichTextBox ReviewsTextBox;
        private System.Windows.Forms.TextBox PublisherTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboBoxGame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label AddPicturesLabel;
        private System.Windows.Forms.PictureBox AvatarPicturesBox;
        private System.Windows.Forms.PictureBox BigPicturesGame;
    }
}
