using FacebookWrapper.ObjectModel;
using System;
using System.Linq;

namespace BasicFacebookFeatures.Services
{
    internal class PhotoAnalyzer
    {
        private readonly User r_LoggedInUser;

        public PhotoAnalyzer(User i_LoggedInUser)
        {
            r_LoggedInUser = i_LoggedInUser;
        }

        public int CountTotalPhotos()
        {
            return r_LoggedInUser?.Albums?.Sum(album => album.Photos.Count) ?? 0;
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
            bool isFirstPhoto = true;
            int extremeLikes = -1;

            foreach (Album album in r_LoggedInUser?.Albums)
            {
                foreach (Photo photo in album.Photos)
                {
                    int likesCount = photo.LikedBy?.Count ?? 0;

                    if (i_Comparison(likesCount, extremeLikes) || isFirstPhoto)
                    {
                        extremePhoto = photo;
                        extremeLikes = likesCount;
                        isFirstPhoto = false;
                    }
                }
            }

            return extremePhoto;
        }
    }
} 