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
            this.checkBoxRememberUser = new System.Windows.Forms.CheckBox();
            this.textBoxAppID = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBoxPost = new System.Windows.Forms.RichTextBox();
            this.buttonAddPicture = new System.Windows.Forms.Button();
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.pictureBoxSelectedGroup = new System.Windows.Forms.PictureBox();
            this.pictureBoxSelectedAlbum = new System.Windows.Forms.PictureBox();
            this.pictureBoxSelectedFriend = new System.Windows.Forms.PictureBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.searchableListWithTitleGרםופד = new BasicFacebookFeatures.SearchableListWithTitle();
            this.searchableListWithTitleAlbums = new BasicFacebookFeatures.SearchableListWithTitle();
            this.searchableListWithTitleFriends = new BasicFacebookFeatures.SearchableListWithTitle();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedAlbum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedFriend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(865, 483);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonCancel);
            this.tabPage1.Controls.Add(this.buttonPost);
            this.tabPage1.Controls.Add(this.buttonAddPicture);
            this.tabPage1.Controls.Add(this.richTextBoxPost);
            this.tabPage1.Controls.Add(this.pictureBoxSelectedGroup);
            this.tabPage1.Controls.Add(this.searchableListWithTitleGרםופד);
            this.tabPage1.Controls.Add(this.pictureBoxSelectedAlbum);
            this.tabPage1.Controls.Add(this.searchableListWithTitleAlbums);
            this.tabPage1.Controls.Add(this.checkBoxRememberUser);
            this.tabPage1.Controls.Add(this.pictureBoxSelectedFriend);
            this.tabPage1.Controls.Add(this.searchableListWithTitleFriends);
            this.tabPage1.Controls.Add(this.textBoxAppID);
            this.tabPage1.Controls.Add(this.buttonLogout);
            this.tabPage1.Controls.Add(this.buttonLogin);
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(857, 452);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // textBoxAppID
            // 
            this.textBoxAppID.Location = new System.Drawing.Point(6, 47);
            this.textBoxAppID.Name = "textBoxAppID";
            this.textBoxAppID.Size = new System.Drawing.Size(237, 26);
            this.textBoxAppID.TabIndex = 54;
            this.textBoxAppID.Text = "1255437599029620";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(857, 452);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBoxPost
            // 
            this.richTextBoxPost.Location = new System.Drawing.Point(344, 14);
            this.richTextBoxPost.Name = "richTextBoxPost";
            this.richTextBoxPost.Size = new System.Drawing.Size(472, 127);
            this.richTextBoxPost.TabIndex = 63;
            this.richTextBoxPost.Text = "";
            // 
            // buttonAddPicture
            // 
            this.buttonAddPicture.Location = new System.Drawing.Point(688, 147);
            this.buttonAddPicture.Name = "buttonAddPicture";
            this.buttonAddPicture.Size = new System.Drawing.Size(128, 31);
            this.buttonAddPicture.TabIndex = 64;
            this.buttonAddPicture.Text = "Add a Picture";
            this.buttonAddPicture.UseVisualStyleBackColor = true;
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(692, 184);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(61, 31);
            this.buttonPost.TabIndex = 65;
            this.buttonPost.Text = "Post";
            this.buttonPost.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(759, 184);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(61, 31);
            this.buttonCancel.TabIndex = 66;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // pictureBoxSelectedGroup
            // 
            this.pictureBoxSelectedGroup.Location = new System.Drawing.Point(356, 265);
            this.pictureBoxSelectedGroup.Name = "pictureBoxSelectedGroup";
            this.pictureBoxSelectedGroup.Size = new System.Drawing.Size(40, 42);
            this.pictureBoxSelectedGroup.TabIndex = 62;
            this.pictureBoxSelectedGroup.TabStop = false;
            // 
            // pictureBoxSelectedAlbum
            // 
            this.pictureBoxSelectedAlbum.Location = new System.Drawing.Point(556, 265);
            this.pictureBoxSelectedAlbum.Name = "pictureBoxSelectedAlbum";
            this.pictureBoxSelectedAlbum.Size = new System.Drawing.Size(39, 42);
            this.pictureBoxSelectedAlbum.TabIndex = 60;
            this.pictureBoxSelectedAlbum.TabStop = false;
            // 
            // pictureBoxSelectedFriend
            // 
            this.pictureBoxSelectedFriend.Location = new System.Drawing.Point(759, 265);
            this.pictureBoxSelectedFriend.Name = "pictureBoxSelectedFriend";
            this.pictureBoxSelectedFriend.Size = new System.Drawing.Size(39, 42);
            this.pictureBoxSelectedFriend.TabIndex = 57;
            this.pictureBoxSelectedFriend.TabStop = false;
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(36, 108);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(79, 78);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            // 
            // searchableListWithTitleGרםופד
            // 
            this.searchableListWithTitleGרםופד.DisplayMember = "";
            this.searchableListWithTitleGרםופד.Location = new System.Drawing.Point(275, 284);
            this.searchableListWithTitleGרםופד.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchableListWithTitleGרםופד.Name = "searchableListWithTitleGרםופד";
            this.searchableListWithTitleGרםופד.Size = new System.Drawing.Size(167, 149);
            this.searchableListWithTitleGרםופד.TabIndex = 61;
            this.searchableListWithTitleGרםופד.Title = "Groups";
            // 
            // searchableListWithTitleAlbums
            // 
            this.searchableListWithTitleAlbums.DisplayMember = "";
            this.searchableListWithTitleAlbums.Location = new System.Drawing.Point(467, 285);
            this.searchableListWithTitleAlbums.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchableListWithTitleAlbums.Name = "searchableListWithTitleAlbums";
            this.searchableListWithTitleAlbums.Size = new System.Drawing.Size(171, 148);
            this.searchableListWithTitleAlbums.TabIndex = 59;
            this.searchableListWithTitleAlbums.Title = "Albums";
            this.searchableListWithTitleAlbums.SelectedIndexChanged += new System.EventHandler(this.searchableListWithTitleAlbums_SelectedIndexChanged);
            // 
            // searchableListWithTitleFriends
            // 
            this.searchableListWithTitleFriends.DisplayMember = "";
            this.searchableListWithTitleFriends.Location = new System.Drawing.Point(669, 285);
            this.searchableListWithTitleFriends.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchableListWithTitleFriends.Name = "searchableListWithTitleFriends";
            this.searchableListWithTitleFriends.Size = new System.Drawing.Size(164, 148);
            this.searchableListWithTitleFriends.TabIndex = 56;
            this.searchableListWithTitleFriends.Title = "Friends";
            this.searchableListWithTitleFriends.SelectedIndexChanged += new System.EventHandler(this.searchableListWithTitleFriends_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 483);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedAlbum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedFriend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBoxSelectedFriend;
        private System.Windows.Forms.CheckBox checkBoxRememberUser;
        private System.Windows.Forms.PictureBox pictureBoxSelectedAlbum;
        private SearchableListWithTitle searchableListWithTitleAlbums;
        private System.Windows.Forms.PictureBox pictureBoxSelectedGroup;
        private SearchableListWithTitle searchableListWithTitleGרםופד;
        private System.Windows.Forms.RichTextBox richTextBoxPost;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonAddPicture;
    }
}

