using FacebookWrapper.ObjectModel;
using BasicFacebookFeatures.Services;

namespace BasicFacebookFeatures
{
    public class ProfileAnalyzerService
    {
        private readonly User r_LoggedInUser;
        private readonly PhotoAnalyzer r_PhotoAnalyzer;
        private readonly FriendAnalyzer r_FriendAnalyzer;
        private readonly StatisticsAnalyzer r_StatisticsAnalyzer;

        public ProfileAnalyzerService(User i_LoggedInUser)
        {
            r_LoggedInUser = i_LoggedInUser;
            r_PhotoAnalyzer = new PhotoAnalyzer(i_LoggedInUser);
            r_FriendAnalyzer = new FriendAnalyzer(i_LoggedInUser);
            r_StatisticsAnalyzer = new StatisticsAnalyzer(i_LoggedInUser);
        }

        // Basic User Info
        public string UserName => r_LoggedInUser?.Name;
        public string ProfilePictureUrl => r_LoggedInUser?.PictureNormalURL;

        // Statistics
        public int TotalLikes => r_StatisticsAnalyzer.TotalLikes;
        public int TotalFriends => r_StatisticsAnalyzer.TotalFriends;
        public int TotalEvents => r_StatisticsAnalyzer.TotalEvents;
        public int TotalPosts => r_StatisticsAnalyzer.TotalPosts;
        public int TotalVideos => r_StatisticsAnalyzer.TotalVideos;

        // Photo Analysis
        public int CountTotalPhotos() => r_PhotoAnalyzer.CountTotalPhotos();
        public Photo GetBestPhoto() => r_PhotoAnalyzer.GetBestPhoto();
        public Photo GetWorstPhoto() => r_PhotoAnalyzer.GetWorstPhoto();

        // Friend Analysis
        public FacebookObjectCollection<User> GetFriendsWithCommonLanguages() => 
            r_FriendAnalyzer.GetFriendsWithCommonLanguages();

        public FacebookObjectCollection<User> GetFriendsFromSameHometown() => 
            r_FriendAnalyzer.GetFriendsFromSameHometown();

        public FacebookObjectCollection<User> GetFriendsWithSameBirthday() => 
            r_FriendAnalyzer.GetFriendsWithSameBirthday();

        public FacebookObjectCollection<User> GetFriendsWhoLikedPhotos() => 
            r_FriendAnalyzer.GetFriendsWhoLikedPhotos();
    }
} 