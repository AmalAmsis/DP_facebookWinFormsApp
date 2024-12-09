using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using BasicFacebookFeatures.Properties;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
            r_AppSettings = AppSettings.LoadAppSettingsFromFile();
        }

        private FacebookWrapper.LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private FacebookPostManager m_FacebookPostManager;
        private readonly AppSettings r_AppSettings;

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");
            if (m_LoginResult == null)
            {
                login();
            }
        }

        private void login()
        {
            m_LoginResult = FacebookService.Login(
                /// (This is Desig Patter's App ID. replace it with your own)
                textBoxAppID.Text,
                /// requested permissions:
                "email",
                "public_profile",
                /// add any relevant permissions
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
                );

            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                loadUserData();
            }
            else
            {
                MessageBox.Show(m_LoginResult.ErrorMessage, "Login Failed");
                m_LoginResult = null;
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            const bool v_IsLogin = true;

            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            m_LoginResult = null;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
            clearUserData();
            tabPage1.Text = "Main App";
            checkBoxRememberUser.Checked = false;
            toggleLoginUI(!v_IsLogin);
            togglePostButtons(!v_IsLogin);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (checkBoxRememberUser.Checked && m_LoginResult != null)
            {
                r_AppSettings.RememberUser = true;
                r_AppSettings.LastAccessToken = m_LoginResult.AccessToken;
            }
            else
            {
                r_AppSettings.RememberUser = false;
                r_AppSettings.LastAccessToken = null;
            }

            r_AppSettings.SaveAppSettingsToFile();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            checkBoxRememberUser.Checked = r_AppSettings.RememberUser;
            if (r_AppSettings.RememberUser && !string.IsNullOrEmpty(r_AppSettings.LastAccessToken))
            {
                try
                {
                    m_LoginResult = FacebookService.Connect(r_AppSettings.LastAccessToken);
                    loadUserData();
                }
                catch (Exception)
                {
                    MessageBox.Show(m_LoginResult.ErrorMessage, "Login Failed");
                    m_LoginResult = null;
                }
            }
        }

        private void loadUserData()
        {
            const bool v_IsLogin = true;

            m_LoggedInUser = m_LoginResult.LoggedInUser;
            buttonLogin.Text = $"Logged in as {m_LoggedInUser.Name}";
            buttonLogin.BackColor = Color.LightGreen;
            pictureBoxProfile.ImageLocation = m_LoggedInUser.PictureNormalURL;
            labelUserData.Text = $@"{m_LoggedInUser.Name}
 {m_LoggedInUser.Birthday}
 {m_LoggedInUser.Gender}";
            m_FacebookPostManager = new FacebookPostManager(m_LoggedInUser);
            tabPage1.Text = $"{m_LoggedInUser.Name}";
            toggleLoginUI(v_IsLogin);
            fetchUserData();
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
            foreach (User friend in m_LoggedInUser.Friends)
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
            foreach (Album album in m_LoggedInUser.Albums)
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
            foreach (Group group in m_LoggedInUser.Groups)
            {
                searchableListWithTitleAlbums.Items.Add(group);
            }

            if (searchableListWithTitleAlbums.Items.Count == 0)
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
                foreach (Page page in m_LoggedInUser.LikedPages)
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
            foreach (Post post in m_LoggedInUser.NewsFeed)
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
            foreach (Event userEvent in m_LoggedInUser.Events)
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
            User selectedFriend = searchableListWithTitleFriends.SelectedItem as User;
            pictureBoxSelectedFriend.LoadAsync(selectedFriend.PictureSmallURL);
        }

        private void searchableListWithTitleAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            Album selectedAlbum = searchableListWithTitleAlbums.SelectedItem as Album;
            pictureBoxSelectedAlbum.LoadAsync(selectedAlbum.PictureAlbumURL);
        }

        private void searchableListWithTitleGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            Group selectedGroup = searchableListWithTitleGroups.SelectedItem as Group;
            pictureBoxSelectedGroup.LoadAsync(selectedGroup.PictureSmallURL);
        }

        private void searchableListWithTitleLikedPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page selectedPage = searchableListWithTitleLikedPages.SelectedItem as Page;
            pictureBoxSelectedPage.LoadAsync(selectedPage.PictureSmallURL);
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            const bool v_PostButtonsEnabled = true;

            try
            {
                m_FacebookPostManager.PostStatus(richTextBoxPost.Text);
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
                    m_FacebookPostManager.PostPicture(richTextBoxPost.Text, picturePath);
                }
            }

            return userSelection;
        }

        private void richTextBoxPost_TextChanged(object sender, EventArgs e)
        {
            const bool v_PostButtonsEnabled = true;

            togglePostButtons(v_PostButtonsEnabled);
        }

        private void buttonProfileSummary_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProfileAnalyzer formProfileAnalyzer = new FormProfileAnalyzer
            {
                MainForm = this,
                LoginResult = m_LoginResult
            };
            formProfileAnalyzer.ShowDialog();
        }

        private void buttonGuessTheYear_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGuessTheYear formGuessTheYear = new FormGuessTheYear
            {
                MainForm = this,
                LoginResult = m_LoginResult
            };
            formGuessTheYear.ShowDialog();
        }
    }
}
