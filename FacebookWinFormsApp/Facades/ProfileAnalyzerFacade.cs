using FacebookWrapper.ObjectModel;
using BasicFacebookFeatures.Services;

namespace BasicFacebookFeatures
{
    public class ProfileAnalyzerFacade
    {
        private readonly PhotoAnalyzer r_PhotoAnalyzer;
        private readonly FriendAnalyzer r_FriendAnalyzer;
        private readonly StatisticsAnalyzer r_StatisticsAnalyzer;

        public ProfileAnalyzerFacade(User i_LoggedInUser)
        {
            r_PhotoAnalyzer = new PhotoAnalyzer(i_LoggedInUser);
            r_FriendAnalyzer = new FriendAnalyzer(i_LoggedInUser);
            r_StatisticsAnalyzer = new StatisticsAnalyzer(i_LoggedInUser);
        }

        public string UserName
        {
            get 
            { 
                return r_FriendAnalyzer.UserName; 
            }
        }
        
        public string ProfilePictureUrl
        {
            get
            {
                return r_PhotoAnalyzer.ProfilePictureUrl;
            }
        }
        
        public int TotalLikes
        {
            get
            {
                return r_StatisticsAnalyzer.TotalLikes;
            }
        }

        public int TotalFriends
        {
            get 
            { 
                return r_StatisticsAnalyzer.TotalFriends;
            }
        }

        public int TotalEvents
        {
            get 
            { 
                return r_StatisticsAnalyzer.TotalEvents;
            }
        }

        public int TotalPosts
        {
            get
            {
                return r_StatisticsAnalyzer.TotalPosts;
            }
        }

        public int TotalVideos
        {
            get
            {
                return r_StatisticsAnalyzer.TotalVideos;
            }
        }

        public int TotalPhotos
        {
            get
            {
                return r_PhotoAnalyzer.CountTotalPhotos();
            }
        }

        public Photo BestPhoto
        {
            get
            {
                return r_PhotoAnalyzer.GetBestPhoto();
            }
        }

        public Photo WorstPhoto
        {
            get
            {
                return r_PhotoAnalyzer.GetWorstPhoto();
            }
        }

        public FacebookObjectCollection<User> FriendsWithCommonLanguages
        {
            get
            {
                return r_FriendAnalyzer.GetFriendsWithCommonLanguages();
            }
        }

        public FacebookObjectCollection<User> FriendsFromSameHometown
        {
            get
            {
                return r_FriendAnalyzer.GetFriendsFromSameHometown();
            }
        }
            
        public FacebookObjectCollection<User> FriendsWithSameBirthday
        {
            get
            {
                return r_FriendAnalyzer.GetFriendsWithSameBirthday();
            }
        }
           
        public FacebookObjectCollection<User> FriendsWhoLikedPhotos
        {
            get 
            {
                return r_FriendAnalyzer.GetFriendsWhoLikedPhotos();
            }
        }
    }
} 