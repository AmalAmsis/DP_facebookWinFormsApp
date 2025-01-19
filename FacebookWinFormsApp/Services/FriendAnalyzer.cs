using FacebookWrapper.ObjectModel;
using System;
using System.Linq;

namespace BasicFacebookFeatures.Services
{
    internal class FriendAnalyzer
    {
        private readonly User r_LoggedInUser;

        public FriendAnalyzer(User i_LoggedInUser)
        {
            r_LoggedInUser = i_LoggedInUser;
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
    }
} 