using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;

namespace BasicFacebookFeatures
{
    public class FacebookManager
    {
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private FacebookPostManager m_PostManager;
        private readonly AppSettings r_AppSettings;

        public FacebookManager()
        {
            r_AppSettings = AppSettings.LoadAppSettingsFromFile();
        }

        public bool IsLoggedIn => !string.IsNullOrEmpty(m_LoginResult?.AccessToken);
        public string AccessToken => m_LoginResult?.AccessToken;
        public User LoggedInUser => m_LoggedInUser;
        public string UserName => m_LoggedInUser?.Name;
        public string ProfilePictureURL => m_LoggedInUser?.PictureNormalURL;
        public string Birthday => m_LoggedInUser?.Birthday;
        public User.eGender? Gender => m_LoggedInUser?.Gender;
        public LoginResult LoginResult => m_LoginResult;
        public bool RememberUser
        {
            get => r_AppSettings.RememberUser;
            set => r_AppSettings.RememberUser = value;
        }

        public LoginResult Login(string i_AppID, string[] i_Permissions)
        {
            m_LoginResult = FacebookService.Login(i_AppID, i_Permissions);

            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                initializeUserData();
            }

            return m_LoginResult;
        }

        public void Logout()
        {
            FacebookService.LogoutWithUI();
            m_LoginResult = null;
            m_LoggedInUser = null;
            m_PostManager = null;
        }

        public void SaveSettings()
        {
            if (RememberUser && m_LoginResult != null)
            {
                r_AppSettings.LastAccessToken = m_LoginResult.AccessToken;
            }
            else
            {
                r_AppSettings.RememberUser = false;
                r_AppSettings.LastAccessToken = null;
            }

            r_AppSettings.SaveAppSettingsToFile();
        }

        public bool TryConnectFromSavedToken()
        {
            bool isConnected = false;

            if (RememberUser && !string.IsNullOrEmpty(r_AppSettings.LastAccessToken))
            {
                try
                {
                    m_LoginResult = FacebookService.Connect(r_AppSettings.LastAccessToken);
                    initializeUserData();
                    isConnected = true;
                }
                catch (Exception)
                {
                    m_LoginResult = null;
                }
            }

            return isConnected;
        }

        public void PostStatus(string i_Status)
        {
            m_PostManager.PostStatus(i_Status);
        }

        public void PostPicture(string i_Text, string i_PicturePath)
        {
            m_PostManager.PostPicture(i_Text, i_PicturePath);
        }

        public IEnumerable<User> GetFriends()
        {
            return m_LoggedInUser?.Friends ?? new FacebookObjectCollection<User>();
        }

        public IEnumerable<Album> GetAlbums()
        {
            return m_LoggedInUser?.Albums ?? new FacebookObjectCollection<Album>();
        }

        public IEnumerable<Group> GetGroups()
        {
            return m_LoggedInUser?.Groups ?? new FacebookObjectCollection<Group>();
        }

        public IEnumerable<Page> GetLikedPages()
        {
            return m_LoggedInUser?.LikedPages ?? new FacebookObjectCollection<Page>();
        }

        public IEnumerable<Post> GetNewsFeed()
        {
            return m_LoggedInUser?.NewsFeed ?? new FacebookObjectCollection<Post>();
        }

        public IEnumerable<Event> GetEvents()
        {
            return m_LoggedInUser?.Events ?? new FacebookObjectCollection<Event>();
        }

        private void initializeUserData()
        {
            m_LoggedInUser = m_LoginResult.LoggedInUser;
            m_PostManager = new FacebookPostManager(m_LoggedInUser);
        }
    }
} 