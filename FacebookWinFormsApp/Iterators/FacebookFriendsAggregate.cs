using FacebookWrapper.ObjectModel;
using System;

namespace BasicFacebookFeatures.Iterators
{
    public class FacebookFriendsAggregate : IFacebookAggregate<User>
    {
        private readonly FacebookObjectCollection<User> r_Friends;

        public FacebookFriendsAggregate(FacebookObjectCollection<User> i_Friends)
        {
            r_Friends = i_Friends;
        }

        public IFacebookIterator<User> CreateIterator()
        {
            return new FriendsIterator(this);
        }

        private class FriendsIterator : IFacebookIterator<User>
        {
            private readonly FacebookFriendsAggregate r_Agregate;
            private int m_CurrentIndex = -1;
            private int m_Count = -1;

            public FriendsIterator(FacebookFriendsAggregate i_Friends)
            {
                r_Agregate = i_Friends;
                m_Count = r_Agregate.r_Friends.Count;
            }

            public void Reset()
            {
                m_CurrentIndex = -1;
            }

            public bool MoveNext()
            {
                if (m_Count != r_Agregate.r_Friends.Count)
                {
                    throw new Exception("Collection can not be changed during iteration!");
                }

                if (m_CurrentIndex >= m_Count)
                {
                    throw new Exception("Already reached the end of the collection");
                }

                return ++m_CurrentIndex < r_Agregate.r_Friends.Count;
            }

            public object Current
            {
                get
                {
                    return r_Agregate.r_Friends[m_CurrentIndex];
                }
            }
        }
    }
} 