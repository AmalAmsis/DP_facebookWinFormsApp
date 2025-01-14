using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FormProfileAnalyzer : Form
    {
        private Form m_MainForm;
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private ProfileAnalyzer m_ProfileAnalyzer;

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

            m_ProfileAnalyzer = new ProfileAnalyzer(m_LoggedInUser);
            displayProfileAnalysis();
        }

        private void displayProfileAnalysis()
        {
            updateUserInfo();
            updateProfilePictures();
            updateStatistics();
            populateLists();
        }

        private void updateUserInfo()
        {
            labelUserName.Text = m_ProfileAnalyzer.UserName;
        }

        private void updateProfilePictures()
        {
            setPictureBoxImage(pictureBoxProfilePicture, m_ProfileAnalyzer.ProfilePictureUrl);
            setPictureBoxImage(pictureBoxBestPicture, m_ProfileAnalyzer.GetBestPhoto()?.PictureNormalURL);
            setPictureBoxImage(pictureBoxWorstPicture, m_ProfileAnalyzer.GetWorstPhoto()?.PictureNormalURL);
        }

        private void updateStatistics()
        {
            labelTotalLikes.Text = m_ProfileAnalyzer.TotalLikes.ToString();
            labelTotalFriends.Text = m_ProfileAnalyzer.TotalFriends.ToString();
            labelTotalEvents.Text = m_ProfileAnalyzer.TotalEvents.ToString();
            labelTotalPosts.Text = m_ProfileAnalyzer.TotalPosts.ToString();
            labelTotalVideos.Text = m_ProfileAnalyzer.TotalVideos.ToString();
            labelTotalPictures.Text = m_ProfileAnalyzer.CountTotalPhotos().ToString();
        }

        private void populateLists()
        {
            populateList(listBoxFriendsThatSpeakTheSameLanguage, m_ProfileAnalyzer.GetFriendsWithCommonLanguages());
            populateList(listBoxHomeTownFriends, m_ProfileAnalyzer.GetFriendsFromSameHometown());
            populateList(listBoxFriendsWithTheSameBirthday, m_ProfileAnalyzer.GetFriendsWithSameBirthday());
            populateList(listBoxFriendsThatLikedUsersPictures, m_ProfileAnalyzer.GetFriendsWhoLikedPhotos());
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
