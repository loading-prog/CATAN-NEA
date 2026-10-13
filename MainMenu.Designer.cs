namespace catan
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCreatePlayer = new Button();
            btnStartGame = new Button();
            Title = new Button();
            SuspendLayout();
            // 
            // btnCreatePlayer
            // 
            btnCreatePlayer.Location = new Point(61, 195);
            btnCreatePlayer.Name = "btnCreatePlayer";
            btnCreatePlayer.Size = new Size(222, 60);
            btnCreatePlayer.TabIndex = 0;
            btnCreatePlayer.Text = "Create Player";
            btnCreatePlayer.UseVisualStyleBackColor = true;
            btnCreatePlayer.Click += btnCreatePlayer_Click;
            // 
            // btnStartGame
            // 
            btnStartGame.Location = new Point(503, 195);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(222, 60);
            btnStartGame.TabIndex = 1;
            btnStartGame.Text = "Start New Game";
            btnStartGame.UseVisualStyleBackColor = true;
            btnStartGame.Click += btnStartGame_Click;
            // 
            // Title
            // 
            Title.FlatStyle = FlatStyle.Flat;
            Title.Font = new Font("Sprocket BT", 27.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            Title.Location = new Point(276, 12);
            Title.Name = "Title";
            Title.Size = new Size(231, 75);
            Title.TabIndex = 2;
            Title.Text = "CATAN ";
            Title.TextImageRelation = TextImageRelation.TextAboveImage;
            Title.UseVisualStyleBackColor = true;
            Title.Click += Title_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Title);
            Controls.Add(btnStartGame);
            Controls.Add(btnCreatePlayer);
            Name = "MainMenu";
            Text = "MainMenu";
            Load += MainMenu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnCreatePlayer;
        private Button btnStartGame;
        private Button Title;
    }
}