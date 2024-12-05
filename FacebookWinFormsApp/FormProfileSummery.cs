using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FormProfileSummery : Form
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;

        public FormProfileSummery()
        {
            InitializeComponent();
        }

        public void SetLoginResult(LoginResult i_LoginResult)
        {
            m_LoginResult = i_LoginResult;
            m_LoggedInUser = i_LoginResult.LoggedInUser;
            calculateAndUpdateProfileSummaryData();
        }

        private void calculateAndUpdateProfileSummaryData()
        {
            if (m_LoggedInUser != null)
            {
                int totalLikes = m_LoggedInUser.LikedPages?.Count ?? 0;
                int totalFriends = m_LoggedInUser.FriendLists?.Count ?? 0;
                int totalEvents = m_LoggedInUser.Events?.Count ?? 0;
                int totalPosts = m_LoggedInUser.Posts?.Count ?? 0;
                int totalVideos = m_LoggedInUser.Videos?.Count ?? 0;
                int totalPhotos = m_LoggedInUser.PhotosTaggedIn?.Count ?? 0;

                Photo bestPhoto = getBestPicture();
                Photo worstPhoto = getWorstPicture();
                FacebookObjectCollection<User> homeTownFriends = getUsersHomeTownFriends();
                FacebookObjectCollection<User> friendsWithTheSameBirthday = getUsersFriendsWithTheSameBirthday();

                labelTotalLikes.Text = totalLikes.ToString();
                labelTotalFriends.Text = totalFriends.ToString();
                labelTotalEvents.Text = totalEvents.ToString();
                labelTotalPosts.Text = totalPosts.ToString();
                labelTotalVideos.Text = totalVideos.ToString();
                labelTotalPictures.Text = totalPhotos.ToString();

                pictureBoxProfilePicture.ImageLocation = m_LoggedInUser.PictureNormalURL ?? string.Empty;
                pictureBoxBestPicture.ImageLocation = bestPhoto?.PictureNormalURL ?? string.Empty;
                pictureBoxWorstPicture.ImageLocation = worstPhoto?.PictureNormalURL ?? string.Empty;

                listBoxHomeTownFriends.Items.AddRange(homeTownFriends?.ToArray());
                listBoxFriendsWithTheSameBirthday.Items.AddRange(friendsWithTheSameBirthday?.ToArray());
            }
            else
            {
                MessageBox.Show("User is not logged in or data is unavailable.");
                this.Close();
            }

        }

        private FacebookObjectCollection<User> getUsersFriendsWithTheSameBirthday()
        {
            FacebookObjectCollection<User> friendsWithTheSameBirthday = new FacebookObjectCollection<User>();
            
            if (m_LoggedInUser != null)
            {
                FacebookObjectCollection<User> friends = m_LoggedInUser.Friends;
                string birthday = m_LoggedInUser.Birthday;

                if (friends != null)
                {
                    foreach (User friend in friends)
                    {
                        if (friend.Birthday == birthday)
                        {
                            friendsWithTheSameBirthday.Add(friend);
                        }
                    }
                }
            }

            return friendsWithTheSameBirthday;
        }

        private FacebookObjectCollection<User> getUsersHomeTownFriends()
        {
            FacebookObjectCollection<User> homeTownFriends = new FacebookObjectCollection<User>();

            if (m_LoggedInUser != null)
            {
                FacebookObjectCollection<User> friends = m_LoggedInUser.Friends;
                string usersHomeTown = m_LoggedInUser.Hometown?.ToString();

                if (friends != null)
                {
                    foreach (User friend in friends)
                    {
                        string friendsHomeTown = friend.Hometown?.ToString();
                        if (friendsHomeTown == usersHomeTown)
                        {
                            homeTownFriends.Add(friend);
                        }
                    }
                }
            }

            return homeTownFriends;
        }

        private Photo getWorstPicture()
        {
            Photo worstPicture = null;
            int worstPictureNumberOfLikes = Constants.Constants.c_Empty;

            if (m_LoggedInUser != null)
            {
                FacebookObjectCollection<Photo> photos = m_LoggedInUser.PhotosTaggedIn;
                if (photos != null)
                {
                    foreach (Photo photo in photos)
                    {
                        int currentPictureNumberOfLikes = photo.LikedBy?.Count ?? 0;

                        if (isWorstPicture(currentPictureNumberOfLikes, worstPictureNumberOfLikes))
                        {
                            worstPicture = photo;
                        }
                    }
                }
            }

            return worstPicture;
        }

        private Photo getBestPicture()
        {
            Photo bestPicture = null;
            int bestPictureNumberOfLikes = Constants.Constants.c_Empty;

            if (m_LoggedInUser != null)
            {
                FacebookObjectCollection<Photo> photos = m_LoggedInUser.PhotosTaggedIn;
                if (photos != null)
                {
                    foreach (Photo photo in photos)
                    {
                        int currentPictureNumberOfLikes = photo.LikedBy?.Count ?? 0;

                        if (isBestPicture(currentPictureNumberOfLikes, bestPictureNumberOfLikes))
                        {
                            bestPicture = photo;
                        }
                    }
                }
            }
            
            return bestPicture;
        }

        private bool isBestPicture(int currentPictureNumberOfLikes, int currentBestPictureNumberOfLikes)
        {
            return currentBestPictureNumberOfLikes == Constants.Constants.c_Empty || currentPictureNumberOfLikes > currentBestPictureNumberOfLikes;
        }
        
        private bool isWorstPicture(int currentPictureNumberOfLikes, int currentWorstPictureNumberOfLikes)
        {
            return currentWorstPictureNumberOfLikes == Constants.Constants.c_Empty || currentPictureNumberOfLikes < currentWorstPictureNumberOfLikes;
        }
        
    }
}
