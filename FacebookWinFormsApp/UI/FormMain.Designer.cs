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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label nameLabel1;
            System.Windows.Forms.Label birthdayLabel;
            System.Windows.Forms.Label emailLabel;
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonGuessTheYear = new System.Windows.Forms.Button();
            this.buttonProfileAnalyzer = new System.Windows.Forms.Button();
            this.searchableListWithTitleEvents = new BasicFacebookFeatures.SearchableListWithTitle();
            this.labelUserData = new System.Windows.Forms.Label();
            this.searchableListWithTitleFeed = new BasicFacebookFeatures.SearchableListWithTitle();
            this.pictureBoxSelectedPage = new System.Windows.Forms.PictureBox();
            this.searchableListWithTitleLikedPages = new BasicFacebookFeatures.SearchableListWithTitle();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonAddPictureAndPost = new System.Windows.Forms.Button();
            this.richTextBoxPost = new System.Windows.Forms.RichTextBox();
            this.pictureBoxSelectedGroup = new System.Windows.Forms.PictureBox();
            this.searchableListWithTitleGroups = new BasicFacebookFeatures.SearchableListWithTitle();
            this.pictureBoxSelectedAlbum = new System.Windows.Forms.PictureBox();
            this.searchableListWithTitleAlbums = new BasicFacebookFeatures.SearchableListWithTitle();
            this.checkBoxRememberUser = new System.Windows.Forms.CheckBox();
            this.pictureBoxSelectedFriend = new System.Windows.Forms.PictureBox();
            this.searchableListWithTitleFriends = new BasicFacebookFeatures.SearchableListWithTitle();
            this.textBoxAppID = new System.Windows.Forms.TextBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.albumBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.friendListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameTextBox1 = new System.Windows.Forms.TextBox();
            this.membersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.birthdayTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            nameLabel = new System.Windows.Forms.Label();
            nameLabel1 = new System.Windows.Forms.Label();
            birthdayLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedAlbum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedFriend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(7, 12);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(188, 28);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Location = new System.Drawing.Point(203, 13);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(102, 28);
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
            this.tabControl1.Size = new System.Drawing.Size(1453, 663);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.buttonGuessTheYear);
            this.tabPage1.Controls.Add(this.buttonProfileAnalyzer);
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
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1445, 628);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonGuessTheYear
            // 
            this.buttonGuessTheYear.Enabled = false;
            this.buttonGuessTheYear.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuessTheYear.ForeColor = System.Drawing.Color.RosyBrown;
            this.buttonGuessTheYear.Location = new System.Drawing.Point(385, 103);
            this.buttonGuessTheYear.Name = "buttonGuessTheYear";
            this.buttonGuessTheYear.Size = new System.Drawing.Size(109, 66);
            this.buttonGuessTheYear.TabIndex = 73;
            this.buttonGuessTheYear.Text = "Guess The Year";
            this.buttonGuessTheYear.UseVisualStyleBackColor = true;
            this.buttonGuessTheYear.Click += new System.EventHandler(this.buttonGuessTheYear_Click);
            // 
            // buttonProfileAnalyzer
            // 
            this.buttonProfileAnalyzer.Enabled = false;
            this.buttonProfileAnalyzer.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProfileAnalyzer.ForeColor = System.Drawing.Color.RosyBrown;
            this.buttonProfileAnalyzer.Location = new System.Drawing.Point(218, 103);
            this.buttonProfileAnalyzer.Name = "buttonProfileAnalyzer";
            this.buttonProfileAnalyzer.Size = new System.Drawing.Size(139, 66);
            this.buttonProfileAnalyzer.TabIndex = 72;
            this.buttonProfileAnalyzer.Text = "Profile Analyzer";
            this.buttonProfileAnalyzer.UseVisualStyleBackColor = true;
            this.buttonProfileAnalyzer.Click += new System.EventHandler(this.buttonProfileAnalyzer_Click);
            // 
            // searchableListWithTitleEvents
            // 
            this.searchableListWithTitleEvents.DataSource = null;
            this.searchableListWithTitleEvents.DisplayMember = "";
            this.searchableListWithTitleEvents.Location = new System.Drawing.Point(9, 382);
            this.searchableListWithTitleEvents.Margin = new System.Windows.Forms.Padding(4);
            this.searchableListWithTitleEvents.Name = "searchableListWithTitleEvents";
            this.searchableListWithTitleEvents.Size = new System.Drawing.Size(160, 250);
            this.searchableListWithTitleEvents.TabIndex = 71;
            this.searchableListWithTitleEvents.Title = "Events";
            // 
            // labelUserData
            // 
            this.labelUserData.AutoSize = true;
            this.labelUserData.Font = new System.Drawing.Font("Palace Script MT", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserData.ForeColor = System.Drawing.Color.Brown;
            this.labelUserData.Location = new System.Drawing.Point(743, 13);
            this.labelUserData.Name = "labelUserData";
            this.labelUserData.Size = new System.Drawing.Size(0, 34);
            this.labelUserData.TabIndex = 70;
            // 
            // searchableListWithTitleFeed
            // 
            this.searchableListWithTitleFeed.DataSource = null;
            this.searchableListWithTitleFeed.DisplayMember = "";
            this.searchableListWithTitleFeed.Location = new System.Drawing.Point(9, 124);
            this.searchableListWithTitleFeed.Margin = new System.Windows.Forms.Padding(4);
            this.searchableListWithTitleFeed.Name = "searchableListWithTitleFeed";
            this.searchableListWithTitleFeed.Size = new System.Drawing.Size(160, 250);
            this.searchableListWithTitleFeed.TabIndex = 69;
            this.searchableListWithTitleFeed.Title = "Feed";
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
            // searchableListWithTitleLikedPages
            // 
            this.searchableListWithTitleLikedPages.DataSource = null;
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
            this.buttonCancel.Location = new System.Drawing.Point(754, 419);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(91, 34);
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
            this.buttonPost.Location = new System.Drawing.Point(668, 419);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(80, 34);
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
            this.buttonAddPictureAndPost.Size = new System.Drawing.Size(281, 42);
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
            // searchableListWithTitleGroups
            // 
            this.searchableListWithTitleGroups.DataSource = null;
            this.searchableListWithTitleGroups.DisplayMember = "";
            this.searchableListWithTitleGroups.Location = new System.Drawing.Point(411, 473);
            this.searchableListWithTitleGroups.Margin = new System.Windows.Forms.Padding(4);
            this.searchableListWithTitleGroups.Name = "searchableListWithTitleGroups";
            this.searchableListWithTitleGroups.Size = new System.Drawing.Size(150, 150);
            this.searchableListWithTitleGroups.TabIndex = 61;
            this.searchableListWithTitleGroups.Title = "Groups";
            this.searchableListWithTitleGroups.SelectedIndexChanged += new System.EventHandler(this.searchableListWithTitleGroups_SelectedIndexChanged);
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
            // searchableListWithTitleAlbums
            // 
            this.searchableListWithTitleAlbums.DataSource = null;
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
            this.checkBoxRememberUser.Size = new System.Drawing.Size(155, 27);
            this.checkBoxRememberUser.TabIndex = 58;
            this.checkBoxRememberUser.Text = "Remember Me";
            this.checkBoxRememberUser.UseVisualStyleBackColor = true;
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
            // searchableListWithTitleFriends
            // 
            this.searchableListWithTitleFriends.DataSource = null;
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
            this.textBoxAppID.Size = new System.Drawing.Size(237, 31);
            this.textBoxAppID.TabIndex = 54;
            this.textBoxAppID.Text = "1255437599029620";
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
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(920, 628);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(emailLabel);
            this.panel1.Controls.Add(this.emailTextBox);
            this.panel1.Controls.Add(birthdayLabel);
            this.panel1.Controls.Add(this.birthdayTextBox);
            this.panel1.Controls.Add(nameLabel1);
            this.panel1.Controls.Add(this.nameTextBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(nameLabel);
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(961, 371);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 236);
            this.panel1.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 75;
            this.label1.Text = "Album Editor";
            // 
            // albumBindingSource
            // 
            this.albumBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Album);
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(17, 35);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(64, 23);
            nameLabel.TabIndex = 75;
            nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.albumBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(87, 32);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(303, 31);
            this.nameTextBox.TabIndex = 76;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 23);
            this.label2.TabIndex = 75;
            this.label2.Text = "Friend Editor";
            // 
            // friendListBindingSource
            // 
            this.friendListBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.FriendList);
            // 
            // nameLabel1
            // 
            nameLabel1.AutoSize = true;
            nameLabel1.Location = new System.Drawing.Point(17, 109);
            nameLabel1.Name = "nameLabel1";
            nameLabel1.Size = new System.Drawing.Size(64, 23);
            nameLabel1.TabIndex = 76;
            nameLabel1.Text = "Name:";
            // 
            // nameTextBox1
            // 
            this.nameTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.friendListBindingSource, "Name", true));
            this.nameTextBox1.Location = new System.Drawing.Point(109, 101);
            this.nameTextBox1.Name = "nameTextBox1";
            this.nameTextBox1.Size = new System.Drawing.Size(281, 31);
            this.nameTextBox1.TabIndex = 77;
            // 
            // membersBindingSource
            // 
            this.membersBindingSource.DataMember = "Members";
            this.membersBindingSource.DataSource = this.friendListBindingSource;
            // 
            // birthdayLabel
            // 
            birthdayLabel.AutoSize = true;
            birthdayLabel.Location = new System.Drawing.Point(17, 146);
            birthdayLabel.Name = "birthdayLabel";
            birthdayLabel.Size = new System.Drawing.Size(84, 23);
            birthdayLabel.TabIndex = 77;
            birthdayLabel.Text = "Birthday:";
            // 
            // birthdayTextBox
            // 
            this.birthdayTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.membersBindingSource, "Birthday", true));
            this.birthdayTextBox.Location = new System.Drawing.Point(109, 138);
            this.birthdayTextBox.Name = "birthdayTextBox";
            this.birthdayTextBox.Size = new System.Drawing.Size(281, 31);
            this.birthdayTextBox.TabIndex = 78;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(17, 183);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(60, 23);
            emailLabel.TabIndex = 78;
            emailLabel.Text = "Email:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.membersBindingSource, "Email", true));
            this.emailTextBox.Location = new System.Drawing.Point(109, 180);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(281, 31);
            this.emailTextBox.TabIndex = 79;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1453, 663);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersBindingSource)).EndInit();
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
        private System.Windows.Forms.Button buttonGuessTheYear;
        private System.Windows.Forms.Button buttonProfileAnalyzer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.BindingSource membersBindingSource;
        private System.Windows.Forms.BindingSource friendListBindingSource;
        private System.Windows.Forms.TextBox birthdayTextBox;
        private System.Windows.Forms.TextBox nameTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.BindingSource albumBindingSource;
        private System.Windows.Forms.Label label1;
    }
}

