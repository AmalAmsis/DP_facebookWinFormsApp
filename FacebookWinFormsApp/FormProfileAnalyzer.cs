using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Linq;
using System.Windows.Forms;
using BasicFacebookFeatures.Services;

namespace BasicFacebookFeatures
{
    public partial class FormProfileAnalyzer : Form
    {
        private Form m_MainForm;
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private ProfileAnalyzerFacade m_ProfileAnalyzerFacade;

        public FormProfileAnalyzer()
        {
            InitializeComponent();
        }

        public Form MainForm
        {
            get { return m_MainForm; }
            set { m_MainForm = value; }
        }

        public LoginResult LoginResult
        {
            get { return m_LoginResult; }
            set
            {
                m_LoginResult = value;
                m_LoggedInUser = value?.LoggedInUser;
            }
        }

        private void formProfileAnalyzer_Load(object sender, EventArgs e)
        {
            if (m_LoggedInUser == null)
            {
                showErrorMessageAndClose("User is not logged in or data is unavailable.");
                return;
            }

            m_ProfileAnalyzerFacade = new ProfileAnalyzerFacade(m_LoggedInUser);
            displayProfileAnalysis();
        }

        private void displayProfileAnalysis()
        {
            updateUserInfo();
            updateProfilePictures();
            updateStatistics();
            updateFriendsLists();
        }

        private void updateUserInfo()
        {
            labelUserName.Text = m_ProfileAnalyzerFacade.GetUserName();
        }

        private void updateProfilePictures()
        {
            setPictureBoxImage(pictureBoxProfilePicture, m_ProfileAnalyzerFacade.GetProfilePictureUrl());
            setPictureBoxImage(pictureBoxBestPicture, m_ProfileAnalyzerFacade.GetBestPhoto()?.PictureNormalURL);
            setPictureBoxImage(pictureBoxWorstPicture, m_ProfileAnalyzerFacade.GetWorstPhoto()?.PictureNormalURL);
        }

        private void updateStatistics()
        {
            var statistics = m_ProfileAnalyzerFacade.GetStatistics();
            labelTotalLikes.Text = statistics.TotalLikes.ToString();
            labelTotalFriends.Text = statistics.TotalFriends.ToString();
            labelTotalEvents.Text = statistics.TotalEvents.ToString();
            labelTotalPosts.Text = statistics.TotalPosts.ToString();
            labelTotalVideos.Text = statistics.TotalVideos.ToString();
            labelTotalPictures.Text = statistics.TotalPhotos.ToString();
        }

        private void updateFriendsLists()
        {
            var friendsLists = m_ProfileAnalyzerFacade.GetFriendsLists();
            populateList(listBoxFriendsThatSpeakTheSameLanguage, friendsLists.CommonLanguageFriends);
            populateList(listBoxHomeTownFriends, friendsLists.HometownFriends);
            populateList(listBoxFriendsWithTheSameBirthday, friendsLists.SameBirthdayFriends);
            populateList(listBoxFriendsThatLikedUsersPictures, friendsLists.PhotoLikerFriends);
        }

        private void populateList(ListBox i_ListBox, FacebookObjectCollection<User> i_Users)
        {
            if (i_Users != null)
            {
                i_ListBox.Items.AddRange(i_Users.ToArray());
            }
        }

        private void setPictureBoxImage(PictureBox i_PictureBox, string i_ImageUrl)
        {
            i_PictureBox.ImageLocation = i_ImageUrl;
            i_PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void formProfileAnalyzer_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeAndReturnToMainForm();
        }

        private void showErrorMessageAndClose(string i_Message)
        {
            MessageBox.Show(i_Message);
            Close();
        }

        private void closeAndReturnToMainForm()
        {
            Hide();
            Close();
            m_MainForm?.Show();
        }
    }
}
