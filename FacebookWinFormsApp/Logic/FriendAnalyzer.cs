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
            return new FriendFilterContext(new CommonLanguagesStrategy()).FilterFriends();
        }

        public FacebookObjectCollection<User> GetFriendsFromSameHometown()
        {
            return new FriendFilterContext(new SameHometownStrategy()).FilterFriends();
        }

        public FacebookObjectCollection<User> GetFriendsWithSameBirthday()
        {
            return new FriendFilterContext(new SameBirthdayStrategy()).FilterFriends();
        }

        public FacebookObjectCollection<User> GetFriendsWhoLikedPhotos()
        {
            return new FriendFilterContext(new PhotoLikesStrategy()).FilterFriends();
        }
    }
} 