using FacebookWrapper.ObjectModel;
using System;
using System.Linq;

namespace BasicFacebookFeatures
{
    public class ProfileAnalyzer
    {
        private readonly User r_LoggedInUser;

        public ProfileAnalyzer(User i_LoggedInUser)
        {
            r_LoggedInUser = i_LoggedInUser;
        }

        public string UserName => r_LoggedInUser?.Name;
        public string ProfilePictureUrl => r_LoggedInUser?.PictureNormalURL;
        public int TotalLikes => r_LoggedInUser?.LikedPages?.Count ?? 0;
        public int TotalFriends => r_LoggedInUser?.Friends?.Count ?? 0;
        public int TotalEvents => r_LoggedInUser?.Events?.Count ?? 0;
        public int TotalPosts => r_LoggedInUser?.Posts?.Count ?? 0;
        public int TotalVideos => r_LoggedInUser?.Videos?.Count ?? 0;

        public int CountTotalPhotos()
        {
            return r_LoggedInUser?.Albums?.Sum(album => album.Photos.Count) ?? 0;
        }

        public FacebookObjectCollection<User> GetFriendsWithCommonLanguages()
        {
            if (r_LoggedInUser?.Languages == null)
            {
                return new FacebookObjectCollection<User>();
            }

            return filterFriendsByCondition(friend =>
                friend.Languages?.Any(lang => r_LoggedInUser.Languages.Contains(lang)) == true);
        }

        public FacebookObjectCollection<User> GetFriendsFromSameHometown()
        {
            if (r_LoggedInUser?.Hometown == null)
            {
                return new FacebookObjectCollection<User>();
            }

            return filterFriendsByCondition(friend => friend.Hometown == r_LoggedInUser.Hometown);
        }

        public FacebookObjectCollection<User> GetFriendsWithSameBirthday()
        {
            if (string.IsNullOrEmpty(r_LoggedInUser?.Birthday))
            {
                return new FacebookObjectCollection<User>();
            }

            return filterFriendsByCondition(friend => friend.Birthday == r_LoggedInUser.Birthday);
        }

        public FacebookObjectCollection<User> GetFriendsWhoLikedPhotos()
        {
            FacebookObjectCollection<User> friends = new FacebookObjectCollection<User>();

            foreach (Album album in r_LoggedInUser?.Albums ?? Enumerable.Empty<Album>())
            {
                foreach (Photo photo in album.Photos ?? Enumerable.Empty<Photo>())
                {
                    foreach (User user in photo.LikedBy ?? Enumerable.Empty<User>())
                    {
                        friends.Add(user);
                    }
                }
            }

            return friends;
        }

        public Photo GetBestPhoto()
        {
            return getPhotoWithExtremeLikes((current, best) => current > best);
        }

        public Photo GetWorstPhoto()
        {
            return getPhotoWithExtremeLikes((current, worst) => current < worst);
        }

        private FacebookObjectCollection<User> filterFriendsByCondition(Func<User, bool> i_Condition)
        {
            FacebookObjectCollection<User> filteredFriends = new FacebookObjectCollection<User>();

            foreach (User friend in r_LoggedInUser?.Friends ?? Enumerable.Empty<User>())
            {
                if (i_Condition(friend))
                {
                    filteredFriends.Add(friend);
                }
            }

            return filteredFriends;
        }

        private Photo getPhotoWithExtremeLikes(Func<int, int, bool> i_Comparison)
        {
            Photo extremePhoto = null;
            bool isFirstPhoto = true;
            int extremeLikes = -1;

            foreach (Album album in r_LoggedInUser?.Albums)
            {
                foreach (Photo photo in album.Photos)
                {
                    int likesCount = photo.LikedBy?.Count ?? 0;

                    if (i_Comparison(likesCount, extremeLikes) || isFirstPhoto)
                    {
                        extremePhoto = photo;
                        extremeLikes = likesCount;
                        isFirstPhoto = false;
                    }
                }
            }

            return extremePhoto;
        }
    }
} 