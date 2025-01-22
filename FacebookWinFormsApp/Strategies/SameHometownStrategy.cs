using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Services.Strategies
{
    public class SameHometownStrategy : IFriendFilterStrategy
    {
        public bool ShouldIncludeFriend(User i_Friend)
        {
            return i_Friend?.Hometown != null && i_Friend.Hometown == FacebookManager.Instance.LoggedInUser?.Hometown;
        }
    }
} 