using FacebookWrapper.ObjectModel;
using System.Collections.Generic;
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

        public void SetStrategy(IFriendFilterStrategy i_NewStrategy)
        {
            Filter = i_NewStrategy;
        }

        public IEnumerable<User> FilterFriends()
        {
            return FacebookManager.Instance.LoggedInUser?.Friends
                .Where(friend => Filter.ShouldIncludeFriend(friend)) ?? Enumerable.Empty<User>();
        }

    }
}
