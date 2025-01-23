using FacebookWrapper.ObjectModel;
using System;
using System.Linq;
using BasicFacebookFeatures.Iterators;

namespace BasicFacebookFeatures.Services
{
    internal class PhotoAnalyzer
    {
        private readonly User r_LoggedInUser = FacebookManager.Instance.LoggedInUser;

        public string UserName
        {
            get
            {
                return r_LoggedInUser.UserName;
            }
        }

        public string ProfilePictureUrl
        {
            get
            {
                return r_LoggedInUser?.PictureNormalURL;
            }
        }

        public int CountTotalPhotos()
        {
            int count = 0;

            IFacebookAggregate<Album> facebookPhotosAggregator = new FacebookPhotosAggregate(r_LoggedInUser.Albums);
            IFacebookIterator<Album> iterator = facebookPhotosAggregator.CreateIterator();
            
            while (iterator.MoveNext())
            {
                count++;
            }

            return count;
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
            Photo extremePhoto = null;
            int extremeLikes = -1;
            bool isFirstPhoto = true;

            IFacebookAggregate<Album> facebookPhotosAggregator = new FacebookPhotosAggregate(r_LoggedInUser.Albums);
            IFacebookIterator<Album> iterator = facebookPhotosAggregator.CreateIterator();

            while (iterator.MoveNext())
            {
                if (!(iterator.Current is Photo currentPhoto))
                {
                    continue;
                }

                int likesCount = currentPhoto.LikedBy?.Count ?? 0;

                if (i_Comparison(likesCount, extremeLikes) || isFirstPhoto)
                {
                    extremePhoto = currentPhoto;
                    extremeLikes = likesCount;
                    isFirstPhoto = false;
                }
            }

            return extremePhoto;
        }
    }
} 