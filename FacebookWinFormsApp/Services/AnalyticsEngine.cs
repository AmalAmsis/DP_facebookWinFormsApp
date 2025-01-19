using FacebookWrapper.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace BasicFacebookFeatures.Services
{
    internal class AnalyticsEngine
    {
        public AnalyticsResult ProcessUserData(UserData i_UserData)
        {
            return new AnalyticsResult
            {
                EngagementMetrics = CalculateEngagement(i_UserData),
                SocialMetrics = AnalyzeSocialConnections(i_UserData),
                ContentMetrics = AnalyzeContent(i_UserData)
            };
        }

        private EngagementMetrics CalculateEngagement(UserData i_UserData)
        {
            return new EngagementMetrics
            {
                TotalLikes = i_UserData.SocialInfo.LikedPages?.Count ?? 0,
                TotalPosts = i_UserData.ActivityInfo.Posts?.Count ?? 0,
                TotalEvents = i_UserData.ActivityInfo.Events?.Count ?? 0
            };
        }

        private SocialMetrics AnalyzeSocialConnections(UserData i_UserData)
        {
            return new SocialMetrics
            {
                TotalFriends = i_UserData.SocialInfo.Friends?.Count ?? 0,
                CommonLanguageFriends = GetFriendsWithCommonLanguages(i_UserData),
                HometownFriends = GetFriendsFromSameHometown(i_UserData)
            };
        }

        private ContentMetrics AnalyzeContent(UserData i_UserData)
        {
            return new ContentMetrics
            {
                TotalPhotos = CountTotalPhotos(i_UserData),
                BestPhoto = FindBestPhoto(i_UserData),
                WorstPhoto = FindWorstPhoto(i_UserData)
            };
        }

        private int CountTotalPhotos(UserData i_UserData)
        {
            return i_UserData.ActivityInfo.Albums?.Sum(album => album.Photos.Count) ?? 0;
        }

        private Photo FindBestPhoto(UserData i_UserData)
        {
            return FindPhotoWithExtremeLikes(i_UserData, (current, best) => current > best);
        }

        private Photo FindWorstPhoto(UserData i_UserData)
        {
            return FindPhotoWithExtremeLikes(i_UserData, (current, worst) => current < worst);
        }

        private Photo FindPhotoWithExtremeLikes(UserData i_UserData, System.Func<int, int, bool> i_Comparison)
        {
            Photo extremePhoto = null;
            int extremeLikes = -1;
            bool isFirstPhoto = true;

            foreach (Album album in i_UserData.ActivityInfo.Albums ?? Enumerable.Empty<Album>())
            {
                foreach (Photo photo in album.Photos ?? Enumerable.Empty<Photo>())
                {
                    int likesCount = photo.LikedBy?.Count ?? 0;
                    if (isFirstPhoto || i_Comparison(likesCount, extremeLikes))
                    {
                        extremePhoto = photo;
                        extremeLikes = likesCount;
                        isFirstPhoto = false;
                    }
                }
            }

            return extremePhoto;
        }

        private IEnumerable<User> GetFriendsWithCommonLanguages(UserData i_UserData)
        {
            if (i_UserData.SocialInfo.Languages == null)
            {
                return Enumerable.Empty<User>();
            }

            return i_UserData.SocialInfo.Friends?
                .Where(friend => friend.Languages?
                    .Any(lang => i_UserData.SocialInfo.Languages.Contains(lang)) == true) 
                ?? Enumerable.Empty<User>();
        }

        private IEnumerable<User> GetFriendsFromSameHometown(UserData i_UserData)
        {
            if (string.IsNullOrEmpty(i_UserData.BasicInfo.Hometown))
            {
                return Enumerable.Empty<User>();
            }

            return i_UserData.SocialInfo.Friends?
                .Where(friend => friend.Hometown?.Name == i_UserData.BasicInfo.Hometown)
                ?? Enumerable.Empty<User>();
        }
    }

    public class AnalyticsResult
    {
        public EngagementMetrics EngagementMetrics { get; set; }
        public SocialMetrics SocialMetrics { get; set; }
        public ContentMetrics ContentMetrics { get; set; }
    }

    public class EngagementMetrics
    {
        public int TotalLikes { get; set; }
        public int TotalPosts { get; set; }
        public int TotalEvents { get; set; }
    }

    public class SocialMetrics
    {
        public int TotalFriends { get; set; }
        public IEnumerable<User> CommonLanguageFriends { get; set; }
        public IEnumerable<User> HometownFriends { get; set; }
    }

    public class ContentMetrics
    {
        public int TotalPhotos { get; set; }
        public Photo BestPhoto { get; set; }
        public Photo WorstPhoto { get; set; }
    }
} 