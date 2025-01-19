using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Services
{
    public class ProfileAnalyzerFacade
    {
        private readonly ProfileAnalyzerService r_ProfileAnalyzerService;

        public ProfileAnalyzerFacade(User i_LoggedInUser)
        {
            r_ProfileAnalyzerService = new ProfileAnalyzerService(i_LoggedInUser);
        }

        public string GetUserName() => r_ProfileAnalyzerService.UserName;
        public string GetProfilePictureUrl() => r_ProfileAnalyzerService.ProfilePictureUrl;

        public Statistics GetStatistics()
        {
            return new Statistics
            {
                TotalLikes = r_ProfileAnalyzerService.TotalLikes,
                TotalFriends = r_ProfileAnalyzerService.TotalFriends,
                TotalEvents = r_ProfileAnalyzerService.TotalEvents,
                TotalPosts = r_ProfileAnalyzerService.TotalPosts,
                TotalVideos = r_ProfileAnalyzerService.TotalVideos,
                TotalPhotos = r_ProfileAnalyzerService.CountTotalPhotos()
            };
        }

        public FriendsLists GetFriendsLists()
        {
            return new FriendsLists
            {
                CommonLanguageFriends = r_ProfileAnalyzerService.GetFriendsWithCommonLanguages(),
                HometownFriends = r_ProfileAnalyzerService.GetFriendsFromSameHometown(),
                SameBirthdayFriends = r_ProfileAnalyzerService.GetFriendsWithSameBirthday(),
                PhotoLikerFriends = r_ProfileAnalyzerService.GetFriendsWhoLikedPhotos()
            };
        }

        public Photo GetBestPhoto() => r_ProfileAnalyzerService.GetBestPhoto();
        public Photo GetWorstPhoto() => r_ProfileAnalyzerService.GetWorstPhoto();
    }

    public class Statistics
    {
        public int TotalLikes { get; set; }
        public int TotalFriends { get; set; }
        public int TotalEvents { get; set; }
        public int TotalPosts { get; set; }
        public int TotalVideos { get; set; }
        public int TotalPhotos { get; set; }
    }

    public class FriendsLists
    {
        public FacebookObjectCollection<User> CommonLanguageFriends { get; set; }
        public FacebookObjectCollection<User> HometownFriends { get; set; }
        public FacebookObjectCollection<User> SameBirthdayFriends { get; set; }
        public FacebookObjectCollection<User> PhotoLikerFriends { get; set; }
    }
} 