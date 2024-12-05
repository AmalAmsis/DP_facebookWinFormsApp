namespace BasicFacebookFeatures
{
    partial class FormMain
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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBoxchoosenFriend = new System.Windows.Forms.PictureBox();
            this.searchableListWithTitleFriends = new BasicFacebookFeatures.SearchableListWithTitle();
            this.textBoxAppID = new System.Windows.Forms.TextBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBoxRememberUser = new System.Windows.Forms.CheckBox();
            this.searchableListWithTitleAlbums = new BasicFacebookFeatures.SearchableListWithTitle();
            this.pictureBoxAlbum = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxchoosenFriend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbum)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(7, 12);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(154, 28);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Location = new System.Drawing.Point(169, 12);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(67, 28);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(741, 429);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBoxAlbum);
            this.tabPage1.Controls.Add(this.searchableListWithTitleAlbums);
            this.tabPage1.Controls.Add(this.checkBoxRememberUser);
            this.tabPage1.Controls.Add(this.pictureBoxchoosenFriend);
            this.tabPage1.Controls.Add(this.searchableListWithTitleFriends);
            this.tabPage1.Controls.Add(this.textBoxAppID);
            this.tabPage1.Controls.Add(this.buttonLogout);
            this.tabPage1.Controls.Add(this.buttonLogin);
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(733, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBoxchoosenFriend
            // 
            this.pictureBoxchoosenFriend.Location = new System.Drawing.Point(628, 202);
            this.pictureBoxchoosenFriend.Name = "pictureBoxchoosenFriend";
            this.pictureBoxchoosenFriend.Size = new System.Drawing.Size(39, 42);
            this.pictureBoxchoosenFriend.TabIndex = 57;
            this.pictureBoxchoosenFriend.TabStop = false;
            // 
            // searchableListWithTitleFriends
            // 
            this.searchableListWithTitleFriends.DisplayMember = "";
            this.searchableListWithTitleFriends.Location = new System.Drawing.Point(536, 225);
            this.searchableListWithTitleFriends.Margin = new System.Windows.Forms.Padding(4);
            this.searchableListWithTitleFriends.Name = "searchableListWithTitleFriends";
            this.searchableListWithTitleFriends.Size = new System.Drawing.Size(164, 158);
            this.searchableListWithTitleFriends.TabIndex = 56;
            this.searchableListWithTitleFriends.Title = "Friends";
            this.searchableListWithTitleFriends.SelectedIndexChanged += new System.EventHandler(this.searchableListWithTitleFriends_SelectedIndexChanged);
            // 
            // textBoxAppID
            // 
            this.textBoxAppID.Location = new System.Drawing.Point(6, 47);
            this.textBoxAppID.Name = "textBoxAppID";
            this.textBoxAppID.Size = new System.Drawing.Size(237, 26);
            this.textBoxAppID.TabIndex = 54;
            this.textBoxAppID.Text = "1255437599029620";
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(628, 6);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(79, 78);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1235, 666);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBoxRememberUser
            // 
            this.checkBoxRememberUser.AutoSize = true;
            this.checkBoxRememberUser.Location = new System.Drawing.Point(8, 79);
            this.checkBoxRememberUser.Name = "checkBoxRememberUser";
            this.checkBoxRememberUser.Size = new System.Drawing.Size(126, 23);
            this.checkBoxRememberUser.TabIndex = 58;
            this.checkBoxRememberUser.Text = "Remember Me";
            this.checkBoxRememberUser.UseVisualStyleBackColor = true;
            // 
            // searchableListWithTitleAlbums
            // 
            this.searchableListWithTitleAlbums.DisplayMember = "";
            this.searchableListWithTitleAlbums.Location = new System.Drawing.Point(337, 225);
            this.searchableListWithTitleAlbums.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchableListWithTitleAlbums.Name = "searchableListWithTitleAlbums";
            this.searchableListWithTitleAlbums.Size = new System.Drawing.Size(171, 147);
            this.searchableListWithTitleAlbums.TabIndex = 59;
            this.searchableListWithTitleAlbums.Title = "Albums";
            this.searchableListWithTitleAlbums.SelectedIndexChanged += new System.EventHandler(this.searchableListWithTitleAlbums_SelectedIndexChanged);
            // 
            // pictureBoxAlbum
            // 
            this.pictureBoxAlbum.Location = new System.Drawing.Point(422, 202);
            this.pictureBoxAlbum.Name = "pictureBoxAlbum";
            this.pictureBoxAlbum.Size = new System.Drawing.Size(39, 42);
            this.pictureBoxAlbum.TabIndex = 60;
            this.pictureBoxAlbum.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 429);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxchoosenFriend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbum)).EndInit();
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonLogout;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxAppID;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private SearchableListWithTitle searchableListWithTitleFriends;
        private System.Windows.Forms.PictureBox pictureBoxchoosenFriend;
        private System.Windows.Forms.CheckBox checkBoxRememberUser;
        private System.Windows.Forms.PictureBox pictureBoxAlbum;
        private SearchableListWithTitle searchableListWithTitleAlbums;
    }
}

