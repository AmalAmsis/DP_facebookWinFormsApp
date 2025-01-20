using FacebookWrapper.ObjectModel;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

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
            initializeUI();
            new Thread(() => loadProfileData()).Start();
        }

        private void initializeUI()
        {
            labelUserName.Text = "Loading...";
            labelTotalLikes.Text = "0";
            labelTotalFriends.Text = "0";
            labelTotalEvents.Text = "0";
            labelTotalPosts.Text = "0";
            labelTotalVideos.Text = "0";
            labelTotalPictures.Text = "0";

            listBoxFriendsThatSpeakTheSameLanguage.Items.Clear();
            listBoxHomeTownFriends.Items.Clear();
            listBoxFriendsWithTheSameBirthday.Items.Clear();
            listBoxFriendsThatLikedUsersPictures.Items.Clear();
        }

        private void loadProfileData()
        {
            loadBasicInfo();
            loadStatistics();
            loadFriendsLists();
            loadPhotos();
        }

        private void loadBasicInfo()
        {
            new Thread(() =>
            {
                var userName = r_ProfileAnalyzerFacade.UserName;
                labelUserName.Invoke(new Action(() => 
                    labelUserName.Text = userName));
            }).Start();

            new Thread(() =>
            {
                var profilePicUrl = r_ProfileAnalyzerFacade.ProfilePictureUrl;
                pictureBoxProfilePicture.Invoke(new Action(() =>
                {
                    pictureBoxProfilePicture.ImageLocation = profilePicUrl;
                    pictureBoxProfilePicture.SizeMode = PictureBoxSizeMode.StretchImage;
                }));
            }).Start();
        }

        private void loadStatistics()
        {
            loadLikesStatistic();
            loadFriendsStatistic();
            loadEventsStatistic();
            loadPostsStatistic();
            loadVideosStatistic();
            loadPhotosStatistic();
        }

        private void loadLikesStatistic()
        {
            new Thread(() =>
            {
                var totalLikes = r_ProfileAnalyzerFacade.TotalLikes;
                labelTotalLikes.Invoke(new Action(() => 
                    labelTotalLikes.Text = totalLikes.ToString()));
            }).Start();
        }

        private void loadFriendsStatistic()
        {
            new Thread(() =>
            {
                var totalFriends = r_ProfileAnalyzerFacade.TotalFriends;
                labelTotalFriends.Invoke(new Action(() => 
                    labelTotalFriends.Text = totalFriends.ToString()));
            }).Start();
        }

        private void loadEventsStatistic()
        {
            new Thread(() =>
            {
                var totalEvents = r_ProfileAnalyzerFacade.TotalEvents;
                labelTotalEvents.Invoke(new Action(() => 
                    labelTotalEvents.Text = totalEvents.ToString()));
            }).Start();
        }

        private void loadPostsStatistic()
        {
            new Thread(() =>
            {
                var totalPosts = r_ProfileAnalyzerFacade.TotalPosts;
                labelTotalPosts.Invoke(new Action(() => 
                    labelTotalPosts.Text = totalPosts.ToString()));
            }).Start();
        }

        private void loadVideosStatistic()
        {
            new Thread(() =>
            {
                var totalVideos = r_ProfileAnalyzerFacade.TotalVideos;
                labelTotalVideos.Invoke(new Action(() => 
                    labelTotalVideos.Text = totalVideos.ToString()));
            }).Start();
        }

        private void loadPhotosStatistic()
        {
            new Thread(() =>
            {
                var totalPhotos = r_ProfileAnalyzerFacade.TotalPhotos;
                labelTotalPictures.Invoke(new Action(() => 
                    labelTotalPictures.Text = totalPhotos.ToString()));
            }).Start();
        }

        private void loadFriendsLists()
        {
            loadCommonLanguageFriends();
            loadHometownFriends();
            loadBirthdayFriends();
            loadLikedPhotosFriends();
        }

        private void loadCommonLanguageFriends()
        {
            new Thread(() =>
            {
                var commonLanguageFriends = r_ProfileAnalyzerFacade.FriendsWithCommonLanguages;
                listBoxFriendsThatSpeakTheSameLanguage.Invoke(new Action(() => 
                    populateList(listBoxFriendsThatSpeakTheSameLanguage, commonLanguageFriends)));
            }).Start();
        }

        private void loadHometownFriends()
        {
            new Thread(() =>
            {
                var hometownFriends = r_ProfileAnalyzerFacade.FriendsFromSameHometown;
                listBoxHomeTownFriends.Invoke(new Action(() => 
                    populateList(listBoxHomeTownFriends, hometownFriends)));
            }).Start();
        }

        private void loadBirthdayFriends()
        {
            new Thread(() =>
            {
                var birthdayFriends = r_ProfileAnalyzerFacade.FriendsWithSameBirthday;
                listBoxFriendsWithTheSameBirthday.Invoke(new Action(() => 
                    populateList(listBoxFriendsWithTheSameBirthday, birthdayFriends)));
            }).Start();
        }

        private void loadLikedPhotosFriends()
        {
            new Thread(() =>
            {
                var likedPhotosFriends = r_ProfileAnalyzerFacade.FriendsWhoLikedPhotos;
                listBoxFriendsThatLikedUsersPictures.Invoke(new Action(() => 
                    populateList(listBoxFriendsThatLikedUsersPictures, likedPhotosFriends)));
            }).Start();
        }

        private void loadPhotos()
        {
            loadBestPhoto();
            loadWorstPhoto();
        }

        private void loadBestPhoto()
        {
            new Thread(() =>
            {
                var bestPhoto = r_ProfileAnalyzerFacade.BestPhoto;
                if (bestPhoto != null)
                {
                    pictureBoxBestPicture.Invoke(new Action(() =>
                    {
                        pictureBoxBestPicture.ImageLocation = bestPhoto.PictureNormalURL;
                        pictureBoxBestPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    }));
                }
            }).Start();
        }

        private void loadWorstPhoto()
        {
            new Thread(() =>
            {
                var worstPhoto = r_ProfileAnalyzerFacade.WorstPhoto;
                if (worstPhoto != null)
                {
                    pictureBoxWorstPicture.Invoke(new Action(() =>
                    {
                        pictureBoxWorstPicture.ImageLocation = worstPhoto.PictureNormalURL;
                        pictureBoxWorstPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    }));
                }
            }).Start();
        }

        private void populateList(ListBox i_ListBox, FacebookObjectCollection<User> i_Users)
        {
            if (i_Users != null)
            {
                i_ListBox.Items.Clear();
                i_ListBox.Items.AddRange(i_Users.ToArray());
            }
        }

        private void formProfileAnalyzer_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeAndReturnToMainForm();
        }

        private void closeAndReturnToMainForm()
        {
            this.Hide();
            this.Close();
            m_MainForm?.Show();
        }
    }
}
