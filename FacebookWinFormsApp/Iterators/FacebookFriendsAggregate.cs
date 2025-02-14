using FacebookWrapper.ObjectModel;
using System.Collections;
using System.Collections.Generic;

namespace BasicFacebookFeatures.Iterators
{
    public class FacebookFriendsAggregate : IEnumerable<User>
    {
        private readonly FacebookObjectCollection<User> r_Friends;

        public FacebookFriendsAggregate(FacebookObjectCollection<User> i_Friends)
        {
            r_Friends = i_Friends;
        }

        public IEnumerator<User> GetEnumerator()
        {
            return r_Friends.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
