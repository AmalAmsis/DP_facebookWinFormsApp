using System;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper;
using BasicFacebookFeatures.Properties;
using BasicFacebookFeatures.Features;
using System.Threading;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private readonly FacebookManager r_FacebookManager = FacebookManager.Instance;

        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");
            if (!r_FacebookManager.IsLoggedIn)
            {
                login();
            }
        }

        private void login()
        {
            string[] permissions = {
                "email",
                "public_profile",
                "user_age_range",
                "user_birthday",
                "user_events",
                "user_friends",
                "user_gender",
                "user_hometown",
                "user_likes",
                "user_link",
                "user_location",
                "user_photos",
                "user_posts",
                "user_videos"
            };

            new Thread(() =>
            {
                LoginResult loginResult = r_FacebookManager.Login(textBoxAppID.Text, permissions);

                if (!string.IsNullOrEmpty(loginResult.AccessToken))
                {
                    this.Invoke(new Action(() => loadUserData()));
                }
                else
                {
                    this.Invoke(new Action(() => 
                        MessageBox.Show(loginResult.ErrorMessage, "Login Failed")));
                }
            }).Start();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                r_FacebookManager.Logout();
                
                this.Invoke(new Action(() =>
                {
                    const bool v_IsLogin = true;
                    buttonLogin.Text = "Login";
                    buttonLogin.BackColor = buttonLogout.BackColor;
                    buttonLogin.Enabled = true;
                    buttonLogout.Enabled = false;
                    clearUserData();
                    tabPage1.Text = "Main App";
                    checkBoxRememberUser.Checked = false;
                    toggleLoginUI(!v_IsLogin);
                    togglePostButtons(!v_IsLogin);
                    toggleFeaturesButtons(!v_IsLogin);
                }));
            }).Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            r_FacebookManager.RememberUser = checkBoxRememberUser.Checked;
            r_FacebookManager.SaveSettings();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            
            new Thread(() =>
            {
                this.Invoke(new Action(() => 
                {
                    checkBoxRememberUser.Checked = r_FacebookManager.RememberUser;
                }));

                if (r_FacebookManager.TryConnectFromSavedToken())
                {
                    this.Invoke(new Action(() => loadUserData()));
                }
            }).Start();
        }

        private void loadUserData()
        {
            const bool v_IsLogin = true;

            buttonLogin.Text = $"Logged in as {r_FacebookManager.UserName}";
            buttonLogin.BackColor = Color.LightGreen;
            pictureBoxProfile.ImageLocation = r_FacebookManager.ProfilePictureURL;
            labelUserData.Text = $@"{r_FacebookManager.UserName}
{r_FacebookManager.Birthday}
{r_FacebookManager.Gender?.ToString() ?? "Unknown"}";
            tabPage1.Text = r_FacebookManager.UserName;
            toggleLoginUI(v_IsLogin);
            toggleFeaturesButtons(v_IsLogin);

            new Thread(() =>
            {
                fetchUserData();
            }).Start();
        }

        private void clearUserData()
        {
            pictureBoxProfile.Invoke(new Action(() => 
                pictureBoxProfile.Image = Resources.user_icon));
            pictureBoxSelectedAlbum.Invoke(new Action(() => 
                pictureBoxSelectedAlbum.Image = Resources.albums_icon));
            pictureBoxSelectedFriend.Invoke(new Action(() => 
                pictureBoxSelectedFriend.Image = Resources.friends_icon));
            pictureBoxSelectedGroup.Invoke(new Action(() => 
                pictureBoxSelectedGroup.Image = Resources.group_icon));
            pictureBoxSelectedPage.Invoke(new Action(() => 
                pictureBoxSelectedPage.Image = Resources.like_icon));
            
            searchableListWithTitleFriends.Invoke(new Action(() => 
                searchableListWithTitleFriends.Items.Clear()));
            searchableListWithTitleAlbums.Invoke(new Action(() => 
                searchableListWithTitleAlbums.Items.Clear()));
            searchableListWithTitleEvents.Invoke(new Action(() => 
                searchableListWithTitleEvents.Items.Clear()));
            searchableListWithTitleFeed.Invoke(new Action(() => 
                searchableListWithTitleFeed.Items.Clear()));
            searchableListWithTitleGroups.Invoke(new Action(() => 
                searchableListWithTitleGroups.Items.Clear()));
            searchableListWithTitleLikedPages.Invoke(new Action(() => 
                searchableListWithTitleLikedPages.Items.Clear()));
            
            labelUserData.Invoke(new Action(() => 
                labelUserData.Text = ""));
        }

        private void toggleLoginUI(bool i_IsLogin)
        {
            buttonLogin.Enabled = !i_IsLogin;
            buttonLogout.Enabled = i_IsLogin;
            checkBoxRememberUser.Enabled = i_IsLogin;
            richTextBoxPost.Enabled = i_IsLogin;
        }

        private void fetchUserData()
        {
            new Thread(() =>
            {
                fetchUserFriends();
                fetchUserAlbums();
                fetchUserGroups();
                fetchLikedPages();
                fetchUserFeed();
                fetchUserEvents();
            }).Start();
        }

        private void fetchUserFriends()
        {
            new Thread(() =>
            {
                try
                {
                    FacebookObjectCollection<User> friends = r_FacebookManager.GetFriends() as FacebookObjectCollection<User>;

                    if (friends != null && friends.Count > 0)
                    {
                        searchableListWithTitleAlbums.Invoke(new Action(() => {
                            searchableListWithTitleFriends.DataSource = null;
                            friendListBindingSource.DataSource = friends;
                            searchableListWithTitleFriends.DataSource = friendListBindingSource;
                            searchableListWithTitleFriends.DisplayMember = "Name";
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            searchableListWithTitleFriends.DataSource = null;
                            searchableListWithTitleFriends.Items.Clear();
                        }));
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() => MessageBox.Show($"Error retrieving friends: {ex.Message}")));
                }

            }).Start();
        }

        private void fetchUserAlbums()
        {
            new Thread(() =>
            {
                try
                {
                    FacebookObjectCollection<Album> albums = r_FacebookManager.GetAlbums() as FacebookObjectCollection<Album>;

                    if (albums != null && albums.Count > 0)
                    {
                        searchableListWithTitleAlbums.Invoke(new Action(() => {
                            searchableListWithTitleAlbums.DataSource = null;
                            albumBindingSource.DataSource = albums;
                            searchableListWithTitleAlbums.DataSource = albumBindingSource;
                            searchableListWithTitleAlbums.DisplayMember = "Name";
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            searchableListWithTitleAlbums.DataSource = null;
                            searchableListWithTitleAlbums.Items.Clear();
                        }));
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() => MessageBox.Show($"Error retrieving albums: {ex.Message}")));
                }

            }).Start();
        }

        private void fetchUserGroups()
        {
            new Thread(() =>
            {
                searchableListWithTitleGroups.Invoke(new Action(() => {
                    searchableListWithTitleGroups.Items.Clear();
                    searchableListWithTitleGroups.DisplayMember = "Name";
                }));

                foreach (var group in r_FacebookManager.GetGroups())
                {
                    searchableListWithTitleGroups.Invoke(new Action(() => 
                        searchableListWithTitleGroups.Items.Add(group)));
                }
            }).Start();
        }

        private void fetchLikedPages()
        {
            new Thread(() =>
            {
                searchableListWithTitleLikedPages.Invoke(new Action(() => {
                    searchableListWithTitleLikedPages.Items.Clear();
                    searchableListWithTitleLikedPages.DisplayMember = "Name";
                }));

                foreach (var page in r_FacebookManager.GetLikedPages())
                {
                    searchableListWithTitleLikedPages.Invoke(new Action(() => 
                        searchableListWithTitleLikedPages.Items.Add(page)));
                }
            }).Start();
        }

        private void fetchUserFeed()
        {
            new Thread(() =>
            {
                searchableListWithTitleFeed.Invoke(new Action(() => {
                    searchableListWithTitleFeed.Items.Clear();
                    searchableListWithTitleFeed.DisplayMember = "Name";
                }));

                foreach (var post in r_FacebookManager.GetNewsFeed())
                {
                    searchableListWithTitleFeed.Invoke(new Action(() => 
                        searchableListWithTitleFeed.Items.Add(post)));
                }
            }).Start();
        }

        private void fetchUserEvents()
        {
            new Thread(() =>
            {
                searchableListWithTitleEvents.Invoke(new Action(() => {
                    searchableListWithTitleEvents.Items.Clear();
                    searchableListWithTitleEvents.DisplayMember = "Name";
                }));

                foreach (var fbEvent in r_FacebookManager.GetEvents())
                {
                    searchableListWithTitleEvents.Invoke(new Action(() => 
                        searchableListWithTitleEvents.Items.Add(fbEvent)));
                }
            }).Start();
        }

        private void searchableListWithTitleFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchableListWithTitleFriends.SelectedItem is FacebookWrapper.ObjectModel.User selectedFriend)
            {
                new Thread(() =>
                {
                    this.Invoke(new Action(() =>
                    {
                        pictureBoxSelectedFriend.LoadAsync(selectedFriend.PictureSmallURL);
                    }));
                }).Start();
            }
        }

        private void searchableListWithTitleAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchableListWithTitleAlbums.SelectedItem is Album selectedAlbum)
            {
                new Thread(() =>
                {
                    pictureBoxSelectedAlbum.Invoke(new Action(() =>
                        pictureBoxSelectedAlbum.LoadAsync(selectedAlbum.PictureAlbumURL)));
                }).Start();
            }
        }

        private void searchableListWithTitleGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchableListWithTitleGroups.SelectedItem is Group selectedGroup)
            {
                new Thread(() =>
                {
                    pictureBoxSelectedGroup.Invoke(new Action(() =>
                        pictureBoxSelectedGroup.LoadAsync(selectedGroup.PictureSmallURL)));
                }).Start();
            }
        }

        private void searchableListWithTitleLikedPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchableListWithTitleLikedPages.SelectedItem is Page selectedPage)
            {
                new Thread(() =>
                {
                    pictureBoxSelectedPage.Invoke(new Action(() =>
                        pictureBoxSelectedPage.LoadAsync(selectedPage.PictureSmallURL)));
                }).Start();
            }
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            const bool v_PostButtonsEnabled = true;
            string postText = richTextBoxPost.Text;

            togglePostButtons(!v_PostButtonsEnabled);

            new Thread(() =>
            {
                try
                {
                    r_FacebookManager.PostStatus(postText);
                    
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Post published successfully!");
                        richTextBoxPost.Text = string.Empty;
                    }));
                }
                catch (Exception exception)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show($"An error occurred: {exception.Message}");
                        richTextBoxPost.Text = string.Empty;
                    }));
                }
            }).Start();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            const bool v_PostButtonsEnabled = true;
            richTextBoxPost.Text = string.Empty;
            togglePostButtons(!v_PostButtonsEnabled);
        }

        private void togglePostButtons(bool i_ButtonsState)
        {
            buttonPost.Enabled = i_ButtonsState;
            buttonAddPictureAndPost.Enabled = i_ButtonsState;
            buttonCancel.Enabled = i_ButtonsState;
        }

        private void toggleFeaturesButtons(bool i_ButtonsState)
        {
            buttonGuessTheYear.Enabled = i_ButtonsState;
            buttonProfileAnalyzer.Enabled = i_ButtonsState;
        }

        private void buttonAddPictureAndPost_Click(object sender, EventArgs e)
        {
            string picturePath = string.Empty;
            string postText = richTextBoxPost.Text;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picturePath = openFileDialog.FileName;
                
                new Thread(() =>
                {
                    try
                    {
                        r_FacebookManager.PostPicture(postText, picturePath);
                        
                        richTextBoxPost.Invoke(new Action(() => richTextBoxPost.Text = string.Empty));
                        MessageBox.Show("Picture Posted <3");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }).Start();
            }
        }

        private void richTextBoxPost_TextChanged(object sender, EventArgs e)
        {
            const bool v_PostButtonsEnabled = true;
            togglePostButtons(v_PostButtonsEnabled);
        }

        private void buttonProfileAnalyzer_Click(object sender, EventArgs e)
        {
            FacebookFeature profileAnalyzer = FacebookFeatureFactory.CreateFeature(eFeatureType.ProfileAnalyzer, this);
            profileAnalyzer.Show();
        }

        private void buttonGuessTheYear_Click(object sender, EventArgs e)
        {
            FacebookFeature guessTheYear = FacebookFeatureFactory.CreateFeature(eFeatureType.GuessTheYear, this);
            guessTheYear.Show();
        }
    }
}



