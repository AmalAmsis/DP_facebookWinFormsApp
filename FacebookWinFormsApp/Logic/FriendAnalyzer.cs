using FacebookWrapper.ObjectModel;
using System;
using System.Linq;
using BasicFacebookFeatures.Services.Strategies;
using BasicFacebookFeatures.Iterators;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Services
{
    internal class FriendAnalyzer
    {
        private readonly User r_LoggedInUser = FacebookManager.Instance.LoggedInUser;
        private readonly FriendFilterContext r_FriendFilterContext;

        public FriendAnalyzer()
        {
            r_FriendFilterContext = new FriendFilterContext(new CommonLanguagesStrategy());
        }

        public string UserName
        {
            get
            {
                return r_LoggedInUser.UserName;
            }
        }

        public IEnumerable<User> GetFriendsWithCommonLanguages()
        {
            r_FriendFilterContext.SetStrategy(new CommonLanguagesStrategy()); 
            return r_FriendFilterContext.FilterFriends();
        }

        public IEnumerable<User> GetFriendsFromSameHometown()
        {
            r_FriendFilterContext.SetStrategy(new SameHometownStrategy());
            return r_FriendFilterContext.FilterFriends();
        }

        public IEnumerable<User> GetFriendsWithSameBirthday()
        {
            r_FriendFilterContext.SetStrategy(new SameBirthdayStrategy());
            return r_FriendFilterContext.FilterFriends();
        }

        public IEnumerable<User> GetFriendsWhoLikedPhotos()
        {
            r_FriendFilterContext.SetStrategy(new PhotoLikesStrategy());
            return r_FriendFilterContext.FilterFriends();
        }
    }
}
