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

        public FormProfileAnalyzer()
        {
            InitializeComponent();
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

        public LoginResult LoginResult
        {
            get
            {
                return m_LoginResult;
            }
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
            labelUserName.Text = m_LoggedInUser.Name;
        }

        private void updateProfilePictures()
        {
            setPictureBoxImage(pictureBoxProfilePicture, m_LoggedInUser?.PictureNormalURL);
            setPictureBoxImage(pictureBoxBestPicture, getBestPhoto()?.PictureNormalURL);
            setPictureBoxImage(pictureBoxWorstPicture, getWorstPhoto()?.PictureNormalURL);
        }

        private void updateStatistics()
        {
            labelTotalLikes.Text = m_LoggedInUser.LikedPages?.Count.ToString() ?? "0";
            labelTotalFriends.Text = m_LoggedInUser.Friends?.Count.ToString() ?? "0";
            labelTotalEvents.Text = m_LoggedInUser.Events?.Count.ToString() ?? "0";
            labelTotalPosts.Text = m_LoggedInUser.Posts?.Count.ToString() ?? "0";
            labelTotalVideos.Text = m_LoggedInUser.Videos?.Count.ToString() ?? "0";
            labelTotalPictures.Text = countPhotos().ToString();
        }

        private void populateLists()
        {
            populateList(listBoxFriendsThatSpeakTheSameLanguage, getFriendsWithCommonLanguages());
            populateList(listBoxHomeTownFriends, getFriendsFromSameHometown());
            populateList(listBoxFriendsWithTheSameBirthday, getFriendsWithSameBirthday());
            populateList(listBoxFriendsThatLikedUsersPictures, getFriendsWhoLikedPhotos());
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
            i_PictureBox.ImageLocation = i_ImageUrl ?? Constants.Constants.sr_SadEmojiUrl;
            i_PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private int countPhotos()
        {
            return m_LoggedInUser?.Albums?.Sum(album => album.Photos.Count) ?? 0;
        }

        private FacebookObjectCollection<User> getFriendsWithCommonLanguages()
        {
            if (m_LoggedInUser?.Languages == null)
            {
                return new FacebookObjectCollection<User>();
            }

            return filterFriendsByCondition(friend =>
                friend.Languages?.Any(lang => m_LoggedInUser.Languages.Contains(lang)) == true);
        }

        private FacebookObjectCollection<User> getFriendsFromSameHometown()
        {
            if (m_LoggedInUser?.Hometown == null)
            {
                return new FacebookObjectCollection<User>();
            }

            return filterFriendsByCondition(friend => friend.Hometown == m_LoggedInUser.Hometown);
        }

        private FacebookObjectCollection<User> getFriendsWithSameBirthday()
        {
            if (string.IsNullOrEmpty(m_LoggedInUser?.Birthday))
            {
                return new FacebookObjectCollection<User>();
            }

            return filterFriendsByCondition(friend => friend.Birthday == m_LoggedInUser.Birthday);
        }

        private FacebookObjectCollection<User> getFriendsWhoLikedPhotos()
        {
            FacebookObjectCollection<User> friends = new FacebookObjectCollection<User>();

            foreach (Album album in m_LoggedInUser?.Albums ?? Enumerable.Empty<Album>())
            {
                foreach (Photo photo in album.Photos ?? Enumerable.Empty<Photo>())
                {
                    foreach (User user in photo.LikedBy ?? Enumerable.Empty<User>())
                    {
                        friends.Add(user);
                    }
                }
            }

            return friends;
        }

        private FacebookObjectCollection<User> filterFriendsByCondition(Func<User, bool> i_Condition)
        {
            FacebookObjectCollection<User> filteredFriends = new FacebookObjectCollection<User>();

            foreach (User friend in m_LoggedInUser?.Friends ?? Enumerable.Empty<User>())
            {
                if (i_Condition(friend))
                {
                    filteredFriends.Add(friend);
                }
            }

            return filteredFriends;
        }

        private Photo getBestPhoto()
        {
            return getPhotoWithExtremeLikes((current, best) => current > best);
        }

        private Photo getWorstPhoto()
        {
            return getPhotoWithExtremeLikes((current, worst) => current < worst);
        }

        private Photo getPhotoWithExtremeLikes(Func<int, int, bool> i_Comparison)
        {
            Photo extremePhoto = null;
            bool isFirstPhoto = true;
            int extremeLikes = -1;

            foreach (Album album in m_LoggedInUser?.Albums)
            {
                foreach (Photo photo in album.Photos)
                {
                    int likesCount = photo.LikedBy?.Count ?? 0;

                    if (i_Comparison(likesCount, extremeLikes) || isFirstPhoto)
                    {
                        extremePhoto = photo;
                        extremeLikes = likesCount;
                        isFirstPhoto = false;
                    }
                }
            }

            return extremePhoto;
        }

        private void formProfileAnalyzer_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeAndReturnToMainForm();
        }

        private void showErrorMessageAndClose(string i_Message)
        {
            MessageBox.Show(i_Message);
            this.Close();
        }

        private void closeAndReturnToMainForm()
        {
            this.Hide();
            this.Close();
            m_MainForm?.Show();
        }
    }
}
