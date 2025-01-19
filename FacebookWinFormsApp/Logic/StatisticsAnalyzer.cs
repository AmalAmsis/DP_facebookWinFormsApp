using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Services
{
    internal class StatisticsAnalyzer
    {
        private readonly User r_LoggedInUser;

        public StatisticsAnalyzer(User i_LoggedInUser)
        {
            r_LoggedInUser = i_LoggedInUser;
        }

        public string UserName
        {
            get
            {
                return r_LoggedInUser.UserName;
            }
        }

        public int TotalLikes => r_LoggedInUser?.LikedPages?.Count ?? 0;
        public int TotalFriends => r_LoggedInUser?.Friends?.Count ?? 0;
        public int TotalEvents => r_LoggedInUser?.Events?.Count ?? 0;
        public int TotalPosts => r_LoggedInUser?.Posts?.Count ?? 0;
        public int TotalVideos => r_LoggedInUser?.Videos?.Count ?? 0;
    }
} 