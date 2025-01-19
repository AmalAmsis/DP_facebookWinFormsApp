using System;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System.Collections.Generic;

namespace BasicFacebookFeatures
{
    public sealed class FacebookManager
    {
        private static readonly object sr_Lock = new object();
        private static FacebookManager s_Instance = null;
        
        private AppSettings m_AppSettings;
        private FacebookPostManager m_PostManager;

        private User m_LoggedInUser;
        private LoginResult m_LoginResult;

        private bool m_RememberUser = false;

        private FacebookManager()
        {
            m_AppSettings = AppSettings.LoadAppSettingsFromFile();
            m_RememberUser = m_AppSettings.RememberUser;
        }

        public static FacebookManager Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (sr_Lock)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new FacebookManager();
                        }
                    }
                }

                return s_Instance;
            }
        }

        public bool IsLoggedIn
        {
            get
            {
                return m_LoginResult != null && !string.IsNullOrEmpty(m_LoginResult.AccessToken);
            }
        }

        public string AccessToken
        {
            get
            {
                return m_LoginResult?.AccessToken;
            }
        }

        public User LoggedInUser
        {
            get
            {
                return m_LoggedInUser;
            }
        }

        public string UserName
        {
            get
            {
                return m_LoggedInUser?.Name;
            }
        }

        public string ProfilePictureURL
        {
            get
            {
                return m_LoggedInUser?.PictureNormalURL;
            }
        }

        public string Birthday
        {
            get
            {
                return m_LoggedInUser?.Birthday;
            }
        }

        public User.eGender? Gender
        {
            get
            {
                return m_LoggedInUser?.Gender;
            }
        }

        public LoginResult LoginResult
        {
            get
            {
                return m_LoginResult;
            }
        }

        public bool RememberUser
        {
            get
            {
               return m_RememberUser;
            }
            set
            {
                m_RememberUser = value;
                m_AppSettings.RememberUser = value;
            }
        }

        public LoginResult Login(string i_AppID, string[] i_Permissions)
        {
            m_LoginResult = FacebookService.Login(i_AppID, i_Permissions);
            m_LoggedInUser = m_LoginResult.LoggedInUser;

            m_PostManager = new FacebookPostManager(m_LoggedInUser);

            if (m_RememberUser && !string.IsNullOrEmpty(m_LoginResult?.AccessToken))
            {
                m_AppSettings.LastAccessToken = m_LoginResult.AccessToken;
            }

            return m_LoginResult;
        }

        public void Logout()
        {
            FacebookService.LogoutWithUI();
            m_LoginResult = null;
            m_LoggedInUser = null;
            m_PostManager = null;

            if (!m_RememberUser)
            {
                m_AppSettings.LastAccessToken = null;
            }
        }

        public void SaveSettings()
        {
            m_AppSettings.SaveAppSettingsToFile();
        }

        public bool TryConnectFromSavedToken()
        {
            bool isConnected = false;

            if (m_RememberUser && !string.IsNullOrEmpty(m_AppSettings.LastAccessToken))
            {
                try
                {
                    m_LoginResult = FacebookService.Connect(m_AppSettings.LastAccessToken);
                    m_LoggedInUser = m_LoginResult.LoggedInUser;
                    isConnected = true;
                }
                catch (Exception)
                {
                    m_AppSettings.LastAccessToken = null;
                }
            }

            return isConnected;
        }

        public void PostStatus(string i_Status)
        {
            if (string.IsNullOrWhiteSpace(i_Status))
            {
                throw new Exception("Status text is empty!");
            }

            m_PostManager?.PostStatus(i_Status);
        }

        public void PostPicture(string i_PictureText, string i_PicturePath)
        {
            if (string.IsNullOrWhiteSpace(i_PicturePath))
            {
                throw new Exception("No picture was selected!");
            }

            m_PostManager?.PostPicture(i_PicturePath, i_PictureText);
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
    }
} 