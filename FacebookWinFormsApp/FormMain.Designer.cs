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
            this.labelUserData = new System.Windows.Forms.Label();
            this.searchableListWithTitleFeed = new BasicFacebookFeatures.SearchableListWithTitle();
            this.searchableListWithTitleLikedPages = new BasicFacebookFeatures.SearchableListWithTitle();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonAddPictureAndPost = new System.Windows.Forms.Button();
            this.richTextBoxPost = new System.Windows.Forms.RichTextBox();
            this.searchableListWithTitleGroups = new BasicFacebookFeatures.SearchableListWithTitle();
            this.searchableListWithTitleAlbums = new BasicFacebookFeatures.SearchableListWithTitle();
            this.checkBoxRememberUser = new System.Windows.Forms.CheckBox();
            this.searchableListWithTitleFriends = new BasicFacebookFeatures.SearchableListWithTitle();
            this.textBoxAppID = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureBoxSelectedPage = new System.Windows.Forms.PictureBox();
            this.pictureBoxSelectedGroup = new System.Windows.Forms.PictureBox();
            this.pictureBoxSelectedAlbum = new System.Windows.Forms.PictureBox();
            this.pictureBoxSelectedFriend = new System.Windows.Forms.PictureBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.searchableListWithTitleEvents = new BasicFacebookFeatures.SearchableListWithTitle();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedPage)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(928, 663);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.searchableListWithTitleEvents);
            this.tabPage1.Controls.Add(this.labelUserData);
            this.tabPage1.Controls.Add(this.searchableListWithTitleFeed);
            this.tabPage1.Controls.Add(this.pictureBoxSelectedPage);
            this.tabPage1.Controls.Add(this.searchableListWithTitleLikedPages);
            this.tabPage1.Controls.Add(this.buttonCancel);
            this.tabPage1.Controls.Add(this.buttonPost);
            this.tabPage1.Controls.Add(this.buttonAddPictureAndPost);
            this.tabPage1.Controls.Add(this.richTextBoxPost);
            this.tabPage1.Controls.Add(this.pictureBoxSelectedGroup);
            this.tabPage1.Controls.Add(this.searchableListWithTitleGroups);
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
            this.tabPage1.Size = new System.Drawing.Size(920, 632);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelUserData
            // 
            this.labelUserData.AutoSize = true;
            this.labelUserData.Font = new System.Drawing.Font("Palace Script MT", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserData.ForeColor = System.Drawing.Color.Brown;
            this.labelUserData.Location = new System.Drawing.Point(743, 13);
            this.labelUserData.Name = "labelUserData";
            this.labelUserData.Size = new System.Drawing.Size(0, 27);
            this.labelUserData.TabIndex = 70;
            // 
            // searchableListWithTitleFeed
            // 
            this.searchableListWithTitleFeed.DisplayMember = "";
            this.searchableListWithTitleFeed.Location = new System.Drawing.Point(9, 124);
            this.searchableListWithTitleFeed.Margin = new System.Windows.Forms.Padding(4);
            this.searchableListWithTitleFeed.Name = "searchableListWithTitleFeed";
            this.searchableListWithTitleFeed.Size = new System.Drawing.Size(160, 250);
            this.searchableListWithTitleFeed.TabIndex = 69;
            this.searchableListWithTitleFeed.Title = "Feed";
            // 
            // searchableListWithTitleLikedPages
            // 
            this.searchableListWithTitleLikedPages.DisplayMember = "";
            this.searchableListWithTitleLikedPages.Location = new System.Drawing.Point(234, 473);
            this.searchableListWithTitleLikedPages.Margin = new System.Windows.Forms.Padding(4);
            this.searchableListWithTitleLikedPages.Name = "searchableListWithTitleLikedPages";
            this.searchableListWithTitleLikedPages.Size = new System.Drawing.Size(150, 150);
            this.searchableListWithTitleLikedPages.TabIndex = 67;
            this.searchableListWithTitleLikedPages.Title = "Liked Pages";
            this.searchableListWithTitleLikedPages.SelectedIndexChanged += new System.EventHandler(this.searchableListWithTitleLikedPages_SelectedIndexChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Enabled = false;
            this.buttonCancel.Font = new System.Drawing.Font("Mistral", 18F, System.Drawing.FontStyle.Italic);
            this.buttonCancel.ForeColor = System.Drawing.Color.RosyBrown;
            this.buttonCancel.Location = new System.Drawing.Point(761, 408);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(83, 31);
            this.buttonCancel.TabIndex = 66;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonPost
            // 
            this.buttonPost.Enabled = false;
            this.buttonPost.Font = new System.Drawing.Font("Mistral", 18F, System.Drawing.FontStyle.Italic);
            this.buttonPost.ForeColor = System.Drawing.Color.RosyBrown;
            this.buttonPost.Location = new System.Drawing.Point(669, 408);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(80, 31);
            this.buttonPost.TabIndex = 65;
            this.buttonPost.Text = "Post";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonAddPictureAndPost
            // 
            this.buttonAddPictureAndPost.Enabled = false;
            this.buttonAddPictureAndPost.Font = new System.Drawing.Font("Mistral", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddPictureAndPost.ForeColor = System.Drawing.Color.RosyBrown;
            this.buttonAddPictureAndPost.Location = new System.Drawing.Point(618, 371);
            this.buttonAddPictureAndPost.Name = "buttonAddPictureAndPost";
            this.buttonAddPictureAndPost.Size = new System.Drawing.Size(281, 31);
            this.buttonAddPictureAndPost.TabIndex = 64;
            this.buttonAddPictureAndPost.Text = "Add a Picture and Post";
            this.buttonAddPictureAndPost.UseVisualStyleBackColor = true;
            this.buttonAddPictureAndPost.Click += new System.EventHandler(this.buttonAddPictureAndPost_Click);
            // 
            // richTextBoxPost
            // 
            this.richTextBoxPost.Enabled = false;
            this.richTextBoxPost.Location = new System.Drawing.Point(325, 186);
            this.richTextBoxPost.Name = "richTextBoxPost";
            this.richTextBoxPost.Size = new System.Drawing.Size(586, 179);
            this.richTextBoxPost.TabIndex = 63;
            this.richTextBoxPost.Text = "";
            this.richTextBoxPost.TextChanged += new System.EventHandler(this.richTextBoxPost_TextChanged);
            // 
            // searchableListWithTitleGroups
            // 
            this.searchableListWithTitleGroups.DisplayMember = "";
            this.searchableListWithTitleGroups.Location = new System.Drawing.Point(411, 473);
            this.searchableListWithTitleGroups.Margin = new System.Windows.Forms.Padding(4);
            this.searchableListWithTitleGroups.Name = "searchableListWithTitleGroups";
            this.searchableListWithTitleGroups.Size = new System.Drawing.Size(150, 150);
            this.searchableListWithTitleGroups.TabIndex = 61;
            this.searchableListWithTitleGroups.Title = "Groups";
            this.searchableListWithTitleGroups.SelectedIndexChanged += new System.EventHandler(this.searchableListWithTitleGroups_SelectedIndexChanged);
            // 
            // searchableListWithTitleAlbums
            // 
            this.searchableListWithTitleAlbums.DisplayMember = "";
            this.searchableListWithTitleAlbums.Location = new System.Drawing.Point(585, 473);
            this.searchableListWithTitleAlbums.Margin = new System.Windows.Forms.Padding(4);
            this.searchableListWithTitleAlbums.Name = "searchableListWithTitleAlbums";
            this.searchableListWithTitleAlbums.Size = new System.Drawing.Size(150, 150);
            this.searchableListWithTitleAlbums.TabIndex = 59;
            this.searchableListWithTitleAlbums.Title = "Albums";
            this.searchableListWithTitleAlbums.SelectedIndexChanged += new System.EventHandler(this.searchableListWithTitleAlbums_SelectedIndexChanged);
            // 
            // checkBoxRememberUser
            // 
            this.checkBoxRememberUser.AutoSize = true;
            this.checkBoxRememberUser.Enabled = false;
            this.checkBoxRememberUser.ForeColor = System.Drawing.Color.Brown;
            this.checkBoxRememberUser.Location = new System.Drawing.Point(623, 124);
            this.checkBoxRememberUser.Name = "checkBoxRememberUser";
            this.checkBoxRememberUser.Size = new System.Drawing.Size(126, 23);
            this.checkBoxRememberUser.TabIndex = 58;
            this.checkBoxRememberUser.Text = "Remember Me";
            this.checkBoxRememberUser.UseVisualStyleBackColor = true;
            // 
            // searchableListWithTitleFriends
            // 
            this.searchableListWithTitleFriends.DisplayMember = "";
            this.searchableListWithTitleFriends.Location = new System.Drawing.Point(761, 473);
            this.searchableListWithTitleFriends.Margin = new System.Windows.Forms.Padding(4);
            this.searchableListWithTitleFriends.Name = "searchableListWithTitleFriends";
            this.searchableListWithTitleFriends.Size = new System.Drawing.Size(150, 150);
            this.searchableListWithTitleFriends.TabIndex = 56;
            this.searchableListWithTitleFriends.Title = "Friends";
            this.searchableListWithTitleFriends.SelectedIndexChanged += new System.EventHandler(this.searchableListWithTitleFriends_SelectedIndexChanged);
            // 
            // textBoxAppID
            // 
            this.textBoxAppID.Location = new System.Drawing.Point(8, 47);
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
            this.tabPage2.Size = new System.Drawing.Size(857, 490);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // pictureBoxSelectedPage
            // 
            this.pictureBoxSelectedPage.Image = global::BasicFacebookFeatures.Properties.Resources.like_icon;
            this.pictureBoxSelectedPage.Location = new System.Drawing.Point(344, 566);
            this.pictureBoxSelectedPage.Name = "pictureBoxSelectedPage";
            this.pictureBoxSelectedPage.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxSelectedPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSelectedPage.TabIndex = 68;
            this.pictureBoxSelectedPage.TabStop = false;
            // 
            // pictureBoxSelectedGroup
            // 
            this.pictureBoxSelectedGroup.Image = global::BasicFacebookFeatures.Properties.Resources.group_icon;
            this.pictureBoxSelectedGroup.Location = new System.Drawing.Point(518, 566);
            this.pictureBoxSelectedGroup.Name = "pictureBoxSelectedGroup";
            this.pictureBoxSelectedGroup.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxSelectedGroup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSelectedGroup.TabIndex = 62;
            this.pictureBoxSelectedGroup.TabStop = false;
            // 
            // pictureBoxSelectedAlbum
            // 
            this.pictureBoxSelectedAlbum.Image = global::BasicFacebookFeatures.Properties.Resources.albums_icon;
            this.pictureBoxSelectedAlbum.Location = new System.Drawing.Point(688, 566);
            this.pictureBoxSelectedAlbum.Name = "pictureBoxSelectedAlbum";
            this.pictureBoxSelectedAlbum.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxSelectedAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSelectedAlbum.TabIndex = 60;
            this.pictureBoxSelectedAlbum.TabStop = false;
            // 
            // pictureBoxSelectedFriend
            // 
            this.pictureBoxSelectedFriend.Image = global::BasicFacebookFeatures.Properties.Resources.friends_icon;
            this.pictureBoxSelectedFriend.Location = new System.Drawing.Point(857, 566);
            this.pictureBoxSelectedFriend.Name = "pictureBoxSelectedFriend";
            this.pictureBoxSelectedFriend.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxSelectedFriend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSelectedFriend.TabIndex = 57;
            this.pictureBoxSelectedFriend.TabStop = false;
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Image = global::BasicFacebookFeatures.Properties.Resources.user_icon;
            this.pictureBoxProfile.InitialImage = null;
            this.pictureBoxProfile.Location = new System.Drawing.Point(623, 13);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(101, 102);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            // 
            // searchableListWithTitleEvents
            // 
            this.searchableListWithTitleEvents.DisplayMember = "";
            this.searchableListWithTitleEvents.Location = new System.Drawing.Point(9, 382);
            this.searchableListWithTitleEvents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchableListWithTitleEvents.Name = "searchableListWithTitleEvents";
            this.searchableListWithTitleEvents.Size = new System.Drawing.Size(160, 250);
            this.searchableListWithTitleEvents.TabIndex = 71;
            this.searchableListWithTitleEvents.Title = "Events";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 663);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedPage)).EndInit();
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
        private SearchableListWithTitle searchableListWithTitleGroups;
        private System.Windows.Forms.RichTextBox richTextBoxPost;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonAddPictureAndPost;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pictureBoxSelectedPage;
        private SearchableListWithTitle searchableListWithTitleLikedPages;
        private SearchableListWithTitle searchableListWithTitleFeed;
        private System.Windows.Forms.Label labelUserData;
        private SearchableListWithTitle searchableListWithTitleEvents;
    }
}

