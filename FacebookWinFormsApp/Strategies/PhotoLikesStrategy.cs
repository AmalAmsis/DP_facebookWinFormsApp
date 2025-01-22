using FacebookWrapper.ObjectModel;
using System.Linq;

namespace BasicFacebookFeatures.Services.Strategies
{
    public class PhotoLikesStrategy : IFriendFilterStrategy
    {
        public bool ShouldIncludeFriend(User i_Friend)
        {
            return FacebookManager.Instance.LoggedInUser?.Albums?
                .SelectMany(album => album.Photos ?? Enumerable.Empty<Photo>())
                .SelectMany(photo => photo.LikedBy ?? Enumerable.Empty<User>())
                .Any(user => user.Id == i_Friend.Id) ?? false;
        }
    }
} 