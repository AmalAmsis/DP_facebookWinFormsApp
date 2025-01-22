using FacebookWrapper.ObjectModel;
using System;
using System.Linq;
using BasicFacebookFeatures.Services.Strategies;

namespace BasicFacebookFeatures.Services
{
    internal class FriendAnalyzer
    {
        private readonly User r_LoggedInUser = FacebookManager.Instance.LoggedInUser;

        public string UserName
        {
            get
            {
                return r_LoggedInUser.UserName;
            }
        }

        public FacebookObjectCollection<User> GetFriendsWithCommonLanguages()
        {
            if (r_LoggedInUser?.Languages == null)
            {
                return new FacebookObjectCollection<User>();
            }

            return new FriendFilterContext(new CommonLanguagesStrategy()).FilterFriends();
        }

        public FacebookObjectCollection<User> GetFriendsFromSameHometown()
        {
            if (r_LoggedInUser?.Hometown == null)
            {
                return new FacebookObjectCollection<User>();
            }

            return new FriendFilterContext(new SameHometownStrategy()).FilterFriends();
        }

        public FacebookObjectCollection<User> GetFriendsWithSameBirthday()
        {
            if (string.IsNullOrEmpty(r_LoggedInUser?.Birthday))
            {
                return new FacebookObjectCollection<User>();
            }

            return new FriendFilterContext(new SameBirthdayStrategy()).FilterFriends();
        }

        public FacebookObjectCollection<User> GetFriendsWhoLikedPhotos()
        {
            return new FriendFilterContext(new PhotoLikesStrategy()).FilterFriends();
        }
    }
} 