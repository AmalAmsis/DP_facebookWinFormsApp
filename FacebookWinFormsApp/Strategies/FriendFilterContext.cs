using FacebookWrapper.ObjectModel;
using System.Linq;
using BasicFacebookFeatures.Iterators;

namespace BasicFacebookFeatures.Services.Strategies
{
    public class FriendFilterContext
    {
        private IFriendFilterStrategy Filter { get; set; }

        public FriendFilterContext(IFriendFilterStrategy i_Filter)
        {
            Filter = i_Filter;
        }

        public void SetStrategy(IFriendFilterStrategy i_NewStrategy)
        {
            Filter = i_NewStrategy;
        }

        public FacebookObjectCollection<User> FilterFriends()
        {
            FacebookObjectCollection<User> filteredFriends = new FacebookObjectCollection<User>();

            IFacebookAggregate<User> facebookFriendsAggregate = new FacebookFriendsAggregate(FacebookManager.Instance.LoggedInUser?.Friends);
            IFacebookIterator<User> iterator = facebookFriendsAggregate.CreateIterator();

            while (iterator.MoveNext())
            {
                if (!(iterator.Current is User friend))
                {
                    continue;
                }

                if (Filter != null && Filter.ShouldIncludeFriend(friend))
                {
                    filteredFriends.Add(friend);
                }
            }

            return filteredFriends;
        }
    }
}
