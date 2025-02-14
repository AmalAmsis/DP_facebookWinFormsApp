using BasicFacebookFeatures.Iterators;
using FacebookWrapper.ObjectModel;
using System;
using System.Linq;

namespace BasicFacebookFeatures.Services
{
    internal class PhotoAnalyzer
    {
        private readonly User r_LoggedInUser = FacebookManager.Instance.LoggedInUser;

        public string UserName => r_LoggedInUser.UserName;

        public string ProfilePictureUrl => r_LoggedInUser?.PictureNormalURL;

        public int CountTotalPhotos()
        {
            return new FacebookPhotosAggregate(r_LoggedInUser.Albums).Count();
        }

        public Photo GetBestPhoto()
        {
            return getPhotoWithExtremeLikes((current, best) => current > best);
        }

        public Photo GetWorstPhoto()
        {
            return getPhotoWithExtremeLikes((current, worst) => current < worst);
        }

        private Photo getPhotoWithExtremeLikes(Func<int, int, bool> i_Comparison)
        {
            return new FacebookPhotosAggregate(r_LoggedInUser.Albums)
                .OrderByDescending(photo => photo.LikedBy?.Count ?? 0)
                .FirstOrDefault();
        }
    }
}
