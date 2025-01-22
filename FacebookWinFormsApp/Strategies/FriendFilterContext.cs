using FacebookWrapper.ObjectModel;
using System.Linq;

namespace BasicFacebookFeatures.Services.Strategies
{
    public class FriendFilterContext
    {
        private IFriendFilterStrategy Filter { get; set; }

        public FriendFilterContext(IFriendFilterStrategy i_Filter)
        {
            Filter = i_Filter;
        }

        public FacebookObjectCollection<User> FilterFriends()
        {
            FacebookObjectCollection<User> filteredFriends = new FacebookObjectCollection<User>();

            foreach (User friend in FacebookManager.Instance.LoggedInUser?.Friends ?? Enumerable.Empty<User>())
            {
                if (Filter.ShouldIncludeFriend(friend))
                {
                    filteredFriends.Add(friend);
                }
            }

            return filteredFriends;
        }
    }
} 