using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Services.Strategies
{
    public interface IFriendFilterStrategy
    {
        bool ShouldIncludeFriend(User i_Friend);
    }
} 