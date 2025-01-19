using System;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper;
using BasicFacebookFeatures.Properties;
using BasicFacebookFeatures.Features;
using BasicFacebookFeatures.Services;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private readonly FacebookManager r_FacebookManager = FacebookManager.Instance;
        private FacebookFeatureFactory m_FeatureFactory;

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

            LoginResult loginResult = r_FacebookManager.Login(textBoxAppID.Text, permissions);

            if (!string.IsNullOrEmpty(loginResult.AccessToken))
            {
                loadUserData();
            }
            else
            {
                MessageBox.Show(loginResult.ErrorMessage, "Login Failed");
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            const bool v_IsLogin = true;

            r_FacebookManager.Logout();
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
            checkBoxRememberUser.Checked = r_FacebookManager.RememberUser;
            if (r_FacebookManager.TryConnectFromSavedToken())
            {
                loadUserData();
            }
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
            fetchUserData();
            m_FeatureFactory = new FacebookFeatureFactory(this, r_FacebookManager.LoginResult);
        }

        private void clearUserData()
        {
            pictureBoxProfile.Image = Resources.user_icon;
            pictureBoxSelectedAlbum.Image = Resources.albums_icon;
            pictureBoxSelectedFriend.Image = Resources.friends_icon;
            pictureBoxSelectedGroup.Image = Resources.group_icon;
            pictureBoxSelectedPage.Image = Resources.like_icon;
            searchableListWithTitleFriends.Items.Clear();
            searchableListWithTitleAlbums.Items.Clear();
            searchableListWithTitleEvents.Items.Clear();
            searchableListWithTitleFeed.Items.Clear();
            searchableListWithTitleGroups.Items.Clear();
            searchableListWithTitleLikedPages.Items.Clear();
            labelUserData.Text = "";
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
            fetchUserFriends();
            fetchUserAlbums();
            fetchUserGroups();
            fetchLikedPages();
            fetchUserFeed();
            fetchUserEvents();
        }

        private void fetchUserFriends()
        {
            searchableListWithTitleFriends.Items.Clear();
            searchableListWithTitleFriends.DisplayMember = "Name";
            foreach (var friend in r_FacebookManager.GetFriends())
            {
                searchableListWithTitleFriends.Items.Add(friend);
            }

            if (searchableListWithTitleFriends.Items.Count == 0)
            {
                MessageBox.Show("No friends to retrieve :(");
            }
        }

        private void fetchUserAlbums()
        {
            searchableListWithTitleAlbums.Items.Clear();
            searchableListWithTitleAlbums.DisplayMember = "Name";
            foreach (var album in r_FacebookManager.GetAlbums())
            {
                searchableListWithTitleAlbums.Items.Add(album);
            }

            if (searchableListWithTitleAlbums.Items.Count == 0)
            {
                MessageBox.Show("No Albums to retrieve :(");
            }
        }

        private void fetchUserGroups()
        {
            searchableListWithTitleGroups.Items.Clear();
            searchableListWithTitleGroups.DisplayMember = "Name";
            foreach (var group in r_FacebookManager.GetGroups())
            {
                searchableListWithTitleGroups.Items.Add(group);
            }

            if (searchableListWithTitleGroups.Items.Count == 0)
            {
                MessageBox.Show("No groups to retrieve :(");
            }
        }

        private void fetchLikedPages()
        {
            searchableListWithTitleLikedPages.Items.Clear();
            searchableListWithTitleLikedPages.DisplayMember = "Name";
            try
            {
                foreach (var page in r_FacebookManager.GetLikedPages())
                {
                    searchableListWithTitleLikedPages.Items.Add(page);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (searchableListWithTitleLikedPages.Items.Count == 0)
            {
                MessageBox.Show("No liked pages to retrieve :(");
            }
        }

        private void fetchUserFeed()
        {
            searchableListWithTitleFeed.Items.Clear();
            foreach (var post in r_FacebookManager.GetNewsFeed())
            {
                if (post.Message != null)
                {
                    searchableListWithTitleFeed.Items.Add(post.Message);
                }
                else if (post.Caption != null)
                {
                    searchableListWithTitleFeed.Items.Add(post.Caption);
                }
                else
                {
                    searchableListWithTitleFeed.Items.Add($"[{post.CreatedTime}]");
                }
            }

            if (searchableListWithTitleFeed.Items.Count == 0)
            {
                searchableListWithTitleFeed.Items.Add("Feed is empty :(");
            }
        }

        private void fetchUserEvents()
        {
            searchableListWithTitleEvents.Items.Clear();
            foreach (var userEvent in r_FacebookManager.GetEvents())
            {
                if (userEvent.Name != null)
                {
                    searchableListWithTitleEvents.Items.Add($"{userEvent.Name} [{userEvent.TimeString}]");
                }
            }

            if (searchableListWithTitleEvents.Items.Count == 0)
            {
                searchableListWithTitleEvents.Items.Add("No Events to show :(");
            }
        }

        private void searchableListWithTitleFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchableListWithTitleFriends.SelectedItem is FacebookWrapper.ObjectModel.User selectedFriend)
            {
                pictureBoxSelectedFriend.LoadAsync(selectedFriend.PictureSmallURL);
            }
        }

        private void searchableListWithTitleAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchableListWithTitleAlbums.SelectedItem is FacebookWrapper.ObjectModel.Album selectedAlbum)
            {
                pictureBoxSelectedAlbum.LoadAsync(selectedAlbum.PictureAlbumURL);
            }
        }

        private void searchableListWithTitleGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchableListWithTitleGroups.SelectedItem is FacebookWrapper.ObjectModel.Group selectedGroup)
            {
                pictureBoxSelectedGroup.LoadAsync(selectedGroup.PictureSmallURL);
            }
        }

        private void searchableListWithTitleLikedPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchableListWithTitleLikedPages.SelectedItem is FacebookWrapper.ObjectModel.Page selectedPage)
            {
                pictureBoxSelectedPage.LoadAsync(selectedPage.PictureSmallURL);
            }
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            const bool v_PostButtonsEnabled = true;

            try
            {
                r_FacebookManager.PostStatus(richTextBoxPost.Text);
                togglePostButtons(!v_PostButtonsEnabled);
                MessageBox.Show("Post published successfully!");
            }
            catch (Exception exception)
            {
                MessageBox.Show($"An error occurred: {exception.Message}");
            }
            finally
            {
                richTextBoxPost.Text = string.Empty;
            }
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
            try
            {
                if (getPictureAndPost() == DialogResult.OK)
                {
                    MessageBox.Show("Picture Posted <3");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                richTextBoxPost.Text = string.Empty;
            }
        }

        private DialogResult getPictureAndPost()
        {
            DialogResult userSelection = openFileDialog.ShowDialog();
            if (userSelection == DialogResult.OK)
            {
                string picturePath = openFileDialog.FileName;

                if (string.IsNullOrWhiteSpace(picturePath))
                {
                    throw new Exception("Please choose a picture first!");
                }
                else
                {
                    r_FacebookManager.PostPicture(richTextBoxPost.Text, picturePath);
                }
            }

            return userSelection;
        }

        private void richTextBoxPost_TextChanged(object sender, EventArgs e)
        {
            const bool v_PostButtonsEnabled = true;

            togglePostButtons(v_PostButtonsEnabled);
        }

        private void buttonProfileAnalyzer_Click(object sender, EventArgs e)
        {
            IFacebookFeature profileAnalayzer = m_FeatureFactory.CreateFeature(eFeatureType.ProfileAnalyzer);
            profileAnalayzer.Show();
        }

        private void buttonGuessTheYear_Click(object sender, EventArgs e)
        {
            IFacebookFeature guessTheYear = m_FeatureFactory.CreateFeature(eFeatureType.GuessTheYear);
            guessTheYear.Show();
        }
    }
}



