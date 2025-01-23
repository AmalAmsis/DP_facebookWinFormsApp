using FacebookWrapper.ObjectModel;
using System;

namespace BasicFacebookFeatures.Iterators
{
    public class FacebookPhotosAggregate : IFacebookAggregate<Album>
    {
        private readonly FacebookObjectCollection<Album> r_Albums;

        public FacebookPhotosAggregate(FacebookObjectCollection<Album> i_Albums)
        {
            r_Albums = i_Albums;
        }

        public IFacebookIterator<Album> CreateIterator()
        {
            return new PhotosIterator(this);
        }

        private class PhotosIterator : IFacebookIterator<Album>
        {
            private readonly FacebookPhotosAggregate r_Agregate;
            private int m_CurrentAlbumIndex = -1;
            private int m_CurrentPhotoIndex = -1;
            private int m_Count = -1;

            public PhotosIterator(FacebookPhotosAggregate i_Agregate)
            {
                r_Agregate = i_Agregate;
                m_Count = r_Agregate.r_Albums.Count;
            }

            public object Current
            {
                get 
                { 
                    return r_Agregate.r_Albums[m_CurrentAlbumIndex].Photos[m_CurrentPhotoIndex]; 
                }
            }

            public void Reset()
            {
                m_CurrentAlbumIndex = -1;
                m_CurrentPhotoIndex = -1;
            }

            public bool MoveNext()
            {
                if (m_Count != r_Agregate.r_Albums.Count)
                {
                    throw new Exception("Collection can not be changed during iteration!");
                }

                if (r_Agregate.r_Albums == null || r_Agregate.r_Albums.Count == 0)
                {
                    return false;
                }

                if (m_CurrentAlbumIndex == -1)
                {
                    m_CurrentAlbumIndex = 0;
                    m_CurrentPhotoIndex = 0;
                    return hasValidPhoto();
                }

                m_CurrentPhotoIndex++;

                if (m_CurrentPhotoIndex >= r_Agregate.r_Albums[m_CurrentAlbumIndex].Photos?.Count)
                {
                    m_CurrentAlbumIndex++;
                    m_CurrentPhotoIndex = 0;
                    return hasValidPhoto();
                }

                return true;
            }

            private bool hasValidPhoto()
            {
                while (m_CurrentAlbumIndex < r_Agregate.r_Albums.Count)
                {
                    if (r_Agregate.r_Albums[m_CurrentAlbumIndex].Photos != null &&
                        r_Agregate.r_Albums[m_CurrentAlbumIndex].Photos.Count > 0)
                    {
                        return true;
                    }
                    m_CurrentAlbumIndex++;
                }
                return false;
            }
        }
    }
} 