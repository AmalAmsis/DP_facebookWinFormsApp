using FacebookWrapper.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BasicFacebookFeatures.Iterators
{
    public class FacebookPhotosAggregate : IEnumerable<Photo>
    {
        private readonly FacebookObjectCollection<Album> r_Albums;

        public FacebookPhotosAggregate(FacebookObjectCollection<Album> i_Albums)
        {
            r_Albums = i_Albums;
        }

        public IEnumerator<Photo> GetEnumerator()
        {
            return r_Albums.SelectMany(album => album.Photos ?? Enumerable.Empty<Photo>()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
