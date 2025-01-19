using FacebookWrapper.ObjectModel;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FormProfileAnalyzer : Form
    {
        private Form m_MainForm;
        private readonly ProfileAnalyzerFacade r_ProfileAnalyzerFacade;

        public FormProfileAnalyzer(ProfileAnalyzerFacade i_ProfileAnalyzerFacade)
        {
            InitializeComponent();
            r_ProfileAnalyzerFacade = i_ProfileAnalyzerFacade;
        }

        public Form MainForm
        {
            get 
            { 
                return m_MainForm; 
            }
            set 
            { 
                m_MainForm = value; 
            }
        }

        private void formProfileAnalyzer_Load(object sender, EventArgs e)
        {
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
            labelUserName.Text = r_ProfileAnalyzerFacade.UserName;
        }

        private void updateProfilePictures()
        {
            setPictureBoxImage(pictureBoxProfilePicture, r_ProfileAnalyzerFacade.UserName);
            setPictureBoxImage(pictureBoxBestPicture, r_ProfileAnalyzerFacade.BestPhoto?.PictureNormalURL);
            setPictureBoxImage(pictureBoxWorstPicture, r_ProfileAnalyzerFacade.WorstPhoto?.PictureNormalURL);
        }

        private void updateStatistics()
        {
            labelTotalLikes.Text = r_ProfileAnalyzerFacade.TotalLikes.ToString();
            labelTotalFriends.Text = r_ProfileAnalyzerFacade.TotalFriends.ToString();
            labelTotalEvents.Text = r_ProfileAnalyzerFacade.TotalEvents.ToString();
            labelTotalPosts.Text = r_ProfileAnalyzerFacade.TotalPosts.ToString();
            labelTotalVideos.Text = r_ProfileAnalyzerFacade.TotalVideos.ToString();
            labelTotalPictures.Text = r_ProfileAnalyzerFacade.TotalPhotos.ToString();
        }

        private void updateFriendsLists()
        {
            populateList(listBoxFriendsThatSpeakTheSameLanguage, r_ProfileAnalyzerFacade.FriendsWithCommonLanguages);
            populateList(listBoxHomeTownFriends, r_ProfileAnalyzerFacade.FriendsFromSameHometown);
            populateList(listBoxFriendsWithTheSameBirthday, r_ProfileAnalyzerFacade.FriendsWithSameBirthday);
            populateList(listBoxFriendsThatLikedUsersPictures, r_ProfileAnalyzerFacade.FriendsWhoLikedPhotos);
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
