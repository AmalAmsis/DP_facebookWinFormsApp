using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures.Iterators
{
    public interface IFacebookIterator<T>
    {
        bool MoveNext();
        object Current { get; }
        void Reset();
    }
} 