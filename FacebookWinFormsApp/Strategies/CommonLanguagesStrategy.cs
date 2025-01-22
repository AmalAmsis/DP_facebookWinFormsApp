using FacebookWrapper.ObjectModel;
using System.Linq;

namespace BasicFacebookFeatures.Services.Strategies
{
    public class CommonLanguagesStrategy : IFriendFilterStrategy
    {
        public bool ShouldIncludeFriend(User i_Friend)
        {
            return i_Friend.Languages?.Any(lang => FacebookManager.Instance.LoggedInUser?.Languages.Contains(lang) ?? false) == true;
        }
    }
} 