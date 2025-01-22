using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Services.Strategies
{
    public class SameBirthdayStrategy : IFriendFilterStrategy
    {
        public bool ShouldIncludeFriend(User i_Friend)
        {
            return i_Friend.Birthday == FacebookManager.Instance.LoggedInUser?.Birthday;
        }
    }
} 