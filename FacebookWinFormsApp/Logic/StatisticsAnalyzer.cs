using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Services
{
    internal class StatisticsAnalyzer
    {
        private readonly User r_LoggedInUser = FacebookManager.Instance.LoggedInUser;

        public string UserName
        {
            get
            {
                return r_LoggedInUser.UserName;
            }
        }

        public int TotalLikes
        {
            get
            {
                return r_LoggedInUser?.LikedPages?.Count ?? 0;
            }
        }

        public int TotalFriends
        {
            get
            {
                return r_LoggedInUser?.Friends?.Count ?? 0;
            }
        }

        public int TotalEvents
        {
            get
            {
                return r_LoggedInUser?.Events?.Count ?? 0;
            }
        }

        public int TotalPosts
        {
            get
            {
                return r_LoggedInUser?.Posts?.Count ?? 0;
            }
        }

        public int TotalVideos
        {
            get
            {
                return r_LoggedInUser?.Videos?.Count ?? 0;
            }
        }
    }
} 