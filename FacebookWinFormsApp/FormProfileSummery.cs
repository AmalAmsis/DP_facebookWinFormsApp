using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FormProfileSummery : Form
    {
        private User m_LoggedInUser;

        public FormProfileSummery()
        {
            InitializeComponent();
        }

        public void SetLoginResult(LoginResult i_LoginResult)
        {
            m_LoggedInUser = i_LoginResult?.LoggedInUser;
            calculateAndUpdateProfileSummaryData();
        }

        private void calculateAndUpdateProfileSummaryData()
        {
            if (m_LoggedInUser != null)
            {
                int totalLikes = m_LoggedInUser.LikedPages?.Count ?? 0;
                int totalFriends = m_LoggedInUser.Friends?.Count ?? 0;
                int totalEvents = m_LoggedInUser.Events?.Count ?? 0;
                int totalPosts = m_LoggedInUser.Posts?.Count ?? 0;
                int totalVideos = m_LoggedInUser.Videos?.Count ?? 0;
                int totalPhotos = countPhotos();

                Photo bestPhoto = getBestPhoto();
                Photo worstPhoto = getWorstPhoto();

                FacebookObjectCollection<User> friendsThatSpeakTheSameLanguage = getUsersFriendsThatSpeakTheSameLanguage();
                FacebookObjectCollection<User> homeTownFriends = getUsersHomeTownFriends();
                FacebookObjectCollection<User> friendsWithTheSameBirthday = getUsersFriendsWithTheSameBirthday();
                FacebookObjectCollection<User> friendsThatLikedMyPhotos = getUsersFriendsThatLikedMyPhotos();

                labelUserName.Text = m_LoggedInUser.Name;
                labelTotalLikes.Text = totalLikes.ToString();
                labelTotalFriends.Text = totalFriends.ToString();
                labelTotalEvents.Text = totalEvents.ToString();
                labelTotalPosts.Text = totalPosts.ToString();
                labelTotalVideos.Text = totalVideos.ToString();
                labelTotalPictures.Text = totalPhotos.ToString();

                pictureBoxProfilePicture.ImageLocation = m_LoggedInUser.PictureNormalURL ?? Constants.Constants.k_SadEmojiUrl;
                pictureBoxBestPicture.ImageLocation = bestPhoto?.PictureNormalURL ?? Constants.Constants.k_SadEmojiUrl;
                pictureBoxWorstPicture.ImageLocation = worstPhoto?.PictureNormalURL ?? Constants.Constants.k_SadEmojiUrl;

                pictureBoxProfilePicture.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxBestPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxWorstPicture.SizeMode = PictureBoxSizeMode.StretchImage;

                listBoxFriendsThatSpeakTheSameLanguage.Items.AddRange(friendsThatSpeakTheSameLanguage?.ToArray());
                listBoxHomeTownFriends.Items.AddRange(homeTownFriends?.ToArray());
                listBoxFriendsWithTheSameBirthday.Items.AddRange(friendsWithTheSameBirthday?.ToArray());
                listBoxFriendsThatLikedUsersPictures.Items.AddRange(friendsThatLikedMyPhotos?.ToArray());
            }
            else
            {
                MessageBox.Show("User is not logged in or data is unavailable.");
                this.Close();
            }

        }

        private int countPhotos()
        {
            FacebookObjectCollection<Album> albums = m_LoggedInUser?.Albums;
            int totalPhotos = 0;

            foreach (Album album in albums)
            {
                totalPhotos += album.Photos.Count;
            }

            return totalPhotos;
        }

        private FacebookObjectCollection<User> getUsersFriendsThatSpeakTheSameLanguage()
        {
            FacebookObjectCollection<User> friendsThatSpeakTheSameLanguage = new FacebookObjectCollection<User>();
            Page[] usersLanguages = m_LoggedInUser.Languages;

            if (usersLanguages == null)
            {
                return friendsThatSpeakTheSameLanguage;    
            }

            foreach (User friend in m_LoggedInUser?.Friends)
            {
                foreach (Page friendsLanguage in friend.Languages)
                {
                    if (usersLanguages.Contains(friendsLanguage))
                    {
                        friendsThatSpeakTheSameLanguage.Add(friend);
                        break;
                    }
                }
            }

            return friendsThatSpeakTheSameLanguage;
        }

        private FacebookObjectCollection<User> getUsersFriendsWithTheSameBirthday()
        {
            FacebookObjectCollection<User> friendsWithTheSameBirthday = new FacebookObjectCollection<User>();
            string usersBirthday = m_LoggedInUser?.Birthday;

            if (usersBirthday == null)
            {
                return friendsWithTheSameBirthday;
            }

            foreach (User friend in m_LoggedInUser?.Friends)
            {
                if (friend.Birthday == usersBirthday)
                {
                    friendsWithTheSameBirthday.Add(friend);
                }
            }

            return friendsWithTheSameBirthday;
        }

        private FacebookObjectCollection<User> getUsersHomeTownFriends()
        {
            FacebookObjectCollection<User> homeTownFriends = new FacebookObjectCollection<User>();
            City usersHomeTown = m_LoggedInUser?.Hometown;

            if (usersHomeTown == null)
            {
                return homeTownFriends;
            }

            foreach (User friend in m_LoggedInUser?.Friends)
            {
                if (friend.Hometown == usersHomeTown)
                {
                    homeTownFriends.Add(friend);
                }
            }

            return homeTownFriends;
        }

        private FacebookObjectCollection<User> getUsersFriendsThatLikedMyPhotos()
        {
            FacebookObjectCollection<User> friendsThatLikedMyPhotos = new FacebookObjectCollection<User>();
            
            foreach (Album album in m_LoggedInUser?.Albums)
            {
                foreach (Photo photo in album.Photos)
                {
                    foreach (User user in photo.LikedBy)
                    {
                        friendsThatLikedMyPhotos.Add(user);
                    }
                }
            }

            return friendsThatLikedMyPhotos;
        }

        private Photo getWorstPhoto()
        {
            Photo worstPicture = null;
            int worstPictureNumberOfLikes = Constants.Constants.k_Empty;

            foreach (Album album in m_LoggedInUser?.Albums)
            {
                foreach (Photo photo in album.Photos)
                {
                    int currentPictureNumberOfLikes = photo.LikedBy?.Count ?? 0;

                    if (isWorstPicture(currentPictureNumberOfLikes, worstPictureNumberOfLikes))
                    {
                        worstPicture = photo;
                    }
                }
            }

            return worstPicture;
        }

        private Photo getBestPhoto()
        {
            Photo bestPicture = null;
            int bestPictureNumberOfLikes = Constants.Constants.k_Empty;

            foreach (Album album in m_LoggedInUser?.Albums)
            {
                foreach (Photo photo in album.Photos)
                {
                    int currentPictureNumberOfLikes = photo.LikedBy?.Count ?? 0;

                    if (isBestPicture(currentPictureNumberOfLikes, bestPictureNumberOfLikes))
                    {
                        bestPicture = photo;
                    }
                }
            }
            
            return bestPicture;
        }

        private bool isBestPicture(int currentPictureNumberOfLikes, int currentBestPictureNumberOfLikes)
        {
            return currentBestPictureNumberOfLikes == Constants.Constants.k_Empty || currentPictureNumberOfLikes > currentBestPictureNumberOfLikes;
        }
        
        private bool isWorstPicture(int currentPictureNumberOfLikes, int currentWorstPictureNumberOfLikes)
        {
            return currentWorstPictureNumberOfLikes == Constants.Constants.k_Empty || currentPictureNumberOfLikes < currentWorstPictureNumberOfLikes;
        }
    }
}
